namespace Blazor.QuickWeather.Models.OpenWeather.CurrentWeatherAPI
{
    internal class Wind
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
        public double? Gust { get; set; } // Optional
    }
}
