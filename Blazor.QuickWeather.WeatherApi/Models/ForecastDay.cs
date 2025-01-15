namespace Blazor.QuickWeather.WeatherApi
{
    public class ForecastDay
    {
        public string Date { get; set; } = string.Empty;
        public Day Day { get; set; } = new Day();
    }
}
