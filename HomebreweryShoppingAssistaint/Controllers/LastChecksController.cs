using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomebreweryShoppingAssistaint.Data;
using HomebreweryShoppingAssistaint.Models;

namespace HomebreweryShoppingAssistaint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LastChecksController : ControllerBase
    {
        private readonly HomebreweryShoppingAssistaintContext _context;

        public LastChecksController(HomebreweryShoppingAssistaintContext context)
        {
            _context = context;
        }

        // GET: api/LastChecks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LastCheck>>> GetLastCheck()
        {
          if (_context.LastCheck == null)
          {
              return NotFound();
          }
            return await _context.LastCheck.ToListAsync();
        }

        // GET: api/LastChecks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LastCheck>> GetLastCheck(int id)
        {
          if (_context.LastCheck == null)
          {
              return NotFound();
          }
            var lastCheck = await _context.LastCheck.FindAsync(id);

            if (lastCheck == null)
            {
                return NotFound();
            }

            return lastCheck;
        }

        // PUT: api/LastChecks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLastCheck(int id, LastCheck lastCheck)
        {
            if (id != lastCheck.LastCheckID)
            {
                return BadRequest();
            }

            _context.Entry(lastCheck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LastCheckExists(id))
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

        // POST: api/LastChecks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LastCheck>> PostLastCheck(LastCheck lastCheck)
        {
          if (_context.LastCheck == null)
          {
              return Problem("Entity set 'HomebreweryShoppingAssistaintContext.LastCheck'  is null.");
          }
            _context.LastCheck.Add(lastCheck);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLastCheck", new { id = lastCheck.LastCheckID }, lastCheck);
        }

        // DELETE: api/LastChecks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLastCheck(int id)
        {
            if (_context.LastCheck == null)
            {
                return NotFound();
            }
            var lastCheck = await _context.LastCheck.FindAsync(id);
            if (lastCheck == null)
            {
                return NotFound();
            }

            _context.LastCheck.Remove(lastCheck);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LastCheckExists(int id)
        {
            return (_context.LastCheck?.Any(e => e.LastCheckID == id)).GetValueOrDefault();
        }
    }
}
