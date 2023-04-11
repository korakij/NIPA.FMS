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
    public class NotificationController : ControllerBase
    {
        private readonly App app;

        public NotificationController(App app) // dependency injection (DI)
        {
            this.app = app;
        }

        // HTTP METHOD: URL (collection vs item)
        // GET: api/v1/Chargings
        [HttpGet]
        public IEnumerable<Notification> GetNotificationAll()
        {
            return app.Notifications.All;
        }

        [HttpGet("/Count")]
        public int GetNotificationCount()
        {
            return app.Notifications.All.Count();
        }

        [HttpGet("/Last")]
        public Notification GetNotificationLast()
        {
            return app.Notifications.All.LastOrDefault();
        }

        // GET: api/v1/Chargings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var notification = await app.Notifications.FindAsync(id);

            if (notification == null)
            {
                return NotFound();
            }

            return Ok(notification);
        }

        [HttpGet("{id}/source")]
        public Notification GetNotificationBySource([FromRoute] string id, string application)
        {
            var cnt = app.Notifications.Query(x => x.Source == id && x.Application == application).Count();

            if (cnt == 0)
                return null;

            var noti = app.Notifications.Query(x => x.Source == id && x.Application == application).OrderByDescending(y => y.Id).First();

            return noti;
        }

        // PUT: api/v1/Kanbans/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotification([FromRoute] int id, [FromBody] Notification item)
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
            app.Notifications.Update(item);

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
        public async Task<IActionResult> PostNotification([FromBody] Notification item)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            app.Notifications.Add(item);

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

            return CreatedAtAction(nameof(GetNotificationById), new { id = item.Id }, item);
        }

        // DELETE: api/Kanbans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var notification = await app.Notifications.FindAsync(id);
            if (notification == null)
            {
                return NotFound();
            }

            app.Notifications.Remove(notification);
            await app.SaveChangesAsync();

            return Ok(notification);
        }

        private bool ItemExists(int id)
        {
            return app.Notifications.All.Any(e => e.Id == id);
        }
    }
}
