using System.Text.Json.Serialization;

namespace Blazor.QuickWeather.WeatherApi
{
    public class Current
    {
        /// <summary>
        /// Local time when the real time data was updated.
        /// </summary>
        [JsonPropertyName("last_updated")]
        public string LastUpdated { get; set; }

        /// <summary>
        /// Local time when the real time data was updated in unix time.
        /// </summary>
        [JsonPropertyName("last_updated_epoch")]
        public int LastUpdatedEpoch { get; set; }

        /// <summary>
        /// Temperature in celsius.
        /// </summary>
        [JsonPropertyName("temp_c")]
        public decimal TempC { get; set; }

        /// <summary>
        /// Temperature in fahrenheit.
        /// </summary>
        [JsonPropertyName("temp_f")]
        public decimal TempF { get; set; }

        /// <summary>
        /// Feels like temperature in celsius.
        /// </summary>
        [JsonPropertyName("feelslike_c")]
        public decimal FeelsLikeC { get; set; }

        /// <summary>
        /// Feels like temperature in fahrenheit.
        /// </summary>
        [JsonPropertyName("feelslike_f")]
        public decimal FeelsLikeF { get; set; }

        /// <summary>
        /// Windchill temperature in celsius.
        /// </summary>
        [JsonPropertyName("windchill_c")]
        public decimal WindChillC { get; set; }

        /// <summary>
        /// Windchill temperature in fahrenheit.
        /// </summary>
        [JsonPropertyName("windchill_f")]
        public decimal WindChillF { get; set; }

        /// <summary>
        /// Heat index in celsius.
        /// </summary>
        [JsonPropertyName("heatindex_c")]
        public decimal HeatIndexC { get; set; }

        /// <summary>
        /// Heat index in fahrenheit.
        /// </summary>
        [JsonPropertyName("heatindex_f")]
        public decimal HeatIndexF { get; set; }

        /// <summary>
        /// Dew point in celsius.
        /// </summary>
        [JsonPropertyName("dewpoint_c")]
        public decimal DewPointC { get; set; }

        /// <summary>
        /// Dew point in fahrenheit.
        /// </summary>
        [JsonPropertyName("dewpoint_f")]
        public decimal DewPointF { get; set; }

        /// <summary>
        /// Weather condition details.
        /// </summary>
        [JsonPropertyName("condition")]
        public Condition Condition { get; set; } = new Condition();

        /// <summary>
        /// Wind speed in miles per hour.
        /// </summary>
        [JsonPropertyName("wind_mph")]
        public decimal WindMph { get; set; }

        /// <summary>
        /// Wind speed in kilometers per hour.
        /// </summary>
        [JsonPropertyName("wind_kph")]
        public decimal WindKph { get; set; }

        /// <summary>
        /// Wind direction in degrees.
        /// </summary>
        [JsonPropertyName("wind_degree")]
        public int WindDegree { get; set; }

        /// <summary>
        /// Wind direction as 16-point compass (e.g., NSW).
        /// </summary>
        [JsonPropertyName("wind_dir")]
        public string WindDir { get; set; }

        /// <summary>
        /// Pressure in millibars.
        /// </summary>
        [JsonPropertyName("pressure_mb")]
        public decimal PressureMb { get; set; }

        /// <summary>
        /// Pressure in inches.
        /// </summary>
        [JsonPropertyName("pressure_in")]
        public decimal PressureIn { get; set; }

        /// <summary>
        /// Precipitation amount in millimeters.
        /// </summary>
        [JsonPropertyName("precip_mm")]
        public decimal PrecipMm { get; set; }

        /// <summary>
        /// Precipitation amount in inches.
        /// </summary>
        [JsonPropertyName("precip_in")]
        public decimal PrecipIn { get; set; }

        /// <summary>
        /// Humidity as a percentage.
        /// </summary>
        public int Humidity { get; set; }

        /// <summary>
        /// Cloud cover as a percentage.
        /// </summary>
        public int Cloud { get; set; }

        /// <summary>
        /// Whether it is day (1 = Yes, 0 = No).
        /// </summary>
        [JsonPropertyName("is_day")]
        public int IsDay { get; set; }

        /// <summary>
        /// UV index.
        /// </summary>
        public decimal Uv { get; set; }

        /// <summary>
        /// Wind gust in miles per hour.
        /// </summary>
        [JsonPropertyName("gust_mph")]
        public decimal GustMph { get; set; }

        /// <summary>
        /// Wind gust in kilometers per hour.
        /// </summary>
        [JsonPropertyName("gust_kph")]
        public decimal GustKph { get; set; }
    }
}