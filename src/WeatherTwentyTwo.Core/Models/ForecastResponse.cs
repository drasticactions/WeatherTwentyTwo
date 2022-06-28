// <copyright file="ForecastResponse.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace WeatherTwentyTwo
{
    public class ForecastResponse
    {
        public int CityId { get; set; }

        public string? CityName { get; set; }

        public string? CountryCode { get; set; }

        public WeatherResponse? NewestForecast => this.WeatherForecast.FirstOrDefault();

        public List<WeatherResponse> WeatherForecast { get; set; } = new List<WeatherResponse>();
    }
}
