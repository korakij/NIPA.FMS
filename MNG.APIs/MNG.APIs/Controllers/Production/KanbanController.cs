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
using Newtonsoft.Json;

namespace MNG.APIs.Controllers.Production
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class KanbanController : ControllerBase
    {
        private readonly App app;

        public KanbanController(App app) // dependency injection (DI)
        {
            this.app = app;
        }

        // HTTP METHOD: URL (collection vs item)
        // GET: api/v1/Chargings
        [HttpGet]
        public IEnumerable<Kanban> GetKanbanAll()
        {
            return app.Kanbans.All;
        }

        // GET: api/v1/Chargings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kanban>> GetKanbanById([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kanban = await app.Kanbans.FindAsync(id);

            if (kanban == null)
            {
                return NotFound();
            }

            return Ok(kanban);
        }

        [HttpGet("{id}/Testno")]
        public ActionResult<IEnumerable<Kanban>> GetKanbanByTestNo([FromRoute] string id)
        {
            //var Kanbans = app.Kanbans.Query(x => x.TestChemicalCompositionCode == id).ToList();
            var Kanbans = app.Kanbans.FindAllByTestNo(id);

            return Ok(Kanbans);
        }

        [HttpGet("{id}/Lotno")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Kanban>))]
        public ActionResult GetKanbanByLotNo([FromRoute] string id)
        {
            var Kanbans = app.Kanbans.LoadKanban(id).ToList();

            var setting = new JsonSerializerSettings
            {
                //ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            };

            var json = JsonConvert.SerializeObject(Kanbans, setting);
            return Ok(json);
        }

        [HttpGet("{id}/KanbanByLotno")]
        public ActionResult<IEnumerable<Kanban>> GetKanbansByLotNo([FromRoute] string id)
        {
            //var Kanbans = app.Kanbans.Query(x => x.Code.Contains(id)).ToList();
            var Kanbans = app.Kanbans.FindAllByCode(id);
            
            return Ok(Kanbans);
        }

        [HttpGet("{id}/Validate")]
        public async Task<ActionResult<ChemicalCompositionValidation>> ValidateChemResult([FromRoute]string id, string specId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var spec = await app.ChemicalCompositionInLadles.FindAsync(specId);
            var kanban = await app.Kanbans.FindAsync(id);

            var validate = kanban.ValidateResult(spec);

            return Ok(validate);

            //return testChemicalComposition;
        }

        // PUT: api/v1/Kanbans/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKanban([FromRoute] string id, [FromBody] Kanban item, string specId, string _pourStdCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.Code)
            {
                return BadRequest();
            }

            var spec = await app.ChemicalCompositionInLadles.FindAsync(specId);
            item.Validation = item.ValidateResult(spec);

            var pourStd = await app.PourStandards.FindAsync(_pourStdCode);
            item.MatValidation = item.MatValidationResult(pourStd);
            item.UpdatedTime = DateTime.Now;

            item.IsPassed = (item.Validation.IsOk_Al ?? true) && (item.Validation.IsOk_C ?? true) &&
                       (item.Validation.IsOk_CCE ?? true) && (item.Validation.IsOk_Cr ?? true) &&
                       (item.Validation.IsOk_Cu ?? true) && (item.Validation.IsOk_Mg ?? true) &&
                       (item.Validation.IsOk_Mn ?? true) && (item.Validation.IsOk_Mo ?? true) &&
                       (item.Validation.IsOk_Ni ?? true) && (item.Validation.IsOk_P ?? true) &&
                       (item.Validation.IsOk_S ?? true) && (item.Validation.IsOk_Si ?? true) &&
                       (item.Validation.IsOk_Sn ?? true) && (item.Validation.IsOk_Te ?? true) &&
                       (item.Validation.IsOk_Ti ?? true) && (item.Validation.IsOk_V ?? true) &&
                       (item.MatValidation.IsOk_Inoculant ?? true) && (item.MatValidation.IsOk_Magnesium ?? true) &&
                       (item.MatValidation.IsOk_WireInoculant ?? true) && (item.MatValidation.IsOk_WireMagnesium ?? true) &&
                       (item.MatValidation.IsOk_WireInoculant ?? true) && (item.MatValidation.IsOk_WireMagnesium ?? true) &&
                       (item.MatValidation.IsOk_Copper ?? true) && (item.MatValidation.IsOk_Tin ?? true) &&
                       (item.MatValidation.IsOk_Chill ?? true) && (item.MatValidation.IsOk_WireMagnesium ?? true) &&
                       (item.MatValidation.IsOk_FeedTemp ?? true);

            item.IsCompleted = (item.KwHr > 0 ? true : false) && (item.Weight > 0 ? true : false);

            //_context.Entry(Kanbans).State = EntityState.Modified;

            app.Kanbans.Update(item);

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

        // POST: api/Kanbans
        [HttpPost]
        public async Task<IActionResult> PostKanban([FromBody] Kanban item)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            app.Kanbans.Add(item);

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

            return CreatedAtAction(nameof(GetKanbanById), new { id = item.Code }, item);
        }

        // DELETE: api/Kanbans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKanban([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kanban = await app.Kanbans.FindAsync(id);
            if (kanban == null)
            {
                return NotFound();
            }

            app.Kanbans.Remove(kanban);
            await app.SaveChangesAsync();

            return Ok(kanban);
        }

        private bool ItemExists(string id)
        {
            return app.Kanbans.All.Any(e => e.Code == id);
        }
    }
}