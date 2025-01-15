using Blazor.QuickWeather;
using Blazor.QuickWeather.Models;
using Blazor.QuickWeather.OpenWeatherMap;
using Blazor.QuickWeather.Services;
using Microsoft.Extensions.Options;

public class OpenWeatherMapWeatherService : IWeatherService
{
    private readonly OpenWeatherClient _client;
    private readonly IOptions<WeatherServiceOptions> _options;

    public WeatherResource Resource => WeatherResource.OpenWeatherMap;

    public OpenWeatherMapWeatherService(OpenWeatherClient client, IOptions<WeatherServiceOptions> options) {
        _client = client ?? throw new ArgumentNullException(nameof(client));
        _options = options ?? throw new ArgumentNullException(nameof(options));
    }

    public async Task<CurrentWeatherData> GetCurrentWeatherAsync(WeatherRequest request) {
        if (request.Latitude == 0 || request.Longitude == 0) {
            throw new ArgumentException("Latitude and Longitude are required for OpenWeatherMap.");
        }

        // Retrieve the API key from the options
        var apiKey = _options.Value.OpenWeatherMap.ApiKey;

        // Call the OpenWeatherMap client for current weather
        var response = await _client.GetWeatherAsync(apiKey, request.Latitude, request.Longitude);

        return new CurrentWeatherData
        {
            Location = response.Name,
            Temperature = (float)response.Main.Temp,
            Description = response.Weather.FirstOrDefault()?.Description ?? "No description",
            Humidity = response.Main.Humidity,
            WindSpeed = (float)response.Wind.Speed,
            Precipitation = (float?)response.Rain?.OneHour ?? 0.0f,
            Icon = response.Weather.FirstOrDefault()?.Icon ?? string.Empty
        };
    }

    public async Task<ForecastWeatherData> GetForecastWeatherAsync(WeatherRequest request) {
        if (request.Latitude == 0 || request.Longitude == 0) {
            throw new ArgumentException("Latitude and Longitude are required for OpenWeatherMap.");
        }

        // Retrieve the API key from the options
        var apiKey = _options.Value.OpenWeatherMap.ApiKey;

        // Call the OpenWeatherMap client for daily forecast
        var response = await _client.GetForecastDailyAsync(apiKey, request.Latitude, request.Longitude, 7);

        return new ForecastWeatherData
        {
            Location = response.City.Name,
            Forecast = response.List.Select(f => new ForecastDay
            {
                Date = DateTimeOffset.FromUnixTimeSeconds(f.Dt).DateTime.ToShortDateString(),
                MaxTemperature = (float)f.Temp.Max,
                MinTemperature = (float)f.Temp.Min,
                Description = f.Weather.FirstOrDefault()?.Description ?? "No description",
                Icon = f.Weather.FirstOrDefault()?.Icon ?? string.Empty
            }).ToList()
        };
    }
}
