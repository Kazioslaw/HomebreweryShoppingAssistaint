using HomebreweryShoppingAssistant.Models;
using HomebreweryShoppingAssistant.Services;
using HomebreweryShoppingAssistant.Services.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomebreweryShoppingAssistant.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _service;

		public CategoryController(ICategoryService service)
		{
			this._service = service;
		}

		// GET: api/Category
		[HttpGet]
		public async Task<IActionResult> GetList()
		{
			return Ok(await this._service.GetListAsync());
		}

		// GET: api/Category/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			try
			{
				var category = await this._service.GetAsync(id);

				if (category is null)
				{
					return NotFound();
				}

				return Ok(category);
			}
			catch (DataErrorException ex)
			{
				return StatusCode(ex.StatusCode);
			}
		}

		// POST: api/Category
		[HttpPost]
		public async Task<IActionResult> Create(Category category)
		{
			try
			{
				var createdCategory = await this._service.CreateAsync(category);

				if (createdCategory is null)
				{
					return BadRequest();
				}

				return CreatedAtAction(nameof(Get), new { id = createdCategory.CategoryID }, createdCategory);
			}
			catch (DataErrorException ex)
			{
				return StatusCode(ex.StatusCode);
			}
		}

		// PUT: api/Category/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, Category category)
		{
			try
			{
				await this._service.UpdateAsync(id, category);
				return NoContent();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!CategoryExists(id))
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

		// DELETE: api/Category/5
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


		private bool CategoryExists(int id)
		{
			return this._service.GetAsync(id) != null;
		}
	}
}
