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

        public static IServiceCollection AddOpenWeatherMap(this IServiceCollection services, Action<OpenWeatherMapOptions> configure) {
            if (configure == null) {
                throw new ArgumentNullException(nameof(configure));
            }

            var options = new OpenWeatherMapOptions();
            configure(options);

            services.Configure(configure);

            services.AddScoped<OpenWeatherClient>();
            services.AddHttpClient<OpenWeatherClient>();
            services.AddScoped<IWeatherService, OpenWeatherMapWeatherService>();

            return services;
        }

        public static IServiceCollection AddWeatherApi(this IServiceCollection services, Action<WeatherApiOptions> configure) {
            if (configure == null) {
                throw new ArgumentNullException(nameof(configure));
            }

            var options = new WeatherApiOptions();
            configure(options);

            services.Configure(configure);

            services.AddScoped<WeatherApiClient>();
            services.AddHttpClient<WeatherApiClient>();
            services.AddScoped<IWeatherService, WeatherApiWeatherService>();

            return services;
        }
    }
}
