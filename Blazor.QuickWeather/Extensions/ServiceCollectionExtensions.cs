using Blazor.QuickWeather.Factories;
using Blazor.QuickWeather.OpenWeatherMap;
using Blazor.QuickWeather.Services;
using Blazor.QuickWeather.WeatherApi;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.QuickWeather.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddQuickWeather(this IServiceCollection services, Action<WeatherServiceOptions> configure) {
            if (configure == null) {
                throw new ArgumentNullException(nameof(configure));
            }

            var options = new WeatherServiceOptions();
            configure(options);

            services.Configure(configure);
            services.AddScoped<IWeatherServiceFactory, WeatherServiceFactory>();

            return services;
        }

        public static IServiceCollection AddOpenWeatherMap(this IServiceCollection services, string apiKey) {
            if (string.IsNullOrWhiteSpace(apiKey)) {
                throw new ArgumentNullException(nameof(apiKey), "API key for OpenWeatherMap cannot be null or empty.");
            }

            services.Configure<WeatherServiceOptions>(options =>
            {
                options.OpenWeatherMap.ApiKey = apiKey;
            });

            services.AddScoped<OpenWeatherClient>();
            services.AddHttpClient<OpenWeatherClient>();
            services.AddScoped<IWeatherService, OpenWeatherMapWeatherService>();

            return services;
        }

        public static IServiceCollection AddWeatherApi(this IServiceCollection services, string apiKey) {
            if (string.IsNullOrWhiteSpace(apiKey)) {
                throw new ArgumentNullException(nameof(apiKey), "API key for WeatherApi cannot be null or empty.");
            }

            services.Configure<WeatherServiceOptions>(options =>
            {
                options.WeatherApi.ApiKey = apiKey;
            });

            services.AddScoped<WeatherApiClient>();
            services.AddHttpClient<WeatherApiClient>();
            services.AddScoped<IWeatherService, WeatherApiWeatherService>();

            return services;
        }

        public static IServiceCollection AddOpenMeteo(this IServiceCollection services, string apiKey) {
            if (string.IsNullOrWhiteSpace(apiKey)) {
                throw new ArgumentNullException(nameof(apiKey), "API key for OpenMeteo cannot be null or empty.");
            }

            services.Configure<WeatherServiceOptions>(options =>
            {
                options.OpenMeteo.ApiKey = apiKey;
            });

            //add open-meteo http client and services here

            return services;
        }
    }
}
