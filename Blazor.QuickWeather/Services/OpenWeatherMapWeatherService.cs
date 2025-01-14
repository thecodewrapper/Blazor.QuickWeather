using Blazor.QuickWeather.Models.OpenWeather.CurrentWeatherAPI;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Blazor.QuickWeather.Services
{
    public class OpenWeatherMapWeatherService : IWeatherService
    {
        private readonly ILogger<OpenWeatherMapWeatherService> _logger;
        private readonly HttpClient _httpClient;
        private readonly WeatherApiResource _apiResource;

        public OpenWeatherMapWeatherService(ILogger<OpenWeatherMapWeatherService> logger, HttpClient httpClient, WeatherApiResource apiResource) {
            _logger = logger;
            _httpClient = httpClient;
            _apiResource = apiResource;

            // Validate the API key
            if (string.IsNullOrEmpty(_apiResource.ApiKey)) {
                var message = "API key is required for OpenWeatherMap. Please provide a valid API key.";
                _logger.LogError(message);
                throw new ArgumentException(message);
            }
        }

        public async Task<WeatherData> GetWeatherAsync(string location) {
            _logger.LogInformation("Fetching weather data for {Location} using OpenWeatherMap.", location);

            try {
                // Build URL (Replace location handling with actual geocoding logic if necessary)
                var (latitude, longitude) = GetCoordinatesForLocation(location);
                var url = $"{_apiResource.ApiUrl}?lat={latitude}&lon={longitude}&appid={_apiResource.ApiKey}&units=metric";

                _logger.LogDebug("Constructed OpenWeatherMap API URL: {Url}", url);

                var response = await _httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode) {
                    _logger.LogError("Failed to fetch weather data for {Location}. Status Code: {StatusCode}, Reason: {ReasonPhrase}",
                        location, response.StatusCode, response.ReasonPhrase);
                    response.EnsureSuccessStatusCode(); // Throws exception to halt execution
                }

                var json = await response.Content.ReadAsStringAsync();
                _logger.LogDebug("Received JSON response from OpenWeatherMap: {Json}", json);
                var weatherResponse = JsonSerializer.Deserialize<CurrentWeatherResponse>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (weatherResponse == null) {
                    throw new Exception("Invalid response from OpenWeatherMap API.");
                }

                _logger.LogInformation("Successfully fetched weather data for {Location}.", location);

                return new WeatherData
                {
                    Location = weatherResponse.Name,
                    Temperature = (float)weatherResponse.Main.Temp,
                    Description = weatherResponse.Weather.FirstOrDefault()?.Description ?? "No description",
                    Humidity = weatherResponse.Main.Humidity,
                    WindSpeed = (float)weatherResponse.Wind.Speed,
                    Precipitation = (float?)weatherResponse.Rain?.OneHour ?? 0.0f,
                    Icon = weatherResponse.Weather.FirstOrDefault()?.Icon
                };
            }
            catch (Exception) {

                throw;
            }
        }

        private (double Lat, double Lon) GetCoordinatesForLocation(string location) {
            return location switch
            {
                "London" => (51.5074, -0.1278),
                "New York" => (40.7128, -74.0060),
                _ => throw new Exception("Unsupported location. Use geocoding logic.")
            };
        }
    }
}
