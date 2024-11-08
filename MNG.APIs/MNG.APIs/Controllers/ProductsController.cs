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
    public class ProductsController : ControllerBase
    {
        private readonly App app;

        public ProductsController(App app) // dependency injection (DI)
        {
            this.app = app;
        }

        // HTTP METHOD: URL (collection vs item)
        // GET: api/v1/Products
        [HttpGet]
        public IEnumerable<Product> GetProductAll()
        {
            return app.Products.All
                .Include(x => x.ActiveControlPlan)
                .Include(x => x.Material);
        }

        // GET: api/v1/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await app.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("WithoutPicture")]
        public async Task<ActionResult<Product>> GetProductWithoutImage()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await app.Products.FindWithoutImage();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/v1/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromRoute] int id, [FromBody] Product item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.Id)
            {
                return BadRequest();
            }

            //_context.Entry(material).State = EntityState.Modified;
            app.Products.Update(item);

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

        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] Product item)
        {

            ModelState.Remove(nameof(item.Material));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            app.Products.Add(item);

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

            return CreatedAtAction(nameof(GetProductById), new { id = item.Id }, item);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var material = await app.Products.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }

            app.Products.Remove(material);
            await app.SaveChangesAsync();

            return Ok(material);
        }

        private bool ItemExists(int id)
        {
            return app.Products.All.Any(e => e.Id == id);
        }
    }
}