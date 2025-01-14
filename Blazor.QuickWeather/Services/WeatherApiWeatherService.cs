using Blazor.QuickWeather.Models.WeatherApi;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Blazor.QuickWeather.Services
{
    internal class WeatherApiWeatherService : IWeatherService
    {
        private readonly ILogger<WeatherApiWeatherService> _logger;
        private readonly HttpClient _httpClient;
        private readonly WeatherApiResource _apiResource;

        public WeatherApiWeatherService(ILogger<WeatherApiWeatherService> logger, HttpClient httpClient, WeatherApiResource apiResource) {
            _logger = logger;
            _httpClient = httpClient;
            _apiResource = apiResource;
        }

        public async Task<WeatherData> GetWeatherAsync(string location) {
            _logger.LogInformation("Fetching weather data for {Location} using WeatherAPI.", location);

            try {
                if (string.IsNullOrEmpty(_apiResource.ApiKey)) {
                    _logger.LogError("API key is missing for WeatherAPI.");
                    throw new Exception("API key is required for WeatherAPI.");
                }

                var url = $"{_apiResource.ApiUrl}/current.json?key={_apiResource.ApiKey}&q={location}";
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode) {
                    _logger.LogError("Failed to fetch weather data for {Location}. Status Code: {StatusCode}", location, response.StatusCode);
                    throw new Exception($"Failed to fetch weather data: {response.ReasonPhrase}");
                }

                var json = await response.Content.ReadAsStringAsync();
                var weatherApiResponse = JsonSerializer.Deserialize<WeatherApiResponse>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (weatherApiResponse == null) {
                    _logger.LogError("Invalid response from WeatherAPI for {Location}.", location);
                    throw new Exception("Invalid response from WeatherAPI.");
                }

                _logger.LogInformation("Successfully fetched weather data for {Location}.", location);

                return new WeatherData
                {
                    Location = $"{weatherApiResponse.Location.Name}, {weatherApiResponse.Location.Country}",
                    Temperature = weatherApiResponse.Current.TempC,
                    Description = weatherApiResponse.Current.Condition.Text,
                    Humidity = weatherApiResponse.Current.Humidity,
                    WindSpeed = weatherApiResponse.Current.WindKph / 3.6f, // Convert from km/h to m/s
                    Precipitation = weatherApiResponse.Current.PrecipMm
                };
            }
            catch (Exception ex) {
                _logger.LogError(ex, "An error occurred while fetching weather data for {Location}.", location);
                throw;
            }
        }
    }
}
