using System.Data;
using HomebreweryShoppingAssistant.Models;
using HomebreweryShoppingAssistant.Services;
using HomebreweryShoppingAssistant.Services.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace HomebreweryShoppingAssistant.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController : ControllerBase
	{

		private readonly IProductService _service;

		public ProductController(IProductService service)
		{
			this._service = service;
		}

		// GET: api/Product
		[HttpGet]
		public async Task<IActionResult> GetList()
		{
			return Ok(await this._service.GetListAsync());
		}

		// GET: api/Product/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			try
			{
				var product = await this._service.GetAsync(id);

				if (product is null)
				{
					return NotFound();
				}

				return Ok(product);
			}
			catch (DataErrorException ex)
			{
				return StatusCode(ex.StatusCode);
			}
		}

		// POST: api/Product
		[HttpPost]
		public async Task<IActionResult> Create(Product product)
		{
			try
			{
				var createdProduct = await this._service.CreateAsync(product);

				if (createdProduct is null)
				{
					return BadRequest();
				}

				return CreatedAtAction(nameof(Get), new { id = createdProduct.ProductID }, createdProduct);
			}
			catch (DataErrorException ex)
			{
				return StatusCode(ex.StatusCode);
			}
		}

		// PUT: api/Product/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, Product product)
		{
			try
			{
				await this._service.UpdateAsync(id, product);
				return NoContent();
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
			catch (DataErrorException ex)
			{
				return StatusCode(ex.StatusCode);
			}
		}

		// DELETE: api/Product/5
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
				return this.StatusCode(ex.StatusCode);
			}
		}

		private bool ProductExists(int id)
		{
			return this._service.GetAsync(id) != null;
		}
	}
}
