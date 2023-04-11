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
    public class SettingController : ControllerBase
    {
        private readonly App app;

        public SettingController(App app) // dependency injection (DI)
        {
            this.app = app;
        }

        // HTTP METHOD: URL (collection vs item)
        // GET: api/v1/Materials
        [HttpGet]
        public IEnumerable<Setting> GetSettingAll()
        {
            return app.Settings.All;
        }

        // GET: api/v1/Materials/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSettingById([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var setting = await app.Settings.FindAsync(id);

            if (setting == null)
            {
                return NotFound();
            }

            return Ok(setting);
        }

        // PUT: api/v1/Materials/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSetting([FromRoute] string id, [FromBody] Setting item)
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
            app.Settings.Update(item);

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

        // POST: api/Materials
        [HttpPost]
        public async Task<IActionResult> PostSetting([FromBody] Setting item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            app.Settings.Add(item);

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

            return CreatedAtAction(nameof(GetSettingById), new { id = item.Code }, item);
        }

        // DELETE: api/Materials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSetting([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var setting = await app.Settings.FindAsync(id);
            if (setting == null)
            {
                return NotFound();
            }

            app.Settings.Remove(setting);
            await app.SaveChangesAsync();

            return Ok(setting);
        }

        private bool ItemExists(string id)
        {
            return app.Settings.All.Any(e => e.Code == id);
        }
    }
}