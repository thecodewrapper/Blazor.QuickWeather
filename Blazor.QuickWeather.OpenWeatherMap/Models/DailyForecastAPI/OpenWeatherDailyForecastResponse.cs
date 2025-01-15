namespace Blazor.QuickWeather.OpenWeatherMap.DailyForecastAPI
{
    public class OpenWeatherDailyForecastResponse
    {
        public City City { get; set; } = new City();
        public List<DailyForecastItem> List { get; set; } = new List<DailyForecastItem>();
    }
}
