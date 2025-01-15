namespace Blazor.QuickWeather.OpenWeatherMap.DailyForecastAPI
{
    public class DailyForecastItem
    {
        public long Dt { get; set; } // Unix timestamp for the forecast day
        public Temp Temp { get; set; } = new Temp();
        public FeelsLike Feels_Like { get; set; } = new FeelsLike();
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public List<WeatherCondition> Weather { get; set; } = new List<WeatherCondition>();
        public double Speed { get; set; } // Wind speed
        public int Deg { get; set; } // Wind direction
        public int Clouds { get; set; } // Cloudiness percentage
        public double? Rain { get; set; } // Rain volume, may be null
        public double Pop { get; set; } // Probability of precipitation
    }
}
