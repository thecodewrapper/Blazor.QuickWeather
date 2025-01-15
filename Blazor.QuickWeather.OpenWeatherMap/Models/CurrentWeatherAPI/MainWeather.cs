namespace Blazor.QuickWeather.OpenWeatherMap.CurrentWeatherAPI
{
    public class MainWeather
    {
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public int? SeaLevel { get; set; } // Optional
        public int? GrndLevel { get; set; } // Optional
    }
}
