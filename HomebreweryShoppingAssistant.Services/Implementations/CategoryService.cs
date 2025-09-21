namespace HomebreweryShoppingAssistant.Services
{
	public class CategoryService : ICategoryService
	{

		private readonly AppDbContext _db;

		public CategoryService(AppDbContext db)
		{
			this._db = db;
		}

		public async Task<IEnumerable<Category>> GetListAsync()
		{
			return await this._db.Categories.ToListAsync();
		}

		public async Task<Category> GetAsync(int id)
		{
			var category = await this._db.Categories.FindAsync(id);

			Validations<Category>.IsNull(category, StatusCodes.Status404NotFound);

			return category!;
		}

		public async Task<Category> CreateAsync(Category entity)
		{
			Validations<Category>.IsNull(entity, StatusCodes.Status400BadRequest);

			this._db.Categories.Add(entity);
			await this._db.SaveChangesAsync();
			return entity;
		}

		public async Task UpdateAsync(int id, Category entity)
		{
			Validations<Category>.IsNull(entity, StatusCodes.Status400BadRequest);

			var existingCategory = await this._db.Categories.FindAsync(id);

			Validations<Category>.IsNull(existingCategory, StatusCodes.Status404NotFound);

			existingCategory!.CategoryName = entity.CategoryName;

			await this._db.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var categoryToDelete = await this._db.Categories.FindAsync(id);

			Validations<Category>.IsNull(categoryToDelete, StatusCodes.Status404NotFound);

			this._db.Categories.Remove(categoryToDelete!);
			await this._db.SaveChangesAsync();
		}
	}
}
