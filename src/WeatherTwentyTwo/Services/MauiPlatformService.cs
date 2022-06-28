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
            // TODO: Hard code location for now...
            //try
            //{
            //    var result = await Geolocation.GetLocationAsync(new GeolocationRequest() { DesiredAccuracy = GeolocationAccuracy.Low, RequestFullAccuracy = false  });
            //    if (result is not null)
            //    {
            //        return new Coordinate(result.Latitude, result.Longitude);
            //    }
            //}
            //catch (Exception)
            //{
            //}

            return new Coordinate(42.344903, -71.126069);
        }
    }
}