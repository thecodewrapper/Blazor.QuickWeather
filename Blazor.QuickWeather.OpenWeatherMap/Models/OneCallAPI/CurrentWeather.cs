namespace Blazor.QuickWeather.OpenWeatherMap.OneCallAPI
{
    public class CurrentWeather
    {
        public long Dt { get; set; }
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
        public int WindDeg { get; set; }
        public double? WindGust { get; set; }
        public List<WeatherCondition>? Weather { get; set; }
        public Rain? Rain { get; set; }
    }
}
