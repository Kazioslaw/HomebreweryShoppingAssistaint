using HomebreweryShoppingAssistaint.Data;
using HomebreweryShoppingAssistaint.Models;
using HomebreweryShoppingAssistant.Services.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HomebreweryShoppingAssistant.Services
{
	public class FermenterService : IFermenterService
	{
		private readonly HomebreweryShoppingAssistaintContext _db;
		public FermenterService(HomebreweryShoppingAssistaintContext db)
		{
			this._db = db;
		}

		public async Task<IEnumerable<Fermenter>> GetListAsync()
		{
			return await this._db.Fermenters.ToListAsync();
		}

		public async Task<Fermenter> GetAsync(int id)
		{
			var fermenter = await this._db.Fermenters.FindAsync(id);

			if (fermenter is null)
			{
				throw new DataErrorException(StatusCodes.Status404NotFound, "Fermenter with this id is not found.");
			}

			return fermenter;
		}

		public async Task<Fermenter> CreateAsync(Fermenter entity)
		{
			if (entity is null)
			{
				throw new DataErrorException(StatusCodes.Status400BadRequest, "Fermenter can't be null.");
			}

			await this._db.Fermenters.AddAsync(entity);
			await this._db.SaveChangesAsync();

			return entity;
		}

		public async Task UpdateAsync(int id, Fermenter entity)
		{
			if (entity is null)
			{
				throw new DataErrorException(StatusCodes.Status400BadRequest, "Fermenter can't be null.");
			}

			var existingFermenter = await this._db.Fermenters.FindAsync(id);

			if (existingFermenter is null)
			{
				throw new DataErrorException(StatusCodes.Status404NotFound, "Fermenter with this id is not found.");
			}

			await this._db.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var fermenterToDelete = await this._db.Fermenters.FindAsync(id);

			if (fermenterToDelete is null)
			{
				throw new DataErrorException(StatusCodes.Status404NotFound, "Fermenter with this id is not found.");
			}

			this._db.Fermenters.Remove(fermenterToDelete);
			await this._db.SaveChangesAsync();
		}
	}
}
