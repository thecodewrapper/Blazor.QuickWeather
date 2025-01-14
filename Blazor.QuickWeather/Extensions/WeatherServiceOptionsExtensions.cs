namespace Blazor.QuickWeather.Extensions
{
    public static class WeatherServiceOptionsExtensions
    {
        /// <summary>
        /// Adds an API resource to the WeatherServiceOptions.
        /// </summary>
        public static WeatherServiceOptions AddApiResource(
            this WeatherServiceOptions options,
            string name,
            string apiUrl,
            string apiKey = null) {
            options.ApiResources.Add(new WeatherApiResource
            {
                Name = name,
                ApiUrl = apiUrl,
                ApiKey = apiKey
            });
            return options;
        }

        /// <summary>
        /// Sets the default API resource by moving it to the top of the list.
        /// </summary>
        public static WeatherServiceOptions SetDefaultApiResource(
            this WeatherServiceOptions options,
            string name) {
            var defaultResource = options.ApiResources.FirstOrDefault(r => r.Name == name);
            if (defaultResource != null) {
                options.ApiResources.Remove(defaultResource);
                options.ApiResources.Insert(0, defaultResource);
            }
            else {
                throw new ArgumentException($"API resource with name '{name}' not found.", nameof(name));
            }

            return options;
        }
    }
}
