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
    public class PouringStandardController : Controller
    {
        private readonly App app;

        public PouringStandardController(App app) // dependency injection (DI)
        {
            this.app = app;
        }

        // HTTP METHOD: URL (collection vs item)
        // GET: api/v1/Products
        [HttpGet]
        public IEnumerable<PourStandard> GetPouringStandardAll()
        {
            return app.PourStandards.All;
        }

        // GET: api/v1/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PourStandard>> GetPouringStandardById([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pourStd = await app.PourStandards.FindAsync(id);

            if (pourStd == null)
            {
                return NotFound();
            }

            return Ok(pourStd);
        }

        // PUT: api/v1/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPouringStandard([FromRoute] string id, [FromBody] PourStandard item)
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
            app.PourStandards.Update(item);

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
        public async Task<IActionResult> PostPouringStandard([FromBody] PourStandard item)
        {

            //ModelState.Remove(nameof(item.Material));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            app.PourStandards.Add(item);

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

            return CreatedAtAction(nameof(PourStandard), new { id = item.Code }, item);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePouringStandard([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pourStd = await app.PourStandards.FindAsync(id);
            if (pourStd == null)
            {
                return NotFound();
            }

            app.PourStandards.Remove(pourStd);
            await app.SaveChangesAsync();

            return Ok(pourStd);
        }

        private bool ItemExists(string id)
        {
            return app.PourStandards.All.Any(e => e.Code == id);
        }
    }
}