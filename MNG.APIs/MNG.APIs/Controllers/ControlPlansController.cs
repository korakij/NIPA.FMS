using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    public class ControlPlansController : ControllerBase
    {
        private readonly App app;

        public ControlPlansController(App app) // dependency injection (DI)
        {
            this.app = app;
        }

        // HTTP METHOD: URL (collection vs item)
        // GET: api/v1/ControlPlans
        [HttpGet]
        public IEnumerable<ControlPlan> GetControlPlanAll()
        {
            return app.ControlPlans.All
                .Include(x => x.Product)
                .Include(x => x.ChemicalCompositionInFurnace)
                .Include(x => x.ChemicalCompositionInLadle)
                .Include(x => x.Melting)
                .Include(x => x.Pouring)
                .Include(x => x.Molding)
                .Include(x => x.ShotBlasting)
                .Include(x => x.Tooling).ToList();
        }

        // GET: api/v1/ControlPlans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ControlPlan>> GetControlPlanById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var controlPlan = await app.ControlPlans.FindAsync(id);

            if (controlPlan == null)
            {
                return NotFound();
            }

            return Ok(controlPlan);
        }

        // GET: api/v1/ControlPlans/5
        [HttpGet("{id}/byCode")]
        public ActionResult<ControlPlan> GetControlPlanByCode([FromRoute] string id)
        {
            return app.ControlPlans.All.Where(x => x.Code == id).LastOrDefault();
        }

        // PUT: api/v1/ControlPlans/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutControlPlan([FromRoute] int id, [FromBody] ControlPlan item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.Id)
            {
                return BadRequest();
            }

            //_context.Entry(ControlPlan).State = EntityState.Modified;
            app.ControlPlans.Update(item);

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

        // POST: api/ControlPlan
        [HttpPost]
        public async Task<IActionResult> PostControlPlan([FromBody] ControlPlan item)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            app.ControlPlans.Add(item);

            try
            {
                await app.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ItemExists(item.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetControlPlanById), new { id = item.Id }, item);
        }

        // DELETE: api/ControlPlan/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteControlPlan([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var controlPlan = await app.ControlPlans.FindAsync(id);
            if (controlPlan == null)
            {
                return NotFound();
            }

            app.ControlPlans.Remove(controlPlan);
            await app.SaveChangesAsync();

            return Ok(controlPlan);
        }

        private bool ItemExists(int id)
        {
            return app.ControlPlans.All.Any(e => e.Id == id);
        }
    }
}