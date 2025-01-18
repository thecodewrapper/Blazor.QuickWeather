using System.Text.Json.Serialization;

namespace Blazor.QuickWeather.OpenWeatherMap.OneCallAPI
{
    public class MinutelyWeather
    {
        [JsonPropertyName("dt")]
        public long DateTime { get; set; }

        [JsonPropertyName("precipitation")]
        public double Precipitation { get; set; }
    }
}
