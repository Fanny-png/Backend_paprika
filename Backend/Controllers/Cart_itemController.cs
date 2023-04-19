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
    public class Cart_itemController : ControllerBase
    {
        private readonly EcommerceContext _context;

        public Cart_itemController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: api/Cart_item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart_item>>> GetCart_Items()
        {
          if (_context.Cart_Items == null)
          {
              return NotFound();
          }
            return await _context.Cart_Items.ToListAsync();
        }

        // GET: api/Cart_item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cart_item>> GetCart_item(int id)
        {
          if (_context.Cart_Items == null)
          {
              return NotFound();
          }
            var cart_item = await _context.Cart_Items.FindAsync(id);

            if (cart_item == null)
            {
                return NotFound();
            }

            return cart_item;
        }

        // PUT: api/Cart_item/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart_item(int id, Cart_item cart_item)
        {
            if (id != cart_item.product_id)
            {
                return BadRequest();
            }

            _context.Entry(cart_item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Cart_itemExists(id))
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

        // POST: api/Cart_item
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cart_item>> PostCart_item(Cart_item cart_item)
        {
          if (_context.Cart_Items == null)
          {
              return Problem("Entity set 'EcommerceContext.Cart_Items'  is null.");
          }
            _context.Cart_Items.Add(cart_item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCart_item", new { id = cart_item.product_id }, cart_item);
        }

        // DELETE: api/Cart_item/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart_item(int id)
        {
            if (_context.Cart_Items == null)
            {
                return NotFound();
            }
            var cart_item = await _context.Cart_Items.FindAsync(id);
            if (cart_item == null)
            {
                return NotFound();
            }

            _context.Cart_Items.Remove(cart_item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Cart_itemExists(int id)
        {
            return (_context.Cart_Items?.Any(e => e.product_id == id)).GetValueOrDefault();
        }
    }
}
