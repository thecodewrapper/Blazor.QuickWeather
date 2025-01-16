using Blazor.QuickWeather.Factories;
using Blazor.QuickWeather.Models;
using Blazor.QuickWeather.Utilities;
using Microsoft.AspNetCore.Components;
using System.Text;

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
        protected bool _useCustomIcons = true;

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

        protected string GetWeatherIconUrl(string icon, int code, bool isDayTime) {
            if (_useCustomIcons) {
                StringBuilder sb = new StringBuilder("_content/Blazor.QuickWeather/icons/animated/");
                switch (Source) {
                    case WeatherDataSource.OpenWeatherMap: sb.Append(WeatherIconMapper.GetOpenWeatherMapIcon(code, isDayTime)); break;
                    case WeatherDataSource.WeatherApi: sb.Append(WeatherIconMapper.GetWeatherApiIcon(code, isDayTime)); break;
                }
                return sb.ToString();
            }

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
