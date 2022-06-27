// <copyright file="WeatherCondition.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace WeatherTwentyTwo
{
    public class WeatherCondition
    {
        public int ConditionId { get; set; }

        public string? Main { get; set; }

        public string? Description { get; set; }

        public string? IconId { get; set; }

        public WeatherType WeatherType { get; set; }
    }
}
