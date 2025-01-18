using Blazor.QuickWeather;
using Blazor.QuickWeather.Models;
using Blazor.QuickWeather.OpenWeatherMap;
using Blazor.QuickWeather.OpenWeatherMap.CurrentWeatherAPI;
using Blazor.QuickWeather.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

public class OpenWeatherMapWeatherService : IWeatherService
{
    private readonly ILogger<OpenWeatherMapWeatherService> _logger;
    private readonly OpenWeatherClient _client;
    private readonly IOptions<OpenWeatherMapOptions> _options;

    public WeatherDataSource Resource => WeatherDataSource.OpenWeatherMap;

    public OpenWeatherMapWeatherService(ILogger<OpenWeatherMapWeatherService> logger, OpenWeatherClient client, IOptions<OpenWeatherMapOptions> options) {
        _logger = logger;
        _client = client ?? throw new ArgumentNullException(nameof(client));
        _options = options ?? throw new ArgumentNullException(nameof(options));
    }

    public async Task<CurrentWeatherData> GetCurrentWeatherAsync(WeatherRequest request) {
        try {
            if (!IsRequestValid(request))
                return null;

            var apiKey = _options.Value.CurrentWeatherApiKey;

            var response = await _client.GetWeatherAsync(apiKey, request.Latitude, request.Longitude);

            return new CurrentWeatherData
            {
                Location = response.Name,
                Temperature = (float)response.Main.Temp,
                Description = response.Weather.FirstOrDefault()?.Description ?? "No description",
                Humidity = response.Main.Humidity,
                WindSpeed = (float)response.Wind.Speed,
                Precipitation = (float?)response.Rain?.OneHour ?? 0.0f,
                FeelsLike = (float)response.Main.FeelsLike,
                Icon = response.Weather.FirstOrDefault()?.Icon ?? string.Empty,
                Code = response.Weather.FirstOrDefault()?.Id ?? 0,
                IsDay = IsDayTime(response)
            };
        }
        catch (Exception ex) {
            _logger.LogError("Exception caught: {@ex}", ex);
            return null;
        }
    }

    public async Task<ForecastWeatherData> GetForecastWeatherAsync(WeatherRequest request) {
        try {
            if (!IsRequestValid(request))
                return null;

            var apiKey = _options.Value.OneCallApiKey;

            var response = await _client.GetOneCallAsync(apiKey, request.Latitude, request.Longitude);

            return new ForecastWeatherData
            {
                Location = $"Lat: {response.Latitude}, Lon: {response.Longitude}",
                Forecast = response.Daily.Select(day => new ForecastDay
                {
                    Date = DateTimeOffset.FromUnixTimeSeconds(day.DateTime).DateTime,
                    MaxTemperature = (float)day.Temp.Max,
                    MinTemperature = (float)day.Temp.Min,
                    Description = day.Weather.FirstOrDefault()?.Description ?? "No description",
                    Icon = day.Weather.FirstOrDefault()?.Icon ?? string.Empty,
                    Code = day.Weather.FirstOrDefault()?.Id ?? 0,
                    PrecipitationProbability = (int)day.PrecipitationProbability,
                    WindSpeed = (int)(day.WindSpeed * 1.609), //to kph
                    IsDay = true
                }).ToList()
            };
        }
        catch (Exception ex) {
            _logger.LogError("Exception caught: {@ex}", ex);
            return null;
        }
    }

    private static bool IsDayTime(OpenWeatherCurrentWeatherResponse weatherResponse) {
        long sunrise = weatherResponse.Sys.Sunrise;
        long sunset = weatherResponse.Sys.Sunset;
        long currentTime = weatherResponse.Dt;

        return currentTime >= sunrise && currentTime < sunset;
    }

    private bool IsRequestValid(WeatherRequest request) {
        if (request.Longitude == 0 || request.Latitude == 0) {
            _logger.LogError("Longitude/latitude is required for OpenWeatherMap.");
            return false;
        }
        return true;
    }
}
