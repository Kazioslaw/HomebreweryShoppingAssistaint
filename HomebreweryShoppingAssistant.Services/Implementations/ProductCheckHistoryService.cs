using HomebreweryShoppingAssistaint.Data;
using HomebreweryShoppingAssistaint.Models;
using HomebreweryShoppingAssistant.Services.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HomebreweryShoppingAssistant.Services
{
	public class ProductCheckHistoryService : IProductCheckHistoryService
	{
		private readonly HomebreweryShoppingAssistaintContext _db;

		public ProductCheckHistoryService(HomebreweryShoppingAssistaintContext db)
		{
			this._db = db;
		}

		public async Task<IEnumerable<ProductCheckHistory>> GetListAsync()
		{
			return await this._db.ProductCheckHistories.ToListAsync();
		}

		public async Task<ProductCheckHistory> GetAsync(int id)
		{
			var productCheckHistory = await this._db.ProductCheckHistories.FindAsync(id);

			Validations<ProductCheckHistory>.IsNull(productCheckHistory, StatusCodes.Status404NotFound);

			return productCheckHistory!;
		}

		public async Task<ProductCheckHistory> CreateAsync(ProductCheckHistory entity)
		{
			if (entity is null)
			{
				throw new DataErrorException(StatusCodes.Status400BadRequest, "Product chech history can't be null.");
			}

			Validations<ProductCheckHistory>.IsNull(entity, StatusCodes.Status400BadRequest);

			await this._db.ProductCheckHistories.AddAsync(entity);
			await this._db.SaveChangesAsync();
			return entity;
		}

		public async Task UpdateAsync(int id, ProductCheckHistory entity)
		{
			Validations<ProductCheckHistory>.IsNull(entity, StatusCodes.Status400BadRequest);

			var existingProductCheckHistory = await this._db.ProductCheckHistories.FindAsync(id);
			Validations<ProductCheckHistory>.IsNull(existingProductCheckHistory, StatusCodes.Status404NotFound);

			existingProductCheckHistory!.ProductID = entity.ProductID;
			existingProductCheckHistory.CheckDateTime = entity.CheckDateTime;

			await this._db.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var productCheckHistoryToDelete = await this._db.ProductCheckHistories.FindAsync(id);

			Validations<ProductCheckHistory>.IsNull(productCheckHistoryToDelete, StatusCodes.Status404NotFound);

			this._db.ProductCheckHistories.Remove(productCheckHistoryToDelete!);
			await this._db.SaveChangesAsync();
		}
	}
}
