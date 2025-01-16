using Blazor.QuickWeather.Factories;
using Blazor.QuickWeather.Models;
using Microsoft.AspNetCore.Components;

namespace Blazor.QuickWeather.Components
{
    public class QuickWeatherComponentBase : ComponentBase
    {
        [Inject] IWeatherServiceFactory WeatherServiceFactory { get; set; }
        [Parameter] public string Location { get; set; } = "London";
        [Parameter] public double Lon { get; set; }
        [Parameter] public double Lat { get; set; }
        [Parameter] public WeatherDataSource? Source { get; set; }
        [Parameter] public int UpdateIntervalSeconds { get; set; } = 30;
        [Parameter] public bool Forecast { get; set; } = false;
        protected List<ForecastDay>? ForecastData = new();

        protected CurrentWeatherData? WeatherData;
        protected Timer? UpdateTimer;
        protected DateTime LastUpdated;

        protected override async Task OnInitializedAsync() {
            await LoadWeatherData();
            StartTimer();
        }

        private async Task LoadWeatherData() {
            var request = new WeatherRequest
            {
                CityName = Location,
                Longitude = Lon,
                Latitude = Lat,
                IpAddress = string.Empty
            };

            if (Source == null) {
                Source = WeatherDataSource.WeatherApi;
            }

            var weatherService = WeatherServiceFactory.Create(Source.Value);

            WeatherData = await weatherService.GetCurrentWeatherAsync(request);

            if (WeatherData != null) {
                LastUpdated = DateTime.Now;

                if (Forecast) {
                    ForecastData = (await weatherService.GetForecastWeatherAsync(request))?.Forecast;
                }
            }
            else {
                ForecastData = null;
            }
        }

        protected async Task OnDemandUpdate() {
            await LoadWeatherData();
            StateHasChanged();
        }

        private void StartTimer() {
            if (UpdateIntervalSeconds < 1) {
                throw new ArgumentException("UpdateIntervalSeconds must be greater than or equal to 1 second.");
            }

            var updateIntervalMilliseconds = UpdateIntervalSeconds * 1000;

            UpdateTimer = new Timer(async _ =>
            {
                await InvokeAsync(async () =>
                {
                    await LoadWeatherData();
                    StateHasChanged();
                });
            }, null, updateIntervalMilliseconds, updateIntervalMilliseconds);
        }

        protected string GetWeatherIconUrl(string icon) {
            return Source switch
            {
                WeatherDataSource.OpenWeatherMap => $"https://openweathermap.org/img/wn/{icon}@2x.png",
                WeatherDataSource.WeatherApi => icon,
                _ => string.Empty
            };
        }

        public void Dispose() {
            UpdateTimer?.Dispose();
        }
    }
}
