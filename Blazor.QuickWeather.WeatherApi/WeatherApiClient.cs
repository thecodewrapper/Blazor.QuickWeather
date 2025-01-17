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
        
        public Task<WeatherApiCurrentWeatherResponse> GetWeatherAsync(string apiKey, string location) {
            _logger.LogDebug("GetWeatherAsync: ApiKey: {ApiKey} Location: {Location}", apiKey, location);

            var url = $"{Constants.WEATHERAPI_CURRENTWEATHER_BASEURL}?key={apiKey}&q={Uri.EscapeDataString(location)}";
            _logger.LogDebug("Constructed WeatherAPI Current Weather API URL: {Url}", url);

            return GetWeatherInternal(url);
        }

        public Task<WeatherApiCurrentWeatherResponse> GetWeatherAsync(string apiKey, double lat, double lon) {
            _logger.LogDebug("GetWeatherAsync: ApiKey: {ApiKey}, Latitude: {@lat}, Longitute: {@lon}", apiKey, lat, lon);

            var url = $"{Constants.WEATHERAPI_CURRENTWEATHER_BASEURL}?key={apiKey}&q={lat},{lon}";
            _logger.LogDebug("Constructed WeatherAPI Current Weather API URL: {Url}", url);

            return GetWeatherInternal(url);
        }

        public Task<WeatherApiForecastResponse> GetForecastDailyAsync(string apiKey, string location, int days) {
            _logger.LogDebug("GetForecastDailyAsync: ApiKey: {ApiKey} Location: {Location}, Days: {Days}", apiKey, location, days);

            var url = $"{Constants.WEATHERAPI_FORECASTWEATHER_BASEURL}?key={apiKey}&q={Uri.EscapeDataString(location)}&days={days}";
            _logger.LogDebug("Constructed WeatherAPI Daily Forecast API URL: {Url}", url);

            return GetForecastInternal(url);
        }

        public Task<WeatherApiForecastResponse> GetForecastDailyAsync(string apiKey, double lat, double lon, int days) {
            _logger.LogDebug("GetForecastDailyAsync: ApiKey: {ApiKey}, Latitude: {@lat}, Longitute: {@lon}, Days: {Days}", apiKey, lat, lon, days);

            var url = $"{Constants.WEATHERAPI_FORECASTWEATHER_BASEURL}?key={apiKey}&q={lat},{lon}&days={days}";
            _logger.LogDebug("Constructed WeatherAPI Daily Forecast API URL: {Url}", url);

            return GetForecastInternal(url);
        }

        private async Task<WeatherApiCurrentWeatherResponse> GetWeatherInternal(string url) {
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

        private async Task<WeatherApiForecastResponse> GetForecastInternal(string url) {
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
