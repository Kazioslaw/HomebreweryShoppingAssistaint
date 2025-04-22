using HomebreweryShoppingAssistaintClient.ApiClient.Services;

namespace HomebreweryShoppingAssistaintClient.ApiClient.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiService<TDto, TId>(
            this IServiceCollection services,
            string baseUrl,
            string resourcePath)
        {
            services.AddHttpClient($"api-{typeof(TDto).Name}", client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });

            services.AddScoped<IApiService<TDto, TId>>(sp =>
            {
                var clientFactory = sp.GetRequiredService<IHttpClientFactory>();
                var client = clientFactory.CreateClient($"api-{typeof(TDto).Name}");
                return new ApiService<TDto, TId>(client, resourcePath);
            });

            return services;
        }
    }
}
