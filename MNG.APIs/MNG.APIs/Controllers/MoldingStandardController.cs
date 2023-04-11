using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MNG.Models;
using MNG.Services;
using MNG.Services.Data;

namespace MNG.APIs.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MoldingStandardController : ControllerBase
    {
        private readonly App app;

        public MoldingStandardController(App app) // dependency injection (DI)
        {
            this.app = app;
        }

        // HTTP METHOD: URL(collection vs item)
        // GET: api/v1/Products
        [HttpGet]
        public IEnumerable<MoldStandard> GetMoldStandardAll()
        {
            return app.MoldStandards.All;
        }

        // GET: api/v1/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MoldStandard>> GetMoldStandardById([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var moldStandard = await app.MoldStandards.FindAsync(id);

            if (moldStandard == null)
            {
                return NotFound();
            }

            //app.Materials.Query(x => x.Code == meltStandard.MaterialCode).Load();

            //if (moldStandard.ActiveControlPlanId != null)
            //    app.ControlPlans.Query(x => x.Id == moldStandard.ActiveControlPlanId).Load();

            return Ok(moldStandard);
        }

        // PUT: api/v1/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoldStandard([FromRoute] string id, [FromBody] MoldStandard item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.Code)
            {
                return BadRequest();
            }

            //_context.Entry(material).State = EntityState.Modified;
            app.MoldStandards.Update(item);

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

        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> PostMoldStandard([FromBody] MoldStandard item)
        {

            ModelState.Remove(nameof(item.Code));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            app.MoldStandards.Add(item);

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

            return CreatedAtAction(nameof(GetMoldStandardById), new { id = item.Code }, item);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoldStandard([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var moldStandard = await app.MoldStandards.FindAsync(id);
            if (moldStandard == null)
            {
                return NotFound();
            }

            app.MoldStandards.Remove(moldStandard);
            await app.SaveChangesAsync();

            return Ok(moldStandard);
        }

        private bool ItemExists(string id)
        {
            return app.MeltStandards.All.Any(e => e.Code == id);
        }
    }
}