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
    public class ChemicalCompositionInFurnaceController : ControllerBase
    {
        private readonly App app;

        public ChemicalCompositionInFurnaceController(App app) // dependency injection (DI)
        {
            this.app = app;
        }

        // HTTP METHOD: URL (collection vs item)
        // GET: api/v1/Products
        [HttpGet]
        public IEnumerable<ChemicalCompositionInFurnace> GetChemicalCompositionInFurnaceAll()
        {
            return app.ChemicalCompositionInFurnaces.All;
        }

        [HttpGet("ByProductId/{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChemicalCompositionInFurnace))]
        public ActionResult<ChemicalCompositionInFurnace> GetChemicalCompositionInFurnaceByProductId([FromRoute] int productId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var obj = app.ChemicalCompositionInFurnaces.GetByProductId(productId);

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChemicalCompositionInFurnace))]
        public async Task<ActionResult<ChemicalCompositionInFurnace>> GetChemicalCompositionInFurnaceById([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chemicalCompositionInFurnace = await app.ChemicalCompositionInFurnaces.FindAsync(id);

            if (chemicalCompositionInFurnace == null)
            {
                return NotFound();
            }

            return Ok(chemicalCompositionInFurnace);
        }

        // PUT: api/v1/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChemicalCompositionInFurnace([FromRoute] string id, [FromBody] ChemicalCompositionInFurnace item)
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
            app.ChemicalCompositionInFurnaces.Update(item);

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
        public async Task<IActionResult> PostChemicalCompositionInFurnace([FromBody] ChemicalCompositionInFurnace item)
        {

            //ModelState.Remove(nameof(item.Material));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            app.ChemicalCompositionInFurnaces.Add(item);

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

            return CreatedAtAction(nameof(GetChemicalCompositionInFurnaceById), new { id = item.Code }, item);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChemicalCompositionInFurnace([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chemicalCompositionInFurnace = await app.ChemicalCompositionInFurnaces.FindAsync(id);
            if (chemicalCompositionInFurnace == null)
            {
                return NotFound();
            }

            app.ChemicalCompositionInFurnaces.Remove(chemicalCompositionInFurnace);
            await app.SaveChangesAsync();

            return Ok(chemicalCompositionInFurnace);
        }

        private bool ItemExists(string id)
        {
            return app.ChemicalCompositionInFurnaces.All.Any(e => e.Code == id);
        }
    }
}