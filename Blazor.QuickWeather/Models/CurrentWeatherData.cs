namespace Blazor.QuickWeather
{
    public class CurrentWeatherData
    {
        /// <summary>
        /// The location for which the weather data is fetched.
        /// </summary>
        public string Location { get; set; } = string.Empty;

        /// <summary>
        /// The temperature in Celsius.
        /// </summary>
        public float Temperature { get; set; }

        /// <summary>
        /// The "feels like" temperature.
        /// </summary>
        public float FeelsLike { get; set; }

        /// <summary>
        /// A brief description of the current weather (e.g., "clear sky").
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The humidity percentage (if provided by the API).
        /// </summary>
        public int? Humidity { get; set; }

        /// <summary>
        /// The wind speed in meters per second (if provided by the API).
        /// </summary>
        public float? WindSpeed { get; set; }

        /// <summary>
        /// Precipation in mm (if provided by the API).
        /// </summary>
        public float? Precipitation { get; set; }

        /// <summary>
        /// Inlcudes icon code, if supported by the Api (currently OpenWeather supports this)
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// The weather condition code
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Whether it is daytime or not
        /// </summary>
        public bool IsDay { get; set; }
    }
}
