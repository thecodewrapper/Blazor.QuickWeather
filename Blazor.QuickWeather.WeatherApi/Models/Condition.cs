namespace Blazor.QuickWeather.WeatherApi
{
    public class Condition
    {
        public string Text { get; set; } = string.Empty; // Weather description
        public string Icon { get; set; } = string.Empty; // Icon URL
        public int Code { get; set; }
    }
}
