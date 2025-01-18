using System.Text.Json.Serialization;

namespace Blazor.QuickWeather.OpenWeatherMap.OneCallAPI
{
    public class HourlyWeather
    {
        [JsonPropertyName("dt")]
        public long DateTime { get; set; }

        [JsonPropertyName("temp")]
        public double Temperature { get; set; }

        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }

        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("dew_point")]
        public double DewPoint { get; set; }

        [JsonPropertyName("uvi")]
        public double UVIndex { get; set; }

        [JsonPropertyName("clouds")]
        public int Clouds { get; set; }

        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }

        [JsonPropertyName("wind_speed")]
        public double WindSpeed { get; set; }

        [JsonPropertyName("wind_deg")]
        public int WindDegree { get; set; }

        [JsonPropertyName("wind_gust")]
        public double WindGust { get; set; }

        [JsonPropertyName("weather")]
        public List<WeatherCondition> Weather { get; set; }

        [JsonPropertyName("pop")]
        public double PrecipitationProbability { get; set; }
    }
}
