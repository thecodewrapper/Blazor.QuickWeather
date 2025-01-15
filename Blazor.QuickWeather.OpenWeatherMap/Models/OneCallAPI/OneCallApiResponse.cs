namespace Blazor.QuickWeather.OpenWeatherMap.OneCallAPI
{
    public class OneCallApiResponse
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
        public CurrentWeather? Current { get; set; }
        public List<DailyForecast>? Daily { get; set; }
    }
}
