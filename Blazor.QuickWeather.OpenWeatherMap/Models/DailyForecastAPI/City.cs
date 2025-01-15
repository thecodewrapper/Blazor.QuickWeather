namespace Blazor.QuickWeather.OpenWeatherMap.DailyForecastAPI
{
    public class City
    {
        public int Id { get; set; } // City ID
        public string Name { get; set; } = string.Empty; // City name
        public Coord Coord { get; set; } = new Coord(); // City coordinates (latitude and longitude)
        public string Country { get; set; } = string.Empty; // Country code (e.g., "IT" for Italy)
        public int Population { get; set; } // Population of the city
        public int Timezone { get; set; } // Timezone offset in seconds
    }
}
