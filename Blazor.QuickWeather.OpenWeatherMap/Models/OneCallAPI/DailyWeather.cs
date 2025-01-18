using System.Text.Json.Serialization;

namespace Blazor.QuickWeather.OpenWeatherMap.OneCallAPI
{
    public class DailyWeather
    {
        [JsonPropertyName("dt")]
        public long DateTime { get; set; }

        [JsonPropertyName("sunrise")]
        public long Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public long Sunset { get; set; }

        [JsonPropertyName("moonrise")]
        public long Moonrise { get; set; }

        [JsonPropertyName("moonset")]
        public long Moonset { get; set; }

        [JsonPropertyName("moon_phase")]
        public double MoonPhase { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        [JsonPropertyName("temp")]
        public Temp Temp { get; set; }

        [JsonPropertyName("feels_like")]
        public Temp FeelsLike { get; set; }

        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("dew_point")]
        public double DewPoint { get; set; }

        [JsonPropertyName("wind_speed")]
        public double WindSpeed { get; set; }

        [JsonPropertyName("wind_deg")]
        public int WindDegree { get; set; }

        [JsonPropertyName("wind_gust")]
        public double WindGust { get; set; }

        [JsonPropertyName("weather")]
        public List<WeatherCondition> Weather { get; set; }

        [JsonPropertyName("clouds")]
        public int Clouds { get; set; }

        [JsonPropertyName("pop")]
        public double PrecipitationProbability { get; set; }

        [JsonPropertyName("rain")]
        public double? Rain { get; set; }

        [JsonPropertyName("uvi")]
        public double UVIndex { get; set; }
    }
}
