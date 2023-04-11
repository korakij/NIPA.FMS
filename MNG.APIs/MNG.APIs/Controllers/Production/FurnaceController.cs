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
    public class FurnaceController : ControllerBase
    {
        private readonly App app;

        public FurnaceController(App app) // dependency injection (DI)
        {
            this.app = app;
        }

        // HTTP METHOD: URL (collection vs item)
        // GET: api/v1/Chargings
        [HttpGet]
        public IEnumerable<Furnace> GetFurnaceAll()
        {
            return app.Furnaces.All;
        }

        // GET: api/v1/Chargings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Furnace>> GetFurnaceById([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var furnace = await app.Furnaces.FindAsync(id);

            if (furnace == null)
            {
                return NotFound();
            }

            return Ok(furnace);
        }

        // PUT: api/v1/Chargings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFurnace([FromRoute] string id, [FromBody] Furnace item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.Code)
            {
                return BadRequest();
            }

            //_context.Entry(Charging).State = EntityState.Modified;
            app.Furnaces.Update(item);

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
        public async Task<IActionResult> PostFurnace([FromBody] Furnace item)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            app.Furnaces.Add(item);

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

            return CreatedAtAction(nameof(GetFurnaceById), new { id = item.Code }, item);
        }

        // DELETE: api/Charging/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFurnace([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var furnace = await app.Furnaces.FindAsync(id);
            if (furnace == null)
            {
                return NotFound();
            }

            app.Furnaces.Remove(furnace);
            await app.SaveChangesAsync();

            return Ok(furnace);
        }

        private bool ItemExists(string id)
        {
            return app.Furnaces.All.Any(e => e.Code == id);
        }
    }
}