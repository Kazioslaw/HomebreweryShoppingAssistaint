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
    public class ProductLastChecksController : Controller
    {
        private readonly HomebreweryShoppingAssistaintContext _context;

        public ProductLastChecksController(HomebreweryShoppingAssistaintContext context)
        {
            _context = context;
        }

        // GET: ProductLastChecks
        public async Task<IActionResult> Index()
        {
              return _context.ProductLastCheck != null ? 
                          View(await _context.ProductLastCheck.ToListAsync()) :
                          Problem("Entity set 'HomebreweryShoppingAssistaintContext.ProductLastCheck'  is null.");
        }

        // GET: ProductLastChecks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductLastCheck == null)
            {
                return NotFound();
            }

            var productLastCheck = await _context.ProductLastCheck
                .FirstOrDefaultAsync(m => m.ProductCheckHistoryID == id);
            if (productLastCheck == null)
            {
                return NotFound();
            }

            return View(productLastCheck);
        }

        // GET: ProductLastChecks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductLastChecks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductCheckHistoryID,ProductID,ShopID,LastCheckDateTime")] ProductCheckHistory productLastCheck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productLastCheck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productLastCheck);
        }

        // GET: ProductLastChecks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductLastCheck == null)
            {
                return NotFound();
            }

            var productLastCheck = await _context.ProductLastCheck.FindAsync(id);
            if (productLastCheck == null)
            {
                return NotFound();
            }
            return View(productLastCheck);
        }

        // POST: ProductLastChecks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductCheckHistoryID,ProductID,ShopID,LastCheckDateTime")] ProductCheckHistory productLastCheck)
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
                    if (!ProductLastCheckExists(productLastCheck.ProductCheckHistoryID))
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

        // GET: ProductLastChecks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductLastCheck == null)
            {
                return NotFound();
            }

            var productLastCheck = await _context.ProductLastCheck
                .FirstOrDefaultAsync(m => m.ProductCheckHistoryID == id);
            if (productLastCheck == null)
            {
                return NotFound();
            }

            return View(productLastCheck);
        }

        // POST: ProductLastChecks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductLastCheck == null)
            {
                return Problem("Entity set 'HomebreweryShoppingAssistaintContext.ProductLastCheck'  is null.");
            }
            var productLastCheck = await _context.ProductLastCheck.FindAsync(id);
            if (productLastCheck != null)
            {
                _context.ProductLastCheck.Remove(productLastCheck);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductLastCheckExists(int id)
        {
          return (_context.ProductLastCheck?.Any(e => e.ProductCheckHistoryID == id)).GetValueOrDefault();
        }
    }
}
