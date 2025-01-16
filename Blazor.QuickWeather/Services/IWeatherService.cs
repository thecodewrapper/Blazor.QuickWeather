using Blazor.QuickWeather.Models;

namespace Blazor.QuickWeather.Services
{
    public interface IWeatherService
    {
        WeatherDataSource Resource { get; }
        Task<CurrentWeatherData> GetCurrentWeatherAsync(WeatherRequest request);
        Task<ForecastWeatherData> GetForecastWeatherAsync(WeatherRequest request);
    }
}
