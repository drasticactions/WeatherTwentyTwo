// <copyright file="OpenWeatherMapResponse.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using OpenWeatherMap.Standard.Models;
using UnitsNet;

namespace WeatherTwentyTwo
{
    public class OpenWeatherMapResponse : WeatherResponse
    {
        public OpenWeatherMapResponse(WeatherData data)
        {
            this.OpenWeatherMapReading = data;
            if (data.WeatherDayInfo is not null)
            {
                this.Temperature = UnitsNet.Temperature.FromKelvins(data.WeatherDayInfo.Temperature);
                this.Pressure = UnitsNet.Pressure.FromHectopascals(data.WeatherDayInfo.Pressure);
                this.MinimumTemperature = UnitsNet.Temperature.FromKelvins(data.WeatherDayInfo.MinimumTemperature);
                this.MaximumTemperature = UnitsNet.Temperature.FromKelvins(data.WeatherDayInfo.MaximumTemperature);
                this.GroundLevelPressure = Pressure.FromHectopascals(data.WeatherDayInfo.GroundLevel);
                this.SeaLevelPressure = Pressure.FromHectopascals(data.WeatherDayInfo.SeaLevel);
            }

            if (data.Rain is not null)
            {
                this.RainfallLastHour = Length.FromMillimeters(data.Rain.LastHour);
                this.RainfallLastThreeHours = Length.FromMillimeters(data.Rain.LastThreeHours);
            }

            if (data.Snow is not null)
            {
                this.SnowfallLastHour = Length.FromMillimeters(data.Snow.LastHour);
                this.SnowfallLastThreeHours = Length.FromMillimeters(data.Snow.LastThreeHours);
            }

            if (data.Clouds is not null)
            {
                this.Cloudiness = Ratio.FromPercent(data.Clouds.All);
            }

            if (data.Wind is not null)
            {
                this.WindDirection = Angle.FromDegrees(data.Wind.Degree);
                this.WindSpeed = Speed.FromMetersPerSecond(data.Wind.Speed);
                this.WindGust = Speed.FromMetersPerSecond(data.Wind.Gust);
            }

            this.Sunrise = data.DayInfo.Sunrise;
            this.Sunrise = data.DayInfo.Sunset;

            this.MeasuredTime = data.AcquisitionDateTime;
            this.FetchedTime = DateTime.UtcNow;

            if (data.Weathers is not null && data.Weathers.Any())
            {
                this.DefaultCondition = new OpenWeatherMapConditions(data.Weathers.First());
                foreach (var item in data.Weathers)
                {
                    this.Conditions.Add(new OpenWeatherMapConditions(item));
                }
            }
        }

        /// <summary>
        /// Gets the Open Weather Map Reading.
        /// This is Raw from the OpenWeatherMap API and the OpenWeatherMap.Standard library.
        /// </summary>
        public WeatherData OpenWeatherMapReading { get; }
    }
}
