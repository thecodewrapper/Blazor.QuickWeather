namespace Blazor.QuickWeather
{
    public class WeatherServiceOptions
    {
        public List<WeatherApiResource> ApiResources { get; internal set; } = new();
    }
}
