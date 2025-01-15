namespace Blazor.QuickWeather.WeatherApi
{
    public class WeatherApiForecastResponse
    {
        public Location Location { get; set; } = new Location();
        public Forecast Forecast { get; set; } = new Forecast();
    }
}
