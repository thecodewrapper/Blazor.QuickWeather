using Blazor.QuickWeather.Models;
using Blazor.QuickWeather.WeatherApi;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace Blazor.QuickWeather.Services
{
    internal class WeatherApiWeatherService : IWeatherService
    {
        private readonly ILogger<WeatherApiWeatherService> _logger;
        private readonly WeatherApiClient _client;
        private readonly IOptions<WeatherServiceOptions> _options;

        public WeatherDataSource Resource => WeatherDataSource.WeatherApi;

        public WeatherApiWeatherService(ILogger<WeatherApiWeatherService> logger, WeatherApiClient client, IOptions<WeatherServiceOptions> options) {
            _logger = logger;
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public async Task<CurrentWeatherData> GetCurrentWeatherAsync(WeatherRequest request) {
            try {
                if (string.IsNullOrEmpty(request.CityName)) {
                    _logger.LogError("City name is required for WeatherApi.");
                    return null;
                }

                var apiKey = _options.Value.WeatherApi.ApiKey;

                var weatherApiResponse = await _client.GetWeatherAsync(apiKey, request.CityName);

                return new CurrentWeatherData
                {
                    Location = $"{weatherApiResponse.Location.Name}, {weatherApiResponse.Location.Country}",
                    Temperature = (float)weatherApiResponse.Current.TempC,
                    Description = weatherApiResponse.Current.Condition.Text,
                    Humidity = weatherApiResponse.Current.Humidity,
                    WindSpeed = (float)(weatherApiResponse.Current.WindKph), // Convert kph to m/s
                    Precipitation = (float)weatherApiResponse.Current.PrecipMm,
                    Icon = weatherApiResponse.Current.Condition.Icon,
                    FeelsLike = (float)weatherApiResponse.Current.FeelsLikeC,
                    Code = weatherApiResponse.Current.Condition.Code,
                    IsDay = weatherApiResponse.Current.IsDay == 1
                };
            }
            catch (Exception ex) {
                _logger.LogError("Exception caught: {@ex}", ex);
                return null;
            }
        }

        public async Task<ForecastWeatherData> GetForecastWeatherAsync(WeatherRequest request) {
            try {
                if (string.IsNullOrEmpty(request.CityName)) {
                    _logger.LogError("City name is required for WeatherApi.");
                }

                var apiKey = _options.Value.WeatherApi.ApiKey;

                var forecastApiResponse = await _client.GetForecastDailyAsync(apiKey, request.CityName, 7);

                return new ForecastWeatherData
                {
                    Location = $"{forecastApiResponse.Location.Name}, {forecastApiResponse.Location.Country}",
                    Forecast = forecastApiResponse.Forecast.ForecastDay.Select(day => new Blazor.QuickWeather.Models.ForecastDay
                    {
                        Date = DateTime.Parse(day.Date),
                        MaxTemperature = (float)day.Day.MaxtempC,
                        MinTemperature = (float)day.Day.MintempC,
                        Description = day.Day.Condition.Text,
                        Icon = day.Day.Condition.Icon,
                        PrecipitationProbability = day.Day.DailyChanceOfRain,
                        WindSpeed = day.Day.MaxwindKph,
                        Code = day.Day.Condition.Code,
                        IsDay = true

                    }).ToList()
                };
            }
            catch (Exception ex) {
                _logger.LogError("Exception caught: {@ex}", ex);
                return null;
            }
        }
    }
}
