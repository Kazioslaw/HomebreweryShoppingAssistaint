using HomebreweryShoppingAssistaint.Data;
using HomebreweryShoppingAssistaint.Models;
using HomebreweryShoppingAssistant.Services.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HomebreweryShoppingAssistant.Services
{
	public class GeneralProductService : IGeneralProductService
	{
		private HomebreweryShoppingAssistaintContext _db;

		public GeneralProductService(HomebreweryShoppingAssistaintContext db)
		{
			this._db = db;
		}

		public async Task<IEnumerable<GeneralProduct>> GetListAsync()
		{
			return await this._db.GeneralProduct.ToListAsync();
		}

		public async Task<GeneralProduct> GetAsync(int id)
		{
			var generalProduct = await this._db.GeneralProduct.FindAsync(id);

			if (generalProduct is null)
			{
				throw new DataErrorException(StatusCodes.Status404NotFound, "General product with this id is not found.");
			}

			return generalProduct;
		}
		public async Task<GeneralProduct> CreateAsync(GeneralProduct entity)
		{
			if (entity is null)
			{
				throw new DataErrorException(StatusCodes.Status400BadRequest, "General product can't be null.");
			}

			await this._db.GeneralProduct.AddAsync(entity);
			await this._db.SaveChangesAsync();

			return entity;
		}

		public async Task UpdateAsync(int id, GeneralProduct entity)
		{
			if (entity is null)
			{
				throw new DataErrorException(StatusCodes.Status400BadRequest, "General product can't be null.");
			}

			var existingGeneralProduct = await this._db.GeneralProduct.FindAsync(id);

			if (existingGeneralProduct is null)
			{
				throw new DataErrorException(StatusCodes.Status404NotFound, "General product with this id is not found.");
			}

			existingGeneralProduct.CategoryID = entity.CategoryID;

			await this._db.SaveChangesAsync();
		}
		public async Task DeleteAsync(int id)
		{
			var generalProductToDelete = await this._db.GeneralProduct.FindAsync(id);

			if (generalProductToDelete is null)
			{
				throw new DataErrorException(StatusCodes.Status404NotFound, "General product with this id is not found.");
			}

			this._db.GeneralProduct.Remove(generalProductToDelete);
			await this._db.SaveChangesAsync();
		}
	}
}
