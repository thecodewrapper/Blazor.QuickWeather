namespace Blazor.QuickWeather.Services
{
    public interface IWeatherService
    {
        Task<WeatherData> GetWeatherAsync(string location);
    }
}
