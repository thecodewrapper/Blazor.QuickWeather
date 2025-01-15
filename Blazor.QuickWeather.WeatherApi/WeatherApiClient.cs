using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Blazor.QuickWeather.WeatherApi
{
    public class WeatherApiClient
    {
        private readonly ILogger<WeatherApiClient> _logger;
        private readonly HttpClient _httpClient;

        public WeatherApiClient(ILogger<WeatherApiClient> logger, HttpClient httpClient) {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<WeatherApiCurrentWeatherResponse> GetWeatherAsync(string apiKey, string location) {
            _logger.LogDebug("GetWeatherAsync: ApiKey: {ApiKey} Location: {Location}", apiKey, location);

            var url = $"{Constants.WEATHERAPI_CURRENTWEATHER_BASEURL}?key={apiKey}&q={Uri.EscapeDataString(location)}";
            _logger.LogDebug("Constructed WeatherAPI Current Weather API URL: {Url}", url);

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            _logger.LogDebug("Received JSON response from WeatherAPI: {Json}", json);

            var weatherResponse = JsonSerializer.Deserialize<WeatherApiCurrentWeatherResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (weatherResponse == null) {
                throw new Exception("Invalid response from WeatherAPI.");
            }

            return weatherResponse;
        }

        public async Task<WeatherApiForecastResponse> GetForecastDailyAsync(string apiKey, string location, int days) {
            _logger.LogDebug("GetForecastDailyAsync: ApiKey: {ApiKey} Location: {Location}, Days: {Days}", apiKey, location, days);

            var url = $"{Constants.WEATHERAPI_FORECASTWEATHER_BASEURL}?key={apiKey}&q={Uri.EscapeDataString(location)}&days={days}";
            _logger.LogDebug("Constructed WeatherAPI Daily Forecast API URL: {Url}", url);

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            _logger.LogDebug("Received JSON response from WeatherAPI Daily Forecast API: {Json}", json);

            var forecastResponse = JsonSerializer.Deserialize<WeatherApiForecastResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (forecastResponse == null) {
                throw new Exception("Invalid response from WeatherAPI Daily Forecast API.");
            }

            return forecastResponse;
        }
    }
}
