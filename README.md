# Blazor.QuickWeather

Blazor.QuickWeather is a Blazor-based weather application that provides current weather and forecast information using multiple weather APIs. The solution is built with .NET 8 and leverages Serilog for logging.

## Features

- Display current weather information
- Display 7-day weather forecast
- Support for multiple weather APIs (OpenWeatherMap, WeatherApi)
- Blazor Server support
- Configurable via `appsettings.json` and user secrets

## Projects

### Blazor.QuickWeather

Core library containing models, services, and utilities for weather data retrieval.

### Blazor.QuickWeather.BlazorServer

Blazor Server application that hosts the weather components and pages.

### Blazor.QuickWeather.OpenWeatherMap

Library for interacting with the OpenWeatherMap API.

### Blazor.QuickWeather.WeatherApi

Library for interacting with the WeatherApi API.

## Getting Started

### Prerequisites

- .NET 8 SDK
- Visual Studio 2022 or later

### Configuration

1. Clone the repository:

```
git clone https://github.com/your-repo/Blazor.QuickWeather.git
cd Blazor.QuickWeather
```

2. Set up user secrets for API keys:

```
dotnet user-secrets init --project Blazor.QuickWeather.BlazorServer
dotnet user-secrets set "WeatherApiResources:OpenWeatherMap:CurrentApiKey" "your_openweathermap_api_key" --project Blazor.QuickWeather.BlazorServer
dotnet user-secrets set "WeatherApiResources:OpenWeatherMap:OneCallApiKey" "your_openweathermap_api_key" --project Blazor.QuickWeather.BlazorServer
dotnet user-secrets set "WeatherApiResources:WeatherApi:ApiKey" "your_weatherapi_api_key" --project Blazor.QuickWeather.BlazorServer
```

3. Update `appsettings.json` if needed:

```
  "WeatherApiResources": {
  "OpenWeatherMap": {
    "CurrentApiKey": "",
    "OneCallApiKey": ""
  },
  "WeatherApi": {
    "ApiKey": ""
  }
}
```

### Running the Application

1. Open the solution in Visual Studio.
2. Set `Blazor.QuickWeather.BlazorServer` as the startup project.
3. Press `F5` to build and run the application.

## Usage

Navigate to the application in your browser. You will see the current weather and 7-day forecast for the configured location.

## Logging

The application uses Serilog for logging. Logs are configured in `appsettings.json` and can be customized as needed.

## Contributing

Contributions are welcome! Please fork the repository and submit pull requests.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Acknowledgements

- [OpenWeatherMap](https://openweathermap.org/)
- [WeatherApi](https://www.weatherapi.com/)
- [Serilog](https://serilog.net/)

---