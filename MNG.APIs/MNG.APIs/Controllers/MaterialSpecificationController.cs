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
    public class MaterialSpecificationController : ControllerBase
    {
        private readonly App app;

        public MaterialSpecificationController(App app)
        {
            this.app = app;
        }

        [HttpGet]
        public IEnumerable<MaterialSpecification> GetMaterialSpecificationAll()
        {
            return app.MaterialSpecification.All;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialSpecification>> GetMaterialSpecificationById([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var matSpec = await app.MaterialSpecification.FindAsync(id);

            if (matSpec == null)
            {
                return NotFound();
            }

            //app.Materials.Query(x => x.Code == meltStandard.MaterialCode).Load();

            //if (meltStandard.ActiveControlPlanId != null)
            //    app.ControlPlans.Query(x => x.Id == meltStandard.ActiveControlPlanId).Load();

            return Ok(matSpec);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterialSpecification([FromRoute] string id, [FromBody] MaterialSpecification item)
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
            app.MaterialSpecification.Update(item);

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
        public async Task<IActionResult> PostMaterialSpecification([FromBody] MaterialSpecification item)
        {

            ModelState.Remove(nameof(item.Code));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            app.MaterialSpecification.Add(item);

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

            return CreatedAtAction(nameof(GetMaterialSpecificationById), new { id = item.Code }, item);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterialSpecification([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var matSpec = await app.MaterialSpecification.FindAsync(id);
            if (matSpec == null)
            {
                return NotFound();
            }

            app.MaterialSpecification.Remove(matSpec);
            await app.SaveChangesAsync();

            return Ok(matSpec);
        }

        private bool ItemExists(string id)
        {
            return app.MaterialSpecification.All.Any(e => e.Code == id);
        }
    }
}
