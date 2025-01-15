namespace Blazor.QuickWeather.OpenWeatherMap.OneCallAPI
{
    public class DailyForecast
    {
        public long Dt { get; set; }
        public Temp Temp { get; set; }
        public List<WeatherCondition>? Weather { get; set; }
    }
}
