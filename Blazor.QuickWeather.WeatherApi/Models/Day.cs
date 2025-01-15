using System.Text.Json.Serialization;

namespace Blazor.QuickWeather.WeatherApi
{
    public class Day
    {
        [JsonPropertyName("maxtemp_c")]
        public double MaxtempC { get; set; } // Max temperature in Celsius

        [JsonPropertyName("mintemp_c")]
        public double MintempC { get; set; } // Min temperature in Celsius
        public Condition Condition { get; set; } = new Condition();
    }
}
