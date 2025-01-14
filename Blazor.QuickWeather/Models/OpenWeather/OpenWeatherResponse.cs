namespace Blazor.QuickWeather.Models.OpenWeather
{
    internal class OpenWeatherResponse
    {
        public string Name { get; set; } = string.Empty;
        public MainData Main { get; set; } = new();
        public List<WeatherDescription> Weather { get; set; } = new();
        public WindData Wind { get; set; } = new();
        public RainData? Rain { get; set; }
        public SnowData? Snow { get; set; }
    }
}
