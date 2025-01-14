using Blazor.QuickWeather.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.QuickWeather.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddQuickWeather(this IServiceCollection services, Action<WeatherServiceOptions> configure) {
            // Bind the WeatherServiceOptions from the provided configuration
            services.Configure(configure);

            // Register the WeatherService as a scoped service
            services.AddSingleton<IWeatherServiceFactory, WeatherServiceFactory>();

            // Register HttpClient for Blazor Server; it's automatically provided in Blazor WebAssembly
            //services.AddHttpClient();

            return services;
        }
    }
}
