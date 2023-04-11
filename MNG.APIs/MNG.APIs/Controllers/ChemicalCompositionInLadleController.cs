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
    public class ChemicalCompositionInLadleController : ControllerBase
    {
        private readonly App app;

        public ChemicalCompositionInLadleController(App app) // dependency injection (DI)
        {
            this.app = app;
        }

        // HTTP METHOD: URL (collection vs item)
        // GET: api/v1/Products
        [HttpGet]
        public IEnumerable<ChemicalCompositionInLadle> GetChemicalCompositionInLadleAll()
        {
            return app.ChemicalCompositionInLadles.All;
        }

        [HttpGet("ByProductId/{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChemicalCompositionInLadle))]
        public ActionResult<ChemicalCompositionInLadle> GetChemicalCompositionInLadleByProductId([FromRoute] int productId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var obj = app.ChemicalCompositionInLadles.GetByProductId(productId);

            if (obj == null)
            {
                return NotFound();
            }

            return Ok(obj);
        }

        // GET: api/v1/Products/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChemicalCompositionInLadle))]
        public async Task<ActionResult<ChemicalCompositionInLadle>> GetChemicalCompositionInLadleById([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chemicalCompositionInLadle = await app.ChemicalCompositionInLadles.FindAsync(id);

            if (chemicalCompositionInLadle == null)
            {
                return NotFound();
            }

            return Ok(chemicalCompositionInLadle);
        }

        // PUT: api/v1/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChemicalCompositionInLadle([FromRoute] string id, [FromBody] ChemicalCompositionInLadle item)
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
            app.ChemicalCompositionInLadles.Update(item);

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
        public async Task<IActionResult> PostChemicalCompositionInLadle([FromBody] ChemicalCompositionInLadle item)
        {

            //ModelState.Remove(nameof(item.Material));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            app.ChemicalCompositionInLadles.Add(item);

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

            return CreatedAtAction(nameof(GetChemicalCompositionInLadleById), new { id = item.Code }, item);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChemicalCompositionInLadle([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chemicalCompositionInLadle = await app.ChemicalCompositionInLadles.FindAsync(id);
            if (chemicalCompositionInLadle == null)
            {
                return NotFound();
            }

            app.ChemicalCompositionInLadles.Remove(chemicalCompositionInLadle);
            await app.SaveChangesAsync();

            return Ok(chemicalCompositionInLadle);
        }

        private bool ItemExists(string id)
        {
            return app.ChemicalCompositionInLadles.All.Any(e => e.Code == id);
        }
    }
}