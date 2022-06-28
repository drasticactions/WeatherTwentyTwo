// <copyright file="IPlatformService.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;

namespace WeatherTwentyTwo.Services
{
    public interface IPlatformService
    {
        public Task<Coordinate> GetLocationAsync();
    }
}