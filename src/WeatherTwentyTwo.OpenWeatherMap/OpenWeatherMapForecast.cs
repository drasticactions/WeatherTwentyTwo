// <copyright file="OpenWeatherMapForecast.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using OpenWeatherMap.Standard.Models;

namespace WeatherTwentyTwo
{
    public class OpenWeatherMapForecast : ForecastResponse
    {
        public OpenWeatherMapForecast(ForecastData data)
        {
            this.CityName = data.City.Name;
            this.CityId = data.City.Id;
            this.CountryCode = data.City.Country;
            this.OpenWeatherMapForecastData = data;
            foreach (var item in data.WeatherData)
            {
                this.WeatherForecast.Add(new OpenWeatherMapResponse(item));
            }
        }

        /// <summary>
        /// Gets the Open Weather Map Raw Data.
        /// </summary>
        public ForecastData OpenWeatherMapForecastData { get; }
    }
}
