using System.Text.Json.Serialization;

namespace Blazor.QuickWeather.WeatherApi
{
    public class Current
    {
        [JsonPropertyName("temp_c")]
        public float TempC { get; set; }
        public int Humidity { get; set; }

        [JsonPropertyName("wind_kph")]
        public float WindKph { get; set; }

        [JsonPropertyName("precip_mm")]
        public float PrecipMm { get; set; }
        public Condition Condition { get; set; } = new Condition();
    }
}
