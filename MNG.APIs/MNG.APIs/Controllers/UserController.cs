using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MNG.Models;
using MNG.Services;
using System.Collections;

namespace MNG.APIs.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly App app;

        public UserController(App app)
        {
            this.app = app;
        }

        [HttpGet]
        public IEnumerable<User> GetUserAll()
        {
            return app.Users.All;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserByName([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = await app.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            app.Users.Add(item);

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

            return CreatedAtAction(nameof(GetUserByName), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute] int id, [FromBody] User item)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.Id)
            {
                return BadRequest();
            }

            app.Users.Update(item);

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

        private bool ItemExists(int id)
        {
            return app.Users.All.Any(e => e.Id == id);
        }
    }
}
