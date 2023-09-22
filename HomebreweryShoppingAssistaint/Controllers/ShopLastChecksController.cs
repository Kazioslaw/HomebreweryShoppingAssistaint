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
    public class ShopLastChecksController : Controller
    {
        private readonly HomebreweryShoppingAssistaintContext _context;

        public ShopLastChecksController(HomebreweryShoppingAssistaintContext context)
        {
            _context = context;
        }

        // GET: ShopLastChecks
        public async Task<IActionResult> Index()
        {
              return _context.ShopLastCheck != null ? 
                          View(await _context.ShopLastCheck.ToListAsync()) :
                          Problem("Entity set 'HomebreweryShoppingAssistaintContext.ShopLastCheck'  is null.");
        }

        // GET: ShopLastChecks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ShopLastCheck == null)
            {
                return NotFound();
            }

            var shopLastCheck = await _context.ShopLastCheck
                .FirstOrDefaultAsync(m => m.ShopLastCheckID == id);
            if (shopLastCheck == null)
            {
                return NotFound();
            }

            return View(shopLastCheck);
        }

        // GET: ShopLastChecks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShopLastChecks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShopLastCheckID,ShopID,LastCheckDateTime")] ShopLastCheck shopLastCheck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopLastCheck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shopLastCheck);
        }

        // GET: ShopLastChecks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ShopLastCheck == null)
            {
                return NotFound();
            }

            var shopLastCheck = await _context.ShopLastCheck.FindAsync(id);
            if (shopLastCheck == null)
            {
                return NotFound();
            }
            return View(shopLastCheck);
        }

        // POST: ShopLastChecks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShopLastCheckID,ShopID,LastCheckDateTime")] ShopLastCheck shopLastCheck)
        {
            if (id != shopLastCheck.ShopLastCheckID)
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
                    if (!ShopLastCheckExists(shopLastCheck.ShopLastCheckID))
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

        // GET: ShopLastChecks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ShopLastCheck == null)
            {
                return NotFound();
            }

            var shopLastCheck = await _context.ShopLastCheck
                .FirstOrDefaultAsync(m => m.ShopLastCheckID == id);
            if (shopLastCheck == null)
            {
                return NotFound();
            }

            return View(shopLastCheck);
        }

        // POST: ShopLastChecks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ShopLastCheck == null)
            {
                return Problem("Entity set 'HomebreweryShoppingAssistaintContext.ShopLastCheck'  is null.");
            }
            var shopLastCheck = await _context.ShopLastCheck.FindAsync(id);
            if (shopLastCheck != null)
            {
                _context.ShopLastCheck.Remove(shopLastCheck);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopLastCheckExists(int id)
        {
          return (_context.ShopLastCheck?.Any(e => e.ShopLastCheckID == id)).GetValueOrDefault();
        }
    }
}
