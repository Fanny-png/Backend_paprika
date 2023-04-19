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
    public class Shopping_sessionController : ControllerBase
    {
        private readonly EcommerceContext _context;

        public Shopping_sessionController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: api/Shopping_session
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shopping_session>>> GetShopping_Sessions()
        {
          if (_context.Shopping_Sessions == null)
          {
              return NotFound();
          }
            return await _context.Shopping_Sessions.ToListAsync();
        }

        // GET: api/Shopping_session/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shopping_session>> GetShopping_session(int id)
        {
          if (_context.Shopping_Sessions == null)
          {
              return NotFound();
          }
            var shopping_session = await _context.Shopping_Sessions.FindAsync(id);

            if (shopping_session == null)
            {
                return NotFound();
            }

            return shopping_session;
        }

        // PUT: api/Shopping_session/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShopping_session(int id, Shopping_session shopping_session)
        {
            if (id != shopping_session.shopping_session_id)
            {
                return BadRequest();
            }

            _context.Entry(shopping_session).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Shopping_sessionExists(id))
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

        // POST: api/Shopping_session
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Shopping_session>> PostShopping_session(Shopping_session shopping_session)
        {
          if (_context.Shopping_Sessions == null)
          {
              return Problem("Entity set 'EcommerceContext.Shopping_Sessions'  is null.");
          }
            _context.Shopping_Sessions.Add(shopping_session);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShopping_session", new { id = shopping_session.shopping_session_id }, shopping_session);
        }

        // DELETE: api/Shopping_session/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShopping_session(int id)
        {
            if (_context.Shopping_Sessions == null)
            {
                return NotFound();
            }
            var shopping_session = await _context.Shopping_Sessions.FindAsync(id);
            if (shopping_session == null)
            {
                return NotFound();
            }

            _context.Shopping_Sessions.Remove(shopping_session);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Shopping_sessionExists(int id)
        {
            return (_context.Shopping_Sessions?.Any(e => e.shopping_session_id == id)).GetValueOrDefault();
        }
    }
}
