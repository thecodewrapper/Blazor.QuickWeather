namespace Blazor.QuickWeather
{
    public class WeatherData
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
        /// A brief description of the current weather (e.g., "clear sky").
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The humidity percentage (if provided by the API).
        /// </summary>
        public int Humidity { get; set; }

        /// <summary>
        /// The wind speed in meters per second (if provided by the API).
        /// </summary>
        public float WindSpeed { get; set; }

        /// <summary>
        /// Precipation in mm (if provided by the API).
        /// </summary>
        public float Precipitation { get; set; }
    }
}
