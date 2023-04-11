using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MNG.Models;
using MNG.Models.Productions;
using MNG.Services;
using MNG.Services.Data;

namespace MNG.APIs.Controllers.Production
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TestChemicalCompositionController : ControllerBase
    {
        private readonly App app;

        public TestChemicalCompositionController(App app) // dependency injection (DI)
        {
            this.app = app;
        }

        // HTTP METHOD: URL (collection vs item)
        // GET: api/v1/Chargings
        [HttpGet]
        public IEnumerable<TestChemicalComposition> GetTestChemicalCompositionAll()
        {
            return app.TestChemicalCompositions.All;
        }

        [HttpGet("{id}/TestCountByLotNo")]
        public int GetTestNoCountByLotNo([FromRoute] string id)
        {
            return app.TestChemicalCompositions.Query(x => x.Code.Contains(id)).ToList().Count();
        }

        [HttpGet("{id}/TestsByLotNoFilter")]
        public ActionResult<IEnumerable<TestChemicalComposition>> GetTestNoByLotNoFilter([FromRoute] string id)
        {
            return app.TestChemicalCompositions.Query(x => x.Code.Contains(id)).ToList();
        }

        // GET: api/v1/Chargings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestChemicalComposition>> GetTestChemicalCompositionById([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var testChemicalComposition = await app.TestChemicalCompositions.FindAsync(id);

            if (testChemicalComposition == null)
            {
                return null;
            }

            return Ok(testChemicalComposition);
        }

        [HttpGet("{id}/TestsByLotno")]
        public ActionResult<IEnumerable<TestChemicalComposition>> GetTestsByLotNo([FromRoute] string id)
        {
            var Tests = app.TestChemicalCompositions.Query(x => x.Code.Contains(id)).ToList();

            return Ok(Tests);
        }

        [HttpGet("{id}/Validate")]
        public async Task<ActionResult<ChemicalCompositionValidation>> ValidateChemResult([FromRoute]string id, string specId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var spec = await app.ChemicalCompositionInFurnaces.FindAsync(specId);
            var testChemicalComposition = await app.TestChemicalCompositions.FindAsync(id);

            var validate = testChemicalComposition.ValidateResult(spec);

            return Ok(validate);

            //return testChemicalComposition;
        }

        // PUT: api/v1/Chargings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestChemicalComposition([FromRoute] string id, [FromBody] TestChemicalComposition item, string specId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.Code)
            {
                return BadRequest();
            }

            var spec = await app.ChemicalCompositionInFurnaces.FindAsync(specId);
            item.Validation = item.ValidateResult(spec);
            item.IsCompleted = true;
            item.UpdatedTime = DateTime.Now;

            item.IsPassed = (item.Validation.IsOk_Al ?? true) && (item.Validation.IsOk_C ?? true) &&
                       (item.Validation.IsOk_CCE ?? true) && (item.Validation.IsOk_Cr ?? true) &&
                       (item.Validation.IsOk_Cu ?? true) && (item.Validation.IsOk_Mg ?? true) &&
                       (item.Validation.IsOk_Mn ?? true) && (item.Validation.IsOk_Mo ?? true) &&
                       (item.Validation.IsOk_Ni ?? true) && (item.Validation.IsOk_P ?? true) &&
                       (item.Validation.IsOk_S ?? true) && (item.Validation.IsOk_Si ?? true) &&
                       (item.Validation.IsOk_Sn ?? true) && (item.Validation.IsOk_Te ?? true) &&
                       (item.Validation.IsOk_Ti ?? true) && (item.Validation.IsOk_V ?? true);

            //_context.Entry(Charging).State = EntityState.Modified;
            app.TestChemicalCompositions.Update(item);

            try
            {
                await app.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Charging
        [HttpPost]
        public async Task<IActionResult> PostTestChemicalComposition([FromBody] TestChemicalComposition item)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            app.TestChemicalCompositions.Add(item);

            try
            {
                await app.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ItemExists(item.Code))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetTestChemicalCompositionById), new { id = item.Code }, item);
        }

        // DELETE: api/Charging/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestChemicalComposition([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var testChemicalComposition = await app.TestChemicalCompositions.FindAsync(id);
            if (testChemicalComposition == null)
            {
                return NotFound();
            }

            app.TestChemicalCompositions.Remove(testChemicalComposition);
            await app.SaveChangesAsync();

            return Ok(testChemicalComposition);
        }

        private bool ItemExists(string id)
        {
            return app.TestChemicalCompositions.All.Any(e => e.Code == id);
        }
    }
}