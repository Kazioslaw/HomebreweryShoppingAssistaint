using HomebreweryShoppingAssistaint.Data;
using HomebreweryShoppingAssistaint.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomebreweryShoppingAssistaint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductCheckHistoryController : Controller
    {
        private readonly HomebreweryShoppingAssistaintContext _context;

        public ProductCheckHistoryController(HomebreweryShoppingAssistaintContext context)
        {
            _context = context;
        }

        [HttpGet]
        // GET: ProductCheckHistories
        public async Task<IActionResult> Index()
        {
            var productCheckHistory = await _context.ProductCheckHistories.ToListAsync();
            return Ok(productCheckHistory);
        }

        [HttpGet("Details/{id}")]
        // GET: ProductCheckHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductCheckHistories == null)
            {
                return NotFound();
            }

            var productCheckHistory = await _context.ProductCheckHistories
                .FirstOrDefaultAsync(m => m.ProductCheckHistoryID == id);
            if (productCheckHistory == null)
            {
                return NotFound();
            }

            return View(productCheckHistory);
        }

        [HttpGet("Create")]
        // GET: ProductCheckHistories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductCheckHistories/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductCheckHistoryID,ProductID,ShopID,CheckDateTime")] ProductCheckHistory productCheckHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productCheckHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productCheckHistory);
        }

        [HttpGet("Edit/{id}")]
        // GET: ProductCheckHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductCheckHistories == null)
            {
                return NotFound();
            }

            var productCheckHistory = await _context.ProductCheckHistories.FindAsync(id);
            if (productCheckHistory == null)
            {
                return NotFound();
            }
            return View(productCheckHistory);
        }

        // POST: ProductCheckHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductCheckHistoryID,ProductID,ShopID,CheckDateTime")] ProductCheckHistory productCheckHistory)
        {
            if (id != productCheckHistory.ProductCheckHistoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productCheckHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductCheckHistoryExists(productCheckHistory.ProductCheckHistoryID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productCheckHistory);
        }

        [HttpGet("Delete/{id}")]
        // GET: ProductCheckHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductCheckHistories == null)
            {
                return NotFound();
            }

            var productCheckHistory = await _context.ProductCheckHistories
                .FirstOrDefaultAsync(m => m.ProductCheckHistoryID == id);
            if (productCheckHistory == null)
            {
                return NotFound();
            }

            return View(productCheckHistory);
        }

        // POST: ProductCheckHistories/Delete/5
        [HttpPost("Delete/{id}"), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductCheckHistories == null)
            {
                return Problem("Entity set 'HomebreweryShoppingAssistaintContext.ProductCheckHistory'  is null.");
            }
            var productCheckHistory = await _context.ProductCheckHistories.FindAsync(id);
            if (productCheckHistory != null)
            {
                _context.ProductCheckHistories.Remove(productCheckHistory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductCheckHistoryExists(int id)
        {
            return (_context.ProductCheckHistories?.Any(e => e.ProductCheckHistoryID == id)).GetValueOrDefault();
        }
    }
}
