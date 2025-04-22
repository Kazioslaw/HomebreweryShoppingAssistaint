using HomebreweryShoppingAssistaint.Data;
using HomebreweryShoppingAssistaint.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HomebreweryShoppingAssistaint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {

        private readonly HomebreweryShoppingAssistaintContext _context;

        public ProductsController(HomebreweryShoppingAssistaintContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            var product = _context.Products.Include(p => p.GeneralProduct).Include(p => p.Shop);
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products
                .Include(p => p.GeneralProduct)
                .Include(p => p.Shop)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            ViewData["GeneralProductID"] = new SelectList(_context.GeneralProduct, "GeneralProductID", "GeneralProductID");
            ViewData["ShopID"] = new SelectList(_context.Set<Shop>(), "ShopID", "ShopID");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,ProductName,ProductDescription,ProductPrice,Product30DaysPrice,GeneralProductID,ShopID")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GeneralProductID"] = new SelectList(_context.GeneralProduct, "GeneralProductID", "GeneralProductID", product.GeneralProductID);
            ViewData["ShopID"] = new SelectList(_context.Set<Shop>(), "ShopID", "ShopID", product.ShopID);
            return View(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductID)
            {
                return BadRequest();
            }

            if (product == null)
            {
                return NotFound();
            }
            ViewData["GeneralProductID"] = new SelectList(_context.GeneralProduct, "GeneralProductID", "GeneralProductID", product.GeneralProductID);
            ViewData["ShopID"] = new SelectList(_context.Set<Shop>(), "ShopID", "ShopID", product.ShopID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductName,ProductDescription,ProductPrice,Product30DaysPrice,GeneralProductID,ShopID")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DBConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            ViewData["GeneralProductID"] = new SelectList(_context.GeneralProduct, "GeneralProductID", "GeneralProductID", product.GeneralProductID);
            ViewData["ShopID"] = new SelectList(_context.Set<Shop>(), "ShopID", "ShopID", product.ShopID);
            return View(product);
        }

        [HttpGet("Delete/{id}")]
        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.GeneralProduct)
                .Include(p => p.Shop)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST: Products/Delete/5
        [HttpPost("Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'HomebreweryShoppingAssistaintContext.Product'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.ProductID == id)).GetValueOrDefault();
        }
    }
}
