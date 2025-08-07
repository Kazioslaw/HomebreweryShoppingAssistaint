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

			if (shopCheckHistory is null)
			{
				throw new DataErrorException(StatusCodes.Status404NotFound, "Shop check history with this id is not exist");
			}

			return shopCheckHistory;
		}

		public async Task<ShopCheckHistory> CreateAsync(ShopCheckHistory entity)
		{
			if (entity is null)
			{
				throw new DataErrorException(StatusCodes.Status400BadRequest, "Shop check history can't be null.");
			}

			await this._db.ShopCheckHistories.AddAsync(entity);
			await this._db.SaveChangesAsync();
			return entity;
		}

		public async Task UpdateAsync(int id, ShopCheckHistory entity)
		{
			if (entity is null)
			{
				throw new DataErrorException(StatusCodes.Status400BadRequest, "Shop check history can't be null.");
			}

			var existingShopCheckHistory = await this._db.ShopCheckHistories.FindAsync(id);

			if (existingShopCheckHistory is null)
			{
				throw new DataErrorException(StatusCodes.Status404NotFound, "Shop check history with this id is not exist");
			}

			existingShopCheckHistory.CheckDateTime = entity.CheckDateTime;
			existingShopCheckHistory.ShopID = entity.ShopID;

			await this._db.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var shopCheckHistoryToDelete = await this._db.ShopCheckHistories.FindAsync(id);

			if (shopCheckHistoryToDelete is null)
			{
				throw new DataErrorException(StatusCodes.Status404NotFound, "Shop check history with this id is not exist");
			}

			this._db.ShopCheckHistories.Remove(shopCheckHistoryToDelete);
			await this._db.SaveChangesAsync();
		}
	}
}
