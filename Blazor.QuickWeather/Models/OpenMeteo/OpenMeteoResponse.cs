namespace Blazor.QuickWeather.Models.OpenMeteo
{
    internal class OpenMeteoResponse
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public HourlyData Hourly { get; set; } = new HourlyData();
    }
}
