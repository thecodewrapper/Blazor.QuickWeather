using System.Text.Json;
using Blazor.QuickWeather.Models.OpenMeteo;
using Microsoft.Extensions.Logging;

namespace Blazor.QuickWeather.Services
{
    public class OpenMeteoWeatherService : IWeatherService
    {
        private readonly ILogger<OpenMeteoWeatherService> _logger;
        private readonly HttpClient _httpClient;
        private readonly WeatherApiResource _apiResource;

        public OpenMeteoWeatherService(ILogger<OpenMeteoWeatherService> logger, HttpClient httpClient, WeatherApiResource apiResource) {
            _logger = logger;
            _httpClient = httpClient;
            _apiResource = apiResource;
        }

        public async Task<WeatherData> GetWeatherAsync(string location) {
            _logger.LogInformation("Fetching weather data for {Location} using Open-Meteo.", location);

            try {
                // Convert location to latitude and longitude (for simplicity, hardcoded here)
                // In production, use a geocoding API to resolve the location dynamically.
                var (latitude, longitude) = GetCoordinatesForLocation(location);

                var url = $"{_apiResource.ApiUrl}?latitude={latitude}&longitude={longitude}&hourly=temperature_2m";
                _logger.LogDebug("Calling Open-Meteo API: {Url}", url);

                var response = await _httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode) {
                    _logger.LogError("Failed to fetch weather data for {Location}. Status Code: {StatusCode}, Reason: {ReasonPhrase}",
                        location, response.StatusCode, response.ReasonPhrase);
                    throw new Exception($"Failed to fetch weather data: {response.ReasonPhrase}");
                }

                var json = await response.Content.ReadAsStringAsync();
                _logger.LogDebug("Received JSON response from Open-Meteo: {Json}", json);

                var openMeteoResponse = JsonSerializer.Deserialize<OpenMeteoResponse>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (openMeteoResponse == null) {
                    throw new Exception("Invalid response from Open-Meteo.");
                }

                // Simplified example: Use the first temperature value
                return new WeatherData
                {
                    Location = location,
                    Temperature = (float)openMeteoResponse.Hourly.Temperature2m.FirstOrDefault(),
                    Description = "Hourly forecast from Open-Meteo"
                };
            }
            catch (Exception ex) {
                _logger.LogError(ex, "An error occurred while fetching weather data for {Location} using Open-Meteo.", location);
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