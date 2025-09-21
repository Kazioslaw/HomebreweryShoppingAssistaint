using System.Data;
using HomebreweryShoppingAssistant.Models;
using HomebreweryShoppingAssistant.Services;
using HomebreweryShoppingAssistant.Services.Helpers;
using Microsoft.AspNetCore.Mvc;
namespace HomebreweryShoppingAssistant.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductCheckHistoryController : ControllerBase
	{
		private readonly IProductCheckHistoryService _service;

		public ProductCheckHistoryController(IProductCheckHistoryService service)
		{
			this._service = service;
		}

		// GET: api/ProductCheckHistory
		[HttpGet]
		public async Task<IActionResult> GetList()
		{
			return Ok(await this._service.GetListAsync());
		}

		// GET: api/ProductCheckHistory/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			try
			{
				var productCheckHistory = await this._service.GetAsync(id);


				if (productCheckHistory is null)
				{
					return NotFound();
				}

				return Ok(productCheckHistory);
			}
			catch (DataErrorException ex)
			{
				return StatusCode(ex.StatusCode);
			}
		}

		// POST: api/ProductCheckHistory
		[HttpPost]
		public async Task<IActionResult> Create(ProductCheckHistory productCheckHistory)
		{
			try
			{
				var createdProductCheckHistory = await this._service.CreateAsync(productCheckHistory);

				if (createdProductCheckHistory is null)
				{
					return BadRequest();
				}

				return CreatedAtAction(nameof(Get), new { id = createdProductCheckHistory.ProductCheckHistoryID }, createdProductCheckHistory);
			}
			catch (DataErrorException ex)
			{
				return StatusCode(ex.StatusCode);
			}
		}

		// PUT: api/ProductCheckHistory/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, ProductCheckHistory productCheckHistory)
		{
			try
			{
				await this._service.UpdateAsync(id, productCheckHistory);
				return NoContent();
			}
			catch (DBConcurrencyException)
			{
				if (!ProductCheckHistoryExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
			catch (DataErrorException ex)
			{
				return StatusCode(ex.StatusCode);
			}
		}

		// DELETE: api/ProductCheckHistory/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				await this._service.DeleteAsync(id);
				return NoContent();

			}
			catch (DataErrorException ex)
			{
				return StatusCode(ex.StatusCode);
			}

		}

		private bool ProductCheckHistoryExists(int id)
		{
			return this._service.GetAsync(id) != null;
		}
	}
}
