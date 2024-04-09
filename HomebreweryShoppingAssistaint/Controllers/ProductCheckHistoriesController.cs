using HomebreweryShoppingAssistaint.Data;
using HomebreweryShoppingAssistaint.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HomebreweryShoppingAssistaint.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCheckHistoryController : ControllerBase
    {
        private readonly HomebreweryShoppingAssistaintContext _context;

        public ProductCheckHistoryController(HomebreweryShoppingAssistaintContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCheckHistory>>> GetProductCheckHistory()
        {
            var productCheckHistory = await _context.ProductCheckHistory.ToListAsync();
            return Ok(productCheckHistory);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCheckHistory>> GetProductCheckHistory(int id)
        {
            if (id == null || _context.ProductCheckHistory == null)
            {
                return NotFound();
            }

            var productCheckHistory = await _context.ProductCheckHistory.FindAsync(id);

            if (productCheckHistory == null)
            {
                return NotFound();
            }

            return Ok(productCheckHistory);
        }

        [HttpPost]
        public async Task<ActionResult<ProductCheckHistory>> PostProductCheckHistory(ProductCheckHistory productCheckHistory)
        {
            _context.ProductCheckHistory.Add(productCheckHistory);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetProductCheckHistory", new { id = productCheckHistory.ProductCheckHistoryID }, productCheckHistory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductCheckHistory(int id, ProductCheckHistory productCheckHistory)
        {
            if (id != productCheckHistory.ProductID)
            {
                return BadRequest();
            }

            _context.ProductCheckHistory.Update(productCheckHistory);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DBConcurrencyException)
            {
                if (!ProductCheckHistoryExists(id))
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
        public async Task<IActionResult> DeleteProductCheckHistory(int id)
        {
            var productCheckHistory = await _context.ProductCheckHistory.FindAsync(id);
            if (productCheckHistory == null)
            {
                return NotFound();
            }

            _context.ProductCheckHistory.Remove(productCheckHistory);
            await _context.SaveChangesAsync();
            return Ok();
        }


        private bool ProductCheckHistoryExists(int id)
        {
            return (_context.ProductCheckHistory?.Any(e => e.ProductCheckHistoryID == id)).GetValueOrDefault();
        }
    }
}
