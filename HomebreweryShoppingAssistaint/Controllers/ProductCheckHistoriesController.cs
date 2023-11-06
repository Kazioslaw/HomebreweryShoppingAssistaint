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
<<<<<<<< HEAD:HomebreweryShoppingAssistaint/Controllers/ProductCheckHistoriesController.cs
    [ApiController]
    [Route("[controller]")]
    public class ProductCheckHistoriesController : Controller
    {
        private readonly HomebreweryShoppingAssistaintContext _context;

        public ProductCheckHistoriesController(HomebreweryShoppingAssistaintContext context)
========
    public class ProductCheckHistoryController : Controller
    {
        private readonly HomebreweryShoppingAssistaintContext _context;

        public ProductCheckHistoryController(HomebreweryShoppingAssistaintContext context)
>>>>>>>> master:HomebreweryShoppingAssistaint/Controllers/ProductCheckHistoryController.cs
        {
            _context = context;
        }

<<<<<<<< HEAD:HomebreweryShoppingAssistaint/Controllers/ProductCheckHistoriesController.cs
        [HttpGet]
        // GET: ProductLastChecks
========
        // GET: ProductCheckHistory
>>>>>>>> master:HomebreweryShoppingAssistaint/Controllers/ProductCheckHistoryController.cs
        public async Task<IActionResult> Index()
        {
              return _context.ProductCheckHistory != null ? 
                          View(await _context.ProductCheckHistory.ToListAsync()) :
<<<<<<<< HEAD:HomebreweryShoppingAssistaint/Controllers/ProductCheckHistoriesController.cs
                          Problem("Entity set 'HomebreweryShoppingAssistaintContext.ProductLastCheck'  is null.");
        }

        [HttpGet("Details/{id}")]
        // GET: ProductLastChecks/Details/5
========
                          Problem("Entity set 'HomebreweryShoppingAssistaintContext.ProductCheckHistory'  is null.");
        }

        // GET: ProductCheckHistory/Details/5
>>>>>>>> master:HomebreweryShoppingAssistaint/Controllers/ProductCheckHistoryController.cs
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

<<<<<<<< HEAD:HomebreweryShoppingAssistaint/Controllers/ProductCheckHistoriesController.cs
        [HttpGet("Create")]
        // GET: ProductCheckHistories/Create
========
        // GET: ProductCheckHistory/Create
>>>>>>>> master:HomebreweryShoppingAssistaint/Controllers/ProductCheckHistoryController.cs
        public IActionResult Create()
        {
            return View();
        }

<<<<<<<< HEAD:HomebreweryShoppingAssistaint/Controllers/ProductCheckHistoriesController.cs
        // POST: ProductCheckHistories/Create
========
        // POST: ProductCheckHistory/Create
>>>>>>>> master:HomebreweryShoppingAssistaint/Controllers/ProductCheckHistoryController.cs
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
<<<<<<<< HEAD:HomebreweryShoppingAssistaint/Controllers/ProductCheckHistoriesController.cs
        public async Task<IActionResult> Create([Bind("ProductCheckHistoryID,ProductID,ShopID,LastCheckDateTime")] ProductCheckHistory productLastCheck)
========
        public async Task<IActionResult> Create([Bind("ProductCheckHistoryID,ProductID,ShopID,CheckDateTime")] ProductCheckHistory productLastCheck)
>>>>>>>> master:HomebreweryShoppingAssistaint/Controllers/ProductCheckHistoryController.cs
        {
            if (ModelState.IsValid)
            {
                _context.Add(productLastCheck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productLastCheck);
        }

<<<<<<<< HEAD:HomebreweryShoppingAssistaint/Controllers/ProductCheckHistoriesController.cs
        [HttpGet("Edit/{id}")]
        // GET: ProductCheckHistories/Edit/5
========
        // GET: ProductCheckHistory/Edit/5
>>>>>>>> master:HomebreweryShoppingAssistaint/Controllers/ProductCheckHistoryController.cs
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

<<<<<<<< HEAD:HomebreweryShoppingAssistaint/Controllers/ProductCheckHistoriesController.cs
        // POST: ProductCheckHistories/Edit/5
========
        // POST: ProductCheckHistory/Edit/5
>>>>>>>> master:HomebreweryShoppingAssistaint/Controllers/ProductCheckHistoryController.cs
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
<<<<<<<< HEAD:HomebreweryShoppingAssistaint/Controllers/ProductCheckHistoriesController.cs
        public async Task<IActionResult> Edit(int id, [Bind("ProductCheckHistoryID,ProductID,ShopID,LastCheckDateTime")] ProductCheckHistory productLastCheck)
========
        public async Task<IActionResult> Edit(int id, [Bind("ProductCheckHistoryID,ProductID,ShopID,CheckDateTime")] ProductCheckHistory productLastCheck)
>>>>>>>> master:HomebreweryShoppingAssistaint/Controllers/ProductCheckHistoryController.cs
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

<<<<<<<< HEAD:HomebreweryShoppingAssistaint/Controllers/ProductCheckHistoriesController.cs
        [HttpGet("Delete/{id}")]
        // GET: ProductCheckHistories/Delete/5
========
        // GET: ProductCheckHistory/Delete/5
>>>>>>>> master:HomebreweryShoppingAssistaint/Controllers/ProductCheckHistoryController.cs
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

<<<<<<<< HEAD:HomebreweryShoppingAssistaint/Controllers/ProductCheckHistoriesController.cs
        // POST: ProductCheckHistories/Delete/5
        [HttpPost("Delete/{id}"), ActionName("Delete")]
========
        // POST: ProductCheckHistory/Delete/5
        [HttpPost, ActionName("Delete")]
>>>>>>>> master:HomebreweryShoppingAssistaint/Controllers/ProductCheckHistoryController.cs
        [ValidateAntiForgeryToken]
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
