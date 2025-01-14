namespace Blazor.QuickWeather.Models.WeatherApi
{
    internal class WeatherApiResponse
    {
        public LocationData Location { get; set; } = new LocationData();
        public CurrentWeatherData Current { get; set; } = new CurrentWeatherData();
    }
}
