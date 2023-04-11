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
    public class ShotBlastStandardController : Controller
    {
        private readonly App app;

        public ShotBlastStandardController(App app)
        {
            this.app = app;
        }

        // HTTP METHOD: URL (collection vs item)
        // GET: api/v1/Products
        [HttpGet]
        public IEnumerable<ShotBlastStandard> GetShotBlastStandardAll()
        {
            return app.ShotBlastStandards.All;
        }

        // GET: api/v1/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShotBlastStandard>> GetShotBlastStandardById([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shotBlastStd = await app.ShotBlastStandards.FindAsync(id);

            if (shotBlastStd == null)
            {
                return NotFound();
            }

            return Ok(shotBlastStd);
        }

        // PUT: api/v1/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShotBlastStandard([FromRoute] string id, [FromBody] ShotBlastStandard item)
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
            app.ShotBlastStandards.Update(item);

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
        public async Task<IActionResult> PostShotBlastStandard([FromBody] ShotBlastStandard item)
        {

            //ModelState.Remove(nameof(item.Material));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            app.ShotBlastStandards.Add(item);

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

            return CreatedAtAction(nameof(ShotBlastStandard), new { id = item.Code }, item);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShotBlastStandard([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shotBlastStd = await app.ShotBlastStandards.FindAsync(id);
            if (shotBlastStd == null)
            {
                return NotFound();
            }

            app.ShotBlastStandards.Remove(shotBlastStd);
            await app.SaveChangesAsync();

            return Ok(shotBlastStd);
        }

        private bool ItemExists(string id)
        {
            return app.ShotBlastStandards.All.Any(e => e.Code == id);
        }
    }
}
