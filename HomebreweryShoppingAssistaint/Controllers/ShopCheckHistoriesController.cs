using HomebreweryShoppingAssistaint.Data;
using HomebreweryShoppingAssistaint.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomebreweryShoppingAssistaint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopCheckHistoriesController : Controller
    {
        private readonly HomebreweryShoppingAssistaintContext _context;

        public ShopCheckHistoriesController(HomebreweryShoppingAssistaintContext context)
        {
            _context = context;
        }

        [HttpGet]
        // GET: ShopCheckHistories
        public async Task<IActionResult> Index()
        {
            var shopCheckHistory = await _context.ShopCheckHistory.ToListAsync();
            return Ok(shopCheckHistory);
        }

        [HttpGet("Details/{id}")]
        // GET: ShopCheckHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ShopCheckHistory == null)
            {
                return NotFound();
            }

            var shopCheckHistory = await _context.ShopCheckHistory
                .FirstOrDefaultAsync(m => m.ShopCheckHistoryID == id);
            if (shopCheckHistory == null)
            {
                return NotFound();
            }

            return View(shopCheckHistory);
        }

        [HttpGet("Create")]
        // GET: ShopCheckHistories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShopCheckHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShopCheckHistoryID,ShopID,CheckDateTime")] ShopCheckHistory shopCheckHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopCheckHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shopCheckHistory);
        }

        [HttpGet("Edit/{id}")]
        // GET: ShopCheckHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            return View(shopCheckHistory);
        }

        // POST: ShopCheckHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShopCheckHistoryID,ShopID,CheckDateTime")] ShopCheckHistory shopCheckHistory)
        {
            if (id != shopCheckHistory.ShopCheckHistoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopCheckHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopCheckHistoryExists(shopCheckHistory.ShopCheckHistoryID))
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
            return View(shopCheckHistory);
        }

        [HttpGet("Delete/{id}")]
        // GET: ShopCheckHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ShopCheckHistory == null)
            {
                return NotFound();
            }

            var shopCheckHistory = await _context.ShopCheckHistory
                .FirstOrDefaultAsync(m => m.ShopCheckHistoryID == id);
            if (shopCheckHistory == null)
            {
                return NotFound();
            }

            return View(shopCheckHistory);
        }


        // POST: ShopCheckHistories/Delete/5
        [HttpPost("Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ShopCheckHistory == null)
            {
                return Problem("Entity set 'HomebreweryShoppingAssistaintContext.ShopCheckHistory'  is null.");
            }
            var shopCheckHistory = await _context.ShopCheckHistory.FindAsync(id);
            if (shopCheckHistory != null)
            {
                _context.ShopCheckHistory.Remove(shopCheckHistory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopCheckHistoryExists(int id)
        {
            return (_context.ShopCheckHistory?.Any(e => e.ShopCheckHistoryID == id)).GetValueOrDefault();
        }
    }
}
