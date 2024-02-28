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
    public class ChargingController : ControllerBase
    {
        private readonly App app;

        public ChargingController(App app) // dependency injection (DI)
        {
            this.app = app;
        }

        // HTTP METHOD: URL (collection vs item)
        // GET: api/v1/Chargings
        [HttpGet]
        public IEnumerable<Charging> GetChargingAll()
        {
            return app.Chargings.All;
        }

        [HttpGet("{id}/testnos")]
        public ActionResult<IEnumerable<TestChemicalComposition>> GetTestNoByChargeNo([FromRoute] string id)
        {
            return app.TestChemicalCompositions.FindAllByChargingCode(id).ToList();
        }

        // GET: api/v1/Chargings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Charging>> GetChargingById([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var charging = await app.Chargings.FindAsync(id);

            if (charging == null)
            {
                return NotFound();
            }

            return Ok(charging);
        }

        // PUT: api/v1/Chargings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharging([FromRoute] string id, [FromBody] Charging item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.ChargeNo)
            {
                return BadRequest();
            }

            //_context.Entry(Charging).State = EntityState.Modified;
            app.Chargings.Update(item);

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
        public async Task<IActionResult> PostCharging([FromBody] Charging item)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            app.Chargings.Add(item);

            try
            {
                await app.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ItemExists(item.ChargeNo))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetChargingById), new { id = item.ChargeNo }, item);
        }

        // DELETE: api/Charging/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharging([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var charging = await app.Chargings.FindAsync(id);
            if (charging == null)
            {
                return NotFound();
            }

            app.Chargings.Remove(charging);
            await app.SaveChangesAsync();

            return Ok(charging);
        }

        private bool ItemExists(string id)
        {
            return app.Chargings.All.Any(e => e.ChargeNo == id);
        }
    }
}