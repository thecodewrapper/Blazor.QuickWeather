using Blazor.QuickWeather.Models.WeatherApi;

namespace Blazor.QuickWeather.Models.OpenWeather.CurrentWeatherAPI
{
    internal class CurrentWeatherResponse
    {
        public Coordinates Coord { get; set; } = new Coordinates();
        public List<WeatherCondition> Weather { get; set; } = new List<WeatherCondition>();
        public string Base { get; set; } = string.Empty;
        public MainWeather Main { get; set; } = new MainWeather();
        public int Visibility { get; set; }
        public Wind Wind { get; set; } = new Wind();
        public Rain? Rain { get; set; } // Rain is optional
        public Clouds Clouds { get; set; } = new Clouds();
        public int Dt { get; set; }
        public Sys Sys { get; set; } = new Sys();
        public int Timezone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Cod { get; set; }
    }
}
