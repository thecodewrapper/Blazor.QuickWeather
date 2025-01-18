using Blazor.QuickWeather.OpenWeatherMap.CurrentWeatherAPI;
using Blazor.QuickWeather.OpenWeatherMap.DailyForecastAPI;
using Blazor.QuickWeather.OpenWeatherMap.OneCallAPI;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Blazor.QuickWeather.OpenWeatherMap
{
    public class OpenWeatherClient
    {
        private readonly ILogger<OpenWeatherClient> _logger;
        private readonly HttpClient _httpClient;

        public OpenWeatherClient(ILogger<OpenWeatherClient> logger, HttpClient httpClient) {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<OpenWeatherCurrentWeatherResponse> GetWeatherAsync(string apiKey, double lat, double lon) {
            _logger.LogDebug("GetWeatherAsync: ApiKey: {@ApiKey} Lat: {@Lat}, Lon: {@Lon}", apiKey, lat, lon);

            ValidateApiKey(apiKey);

            var url = $"{Constants.OPENWEATHER_CURRENTWEATHER_BASEURL}?lat={lat}&lon={lon}&appid={apiKey}&units=metric";
            _logger.LogDebug("Constructed OpenWeatherMap API URL: {Url}", url);

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode) {
                _logger.LogError("Failed to fetch weather data. Status Code: {StatusCode}, Reason: {ReasonPhrase}",
                    response.StatusCode, response.ReasonPhrase);
                response.EnsureSuccessStatusCode(); // Throws exception to halt execution
            }

            var json = await response.Content.ReadAsStringAsync();
            _logger.LogDebug("Received JSON response from OpenWeatherMap: {Json}", json);
            var weatherResponse = JsonSerializer.Deserialize<OpenWeatherCurrentWeatherResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (weatherResponse == null) {
                throw new Exception("Invalid response from OpenWeatherMap API.");
            }

            return weatherResponse;
        }

        public async Task<OpenWeatherDailyForecastResponse> GetForecastDailyAsync(string apiKey, double lat, double lon, int cnt) {
            _logger.LogDebug("GetForecastAsync: ApiKey: {@ApiKey}, Lat: {@Lat}, Lon: {@Lon}, Cnt: {@cnt}", apiKey, lat, lon, cnt);

            ValidateApiKey(apiKey);

            var forecastWeatherUrl = $"{Constants.OPENWEATHER_FORECASTWEATHER_DAILY_BASEURL}?lat={lat}&lon={lon}&cnt={cnt}&appid={apiKey}&units=metric";
            _logger.LogDebug("Calling OpenWeatherMap Daily Forecast API: {Url}", forecastWeatherUrl);

            var response = await _httpClient.GetAsync(forecastWeatherUrl);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var forecastResponse = JsonSerializer.Deserialize<OpenWeatherDailyForecastResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (forecastResponse == null) {
                throw new Exception("Invalid response from OpenWeatherMap Daily Forecast API.");
            }

            return forecastResponse;
        }

        public async Task<OneCallApiResponse> GetOneCallAsync(string apiKey, double lat, double lon) {
            _logger.LogDebug("GetOneCallAsync: ApiKey: {@ApiKey}, Lat: {@Lat}, Lon: {@Lon}", apiKey, lat, lon);

            ValidateApiKey(apiKey);

            var forecastWeatherUrl = $"{Constants.OPENWEATHER_ONECALL_BASEURL}?lat={lat}&lon={lon}&appid={apiKey}&units=metric";
            _logger.LogDebug("Calling OpenWeatherMap Daily OneCall API: {Url}", forecastWeatherUrl);

            var response = await _httpClient.GetAsync(forecastWeatherUrl);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var forecastResponse = JsonSerializer.Deserialize<OneCallApiResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (forecastResponse == null) {
                throw new Exception("Invalid response from OpenWeatherMap OneCall API.");
            }

            return forecastResponse;
        }

        private void ValidateApiKey(string apiKey) {
            if (string.IsNullOrEmpty(apiKey)) {
                var message = "API key is required for OpenWeatherMap. Please provide a valid API key.";
                _logger.LogError(message);
                throw new ArgumentException(message);
            }
        }
    }
}
