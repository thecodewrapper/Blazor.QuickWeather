namespace Blazor.QuickWeather.Models.OpenMeteo
{
    internal class HourlyData
    {
        public List<string> Time { get; set; } = new List<string>();
        public List<double> Temperature2m { get; set; } = new List<double>();
    }
}
