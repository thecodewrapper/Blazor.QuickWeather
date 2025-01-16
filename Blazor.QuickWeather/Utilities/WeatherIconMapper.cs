namespace Blazor.QuickWeather.Utilities
{
    /// <summary>
    /// Code to icon mapper
    /// </summary>
    public class WeatherIconMapper
    {
        /// <summary>
        /// Maps the weather code from WeatherAPI to a custom icon
        /// </summary>
        /// <param name="code"></param>
        /// <param name="isDayTime"></param>
        /// <returns></returns>
        public static string GetWeatherApiIcon(int code, bool isDayTime) {
            var iconMappings = new Dictionary<int, string>
        {
            { 1000, isDayTime ? "clear-day.svg" : "clear-night.svg" },
            { 1003, isDayTime ? "cloudy-1-day.svg" : "cloudy-1-night.svg" },
            { 1006, isDayTime ? "cloudy-2-day.svg" : "cloudy-2-night.svg" },
            { 1009, isDayTime ? "cloudy-3-day.svg" : "cloudy-3-night.svg" },
            { 1030, isDayTime ? "fog-day.svg" : "fog-night.svg" },
            { 1063, isDayTime ? "rainy-1-day.svg" : "rainy-1-night.svg" },
            { 1066, isDayTime ? "snowy-1-day.svg" : "snowy-1-night.svg" },
            { 1069, "rain-and-sleet-mix.svg" },
            { 1072, "frost.svg" },
            { 1087, isDayTime ? "isolated-thunderstorms-day.svg" : "isolated-thunderstorms-night.svg" },
            { 1114, "snowy-2.svg" },
            { 1117, "snowy-3.svg" },
            { 1135, "fog.svg" },
            { 1147, "frost.svg" },
            { 1150, "rainy-1.svg" },
            { 1153, "rainy-2.svg" },
            { 1168, "rainy-3.svg" },
            { 1171, "rainy-3.svg" },
            { 1180, isDayTime ? "rainy-1-day.svg" : "rainy-1-night.svg" },
            { 1183, isDayTime ? "rainy-2-day.svg" : "rainy-2-night.svg" },
            { 1186, isDayTime ? "rainy-3-day.svg" : "rainy-3-night.svg" },
            { 1189, isDayTime ? "rainy-3-day.svg" : "rainy-3-night.svg" },
            { 1192, "rainy-3.svg" },
            { 1195, "rainy-3.svg" },
            { 1198, "frost.svg" },
            { 1201, "frost.svg" },
            { 1204, isDayTime ? "rainy-1-day.svg" : "rainy-1-night.svg" },
            { 1207, "rainy-2.svg" },
            { 1210, "snowy-1.svg" },
            { 1213, "snowy-2.svg" },
            { 1216, "snowy-3.svg" },
            { 1219, "snowy-3.svg" },
            { 1222, "snowy-3.svg" },
            { 1225, "snowy-3.svg" },
            { 1237, "hail.svg" },
            { 1240, isDayTime ? "rainy-1-day.svg" : "rainy-1-night.svg" },
            { 1243, "rainy-3.svg" },
            { 1246, "rainy-3.svg" },
            { 1249, "rain-and-sleet-mix.svg" },
            { 1252, "rain-and-sleet-mix.svg" },
            { 1255, "snowy-2.svg" },
            { 1258, "snowy-3.svg" },
            { 1261, "hail.svg" },
            { 1264, "hail.svg" },
            { 1273, isDayTime ? "scattered-thunderstorms-day.svg" : "scattered-thunderstorms-night.svg" },
            { 1276, "severe-thunderstorm.svg" },
            { 1279, "snow-and-sleet-mix.svg" },
            { 1282, "snow-and-sleet-mix.svg" }
        };

            // Default to cloudy if code not found
            return iconMappings.ContainsKey(code) ? iconMappings[code] : (isDayTime ? "cloudy-day.svg" : "cloudy-night.svg");
        }


        /// <summary>
        /// Maps the weather code from OpenWeatherMap to a custom icon
        /// </summary>
        /// <param name="code"></param>
        /// <param name="isDayTime"></param>
        /// <returns></returns>
        public static string GetOpenWeatherMapIcon(int code, bool isDayTime) {
            var iconMappings = new Dictionary<int, string>
        {
            // Thunderstorm group (2xx)
            { 200, "isolated-thunderstorms.svg" },
            { 201, "isolated-thunderstorms.svg" },
            { 202, "isolated-thunderstorms.svg" },
            { 210, "scattered-thunderstorms.svg" },
            { 211, "scattered-thunderstorms.svg" },
            { 212, "severe-thunderstorm.svg" },
            { 221, "scattered-thunderstorms.svg" },
            { 230, "isolated-thunderstorms.svg" },
            { 231, "isolated-thunderstorms.svg" },
            { 232, "isolated-thunderstorms.svg" },

            // Drizzle group (3xx)
            { 300, "rainy-1.svg" },
            { 301, "rainy-1.svg" },
            { 302, "rainy-2.svg" },
            { 310, "rainy-1.svg" },
            { 311, "rainy-1.svg" },
            { 312, "rainy-2.svg" },
            { 313, "rain-and-sleet-mix.svg" },
            { 314, "rain-and-sleet-mix.svg" },
            { 321, "rain-and-sleet-mix.svg" },

            // Rain group (5xx)
            { 500, isDayTime ? "rainy-1-day.svg" : "rainy-1-night.svg" },
            { 501, isDayTime ? "rainy-2-day.svg" : "rainy-2-night.svg" },
            { 502, isDayTime ? "rainy-3-day.svg" : "rainy-3-night.svg" },
            { 503, "rainy-3.svg" },
            { 504, "rainy-3.svg" },
            { 511, "frost.svg" },
            { 520, isDayTime ? "rainy-1-day.svg" : "rainy-1-night.svg" },
            { 521, isDayTime ? "rainy-2-day.svg" : "rainy-2-night.svg" },
            { 522, "rainy-3.svg" },
            { 531, "rainy-3.svg" },

            // Snow group (6xx)
            { 600, "snowy-1.svg" },
            { 601, "snowy-2.svg" },
            { 602, "snowy-3.svg" },
            { 611, "snow-and-sleet-mix.svg" },
            { 612, "snow-and-sleet-mix.svg" },
            { 613, "snow-and-sleet-mix.svg" },
            { 615, "rain-and-snow-mix.svg" },
            { 616, "rain-and-snow-mix.svg" },
            { 620, "snowy-1.svg" },
            { 621, "snowy-2.svg" },
            { 622, "snowy-3.svg" },

            // Atmosphere group (7xx)
            { 701, "fog.svg" },
            { 711, "haze.svg" },
            { 721, "haze.svg" },
            { 731, "dust.svg" },
            { 741, "fog.svg" },
            { 751, "dust.svg" },
            { 761, "dust.svg" },
            { 762, "ash.svg" },
            { 771, "wind.svg" },
            { 781, "tornado.svg" },

            // Clear group (800)
            { 800, isDayTime ? "clear-day.svg" : "clear-night.svg" },

            // Clouds group (80x)
            { 801, isDayTime ? "cloudy-1-day.svg" : "cloudy-1-night.svg" },
            { 802, isDayTime ? "cloudy-2-day.svg" : "cloudy-2-night.svg" },
            { 803, isDayTime ? "cloudy-3-day.svg" : "cloudy-3-night.svg" },
            { 804, "cloudy.svg" }
        };

            // Default to cloudy if code not found
            return iconMappings.ContainsKey(code) ? iconMappings[code] : (isDayTime ? "cloudy-day.svg" : "cloudy-night.svg");
        }
    }
}
