using System.Text.Json.Serialization;

namespace Blazor.QuickWeather.OpenWeatherMap.CurrentWeatherAPI
{
    public class MainWeather
    {
        public double Temp { get; set; }

        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }

        [JsonPropertyName("temp_min")]
        public double TempMin { get; set; }

        [JsonPropertyName("temp_max")]
        public double TempMax { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }

        [JsonPropertyName("sea_level")]
        public int? SeaLevel { get; set; } // Optional

        [JsonPropertyName("grnd_level")]
        public int? GrndLevel { get; set; } // Optional
    }
}
