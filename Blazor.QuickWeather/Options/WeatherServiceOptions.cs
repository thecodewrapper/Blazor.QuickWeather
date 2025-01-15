namespace Blazor.QuickWeather
{
    public class WeatherServiceOptions
    {
        public WeatherApiResource OpenWeatherMap { get; internal set; } = new();
        public WeatherApiResource WeatherApi { get; internal set; } = new();
        public WeatherApiResource OpenMeteo { get; internal set; } = new();
    }
}
