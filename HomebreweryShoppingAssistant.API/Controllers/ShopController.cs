using HomebreweryShoppingAssistant.Models;
using HomebreweryShoppingAssistant.Services;
using HomebreweryShoppingAssistant.Services.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomebreweryShoppingAssistant.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ShopController : ControllerBase
	{
		private readonly IShopService _service;

		public ShopController(IShopService service)
		{
			this._service = service;
		}

		// GET: api/Shop
		[HttpGet]
		public async Task<IActionResult> GetList()
		{
			return Ok(await this._service.GetListAsync());
		}

		// GET: api/Shop/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			try
			{
				var shop = await this._service.GetAsync(id);

				if (shop is null)
				{
					return NotFound();
				}

				return Ok(shop);
			}
			catch (DataErrorException ex)
			{
				return StatusCode(ex.StatusCode);
			}
		}

		// POST: api/Shop
		[HttpPost]
		public async Task<ActionResult<Shop>> Create(Shop shop)
		{
			try
			{
				var createdShop = await this._service.CreateAsync(shop);

				if (createdShop is null)
				{
					return BadRequest();
				}

				return CreatedAtAction(nameof(Get), new { id = createdShop.ShopID }, createdShop);
			}
			catch (DataErrorException ex)
			{

				return StatusCode(ex.StatusCode);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, Shop shop)
		{
			try
			{
				await this._service.UpdateAsync(id, shop);
				return NoContent();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ShopExists(id))
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

		private bool ShopExists(int id)
		{
			return this._service.GetAsync(id) != null;
		}
	}
}
