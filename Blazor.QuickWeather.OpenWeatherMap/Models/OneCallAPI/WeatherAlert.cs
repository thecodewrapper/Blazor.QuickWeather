using System.Text.Json.Serialization;

namespace Blazor.QuickWeather.OpenWeatherMap.OneCallAPI
{
    public class WeatherAlert
    {
        [JsonPropertyName("sender_name")]
        public string SenderName { get; set; }

        [JsonPropertyName("event")]
        public string Event { get; set; }

        [JsonPropertyName("start")]
        public long Start { get; set; }

        [JsonPropertyName("end")]
        public long End { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }
    }
}
