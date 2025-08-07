using HomebreweryShoppingAssistaint.Data;
using HomebreweryShoppingAssistaint.Models;
using HomebreweryShoppingAssistant.Services.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HomebreweryShoppingAssistant.Services
{
	public class ShopCheckHistoryService : IShopCheckHistoryService
	{
		private readonly HomebreweryShoppingAssistaintContext _db;

		public ShopCheckHistoryService(HomebreweryShoppingAssistaintContext db)
		{
			_db = db;
		}

		public async Task<IEnumerable<ShopCheckHistory>> GetListAsync()
		{
			return await this._db.ShopCheckHistories.ToListAsync();
		}

		public async Task<ShopCheckHistory> GetAsync(int id)
		{
			var shopCheckHistory = await this._db.ShopCheckHistories.FindAsync(id);

			Validations<ShopCheckHistory>.IsNull(shopCheckHistory, StatusCodes.Status404NotFound);

			return shopCheckHistory!;
		}

		public async Task<ShopCheckHistory> CreateAsync(ShopCheckHistory entity)
		{
			Validations<ShopCheckHistory>.IsNull(entity, StatusCodes.Status400BadRequest);

			await this._db.ShopCheckHistories.AddAsync(entity);
			await this._db.SaveChangesAsync();
			return entity;
		}

		public async Task UpdateAsync(int id, ShopCheckHistory entity)
		{
			Validations<ShopCheckHistory>.IsNull(entity, StatusCodes.Status400BadRequest);

			var existingShopCheckHistory = await this._db.ShopCheckHistories.FindAsync(id);

			Validations<ShopCheckHistory>.IsNull(existingShopCheckHistory, StatusCodes.Status404NotFound);

			existingShopCheckHistory!.CheckDateTime = entity.CheckDateTime;
			existingShopCheckHistory.ShopID = entity.ShopID;

			await this._db.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var shopCheckHistoryToDelete = await this._db.ShopCheckHistories.FindAsync(id);

			Validations<ShopCheckHistory>.IsNull(shopCheckHistoryToDelete, StatusCodes.Status404NotFound);

			this._db.ShopCheckHistories.Remove(shopCheckHistoryToDelete!);
			await this._db.SaveChangesAsync();
		}
	}
}
