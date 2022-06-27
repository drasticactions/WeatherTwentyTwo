// <copyright file="OpenWeatherMapCacheTest.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace WeatherTwentyTwo.Core.Tests
{
    /// <summary>
    /// OpenWeatherMap.Cache Tests
    /// </summary>
    [TestClass]
    public class OpenWeatherMapCacheTest
    {
        private OpenWeatherMap.Cache.OpenWeatherMapCache cache;
        private OpenWeatherMapService service;

        public OpenWeatherMapCacheTest()
        {
            var key = ApiKeys.OpenWeatherMapApi;
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("Open Weather Map API key must not be null!");
            }

            this.cache = new OpenWeatherMap.Cache.OpenWeatherMapCache(key, 5000);
            this.service = new OpenWeatherMapService(this.cache);
        }

        [DataRow(42.384080, -71.178179, "Watertown")] // Watertown, MA. United States.
        [DataTestMethod]
        public async Task GetWeatherAsyncTest(double latitude, double longitude, string cityName)
        {
            var result = await this.service.GetWeatherAsync(new Coordinate(latitude, longitude));
            Assert.IsNotNull(result);
            Assert.AreEqual(result.CityName, cityName);
        }
    }
}
