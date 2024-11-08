using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MNG.Models;
using MNG.Models.Productions;
using MNG.Models.Productions.Defects;
using MNG.Services;
using MNG.Services.Data;
using Newtonsoft.Json;

namespace MNG.APIs.Controllers.Production
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PouringController : ControllerBase
    {
        private readonly App app;

        public PouringController(App app)
        {
            this.app = app;
        }

        [HttpGet]
        public IEnumerable<Pouring> GetPouringAll() 
        {
            return app.Pourings.All;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pouring>> GetPouringById([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pouring = await app.Pourings.FindAsync(id);

            if (pouring == null)
            {
                return NotFound();
            }

            return Ok(pouring);
        }

        [HttpGet("{id}/Last")]
        public ActionResult<IEnumerable<Pouring>> GetLast([FromRoute] string id)
        {
            var pourings = app.Pourings.FindLast3000(id);

            return Ok(pourings);
        }

        [HttpGet("{id}/PouringByKanban")]
        public ActionResult<IEnumerable<Pouring>> GetPouringByKanban([FromRoute] string id)
        {
            //var pourings = app.Pourings.Query(x => x.KanbanCode == id).ToList();
            var pourings = app.Pourings.FindAllByKanban(id);

            return Ok(pourings);
        }

        [HttpGet("{id}/FirstPouringByKanban")]
        public ActionResult<IEnumerable<Pouring>> GetFirstPouringByKanban([FromRoute] string id)
        {
            //var pourings = app.Pourings.Query(x => x.KanbanCode == id).FirstOrDefault();
            var pouring = app.Pourings.FindByKanban(id)
                ;
            return Ok(pouring);
        }

        [HttpGet("{id}/DefectSummary")]
        public async Task<int> GetDefectSummaryById([FromRoute] string id)
        {
            var pouring = await app.Pourings.FindAsync(id);

            int totalDefect = 0;

            totalDefect = pouring.Defect.MeltDefect.BlowHole + pouring.Defect.MeltDefect.ChemNG + pouring.Defect.MeltDefect.Chill + pouring.Defect.MeltDefect.HardnessNG +
                pouring.Defect.MeltDefect.MicroNG + pouring.Defect.MeltDefect.PinHole + pouring.Defect.MeltDefect.Shrinkage;

            return totalDefect;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPouringNo([FromRoute] string id, [FromBody] Pouring item, string pourStdCode, string toolingCode)
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
            var pourStd = await app.PourStandards.FindAsync(pourStdCode);
            var tooling = await app.Toolings.FindAsync(toolingCode);

            item.ValidateResult(pourStd, tooling);

            app.Pourings.Update(item);

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

        [HttpPut("{id}/Inspection")]
        public async Task<IActionResult> PutPouringInspection([FromRoute] string id, [FromBody] Pouring item)
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
            app.Pourings.Update(item);

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
        public async Task<IActionResult> PostPouring([FromBody] Pouring item)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            app.Pourings.Add(item);

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

            return CreatedAtAction(nameof(GetPouringById), new { id = item.Code }, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePouring([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pouring = await app.Pourings.FindAsync(id);
            if (pouring == null)
            {
                return NotFound();
            }

            app.Pourings.Remove(pouring);
            await app.SaveChangesAsync();

            return Ok(pouring);
        }

        private bool ItemExists(string id)
        {
            return app.Pourings.All.Any(e => e.Code == id);
        }

    }
}
