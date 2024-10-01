using HomebreweryShoppingAssistaint.Data;
using HomebreweryShoppingAssistaint.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HomebreweryShoppingAssistaint.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class GeneralProductController : Controller
	{
		private readonly HomebreweryShoppingAssistaintContext _context;

		public GeneralProductController(HomebreweryShoppingAssistaintContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<GeneralProduct>>> GetGeneralProducts()
		{
			var generalProducts = await _context.GeneralProduct.ToListAsync();
			return generalProducts;
		}

		[HttpGet("Details/{id}")]
		public async Task<ActionResult<GeneralProduct>> GetGeneralProduct(int id)
		{
			if (id == null || _context.GeneralProduct == null)
			{
				return NotFound();
			}

			var generalProduct = await _context.GeneralProduct.FirstOrDefaultAsync(gp => gp.GeneralProductID == id);

			if (generalProduct == null)
			{
				return NotFound();
			}

			return Ok(generalProduct);
		}

		[HttpPost]
		public async Task<ActionResult> PostGeneralProduct(GeneralProduct generalProduct)
		{
			if (generalProduct == null)
			{
				return BadRequest();
			}
			_context.GeneralProduct.Add(generalProduct);
			await _context.SaveChangesAsync();
			return CreatedAtAction("GetGeneralProduct", new { id = generalProduct.GeneralProductID }, generalProduct);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutGeneralProduct(int id, GeneralProduct generalProduct)
		{
			if (id != generalProduct.GeneralProductID)
			{
				return BadRequest();
			}

			_context.GeneralProduct.Update(generalProduct);

			try
			{
				_context.SaveChangesAsync();
			}
			catch (DBConcurrencyException)
			{
				if (!GeneralProductExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteGeneralProduct(int id)
		{
			var generalProduct = await _context.GeneralProduct.FindAsync(id);
			if (generalProduct == null)
			{
				return NotFound();
			}

			_context.GeneralProduct.Remove(generalProduct);
			await _context.SaveChangesAsync();

			return Ok();
		}

		private bool GeneralProductExists(int id)
		{
			return _context.GeneralProduct.Any(gp => gp.GeneralProductID == id);
		}
	}
}
