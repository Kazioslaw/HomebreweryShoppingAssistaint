namespace HomebreweryShoppingAssistant.Services.Interfaces
{
	public interface IBaseService<T>
	{
		public Task<IEnumerable<T>> GetListAsync();
		public Task<T> GetAsync(int id);
		public Task<T> CreateAsync(T entity);
		public Task UpdateAsync(int id, T entity);
		public Task DeleteAsync(int id);
	}
}
