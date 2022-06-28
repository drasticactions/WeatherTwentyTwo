// <copyright file="OpenWeatherMapService.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using WeatherTwentyTwo.Services;

namespace WeatherTwentyTwo
{
    public class OpenWeatherMapService : IWeatherService
    {
        private OpenWeatherMap.Standard.Current client;

        public OpenWeatherMapService(OpenWeatherMap.Standard.Current client)
        {
            this.client = client;
            this.client.UseHTTPS = true;
            this.client.Units = OpenWeatherMap.Standard.Enums.WeatherUnits.Standard;
        }

        public OpenWeatherMapService(string apiKey)
        {
            this.client = new OpenWeatherMap.Standard.Current(apiKey);
            this.client.UseHTTPS = true;
            this.client.Units = OpenWeatherMap.Standard.Enums.WeatherUnits.Standard;
        }

        public Task<IEnumerable<Location>> GetLocationsAsync(string query)
        {
            throw new NotImplementedException();
        }

        public async Task<ForecastResponse> GetWeatherAsync(Coordinate location)
        {
            var result = await this.client.GetForecastDataByCoordinatesAsync(location.Latitude, location.Longitude);
            return new OpenWeatherMapForecast(result);
        }
    }
}
