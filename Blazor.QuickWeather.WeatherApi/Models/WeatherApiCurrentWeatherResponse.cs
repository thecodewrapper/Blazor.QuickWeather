namespace Blazor.QuickWeather.WeatherApi
{
    public class WeatherApiCurrentWeatherResponse
    {
        public Location Location { get; set; } = new();
        public Current Current { get; set; } = new();
    }
}
