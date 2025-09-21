using HomebreweryShoppingAssistant.Models;
using HomebreweryShoppingAssistant.Services;
using HomebreweryShoppingAssistant.Services.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomebreweryShoppingAssistant.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FermenterController : ControllerBase
	{
		private readonly IFermenterService _service;

		public FermenterController(IFermenterService service)
		{
			this._service = service;
		}

		// GET: api/Fermenter
		[HttpGet]
		public async Task<IActionResult> GetList()
		{
			return Ok(await this._service.GetListAsync());
		}

		// GET: api/Fermenter/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			try
			{
				var fermenter = await this._service.GetAsync(id);

				if (fermenter is null)
				{
					return NotFound();
				}

				return Ok(fermenter);
			}
			catch (DataErrorException ex)
			{
				return StatusCode(ex.StatusCode);
			}
		}

		// POST: api/Fermenter
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Fermenter>> Create(Fermenter fermenter)
		{
			try
			{
				var createdFermenter = await this._service.CreateAsync(fermenter);

				if (createdFermenter is null)
				{
					return BadRequest();
				}

				return CreatedAtAction(nameof(Get), new { id = createdFermenter.Id }, createdFermenter);
			}
			catch (DataErrorException ex)
			{
				return StatusCode(ex.StatusCode);
			}
		}

		// PUT: api/Fermenter/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, Fermenter fermenter)
		{
			try
			{
				await this._service.UpdateAsync(id, fermenter);
				return NoContent();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!FermenterExists(id))
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

		// DELETE: api/Fermenter/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteFermenter(int id)
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

		private bool FermenterExists(int id)
		{
			return this._service.GetAsync(id) != null;
		}
	}
}
