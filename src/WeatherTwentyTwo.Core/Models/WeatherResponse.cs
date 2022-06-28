// <copyright file="WeatherResponse.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using UnitsNet;

namespace WeatherTwentyTwo
{
    public class WeatherResponse
    {
        public Temperature? Temperature { get; set; }

        public Pressure Pressure { get; set; }

        public RelativeHumidity Humidity { get; set; }

        public Temperature MinimumTemperature { get; set; }

        public Temperature MaximumTemperature { get; set; }

        public Pressure? SeaLevelPressure { get; set; }

        public Pressure? GroundLevelPressure { get; set; }

        public Speed WindSpeed { get; set; }

        public Angle WindDirection { get; set; }

        public Speed? WindGust { get; set; }

        public Ratio Cloudiness { get; set; }

        public Length? RainfallLastHour { get; set; }

        public Length? RainfallLastThreeHours { get; set; }

        public Length? SnowfallLastHour { get; set; }

        public Length? SnowfallLastThreeHours { get; set; }

        public DateTime Sunrise { get; set; }

        public DateTime Sunset { get; set; }

        public TimeSpan TimeZoneOffset { get; set; }

        public DateTime FetchedTime { get; set; }

        public DateTime MeasuredTime { get; set; }

        public WeatherCondition? DefaultCondition { get; set; }

        public List<WeatherCondition> Conditions { get; set; } = new List<WeatherCondition>();
    }
}
