namespace Blazor.QuickWeather.WeatherApi
{
    public class Day
    {
        public double MaxtempC { get; set; } // Max temperature in Celsius
        public double MintempC { get; set; } // Min temperature in Celsius
        public Condition Condition { get; set; } = new Condition();
    }
}
