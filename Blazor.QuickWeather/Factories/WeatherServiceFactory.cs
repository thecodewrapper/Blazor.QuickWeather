using Blazor.QuickWeather.Services;
using Microsoft.Extensions.Options;

namespace Blazor.QuickWeather.Factories
{
    public class WeatherServiceFactory : IWeatherServiceFactory
    {
        private readonly IEnumerable<IWeatherService> _weatherServices;

        public WeatherServiceFactory(IEnumerable<IWeatherService> weatherServices) {
            _weatherServices = weatherServices ?? throw new ArgumentNullException(nameof(weatherServices));
        }

        public IWeatherService Create(WeatherResource resource) {
            var service = _weatherServices.FirstOrDefault(ws => ws.Resource == resource);

            if (service == null) {
                throw new InvalidOperationException($"No IWeatherService implementation found for resource: {resource}");
            }

            return service;
        }
    }
}
