namespace Blazor.QuickWeather.Models
{
    public class ForecastWeatherData
    {
        public string Location { get; set; } = string.Empty;
        public List<ForecastDay> Forecast { get; set; } = new List<ForecastDay>();
    }

    public class ForecastDay
    {
        public string Date { get; set; } = string.Empty;
        public float MaxTemperature { get; set; }
        public float MinTemperature { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
    }
}
