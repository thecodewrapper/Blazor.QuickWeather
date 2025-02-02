﻿namespace Blazor.QuickWeather.Models
{
    public class ForecastWeatherData
    {
        public string Location { get; set; } = string.Empty;
        public List<ForecastDay> Forecast { get; set; } = new List<ForecastDay>();
    }

    public class ForecastDay
    {
        public DateTime Date { get; set; }
        public float MaxTemperature { get; set; }
        public float MinTemperature { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public int PrecipitationProbability { get; set; }
        public decimal WindSpeed { get; set; }

        /// <summary>
        /// The weather condition code
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Whether it is daytime or not
        /// </summary>
        public bool IsDay { get; set; }
    }
}
