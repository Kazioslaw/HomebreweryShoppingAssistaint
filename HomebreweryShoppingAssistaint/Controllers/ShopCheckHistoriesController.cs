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
<<<<<<<< HEAD:HomebreweryShoppingAssistaint/Controllers/ShopCheckHistoriesController.cs
    [ApiController]
    [Route("[controller]")]
    public class ShopCheckHistoriesController : Controller
    {
        private readonly HomebreweryShoppingAssistaintContext _context;

        public ShopCheckHistoriesController(HomebreweryShoppingAssistaintContext context)
========
    public class ShopCheckHistoryController : Controller
    {
        private readonly HomebreweryShoppingAssistaintContext _context;

        public ShopCheckHistoryController(HomebreweryShoppingAssistaintContext context)
>>>>>>>> master:HomebreweryShoppingAssistaint/Controllers/ShopCheckHistoryController.cs
        {
            _context = context;
        }

<<<<<<<< HEAD:HomebreweryShoppingAssistaint/Controllers/ShopCheckHistoriesController.cs
        [HttpGet]
        // GET: ShopCheckHistories
========
        // GET: ShopCheckHistory
>>>>>>>> master:HomebreweryShoppingAssistaint/Controllers/ShopCheckHistoryController.cs
        public async Task<IActionResult> Index()
        {
              return _context.ShopCheckHistory != null ? 
                          View(await _context.ShopCheckHistory.ToListAsync()) :
                          Problem("Entity set 'HomebreweryShoppingAssistaintContext.ShopCheckHistory'  is null.");
        }

<<<<<<<< HEAD:HomebreweryShoppingAssistaint/Controllers/ShopCheckHistoriesController.cs
        [HttpGet("Details/{id}")]
        // GET: ShopCheckHistories/Details/5
========
        // GET: ShopCheckHistory/Details/5
>>>>>>>> master:HomebreweryShoppingAssistaint/Controllers/ShopCheckHistoryController.cs
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

<<<<<<<< HEAD:HomebreweryShoppingAssistaint/Controllers/ShopCheckHistoriesController.cs
        [HttpGet("Create")]
        // GET: ShopCheckHistories/Create
========
        // GET: ShopCheckHistory/Create
>>>>>>>> master:HomebreweryShoppingAssistaint/Controllers/ShopCheckHistoryController.cs
        public IActionResult Create()
        {
            return View();
        }

<<<<<<<< HEAD:HomebreweryShoppingAssistaint/Controllers/ShopCheckHistoriesController.cs
        // POST: ShopCheckHistories/Create
========
        // POST: ShopCheckHistory/Create
>>>>>>>> master:HomebreweryShoppingAssistaint/Controllers/ShopCheckHistoryController.cs
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
<<<<<<<< HEAD:HomebreweryShoppingAssistaint/Controllers/ShopCheckHistoriesController.cs
        public async Task<IActionResult> Create([Bind("ShopCheckHistoryID,ShopID,LastCheckDateTime")] ShopCheckHistory shopLastCheck)
========
        public async Task<IActionResult> Create([Bind("ShopCheckHistoryID,ShopID,CheckDateTime")] ShopCheckHistory shopLastCheck)
>>>>>>>> master:HomebreweryShoppingAssistaint/Controllers/ShopCheckHistoryController.cs
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopLastCheck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shopLastCheck);
        }

<<<<<<<< HEAD:HomebreweryShoppingAssistaint/Controllers/ShopCheckHistoriesController.cs
        [HttpGet("Edit/{id}")]
        // GET: ShopCheckHistories/Edit/5
========
        // GET: ShopCheckHistory/Edit/5
>>>>>>>> master:HomebreweryShoppingAssistaint/Controllers/ShopCheckHistoryController.cs
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

<<<<<<<< HEAD:HomebreweryShoppingAssistaint/Controllers/ShopCheckHistoriesController.cs
        // POST: ShopCheckHistories/Edit/5
========
        // POST: ShopCheckHistory/Edit/5
>>>>>>>> master:HomebreweryShoppingAssistaint/Controllers/ShopCheckHistoryController.cs
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
<<<<<<<< HEAD:HomebreweryShoppingAssistaint/Controllers/ShopCheckHistoriesController.cs
        public async Task<IActionResult> Edit(int id, [Bind("ShopCheckHistoryID,ShopID,LastCheckDateTime")] ShopCheckHistory shopLastCheck)
========
        public async Task<IActionResult> Edit(int id, [Bind("ShopCheckHistoryID,ShopID,CheckDateTime")] ShopCheckHistory shopLastCheck)
>>>>>>>> master:HomebreweryShoppingAssistaint/Controllers/ShopCheckHistoryController.cs
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

<<<<<<<< HEAD:HomebreweryShoppingAssistaint/Controllers/ShopCheckHistoriesController.cs
        [HttpGet("Delete/{id}")]
        // GET: ShopCheckHistories/Delete/5
========
        // GET: ShopCheckHistory/Delete/5
>>>>>>>> master:HomebreweryShoppingAssistaint/Controllers/ShopCheckHistoryController.cs
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

<<<<<<<< HEAD:HomebreweryShoppingAssistaint/Controllers/ShopCheckHistoriesController.cs
        // POST: ShopCheckHistories/Delete/5
        [HttpPost("Delete/{id}"), ActionName("Delete")]
========
        // POST: ShopCheckHistory/Delete/5
        [HttpPost, ActionName("Delete")]
>>>>>>>> master:HomebreweryShoppingAssistaint/Controllers/ShopCheckHistoryController.cs
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
