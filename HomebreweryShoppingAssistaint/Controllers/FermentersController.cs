using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomebreweryShoppingAssistaint.Data;
using HomebreweryShoppingAssistaint.Models;

namespace HomebreweryShoppingAssistaint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FermentersController : ControllerBase
    {
        private readonly HomebreweryShoppingAssistaintContext _context;

        public FermentersController(HomebreweryShoppingAssistaintContext context)
        {
            _context = context;
        }

        // GET: api/Fermenters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fermenter>>> GetFermenters()
        {
            return await _context.Fermenters.ToListAsync();
        }

        // GET: api/Fermenters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fermenter>> GetFermenter(long id)
        {
            var fermenter = await _context.Fermenters.FindAsync(id);

            if (fermenter == null)
            {
                return NotFound();
            }

            return fermenter;
        }

        // PUT: api/Fermenters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFermenter(long id, Fermenter fermenter)
        {
            if (id != fermenter.Id)
            {
                return BadRequest();
            }

            _context.Entry(fermenter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FermenterExists(id))
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

        // POST: api/Fermenters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fermenter>> PostFermenter(Fermenter fermenter)
        {
            _context.Fermenters.Add(fermenter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFermenter", new { id = fermenter.Id }, fermenter);
        }

        // DELETE: api/Fermenters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFermenter(long id)
        {
            var fermenter = await _context.Fermenters.FindAsync(id);
            if (fermenter == null)
            {
                return NotFound();
            }

            _context.Fermenters.Remove(fermenter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FermenterExists(long id)
        {
            return _context.Fermenters.Any(e => e.Id == id);
        }
    }
}
