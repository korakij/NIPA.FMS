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
    public class PlanController : ControllerBase
    {
        private readonly App app;

        public PlanController(App app) // dependency injection (DI)
        {
            this.app = app;
        }

        // HTTP METHOD: URL (collection vs item)
        // GET: api/v1/Plan
        [HttpGet]
        public List<Plan> GetPlanAll()
        {
            return app.Plans.All.ToList();
        }

        // GET: api/v1/Plan/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Plan>> GetPlanById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Plan = await app.Plans.FindAsync(id);

            if (Plan == null)
            {
                return NotFound();
            }

            return Plan;
        }

        [HttpGet("byCode/{code}")]
        public async Task<ActionResult<Plan>> GetPlanByCode(string code)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Plan = await app.Plans.FindByCode(code);

            if (Plan == null)
            {
                return NotFound();
            }

            return Plan;
        }

        [HttpGet("byDate/{date}")]
        public async Task<ActionResult<List<Plan>>> GetPlanByDate(DateTime date)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Plan = await app.Plans.FindByDate(date);

            if (Plan == null)
            {
                return NotFound();
            }

            return Ok(Plan);
        }

        [HttpGet("byMonth/{date}")]
        public async Task<ActionResult<List<Plan>>> GetPlanByMonth(DateTime date)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Plan = await app.Plans.FindByMonth(date);

            if (Plan == null)
            {
                return NotFound();
            }

            return Ok(Plan);
        }

        // PUT: api/v1/Plan/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlan([FromRoute] int id, [FromBody] Plan item)
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
            app.Plans.Update(item);

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
        public async Task<IActionResult> PostPlan([FromBody] Plan item)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            app.Plans.Add(item);

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

            return CreatedAtAction(nameof(GetPlanById), new { id = item.Id }, item);
        }

        // DELETE: api/Charging/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlan([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Plan = await app.Plans.FindAsync(id);
            if (Plan == null)
            {
                return NotFound();
            }

            app.Plans.Remove(Plan);
            await app.SaveChangesAsync();

            return Ok(Plan);
        }

        private bool ItemExists(int id)
        {
            return app.Plans.All.Any(e => e.Id == id);
        }
    }
}