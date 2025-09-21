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

			Validations<Shop>.IsNull(shop, StatusCodes.Status404NotFound);

			return shop!;
		}

		public async Task<Shop> CreateAsync(Shop entity)
		{
			Validations<Shop>.IsNull(entity, StatusCodes.Status400BadRequest);

			await this._db.Shops.AddAsync(entity);
			await this._db.SaveChangesAsync();

			return entity;
		}

		public async Task UpdateAsync(int id, Shop entity)
		{
			Validations<Shop>.IsNull(entity, StatusCodes.Status400BadRequest);

			var existingShop = await this._db.Shops.FindAsync(id);

			Validations<Shop>.IsNull(existingShop, StatusCodes.Status404NotFound);

			existingShop!.ShopName = entity.ShopName;
			existingShop.ShopLink = entity.ShopLink;

			await this._db.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var shopToDelete = await this._db.Shops.FindAsync(id);

			Validations<Shop>.IsNull(shopToDelete, StatusCodes.Status404NotFound);

			this._db.Shops.Remove(shopToDelete!);
			await this._db.SaveChangesAsync();
		}
	}
}
