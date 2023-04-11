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
    public class MeltingStandardController : ControllerBase
    {
        private readonly App app;

        public MeltingStandardController(App app) // dependency injection (DI)
        {
            this.app = app;
        }

        // HTTP METHOD: URL (collection vs item)
        // GET: api/v1/Products
        [HttpGet]
        public IEnumerable<MeltStandard> GetMeltStandardAll()
        {
            return app.MeltStandards.All;
        }

        // GET: api/v1/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MeltStandard>> GetMeltStandardById([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var meltStandard = await app.MeltStandards.FindAsync(id);

            if (meltStandard == null)
            {
                return NotFound();
            }

            //app.Materials.Query(x => x.Code == meltStandard.MaterialCode).Load();

            //if (meltStandard.ActiveControlPlanId != null)
            //    app.ControlPlans.Query(x => x.Id == meltStandard.ActiveControlPlanId).Load();

            return Ok(meltStandard);
        }

        // PUT: api/v1/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeltStandard([FromRoute] string id, [FromBody] MeltStandard item)
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
            app.MeltStandards.Update(item);

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
        public async Task<IActionResult> PostMeltStandard([FromBody] MeltStandard item)
        {

            ModelState.Remove(nameof(item.Code));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            app.MeltStandards.Add(item);

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

            return CreatedAtAction(nameof(GetMeltStandardById), new { id = item.Code }, item);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeltStandard([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var meltStandard = await app.MeltStandards.FindAsync(id);
            if (meltStandard == null)
            {
                return NotFound();
            }

            app.MeltStandards.Remove(meltStandard);
            await app.SaveChangesAsync();

            return Ok(meltStandard);
        }

        private bool ItemExists(string id)
        {
            return app.MeltStandards.All.Any(e => e.Code == id);
        }
    }
}