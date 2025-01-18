namespace Blazor.QuickWeather
{
    /// <summary>
    /// Options for OpenWeatherMap
    /// See https://openweathermap.org/api for more information
    /// </summary>
    public class OpenWeatherMapOptions
    {
        public string CurrentWeatherApiKey { get; set; }
        public string OneCallApiKey { get; set; }
    }
}
