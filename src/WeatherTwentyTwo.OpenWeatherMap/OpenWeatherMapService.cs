// <copyright file="OpenWeatherMapService.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using OpenWeatherMap.Cache;
using WeatherTwentyTwo.Services;

namespace WeatherTwentyTwo
{
    public class OpenWeatherMapService : IWeatherService
    {
        private OpenWeatherMapCache client;

        public OpenWeatherMapService(OpenWeatherMapCache client)
        {
            this.client = client;
        }

        public OpenWeatherMapService(string apiKey, int apiCachePeriod = 5000)
        {
            this.client = new OpenWeatherMapCache(apiKey, apiCachePeriod);
        }

        public Task<IEnumerable<Location>> GetLocationsAsync(string query)
        {
            throw new NotImplementedException();
        }

        public async Task<WeatherResponse> GetWeatherAsync(Coordinate location)
        {
            var owLocation = new OpenWeatherMap.Cache.Models.Location(location.Latitude, location.Longitude);
            OpenWeatherMap.Cache.Models.Readings result = await this.client.GetReadingsAsync(owLocation);
            OpenWeatherMap.Cache.Models.WeatherCondition condition = result.Weather.First();
            return new OpenWeatherMapResponse(result);
        }
    }
}
