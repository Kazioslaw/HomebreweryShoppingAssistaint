namespace HomebreweryShoppingAssistant.Client.ApiClient
{
	public interface IApiClient
	{
		Task<TResponse> GetAsync<TResponse>(string uri);
		Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest data);
		Task<TResponse> PutAsync<TRequest, TResponse>(string uri, TRequest data);
		Task DeleteAsync(string uri);
	}
}
