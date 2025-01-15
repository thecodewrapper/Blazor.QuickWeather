namespace Blazor.QuickWeather.Models
{
    public class WeatherRequest
    {
        public string CityName { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string IpAddress { get; set; }
    }
}
