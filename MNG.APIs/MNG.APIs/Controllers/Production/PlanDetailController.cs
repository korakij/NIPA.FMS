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
    public class PlanDetailController : ControllerBase
    {
        private readonly App app;

        public PlanDetailController(App app) // dependency injection (DI)
        {
            this.app = app;
        }

        // HTTP METHOD: URL (collection vs item)
        // GET: api/v1/PlanDetails
        [HttpGet]
        public IEnumerable<PlanDetail> GetPlanDetailAll()
        {
            return app.PlanDetails.All;
        }

        // GET: api/v1/PlanDetail/id
        [HttpGet("{id}")]
        public async Task<ActionResult<PlanDetail>> GetPlanDetailById([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var PlanDetail = await app.PlanDetails.FindAsync(id);

            if (PlanDetail == null)
            {
                return NotFound();
            }

            return PlanDetail;
        }

        [HttpGet("byPlanId/{planId}")]
        public async Task<ActionResult<List<PlanDetail>>> GetPlanDetailByPlanId(int planId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var PlanDetail = await app.PlanDetails.FindByPlanId(planId);

            if (PlanDetail == null)
            {
                return NotFound();
            }

            return PlanDetail;
        }

        // PUT: api/v1/Chargings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanDetail([FromRoute] int id, [FromBody] PlanDetail item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.Id)
            {
                return BadRequest();
            }

            //_context.Entry(Charging).State = EntityState.Modified;
            app.PlanDetails.Update(item);

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

        // POST: api/PlanDetail
        [HttpPost]
        public async Task<IActionResult> PostPlanDetail([FromBody] PlanDetail item)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            app.PlanDetails.Add(item);

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

            return CreatedAtAction(nameof(GetPlanDetailById), new { id = item.Id }, item);
        }

        // DELETE: api/Charging/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanDetail([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var PlanDetail = await app.PlanDetails.FindAsync(id);
            if (PlanDetail == null)
            {
                return NotFound();
            }

            app.PlanDetails.Remove(PlanDetail);
            await app.SaveChangesAsync();

            return Ok(PlanDetail);
        }

        private bool ItemExists(int id)
        {
            return app.PlanDetails.All.Any(e => e.Id == id);
        }
    }
}