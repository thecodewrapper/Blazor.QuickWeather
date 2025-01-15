using Blazor.QuickWeather.Services;

namespace Blazor.QuickWeather.Factories
{
    internal interface IWeatherServiceFactory
    {
        IWeatherService Create(WeatherResource resource);
    }
}
