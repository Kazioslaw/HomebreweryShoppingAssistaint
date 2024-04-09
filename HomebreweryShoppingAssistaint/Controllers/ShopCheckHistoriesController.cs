using HomebreweryShoppingAssistaint.Data;
using HomebreweryShoppingAssistaint.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HomebreweryShoppingAssistaint.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShopCheckHistoriesController : ControllerBase
    {
        private readonly HomebreweryShoppingAssistaintContext _context;

        public ShopCheckHistoriesController(HomebreweryShoppingAssistaintContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopCheckHistory>>> GetShopCheckHistory()
        {
            var shopCheckHistory = await _context.ShopCheckHistory.ToListAsync();
            return Ok(shopCheckHistory);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShopCheckHistory>> GetShopCheckHistory(int? id)
        {
            if (id == null || _context.ShopCheckHistory == null)
            {
                return NotFound();
            }

            var shopCheckHistory = await _context.ShopCheckHistory.FindAsync(id);
            if (shopCheckHistory == null)
            {
                return NotFound();
            }

            return Ok(shopCheckHistory);

        }
        [HttpPost]

        public async Task<ActionResult<ShopCheckHistory>> PostShopCheckHistory(ShopCheckHistory shopCheckHistory)
        {
            _context.ShopCheckHistory.Add(shopCheckHistory);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetShopCheckCategory", new { id = shopCheckHistory.ShopCheckHistoryID }, shopCheckHistory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutShopCheckHistory(int id, ShopCheckHistory shopCheckHistory)
        {
            if (id != shopCheckHistory.ShopCheckHistoryID)
            {
                return BadRequest();
            }

            _context.ShopCheckHistory.Update(shopCheckHistory);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DBConcurrencyException)
            {
                if (!ShopCheckHistoryExists(id))
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
        public async Task<IActionResult> DeleteShopCheckHistory(int id)
        {
            var shopCheckHistory = await _context.ShopCheckHistory.FindAsync(id);
            if (shopCheckHistory == null)
            {
                return NotFound();
            }

            _context.ShopCheckHistory.Remove(shopCheckHistory);
            await _context.SaveChangesAsync();
            return Ok();
        }
        private bool ShopCheckHistoryExists(int id)
        {
            return (_context.ShopCheckHistory?.Any(e => e.ShopCheckHistoryID == id)).GetValueOrDefault();
        }
    }
}
