// <copyright file="MauiPlatformService.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;

namespace WeatherTwentyTwo.Services
{
    public class MauiPlatformService : IPlatformService
    {
        public async Task<Coordinate> GetLocationAsync()
        {
            var result = await Geolocation.GetLocationAsync();
            if (result is not null)
            {
                return new Coordinate(result.Latitude, result.Longitude);
            }

            // TODO: Figure out what location to actually return.
            return new Coordinate(42.344903, -71.126069);
        }
    }
}