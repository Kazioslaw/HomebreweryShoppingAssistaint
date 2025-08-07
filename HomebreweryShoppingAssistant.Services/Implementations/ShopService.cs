using HomebreweryShoppingAssistaint.Data;
using HomebreweryShoppingAssistaint.Models;
using HomebreweryShoppingAssistant.Services.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HomebreweryShoppingAssistant.Services
{
	public class ShopService : IShopService
	{
		private readonly HomebreweryShoppingAssistaintContext _db;
		public ShopService(HomebreweryShoppingAssistaintContext db)
		{
			this._db = db;
		}

		public async Task<IEnumerable<Shop>> GetListAsync()
		{
			return await this._db.Shops.ToListAsync();
		}

		public async Task<Shop> GetAsync(int id)
		{
			var shop = await this._db.Shops.FindAsync(id);

			if (shop is null)
			{
				throw new DataErrorException(StatusCodes.Status404NotFound, "Shop with this id is not exist.");
			}

			return shop;
		}

		public async Task<Shop> CreateAsync(Shop entity)
		{
			if (entity is null)
			{
				throw new DataErrorException(StatusCodes.Status400BadRequest, "Shop can't be null.");
			}

			await this._db.Shops.AddAsync(entity);
			await this._db.SaveChangesAsync();

			return entity;
		}

		public async Task UpdateAsync(int id, Shop entity)
		{
			if (entity is null)
			{
				throw new DataErrorException(StatusCodes.Status400BadRequest, "Shop can't be null.");
			}

			var existingShop = await this._db.Shops.FindAsync(id);

			if (existingShop is null)
			{
				throw new DataErrorException(StatusCodes.Status404NotFound, "Shop with this id is not exist.");
			}

			existingShop.ShopName = entity.ShopName;
			existingShop.ShopLink = entity.ShopLink;

			await this._db.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var shopToDelete = await this._db.Shops.FindAsync(id);

			if (shopToDelete is null)
			{
				throw new DataErrorException(StatusCodes.Status404NotFound, "Shop with this id is not exist.");
			}

			this._db.Shops.Remove(shopToDelete);
			await this._db.SaveChangesAsync();
		}
	}
}
