using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product_categoryController : ControllerBase
    {
        private readonly EcommerceContext _context;

        public Product_categoryController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: api/Product_category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product_category>>> GetProduct_Categories()
        {
          if (_context.Product_Categories == null)
          {
              return NotFound();
          }
            return await _context.Product_Categories.ToListAsync();
        }

        // GET: api/Product_category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product_category>> GetProduct_category(int id)
        {
          if (_context.Product_Categories == null)
          {
              return NotFound();
          }
            var product_category = await _context.Product_Categories.FindAsync(id);

            if (product_category == null)
            {
                return NotFound();
            }

            return product_category;
        }

        // PUT: api/Product_category/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct_category(int id, Product_category product_category)
        {
            if (id != product_category.product_category_id)
            {
                return BadRequest();
            }

            _context.Entry(product_category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Product_categoryExists(id))
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

        // POST: api/Product_category
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product_category>> PostProduct_category(Product_category product_category)
        {
          if (_context.Product_Categories == null)
          {
              return Problem("Entity set 'EcommerceContext.Product_Categories'  is null.");
          }
            _context.Product_Categories.Add(product_category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct_category", new { id = product_category.product_category_id }, product_category);
        }

        // DELETE: api/Product_category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct_category(int id)
        {
            if (_context.Product_Categories == null)
            {
                return NotFound();
            }
            var product_category = await _context.Product_Categories.FindAsync(id);
            if (product_category == null)
            {
                return NotFound();
            }

            _context.Product_Categories.Remove(product_category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Product_categoryExists(int id)
        {
            return (_context.Product_Categories?.Any(e => e.product_category_id == id)).GetValueOrDefault();
        }
    }
}
