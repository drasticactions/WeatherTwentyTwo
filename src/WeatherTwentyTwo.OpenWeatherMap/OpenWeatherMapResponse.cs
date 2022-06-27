// <copyright file="OpenWeatherMapResponse.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using OpenWeatherMap.Cache.Models;

namespace WeatherTwentyTwo
{
    public class OpenWeatherMapResponse : WeatherResponse
    {
        public OpenWeatherMapResponse(Readings readings)
        {
            this.CityName = readings.CityName;
            this.CityId = readings.CityId;
            this.CountryCode = readings.CountryCode;
            this.Temperature = readings.Temperature;
            this.Pressure = readings.Pressure;
            this.Humidity = readings.Humidity;
            this.MinimumTemperature = readings.MinimumTemperature;
            this.MaximumTemperature = readings.MaximumTemperature;
            this.SeaLevelPressure = readings.SeaLevelPressure;
            this.GroundLevelPressure = readings.GroundLevelPressure;
            this.WindSpeed = readings.WindSpeed;
            this.WindDirection = readings.WindDirection;
            this.WindGust = readings.WindGust;
            this.Cloudiness = readings.Cloudiness;
            this.RainfallLastHour = readings.RainfallLastHour;
            this.RainfallLastThreeHours = readings.RainfallLastThreeHours;
            this.SnowfallLastHour = readings.SnowfallLastHour;
            this.SnowfallLastThreeHours = readings.SnowfallLastThreeHours;
            this.Sunrise = readings.Sunrise;
            this.Sunset = readings.Sunset;
            this.TimeZoneOffset = readings.TimeZoneOffset;
            this.FetchedTime = readings.FetchedTime;
            this.MeasuredTime = readings.MeasuredTime;
            this.OpenWeatherMapReading = readings;
        }

        /// <summary>
        /// Gets the Open Weather Map Reading.
        /// This is Raw from the OpenWeatherMap API and the OpenWeatherMap.Cache library.
        /// </summary>
        public Readings OpenWeatherMapReading { get; }
    }
}
