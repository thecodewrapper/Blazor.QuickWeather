namespace Blazor.QuickWeather.WeatherApi
{
    public class Forecast
    {
        public List<ForecastDay> ForecastDay { get; set; } = new List<ForecastDay>();
    }
}
