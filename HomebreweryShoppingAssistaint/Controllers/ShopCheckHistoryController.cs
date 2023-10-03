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
    public class ShopCheckHistoryController : Controller
    {
        private readonly HomebreweryShoppingAssistaintContext _context;

        public ShopCheckHistoryController(HomebreweryShoppingAssistaintContext context)
        {
            _context = context;
        }

        // GET: ShopCheckHistory
        public async Task<IActionResult> Index()
        {
              return _context.ShopCheckHistory != null ? 
                          View(await _context.ShopCheckHistory.ToListAsync()) :
                          Problem("Entity set 'HomebreweryShoppingAssistaintContext.ShopCheckHistory'  is null.");
        }

        // GET: ShopCheckHistory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ShopCheckHistory == null)
            {
                return NotFound();
            }

            var shopLastCheck = await _context.ShopCheckHistory
                .FirstOrDefaultAsync(m => m.ShopCheckHistoryID == id);
            if (shopLastCheck == null)
            {
                return NotFound();
            }

            return View(shopLastCheck);
        }

        // GET: ShopCheckHistory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShopCheckHistory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShopCheckHistoryID,ShopID,CheckDateTime")] ShopCheckHistory shopLastCheck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopLastCheck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shopLastCheck);
        }

        // GET: ShopCheckHistory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ShopCheckHistory == null)
            {
                return NotFound();
            }

            var shopLastCheck = await _context.ShopCheckHistory.FindAsync(id);
            if (shopLastCheck == null)
            {
                return NotFound();
            }
            return View(shopLastCheck);
        }

        // POST: ShopCheckHistory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShopCheckHistoryID,ShopID,CheckDateTime")] ShopCheckHistory shopLastCheck)
        {
            if (id != shopLastCheck.ShopCheckHistoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopLastCheck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopCheckHistoryExists(shopLastCheck.ShopCheckHistoryID))
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
            return View(shopLastCheck);
        }

        // GET: ShopCheckHistory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ShopCheckHistory == null)
            {
                return NotFound();
            }

            var shopLastCheck = await _context.ShopCheckHistory
                .FirstOrDefaultAsync(m => m.ShopCheckHistoryID == id);
            if (shopLastCheck == null)
            {
                return NotFound();
            }

            return View(shopLastCheck);
        }

        // POST: ShopCheckHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ShopCheckHistory == null)
            {
                return Problem("Entity set 'HomebreweryShoppingAssistaintContext.ShopCheckHistory'  is null.");
            }
            var shopLastCheck = await _context.ShopCheckHistory.FindAsync(id);
            if (shopLastCheck != null)
            {
                _context.ShopCheckHistory.Remove(shopLastCheck);
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
