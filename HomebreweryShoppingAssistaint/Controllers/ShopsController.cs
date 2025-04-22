using HomebreweryShoppingAssistaint.Data;
using HomebreweryShoppingAssistaint.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomebreweryShoppingAssistaint.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShopsController : ControllerBase
    {
        private readonly HomebreweryShoppingAssistaintContext _context;

        public ShopsController(HomebreweryShoppingAssistaintContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shop>>> GetShop()
        {
            var shop = await _context.Shops.ToListAsync();
            return Ok(shop);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Shop>> GetShop(int id)
        {
            if (id == null || _context.Shops == null)
            {
                return NotFound();
            }
            var shop = await _context.Shops.FindAsync(id);
            if (shop == null)
            {
                return NotFound();
            }
            return Ok(shop);
        }

        [HttpPost]
        public async Task<ActionResult<Shop>> PostShop(Shop shop)
        {
            _context.Shops.Add(shop);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetProduct", new { id = shop.ShopID }, shop);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShop(int id, Shop shop)
        {
            if (id != shop.ShopID)
            {
                return BadRequest();
            }

            _context.Shops.Update(shop);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopExists(id))
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
        public async Task<IActionResult> DeleteShop(int id)
        {
            var shop = await _context.Shops.FindAsync(id);
            if (shop == null)
            {
                return NotFound();
            }

            _context.Shops.Remove(shop);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool ShopExists(int id)
        {
            return (_context.Shops?.Any(e => e.ShopID == id)).GetValueOrDefault();
        }
    }
}
