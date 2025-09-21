using System.Data;
using HomebreweryShoppingAssistant.Models;
using HomebreweryShoppingAssistant.Services;
using HomebreweryShoppingAssistant.Services.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace HomebreweryShoppingAssistant.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ShopCheckHistoryController : ControllerBase
	{
		private readonly IShopCheckHistoryService _service;

		public ShopCheckHistoryController(IShopCheckHistoryService service)
		{
			this._service = service;
		}

		// GET: api/ShopCheckHistory
		[HttpGet]
		public async Task<IActionResult> GetList()
		{
			return Ok(await this._service.GetListAsync());
		}

		// GET: api/ShopCheckHistory/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			try
			{
				var shopCheckHistory = await this._service.GetAsync(id);

				if (shopCheckHistory is null)
				{
					return NotFound();
				}

				return Ok(shopCheckHistory);
			}
			catch (DataErrorException ex)
			{
				return StatusCode(ex.StatusCode);
			}
		}

		// POST: api/ShopCheckHistory
		[HttpPost]
		public async Task<ActionResult<ShopCheckHistory>> Create(ShopCheckHistory shopCheckHistory)
		{
			try
			{
				var createdShopCheckHistory = await this._service.CreateAsync(shopCheckHistory);

				if (createdShopCheckHistory is null)
				{
					return BadRequest();
				}

				return CreatedAtAction(nameof(Get), new { id = createdShopCheckHistory.ShopCheckHistoryID }, createdShopCheckHistory);

			}
			catch (DataErrorException ex)
			{
				return StatusCode(ex.StatusCode);
			}
		}

		// PUT: api/ShopCheckHistory/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, ShopCheckHistory shopCheckHistory)
		{
			try
			{
				await _service.UpdateAsync(id, shopCheckHistory);
				return NoContent();
			}
			catch (DBConcurrencyException)
			{
				if (!ShopCheckHistoryExists(id))
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

		// DELETE: api/ShopCheckHistory/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				await _service.DeleteAsync(id);
				return NoContent();
			}
			catch (DataErrorException ex)
			{
				return StatusCode(ex.StatusCode);
			}
		}
		private bool ShopCheckHistoryExists(int id)
		{
			return this._service.GetAsync(id) != null;
		}
	}
}
