namespace Blazor.QuickWeather.Models.WeatherApi
{
    internal class CurrentWeatherData
    {
        public float TempC { get; set; }
        public int Humidity { get; set; }
        public float WindKph { get; set; }
        public float PrecipMm { get; set; }
        public WeatherCondition Condition { get; set; } = new WeatherCondition();
    }
}
