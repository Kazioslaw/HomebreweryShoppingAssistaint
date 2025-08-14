using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using HomebreweryShoppingAssistant.Converters;

namespace HomebreweryShoppingAssistant.Client.ApiClient.Services
{
	public class ApiService<TDto, TId> : IApiService<TDto, TId>
	{
		private readonly HttpClient _httpClient;
		private readonly string _resourcePath;

		private readonly JsonSerializerOptions options = new JsonSerializerOptions
		{
			Converters = { new JsonStringEnumConverter(), new CustomDateOnlyConverter(), new CustomDateTimeConverter() },
			PropertyNameCaseInsensitive = true
		};

		public ApiService(HttpClient httpClient, string resourcePath)
		{
			_httpClient = httpClient;
			_resourcePath = resourcePath.TrimEnd('/');
		}

		public async Task<TDto?> GetByIdAsync(TId id)
		{
			var response = await _httpClient.GetAsync($"{_resourcePath}/{id}");
			response.EnsureSuccessStatusCode();
			var json = await response.Content.ReadAsStringAsync();
			return JsonSerializer.Deserialize<TDto>(json, options);
		}

		public async Task<IEnumerable<TDto>> GetAllAsync()
		{
			var response = await _httpClient.GetAsync(_resourcePath);
			response.EnsureSuccessStatusCode();
			var json = await response.Content.ReadAsStringAsync();

			return JsonSerializer.Deserialize<IEnumerable<TDto>>(json, options) ?? [];
		}

		public async Task<TDto?> CreateAsync(TDto item)
		{
			var content = new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");
			var response = await _httpClient.PostAsync(_resourcePath, content);
			response.EnsureSuccessStatusCode();
			var json = await response.Content.ReadAsStringAsync();
			return JsonSerializer.Deserialize<TDto>(json, options);
		}

		public async Task<TDto?> UpdateAsync(TId id, TDto item)
		{
			var content = new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");
			var response = await _httpClient.PutAsync($"{_resourcePath}/{id}", content);
			response.EnsureSuccessStatusCode();
			var json = await response.Content.ReadAsStringAsync();
			return JsonSerializer.Deserialize<TDto>(json, options);
		}

		public async Task DeleteAsync(TId id)
		{
			var response = await _httpClient.DeleteAsync($"{_resourcePath}/{id}");
			response.EnsureSuccessStatusCode();
		}
	}
}