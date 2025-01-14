using System.Text.Json.Serialization;

namespace Blazor.QuickWeather.Models.OpenWeather
{
    internal class RainData
    {
        [JsonPropertyName("1h")]
        public float? OneHour { get; set; }

        [JsonPropertyName("3h")]
        public float? ThreeHour { get; set; }
    }
}
