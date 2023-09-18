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
    public class LastChecksController : Controller
    {
        private readonly HomebreweryShoppingAssistaintContext _context;

        public LastChecksController(HomebreweryShoppingAssistaintContext context)
        {
            _context = context;
        }

        // GET: LastChecks
        public async Task<IActionResult> Index()
        {
              return _context.LastCheck != null ? 
                          View(await _context.LastCheck.ToListAsync()) :
                          Problem("Entity set 'HomebreweryShoppingAssistaintContext.LastCheck'  is null.");
        }

        // GET: LastChecks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LastCheck == null)
            {
                return NotFound();
            }

            var lastCheck = await _context.LastCheck
                .FirstOrDefaultAsync(m => m.LastCheckID == id);
            if (lastCheck == null)
            {
                return NotFound();
            }

            return View(lastCheck);
        }

        // GET: LastChecks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LastChecks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LastCheckID,ProductID,CategoryID,ShopID,LastCheckDateTime")] LastCheck lastCheck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lastCheck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lastCheck);
        }

        // GET: LastChecks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LastCheck == null)
            {
                return NotFound();
            }

            var lastCheck = await _context.LastCheck.FindAsync(id);
            if (lastCheck == null)
            {
                return NotFound();
            }
            return View(lastCheck);
        }

        // POST: LastChecks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LastCheckID,ProductID,CategoryID,ShopID,LastCheckDateTime")] LastCheck lastCheck)
        {
            if (id != lastCheck.LastCheckID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lastCheck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LastCheckExists(lastCheck.LastCheckID))
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
            return View(lastCheck);
        }

        // GET: LastChecks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LastCheck == null)
            {
                return NotFound();
            }

            var lastCheck = await _context.LastCheck
                .FirstOrDefaultAsync(m => m.LastCheckID == id);
            if (lastCheck == null)
            {
                return NotFound();
            }

            return View(lastCheck);
        }

        // POST: LastChecks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LastCheck == null)
            {
                return Problem("Entity set 'HomebreweryShoppingAssistaintContext.LastCheck'  is null.");
            }
            var lastCheck = await _context.LastCheck.FindAsync(id);
            if (lastCheck != null)
            {
                _context.LastCheck.Remove(lastCheck);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LastCheckExists(int id)
        {
          return (_context.LastCheck?.Any(e => e.LastCheckID == id)).GetValueOrDefault();
        }
    }
}
