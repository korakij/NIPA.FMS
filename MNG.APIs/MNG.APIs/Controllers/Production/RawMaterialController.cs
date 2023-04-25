using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MNG.Models.Productions;
using MNG.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MNG.APIs.Controllers.Production
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RawMaterialController : ControllerBase
    {
        private readonly App app;

        public RawMaterialController(App app) // dependency injection (DI)
        {
            this.app = app;
        }

        // HTTP METHOD: URL (collection vs item)
        // GET: api/v1/Chargings
        [HttpGet]
        public IEnumerable<RawMaterial> GetRawMaterialAll()
        {
            return app.RawMaterials.All;
        }

        // GET: api/v1/Chargings/5
        [HttpGet("{code}")]
        public async Task<IActionResult> GetRawMaterialByCode([FromRoute] string code)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rawMat = await app.RawMaterials.FindAsync(code);

            if (rawMat == null)
            {
                return NotFound();
            }

            return Ok(rawMat);
        }

        // PUT: api/v1/Kanbans/5
        [HttpPut("{code}")]
        public async Task<IActionResult> PutNotification([FromRoute] string code, [FromBody] RawMaterial item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (code != item.MatCode)
            {
                return BadRequest();
            }

            //_context.Entry(Charging).State = EntityState.Modified;
            app.RawMaterials.Update(item);

            try
            {
                await app.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(code))
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

        // POST: api/Kanbans
        [HttpPost]
        public async Task<IActionResult> PostRawMaterial([FromBody] RawMaterial item)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            app.RawMaterials.Add(item);

            try
            {
                await app.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ItemExists(item.MatCode))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetRawMaterialByCode), new { id = item.MatCode }, item);
        }

        // DELETE: api/Kanbans/5
        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteNotification([FromRoute] string code)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rawMat = await app.RawMaterials.FindAsync(code);
            if (rawMat == null)
            {
                return NotFound();
            }

            app.RawMaterials.Remove(rawMat);
            await app.SaveChangesAsync();

            return Ok(rawMat);
        }

        private bool ItemExists(string code)
        {
            return app.RawMaterials.All.Any(e => e.MatCode == code);
        }
    }
}
