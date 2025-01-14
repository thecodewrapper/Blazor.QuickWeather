using Blazor.QuickWeather.Services;
using Microsoft.Extensions.Options;

namespace Blazor.QuickWeather.Factories
{
    public class WeatherServiceFactory : IWeatherServiceFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly WeatherServiceOptions _options;

        public WeatherServiceFactory(IHttpClientFactory httpClientFactory, IOptions<WeatherServiceOptions> options) {
            _httpClientFactory = httpClientFactory;
            _options = options.Value;
        }

        public IWeatherService Create(string apiName) {
            var apiResource = _options.ApiResources.FirstOrDefault(r => r.Name.Equals(apiName, StringComparison.OrdinalIgnoreCase));

            if (apiResource == null) {
                throw new Exception($"No weather API resource found with name '{apiName}'.");
            }

            var httpClient = _httpClientFactory.CreateClient();

            return apiResource.Name switch
            {
                "OpenWeatherMap" => new OpenWeatherMapWeatherService(httpClient, apiResource),
                //"WeatherAPI" => new WeatherApiWeatherService(httpClient, apiResource),
                _ => throw new Exception($"No implementation available for weather API '{apiResource.Name}'.")
            };
        }
    }
}
