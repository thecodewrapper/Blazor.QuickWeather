namespace Blazor.QuickWeather.OpenWeatherMap.CurrentWeatherAPI
{
    public class Sys
    {
        public int Type { get; set; }
        public int Id { get; set; }
        public string Country { get; set; } = string.Empty;
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }
}
