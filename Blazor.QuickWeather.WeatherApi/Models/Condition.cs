using System.Text.Json.Serialization;

namespace Blazor.QuickWeather.WeatherApi
{
    public class Condition
    {
        /// <summary>
        /// Weather condition text.
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }

        /// <summary>
        /// Weather icon URL.
        /// </summary>
        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        /// <summary>
        /// Weather condition unique code.
        /// </summary>
        [JsonPropertyName("code")]
        public int Code { get; set; }
    }
}
