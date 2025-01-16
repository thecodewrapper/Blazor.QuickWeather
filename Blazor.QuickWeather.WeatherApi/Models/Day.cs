using System.Text.Json.Serialization;

namespace Blazor.QuickWeather.WeatherApi
{
    public class Day
    {
        /// <summary>
        /// Maximum temperature in Celsius for the day.
        /// </summary>
        [JsonPropertyName("maxtemp_c")]
        public decimal MaxtempC { get; set; }

        /// <summary>
        /// Maximum temperature in Fahrenheit for the day.
        /// </summary>
        [JsonPropertyName("maxtemp_f")]
        public decimal MaxtempF { get; set; }

        /// <summary>
        /// Minimum temperature in Celsius for the day.
        /// </summary>
        [JsonPropertyName("mintemp_c")]
        public decimal MintempC { get; set; }

        /// <summary>
        /// Minimum temperature in Fahrenheit for the day.
        /// </summary>
        [JsonPropertyName("mintemp_f")]
        public decimal MintempF { get; set; }

        /// <summary>
        /// Average temperature in Celsius for the day.
        /// </summary>
        [JsonPropertyName("avgtemp_c")]
        public decimal AvgtempC { get; set; }

        /// <summary>
        /// Average temperature in Fahrenheit for the day.
        /// </summary>
        [JsonPropertyName("avgtemp_f")]
        public decimal AvgtempF { get; set; }

        /// <summary>
        /// Maximum wind speed in miles per hour.
        /// </summary>
        [JsonPropertyName("maxwind_mph")]
        public decimal MaxwindMph { get; set; }

        /// <summary>
        /// Maximum wind speed in kilometers per hour.
        /// </summary>
        [JsonPropertyName("maxwind_kph")]
        public decimal MaxwindKph { get; set; }

        /// <summary>
        /// Total precipitation in millimeters for the day.
        /// </summary>
        [JsonPropertyName("totalprecip_mm")]
        public decimal TotalPrecipMm { get; set; }

        /// <summary>
        /// Total precipitation in inches for the day.
        /// </summary>
        [JsonPropertyName("totalprecip_in")]
        public decimal TotalPrecipIn { get; set; }

        /// <summary>
        /// Total snowfall in centimeters for the day.
        /// </summary>
        [JsonPropertyName("totalsnow_cm")]
        public decimal TotalSnowCm { get; set; }

        /// <summary>
        /// Average visibility in kilometers for the day.
        /// </summary>
        [JsonPropertyName("avgvis_km")]
        public decimal AvgVisKm { get; set; }

        /// <summary>
        /// Average visibility in miles for the day.
        /// </summary>
        [JsonPropertyName("avgvis_miles")]
        public decimal AvgVisMiles { get; set; }

        /// <summary>
        /// Average humidity as a percentage for the day.
        /// </summary>
        [JsonPropertyName("avghumidity")]
        public int AvgHumidity { get; set; }

        /// <summary>
        /// UV Index for the day.
        /// </summary>
        [JsonPropertyName("uv")]
        public decimal UV { get; set; }

        /// <summary>
        /// Indicates if it will rain during the day (1 = Yes, 0 = No).
        /// </summary>
        [JsonPropertyName("daily_will_it_rain")]
        public int DailyWillItRain { get; set; }

        /// <summary>
        /// Indicates if it will snow during the day (1 = Yes, 0 = No).
        /// </summary>
        [JsonPropertyName("daily_will_it_snow")]
        public int DailyWillItSnow { get; set; }

        /// <summary>
        /// Chance of rain as a percentage for the day.
        /// </summary>
        [JsonPropertyName("daily_chance_of_rain")]
        public int DailyChanceOfRain { get; set; }

        /// <summary>
        /// Chance of snow as a percentage for the day.
        /// </summary>
        [JsonPropertyName("daily_chance_of_snow")]
        public int DailyChanceOfSnow { get; set; }

        /// <summary>
        /// Weather condition details for the day.
        /// </summary>
        [JsonPropertyName("condition")]
        public Condition Condition { get; set; } = new Condition();
    }
}
