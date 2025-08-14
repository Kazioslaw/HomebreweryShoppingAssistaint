namespace HomebreweryShoppingAssistant.Services
{
	public class GeneralProductService : IGeneralProductService
	{
		private readonly AppDbContext _db;

		public GeneralProductService(AppDbContext db)
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

			Validations<GeneralProduct>.IsNull(generalProduct, StatusCodes.Status404NotFound);

			return generalProduct!;
		}
		public async Task<GeneralProduct> CreateAsync(GeneralProduct entity)
		{
			Validations<GeneralProduct>.IsNull(entity, StatusCodes.Status400BadRequest);

			await this._db.GeneralProduct.AddAsync(entity);
			await this._db.SaveChangesAsync();

			return entity;
		}

		public async Task UpdateAsync(int id, GeneralProduct entity)
		{
			Validations<GeneralProduct>.IsNull(entity, StatusCodes.Status400BadRequest);

			var existingGeneralProduct = await this._db.GeneralProduct.FindAsync(id);

			Validations<GeneralProduct>.IsNull(existingGeneralProduct, StatusCodes.Status404NotFound);

			existingGeneralProduct!.Name = entity.Name;
			existingGeneralProduct.CategoryID = entity.CategoryID;

			await this._db.SaveChangesAsync();
		}
		public async Task DeleteAsync(int id)
		{
			var generalProductToDelete = await this._db.GeneralProduct.FindAsync(id);

			Validations<GeneralProduct>.IsNull(generalProductToDelete, StatusCodes.Status404NotFound);

			this._db.GeneralProduct.Remove(generalProductToDelete!);
			await this._db.SaveChangesAsync();
		}
	}
}
