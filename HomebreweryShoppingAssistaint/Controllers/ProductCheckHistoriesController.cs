using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HomebreweryShoppingAssistaint.Data;
using HomebreweryShoppingAssistaint.Models;

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

        [HttpGet("Details/{id}")]
        // GET: ProductCheckHistories
        public async Task<IActionResult> Index()
        {
              return _context.ProductCheckHistory != null ? 
                          View(await _context.ProductCheckHistory.ToListAsync()) :
                          Problem("Entity set 'HomebreweryShoppingAssistaintContext.ProductLastCheck'  is null.");
        }

        // GET: ProductCheckHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductCheckHistory == null)
            {
                return NotFound();
            }

            var productLastCheck = await _context.ProductCheckHistory
                .FirstOrDefaultAsync(m => m.ProductCheckHistoryID == id);
            if (productLastCheck == null)
            {
                return NotFound();
            }

            return View(productLastCheck);
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
        public async Task<IActionResult> Create([Bind("ProductCheckHistoriesID,ProductID,ShopID,CheckDateTime")] ProductCheckHistories productLastCheck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productLastCheck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productLastCheck);
        }

        [HttpGet("Edit/{id}")]
        // GET: ProductCheckHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductCheckHistory == null)
            {
                return NotFound();
            }

            var productLastCheck = await _context.ProductCheckHistory.FindAsync(id);
            if (productLastCheck == null)
            {
                return NotFound();
            }
            return View(productLastCheck);
        }

        // POST: ProductCheckHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductCheckHistoryID,ProductID,ShopID,CheckDateTime")] ProductCheckHistory productLastCheck)
        {
            if (id != productLastCheck.ProductCheckHistoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productLastCheck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductCheckHistoryExists(productLastCheck.ProductCheckHistoryID))
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
            return View(productLastCheck);
        }

        [HttpGet("Delete/{id}")]
        // GET: ProductCheckHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductCheckHistory == null)
            {
                return NotFound();
            }

            var productLastCheck = await _context.ProductCheckHistory
                .FirstOrDefaultAsync(m => m.ProductCheckHistoryID == id);
            if (productLastCheck == null)
            {
                return NotFound();
            }

            return View(productLastCheck);
        }

        // POST: ProductCheckHistories/Delete/5
        [HttpPost("Delete/{id}"), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductCheckHistory == null)
            {
                return Problem("Entity set 'HomebreweryShoppingAssistaintContext.ProductCheckHistory'  is null.");
            }
            var productLastCheck = await _context.ProductCheckHistory.FindAsync(id);
            if (productLastCheck != null)
            {
                _context.ProductCheckHistory.Remove(productLastCheck);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductCheckHistoryExists(int id)
        {
          return (_context.ProductCheckHistory?.Any(e => e.ProductCheckHistoryID == id)).GetValueOrDefault();
        }
    }
}
