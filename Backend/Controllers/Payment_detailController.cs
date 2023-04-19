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
    public class Payment_detailController : ControllerBase
    {
        private readonly EcommerceContext _context;

        public Payment_detailController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: api/Payment_detail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment_detail>>> GetPayment_Details()
        {
          if (_context.Payment_Details == null)
          {
              return NotFound();
          }
            return await _context.Payment_Details.ToListAsync();
        }

        // GET: api/Payment_detail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment_detail>> GetPayment_detail(int id)
        {
          if (_context.Payment_Details == null)
          {
              return NotFound();
          }
            var payment_detail = await _context.Payment_Details.FindAsync(id);

            if (payment_detail == null)
            {
                return NotFound();
            }

            return payment_detail;
        }

        // PUT: api/Payment_detail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment_detail(int id, Payment_detail payment_detail)
        {
            if (id != payment_detail.payment_detail_id)
            {
                return BadRequest();
            }

            _context.Entry(payment_detail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Payment_detailExists(id))
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

        // POST: api/Payment_detail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Payment_detail>> PostPayment_detail(Payment_detail payment_detail)
        {
          if (_context.Payment_Details == null)
          {
              return Problem("Entity set 'EcommerceContext.Payment_Details'  is null.");
          }
            _context.Payment_Details.Add(payment_detail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPayment_detail", new { id = payment_detail.payment_detail_id }, payment_detail);
        }

        // DELETE: api/Payment_detail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment_detail(int id)
        {
            if (_context.Payment_Details == null)
            {
                return NotFound();
            }
            var payment_detail = await _context.Payment_Details.FindAsync(id);
            if (payment_detail == null)
            {
                return NotFound();
            }

            _context.Payment_Details.Remove(payment_detail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Payment_detailExists(int id)
        {
            return (_context.Payment_Details?.Any(e => e.payment_detail_id == id)).GetValueOrDefault();
        }
    }
}
