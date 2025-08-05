using HomebreweryShoppingAssistaint.Data;
using HomebreweryShoppingAssistaint.Models;
using HomebreweryShoppingAssistant.Services.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HomebreweryShoppingAssistant.Services
{
	public class CategoryService : ICategoryService
	{

		private readonly HomebreweryShoppingAssistaintContext _db;

		public CategoryService(HomebreweryShoppingAssistaintContext db)
		{
			this._db = db;
		}

		public async Task<IEnumerable<Category>> GetListAsync()
		{
			return await _db.Categories.ToListAsync();
		}

		public async Task<Category> GetAsync(int id)
		{
			var category = await _db.Categories.FindAsync(id);

			if (category is null)
			{
				throw new DataErrorException(StatusCodes.Status404NotFound, "Category with this id is not exist.");
			}

			return category;
		}

		public async Task<Category> CreateAsync(Category entity)
		{
			if (entity is null)
			{
				throw new DataErrorException(StatusCodes.Status400BadRequest, "Category can't be null.");
			}

			_db.Categories.Add(entity);
			await _db.SaveChangesAsync();
			return entity;
		}

		public async Task UpdateAsync(int id, Category entity)
		{
			var existingCategory = await _db.Categories.FindAsync(id);

			if (existingCategory is null)
			{
				throw new DataErrorException(StatusCodes.Status404NotFound, "Category with this id is not exist.");
			}

			if (entity is null)
			{
				throw new DataErrorException(StatusCodes.Status400BadRequest, "Category can't be null");
			}

			existingCategory.CategoryName = entity.CategoryName;

			await _db.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var category = await _db.Categories.FindAsync(id);

			if (category is null)
			{
				throw new DataErrorException(StatusCodes.Status404NotFound, "Category with this id is not exist.");
			}

			_db.Categories.Remove(category);
			await _db.SaveChangesAsync();
		}
	}
}
