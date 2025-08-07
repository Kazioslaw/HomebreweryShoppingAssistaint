using HomebreweryShoppingAssistaint.Data;
using HomebreweryShoppingAssistaint.Models;
using HomebreweryShoppingAssistant.Services.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HomebreweryShoppingAssistant.Services
{
	public class ProductService : IProductService
	{
		private readonly HomebreweryShoppingAssistaintContext _db;
		public ProductService(HomebreweryShoppingAssistaintContext db)
		{
			this._db = db;
		}

		public async Task<IEnumerable<Product>> GetListAsync()
		{
			return await this._db.Products.ToListAsync();
		}
		public async Task<Product> GetAsync(int id)
		{
			var product = await this._db.Products.FindAsync(id);

			if (product is null)
			{
				throw new DataErrorException(StatusCodes.Status404NotFound, "Product with this id is not exist.");
			}

			return product;
		}

		public async Task<Product> CreateAsync(Product entity)
		{
			if (entity is null)
			{
				throw new DataErrorException(StatusCodes.Status400BadRequest, "Product can't be null.");
			}

			await this._db.Products.AddAsync(entity);
			await this._db.SaveChangesAsync();
			return entity;
		}
		public async Task UpdateAsync(int id, Product entity)
		{
			if (entity is null)
			{
				throw new DataErrorException(StatusCodes.Status400BadRequest, "Product can't be null.");
			}

			var existingProduct = await this._db.Products.FindAsync(id);

			if (existingProduct is null)
			{
				throw new DataErrorException(StatusCodes.Status404NotFound, "Product with this id is not found.");
			}

			existingProduct.ProductName = entity.ProductName;
			existingProduct.ProductHarvestYear = entity.ProductHarvestYear;
			existingProduct.ProductPrice = entity.ProductPrice;
			existingProduct.Product30DaysPrice = entity.Product30DaysPrice;
			existingProduct.ProductLink = entity.ProductLink;
			existingProduct.IsAvailable = entity.IsAvailable;
			existingProduct.GeneralProductID = entity.GeneralProductID;
			existingProduct.ShopID = entity.ShopID;

			await this._db.SaveChangesAsync();
		}
		public async Task DeleteAsync(int id)
		{
			var productToDelete = await this._db.Products.FindAsync(id);

			if (productToDelete is null)
			{
				throw new DataErrorException(StatusCodes.Status404NotFound, "Product with this id is not found.");
			}

			this._db.Products.Remove(productToDelete);
			await this._db.SaveChangesAsync();
		}
	}
}
