namespace HomebreweryShoppingAssistant.Services
{
	public class ProductService : IProductService
	{
		private readonly AppDbContext _db;
		public ProductService(AppDbContext db)
		{
			this._db = db;
		}

		public async Task<IEnumerable<Product>> GetListAsync()
		{
			return await this._db.Products.Select(x => new Product() { ProductName = x.ProductName }).ToListAsync();
		}
		public async Task<Product> GetAsync(int id)
		{
			var product = await this._db.Products.FindAsync(id);

			Validations<Product>.IsNull(product, StatusCodes.Status404NotFound);

			return new Product()
			{
				ProductName = product!.ProductName
			};
		}

		public async Task<Product> CreateAsync(Product entity)
		{
			Validations<Product>.IsNull(entity, StatusCodes.Status400BadRequest);

			await this._db.Products.AddAsync(entity);
			await this._db.SaveChangesAsync();
			return entity;
		}
		public async Task UpdateAsync(int id, Product entity)
		{
			Validations<Product>.IsNull(entity, StatusCodes.Status400BadRequest);

			var existingProduct = await this._db.Products.FindAsync(id);

			Validations<Product>.IsNull(existingProduct, StatusCodes.Status404NotFound);

			existingProduct!.ProductName = entity.ProductName;
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

			Validations<Product>.IsNull(productToDelete, StatusCodes.Status404NotFound);

			this._db.Products.Remove(productToDelete!);
			await this._db.SaveChangesAsync();
		}
	}
}
