using HomebreweryShoppingAssistaint.Data;
using HomebreweryShoppingAssistaint.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HomebreweryShoppingAssistaint.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShopCheckHistoryController : ControllerBase
    {
        private readonly HomebreweryShoppingAssistaintContext _context;

        public ShopCheckHistoryController(HomebreweryShoppingAssistaintContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopCheckHistory>>> GetShopCheckHistories()
        {
            var ShopCheckHistories = await _context.ShopCheckHistories.ToListAsync();
            return Ok(ShopCheckHistories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShopCheckHistory>> GetShopCheckHistories(int? id)
        {
            if (id == null || _context.ShopCheckHistories == null)
            {
                return NotFound();
            }

            var ShopCheckHistories = await _context.ShopCheckHistories.FindAsync(id);
            if (ShopCheckHistories == null)
            {
                return NotFound();
            }

            return Ok(ShopCheckHistories);

        }
        [HttpPost]

        public async Task<ActionResult<ShopCheckHistory>> PostShopCheckHistories(ShopCheckHistory ShopCheckHistories)
        {
            _context.ShopCheckHistories.Add(ShopCheckHistories);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetShopCheckCategory", new { id = ShopCheckHistories.ShopCheckHistoryID }, ShopCheckHistories);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutShopCheckHistories(int id, ShopCheckHistory ShopCheckHistories)
        {
            if (id != ShopCheckHistories.ShopCheckHistoryID)
            {
                return BadRequest();
            }

            _context.ShopCheckHistories.Update(ShopCheckHistories);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DBConcurrencyException)
            {
                if (!ShopCheckHistoriesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShopCheckHistories(int id)
        {
            var ShopCheckHistories = await _context.ShopCheckHistories.FindAsync(id);
            if (ShopCheckHistories == null)
            {
                return NotFound();
            }

            _context.ShopCheckHistories.Remove(ShopCheckHistories);
            await _context.SaveChangesAsync();
            return Ok();
        }
        private bool ShopCheckHistoriesExists(int id)
        {
            return (_context.ShopCheckHistories?.Any(e => e.ShopCheckHistoryID == id)).GetValueOrDefault();
        }
    }
}
