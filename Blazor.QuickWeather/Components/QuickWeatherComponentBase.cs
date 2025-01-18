using Blazor.QuickWeather.Factories;
using Blazor.QuickWeather.Models;
using Blazor.QuickWeather.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text;

namespace Blazor.QuickWeather.Components
{
    public class QuickWeatherComponentBase : ComponentBase
    {
        [Inject] IWeatherServiceFactory WeatherServiceFactory { get; set; }
        [Inject] IJSRuntime JSRuntime { get; set; }
        [Parameter] public string Location { get; set; }
        [Parameter] public double? Lon { get; set; }
        [Parameter] public double? Lat { get; set; }

        /// <summary>
        /// The source of the weather information. If not provided, will pick the first available
        /// </summary>
        [Parameter] public WeatherDataSource? Source { get; set; }

        /// <summary>
        /// The update interval in seconds. Defaults to 0 (no auto update)
        /// </summary>
        [Parameter] public int UpdateIntervalSeconds { get; set; }

        /// <summary>
        /// Whether to include 7-day forecast data
        /// </summary>
        [Parameter] public bool IncludeForecast { get; set; } = false;

        /// <summary>
        /// Whether to use the widget icons or icons from the weather source
        /// </summary>
        [Parameter] public bool UseSourceIcons { get; set; } = true;

        protected List<ForecastDay>? ForecastData = new();

        protected CurrentWeatherData? WeatherData;
        protected Timer? UpdateTimer;
        protected DateTime LastUpdated;
        protected Geolocation _userLocation;
        protected bool _isInitialized = false; // Tracks whether the component is initialized

        protected override async Task OnInitializedAsync() {
        }

        protected override async Task OnAfterRenderAsync(bool firstRender) {
            if (firstRender) {
                if (Lat == null || Lon == null) {
                    await GetUserLocationAsync();
                    await LoadWeatherData();
                    StateHasChanged();
                    StartTimer();
                }
                _isInitialized = true; // Mark initialization as complete
            }
        }

        protected override async Task OnParametersSetAsync() {
            if (!_isInitialized) {
                // Avoid running logic before initialization
                return;
            }

            // Reload weather data when parameters change
            await LoadWeatherData();

            // Restart the timer if the update interval has changed
            if (UpdateIntervalSeconds > 0) {
                StartTimer();
            }
            else {
                UpdateTimer?.Dispose(); // Stop the timer if interval is 0
                UpdateTimer = null;
            }
        }

        private async Task LoadWeatherData() {
            var request = new WeatherRequest
            {
                CityName = Location,
                Longitude = Lon ?? _userLocation?.Longitude ?? 0,
                Latitude = Lat ?? _userLocation?.Latitude ?? 0,
                IpAddress = string.Empty
            };

            if (Source == null) {
                Source = WeatherDataSource.WeatherApi;
            }

            var weatherService = WeatherServiceFactory.Create(Source.Value);

            WeatherData = await weatherService.GetCurrentWeatherAsync(request);

            if (WeatherData != null) {
                LastUpdated = DateTime.Now;

                if (IncludeForecast) {
                    ForecastData = (await weatherService.GetForecastWeatherAsync(request))?.Forecast;
                }
                else {
                    ForecastData = null;
                }
            }
            else {
                ForecastData = null;
            }
        }

        private async Task GetUserLocationAsync() {
            try {
                _userLocation = await JSRuntime.InvokeAsync<Geolocation>("getUserLocation");
            }
            catch (Exception ex) {
                Console.WriteLine($"Could not retrieve user location: {ex.Message}");
            }
        }

        protected async Task OnDemandUpdate() {
            await LoadWeatherData();
            StateHasChanged();
        }

        private void StartTimer() {
            if (UpdateIntervalSeconds < 1) {
                return; //dont auto update
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
            if (!UseSourceIcons) {
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
