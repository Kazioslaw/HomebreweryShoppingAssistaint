using HomebreweryShoppingAssistant.Models;
using HomebreweryShoppingAssistant.Services;
using HomebreweryShoppingAssistant.Services.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomebreweryShoppingAssistant.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GeneralProductController : ControllerBase
	{
		private readonly IGeneralProductService _service;

		public GeneralProductController(IGeneralProductService service)
		{
			this._service = service;
		}

		// GET: api/GeneralProduct
		[HttpGet]
		public async Task<IActionResult> GetList()
		{
			return Ok(await this._service.GetListAsync());
		}

		// GET: api/GeneralProduct/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			try
			{
				var generalProduct = await this._service.GetAsync(id);

				if (generalProduct is null)
				{
					return NotFound();
				}

				return Ok(generalProduct);
			}
			catch (DataErrorException ex)
			{
				return StatusCode(ex.StatusCode);
			}
		}

		// POST: api/GeneralProduct
		[HttpPost]
		public async Task<IActionResult> Create(GeneralProduct generalProduct)
		{
			try
			{
				var createdGeneralProduct = await this._service.CreateAsync(generalProduct);

				if (createdGeneralProduct is null)
				{
					return BadRequest();
				}

				return CreatedAtAction(nameof(Get), new { id = createdGeneralProduct.GeneralProductID }, createdGeneralProduct);
			}
			catch (DataErrorException ex)
			{
				return StatusCode(ex.StatusCode);
			}
		}

		// PUT: api/GeneralProduct/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, GeneralProduct generalProduct)
		{
			try
			{
				await this._service.UpdateAsync(id, generalProduct);
				return NoContent();
			}
			catch (DbUpdateConcurrencyException)
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
			catch (DataErrorException ex)
			{
				return StatusCode(ex.StatusCode);
			}
		}

		// DELETE: api/GeneralProduct/5
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

		private bool GeneralProductExists(int id)
		{
			return this._service.GetAsync(id) != null;
		}
	}
}
