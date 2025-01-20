# Blazor.QuickWeather

Blazor.QuickWeather is a Blazor-based weather application that provides current weather and forecast information using multiple weather APIs. The solution is built with .NET 8 and leverages Serilog for logging.

## Features

- Display current weather information
- Display 7-day weather forecast
- Support for multiple weather APIs (OpenWeatherMap, WeatherApi)
- Blazor Server support
- Configurable via `appsettings.json` and user secrets
- Easy integration and widget registration

## Projects

### Blazor.QuickWeather

Razor Class Library containing models, services, utilities for weather data retrieval and the weather components.

### Blazor.QuickWeather.BlazorServer

Blazor Server application that hosts the demo page showcasing the components and usage of the widgets.

### Blazor.QuickWeather.OpenWeatherMap

Library for interacting with the OpenWeatherMap API.

### Blazor.QuickWeather.WeatherApi

Library for interacting with the WeatherApi API.

---

## Getting Started

### Prerequisites

- .NET 8 SDK
- Visual Studio 2022 or later

### Configuration

1. **Set up user secrets for API keys:**

   Run the following commands to configure your API keys:

   ```bash
   dotnet user-secrets init --project Blazor.QuickWeather.BlazorServer
   dotnet user-secrets set "WeatherApiResources:OpenWeatherMap:CurrentApiKey" "your_openweathermap_api_key" --project Blazor.QuickWeather.BlazorServer
   dotnet user-secrets set "WeatherApiResources:OpenWeatherMap:OneCallApiKey" "your_openweathermap_api_key" --project Blazor.QuickWeather.BlazorServer
   dotnet user-secrets set "WeatherApiResources:WeatherApi:ApiKey" "your_weatherapi_api_key" --project Blazor.QuickWeather.BlazorServer
   ```

2. **Update `appsettings.json` if needed:**

   ```json
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

---

## Registering Weather Sources

Blazor.QuickWeather provides extension methods to simplify adding weather services to your application. You can register the weather services and APIs in the `Program.cs` file:

```csharp
using Blazor.QuickWeather.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Configure QuickWeather
builder.Services.AddQuickWeather(options =>
{
    // Additional configuration if needed
});

// Register OpenWeatherMap API
builder.Services.AddOpenWeatherMap(options =>
{
    options.CurrentWeatherApiKey = builder.Configuration["WeatherApiResources:OpenWeatherMap:CurrentApiKey"];
    options.OneCallApiKey = builder.Configuration["WeatherApiResources:OpenWeatherMap:OneCallApiKey"];
});

// Register WeatherApi API
builder.Services.AddWeatherApi(options =>
{
    options.ApiKey = builder.Configuration["WeatherApiResources:WeatherApi:ApiKey"];
});

var app = builder.Build();
```

### Widget Integration

To add a QuickWeather widget, call the `AddQuickWeather` method in the service configuration and ensure a weather service is registered (e.g., OpenWeatherMap or WeatherApi).

---

## Usage

After registering the services and weather sources, you can use the `<QuickWeatherBasic>` or `<QuickWeatherSmall>` component in your Blazor pages to display weather data. Here's how to use it:

### Basic Example

```razor
@page "/"
<PageTitle>QuickWeather</PageTitle>

<QuickWeatherBasic Source="WeatherDataSource.WeatherApi"
                   IncludeForecast="true"
                   UseSourceIcons="true"
                   UpdateIntervalSeconds="300" />
```

### Parameters

| Parameter             | Type                | Description                                                                                  |
|-----------------------|---------------------|----------------------------------------------------------------------------------------------|
| `Source`              | `WeatherDataSource` | Specifies the weather source to use. Options are `WeatherApi` or `OpenWeatherMap`.           |
| `IncludeForecast`     | `bool`              | Determines whether to include a 7-day weather forecast. Defaults to `false`.                 |
| `UseSourceIcons`      | `bool`              | Indicates whether to use the weather icons provided by the selected weather API. Defaults to `false`. |
| `UpdateIntervalSeconds` | `int`             | Specifies the interval (in seconds) for refreshing weather data. Set to `0` to disable auto-refresh. |

### Example Breakdown

- **`Source`**: Choose which weather API to use for fetching data (e.g., `WeatherDataSource.WeatherApi` or `WeatherDataSource.OpenWeatherMap`). Make sure the selected source has been registered in the service container.
- **`IncludeForecast`**: Set to `true` if you want to display a 7-day weather forecast in addition to the current weather.
- **`UseSourceIcons`**: If set to `true`, weather condition icons from the API (e.g., sun, cloud, rain icons) will be used. Otherwise, default icons will be displayed.
- **`UpdateIntervalSeconds`**: Controls how often the widget fetches updated weather data. A value of `300` (5 minutes) is recommended for regular updates without overwhelming the API.

### Customization Example

```razor
<QuickWeatherBasic Source="WeatherDataSource.OpenWeatherMap"
                   IncludeForecast="false"
                   UseSourceIcons="true"
                   UpdateIntervalSeconds="600" />
```

- This example fetches weather data from **OpenWeatherMap**, excludes the forecast, uses the source's weather icons, and refreshes the data every 10 minutes.

---

## Logging

The application uses Serilog for logging. Logs are configured in `appsettings.json` and can be customized as needed.

Example configuration:

```json
"Serilog": {
  "Using": [ "Serilog.Sinks.Console" ],
  "MinimumLevel": {
    "Default": "Debug",
    "Override": {
      "Microsoft": "Warning",
      "System": "Warning",
      "Microsoft.AspNetCore.Components": "Warning" // Suppress Blazor logs
    }
  },
  "WriteTo": [
    {
      "Name": "Console",
      "Args": {
        "outputTemplate": "[{Timestamp:HH:mm:ss} {Level:u3}] {SourceContext}: {Message:lj}{NewLine}{Exception}"
      }
    }
  ],
  "Enrich": [ "FromLogContext", "WithMachineName", "WithThreadId" ]
},
```

---

## Acknowledgements

- [OpenWeatherMap](https://openweathermap.org/)
- [WeatherApi](https://www.weatherapi.com/)
- [Serilog](https://serilog.net/)
- [Weather Icons](https://github.com/Makin-Things/weather-icons)
