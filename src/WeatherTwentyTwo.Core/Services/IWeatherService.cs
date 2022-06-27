// <copyright file="IWeatherService.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace WeatherTwentyTwo.Services;

/// <summary>
/// Weather Service.
/// </summary>
public interface IWeatherService
{
    Task<IEnumerable<Location>> GetLocationsAsync(string query);

    Task<WeatherResponse> GetWeatherAsync(Coordinate location);
}
