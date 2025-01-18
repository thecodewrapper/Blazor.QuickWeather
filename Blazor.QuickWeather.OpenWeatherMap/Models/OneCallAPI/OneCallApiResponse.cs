using System.Text.Json.Serialization;

namespace Blazor.QuickWeather.OpenWeatherMap.OneCallAPI
{
    public class OneCallApiResponse
    {
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("timezone_offset")]
        public int TimezoneOffset { get; set; }

        [JsonPropertyName("current")]
        public CurrentWeather Current { get; set; }

        [JsonPropertyName("minutely")]
        public List<MinutelyWeather>? Minutely { get; set; }

        [JsonPropertyName("hourly")]
        public List<HourlyWeather>? Hourly { get; set; }

        [JsonPropertyName("daily")]
        public List<DailyWeather>? Daily { get; set; }

        [JsonPropertyName("alerts")]
        public List<WeatherAlert>? Alerts { get; set; }
    }
}
