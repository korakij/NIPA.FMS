using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MNG.Models.Productions;
using MNG.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MNG.APIs.Controllers.Production
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TestLogController : ControllerBase
    {
        private readonly App app;

        public TestLogController(App app) // dependency injection (DI)
        {
            this.app = app;
        }

        // HTTP METHOD: URL (collection vs item)
        // GET: api/v1/Chargings
        [HttpGet]
        public IEnumerable<TestLog> GetTestLogAll()
        {
            return app.TestLogs.All;
        }

        // GET: api/v1/Chargings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestLogById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var testLog = await app.TestLogs.FindAsync(id);

            if (testLog == null)
            {
                return NotFound();
            }

            return Ok(testLog);
        }

        // PUT: api/v1/Kanbans/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestLog([FromRoute] int id, [FromBody] TestLog item)
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
            app.TestLogs.Update(item);

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
        public async Task<IActionResult> PostTestLog([FromBody] TestLog item)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            app.TestLogs.Add(item);

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

            return CreatedAtAction(nameof(GetTestLogById), new { id = item.Id }, item);
        }

        // DELETE: api/Kanbans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestCode([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var testLog = await app.TestLogs.FindAsync(id);
            if (testLog == null)
            {
                return NotFound();
            }

            app.TestLogs.Remove(testLog);
            await app.SaveChangesAsync();

            return Ok(testLog);
        }

        private bool ItemExists(int id)
        {
            return app.TestLogs.All.Any(e => e.Id == id);
        }

    }
}
