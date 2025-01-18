namespace Blazor.QuickWeather
{
    public class WeatherServiceOptions
    {
        public OpenWeatherMapOptions OpenWeatherMap { get; internal set; } = new();
        public WeatherApiOptions WeatherApi { get; internal set; } = new();
    }
}
