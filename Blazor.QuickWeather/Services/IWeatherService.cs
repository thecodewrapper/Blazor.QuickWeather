using Blazor.QuickWeather.Models;

namespace Blazor.QuickWeather.Services
{
    public interface IWeatherService
    {
        WeatherResource Resource { get; }
        Task<CurrentWeatherData> GetCurrentWeatherAsync(WeatherRequest request);
        Task<ForecastWeatherData> GetForecastWeatherAsync(WeatherRequest request);
    }
}
