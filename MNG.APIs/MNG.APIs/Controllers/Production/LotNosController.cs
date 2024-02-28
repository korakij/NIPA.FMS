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
    public class LotNosController : ControllerBase
    {
        private readonly App app;

        public LotNosController(App app) // dependency injection (DI)
        {
            this.app = app;
        }

        // HTTP METHOD: URL (collection vs item)
        // GET: api/v1/Chargings
        [HttpGet]
        public IEnumerable<LotNo> GetLotNoAll()
        {
            return app.LotNos.All;
        }

        [HttpGet("{id}/LotNoCount")]
        public int GetLotNoCount([FromRoute] string id)
        {
            return app.LotNos.All.Count();
        }

        [HttpGet("{id}/LotNoByFilter")]
        public ActionResult<IEnumerable<LotNo>> GetLotNoByFilter([FromRoute] string id)
        {
            return app.LotNos.FindAllByFilter(id);
        }

        [HttpGet("{id}/chargings")]
        public ActionResult<IEnumerable<Charging>> GetChargingsByLotNo([FromRoute] string id)
        {
            return app.Chargings.FindAllByLotNo(id);
        }

        [HttpGet("{id}/lotnos")]
        public ActionResult<IEnumerable<TestNoByLotNo>> GetTestByLotNo([FromRoute] string id)
        {
            return app.TestNoByLotNo.Query(x => x.LotCode == id).ToList();
        }

        [HttpGet("{id}/Testnos")]
        public ActionResult<IEnumerable<TestChemicalComposition>> GetTestsByLotNo([FromRoute] string id)
        {
            //var chargings = app.Chargings.Query(x => x.LotNoCode == id).ToList();
            var chargings = app.Chargings.FindAllByLotNo(id);
            var TotalTest = new List<TestChemicalComposition>();

            foreach (var charge in chargings)
            {
                //var tests = app.TestChemicalCompositions.Query(x => x.ChargingCode == charge.ChargeNo).ToList();
                var tests = app.TestChemicalCompositions.FindAllByLotNo(charge);
                TotalTest.AddRange(tests);
            }

            return TotalTest;
        }

        [HttpGet("{id}/Pourings")]
        public ActionResult<IEnumerable<Pouring>> GetPouringsByLotNo([FromRoute] string id)
        {
            var pourings = app.Pourings.FindAllByLotNo(id);

            return pourings;
        }

        // GET: api/v1/Chargings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LotNo>> GetLotNoById([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lotNo = await app.LotNos.FindAsync(id);

            if (lotNo == null)
            {
                return NotFound();
            }

            return lotNo;
        }

        // PUT: api/v1/Chargings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLotNo([FromRoute] string id, [FromBody] LotNo item)
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
            app.LotNos.Update(item);

            var notification = new Notification();
            notification.Source = "Melting";
            notification.Type = "Edit";
            notification.Code = item.Code;
            notification.Time = DateTime.Now;

            app.Notifications.Add(notification);

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
        public async Task<IActionResult> PostLotNo([FromBody] LotNo item)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            app.LotNos.Add(item);

            var notification = new Notification();
            notification.Source = "Melting";
            notification.Application = "LotNo";
            notification.Type = "Create";
            notification.Code = item.Code;
            notification.Time = DateTime.Now;

            app.Notifications.Add(notification);

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

            return CreatedAtAction(nameof(GetLotNoById), new { id = item.Code }, item);
        }

        // DELETE: api/Charging/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLotNo([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lotNo = await app.LotNos.FindAsync(id);
            if (lotNo == null)
            {
                return NotFound();
            }

            app.LotNos.Remove(lotNo);
            await app.SaveChangesAsync();

            return Ok(lotNo);
        }

        private bool ItemExists(string id)
        {
            return app.LotNos.All.Any(e => e.Code == id);
        }
    }
}