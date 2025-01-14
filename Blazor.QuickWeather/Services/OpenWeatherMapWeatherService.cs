using Blazor.QuickWeather.Models.OpenWeather;
using System.Text.Json;

namespace Blazor.QuickWeather.Services
{
    public class OpenWeatherMapWeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly WeatherApiResource _apiResource;

        public OpenWeatherMapWeatherService(HttpClient httpClient, WeatherApiResource apiResource) {
            _httpClient = httpClient;
            _apiResource = apiResource;
        }

        public async Task<WeatherData> GetWeatherAsync(string location) {
            var url = $"{_apiResource.ApiUrl}?q={location}&units=metric";

            if (!string.IsNullOrEmpty(_apiResource.ApiKey)) {
                url += $"&appid={_apiResource.ApiKey}";
            }

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var openWeatherResponse = JsonSerializer.Deserialize<OpenWeatherResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (openWeatherResponse == null) {
                throw new Exception("Invalid response from OpenWeatherMap.");
            }

            return new WeatherData
            {
                Location = openWeatherResponse.Name,
                Temperature = openWeatherResponse.Main.Temp,
                Description = openWeatherResponse.Weather.FirstOrDefault()?.Description ?? "No description",
                Humidity = openWeatherResponse.Main.Humidity,
                WindSpeed = openWeatherResponse.Wind.Speed,
                Precipitation = openWeatherResponse.Rain?.OneHour ?? 0
            };
        }
    }
}
