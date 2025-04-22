namespace HomebreweryShoppingAssistaintClient.ApiClient.Services
{
    public interface IApiService<TDto, TId>
    {
        Task<TDto?> GetByIdAsync(TId id);
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto?> CreateAsync(TDto item);
        Task<TDto?> UpdateAsync(TId id, TDto item);
        Task DeleteAsync(TId id);
    }
}
