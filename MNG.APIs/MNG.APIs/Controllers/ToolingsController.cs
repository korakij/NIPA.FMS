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
    public class ToolingsController : ControllerBase
    {
        private readonly App app;

        public ToolingsController(App app)
        {
            this.app = app;
        }

        // HTTP METHOD: URL (collection vs item)
        // GET: api/v1/Products
        [HttpGet]
        public IEnumerable<Tooling> GetToolingAll()
        {
            return app.Toolings.All;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tooling>> GetToolingById([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tooling = await app.Toolings.FindAsync(id);

            if (tooling == null)
            {
                return NotFound();
            }

            return Ok(tooling);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTooling([FromRoute] string id, [FromBody] Tooling item)
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
            
            app.Toolings.Update(item);

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

        [HttpPost]
        public async Task<IActionResult> PostTooling([FromBody] Tooling item)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            app.Toolings.Add(item);

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

            return CreatedAtAction(nameof(GetToolingById), new { id = item.Code }, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTooling([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tooling = await app.Toolings.FindAsync(id);
            if (tooling == null)
            {
                return NotFound();
            }

            app.Toolings.Remove(tooling);
            await app.SaveChangesAsync();

            return Ok(tooling);
        }

        private bool ItemExists(string id)
        {
            return app.Toolings.All.Any(e => e.Code == id);
        }
    }
}
