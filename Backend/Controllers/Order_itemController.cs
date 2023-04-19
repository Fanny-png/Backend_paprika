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
    public class Order_itemController : ControllerBase
    {
        private readonly EcommerceContext _context;

        public Order_itemController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: api/Order_item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order_item>>> GetOrder_Items()
        {
          if (_context.Order_Items == null)
          {
              return NotFound();
          }
            return await _context.Order_Items.ToListAsync();
        }

        // GET: api/Order_item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order_item>> GetOrder_item(int id)
        {
          if (_context.Order_Items == null)
          {
              return NotFound();
          }
            var order_item = await _context.Order_Items.FindAsync(id);

            if (order_item == null)
            {
                return NotFound();
            }

            return order_item;
        }

        // PUT: api/Order_item/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder_item(int id, Order_item order_item)
        {
            if (id != order_item.order_item_id)
            {
                return BadRequest();
            }

            _context.Entry(order_item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Order_itemExists(id))
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

        // POST: api/Order_item
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order_item>> PostOrder_item(Order_item order_item)
        {
          if (_context.Order_Items == null)
          {
              return Problem("Entity set 'EcommerceContext.Order_Items'  is null.");
          }
            _context.Order_Items.Add(order_item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder_item", new { id = order_item.order_item_id }, order_item);
        }

        // DELETE: api/Order_item/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder_item(int id)
        {
            if (_context.Order_Items == null)
            {
                return NotFound();
            }
            var order_item = await _context.Order_Items.FindAsync(id);
            if (order_item == null)
            {
                return NotFound();
            }

            _context.Order_Items.Remove(order_item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Order_itemExists(int id)
        {
            return (_context.Order_Items?.Any(e => e.order_item_id == id)).GetValueOrDefault();
        }
    }
}
