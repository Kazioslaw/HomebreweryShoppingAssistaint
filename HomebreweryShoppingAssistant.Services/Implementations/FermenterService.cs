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

			Validations<Fermenter>.IsNull(fermenter, StatusCodes.Status404NotFound);

			return fermenter!;
		}

		public async Task<Fermenter> CreateAsync(Fermenter entity)
		{

			Validations<Fermenter>.IsNull(entity, StatusCodes.Status400BadRequest);

			await this._db.Fermenters.AddAsync(entity);
			await this._db.SaveChangesAsync();

			return entity;
		}

		public async Task UpdateAsync(int id, Fermenter entity)
		{

			Validations<Fermenter>.IsNull(entity, StatusCodes.Status400BadRequest);

			var existingFermenter = await this._db.Fermenters.FindAsync(id);

			Validations<Fermenter>.IsNull(existingFermenter, StatusCodes.Status404NotFound);

			existingFermenter!.Number = entity.Number;
			existingFermenter.Name = entity.Name;
			existingFermenter.Type = entity.Type;
			existingFermenter.StartDate = entity.StartDate;

			await this._db.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var fermenterToDelete = await this._db.Fermenters.FindAsync(id);


			Validations<Fermenter>.IsNull(fermenterToDelete, StatusCodes.Status404NotFound);

			this._db.Fermenters.Remove(fermenterToDelete!);
			await this._db.SaveChangesAsync();
		}
	}
}
