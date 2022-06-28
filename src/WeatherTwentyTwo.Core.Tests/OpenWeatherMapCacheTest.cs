// <copyright file="OpenWeatherMapCacheTest.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace WeatherTwentyTwo.Core.Tests
{
    /// <summary>
    /// OpenWeatherMap.Cache Tests.
    /// </summary>
    [TestClass]
    public class OpenWeatherMapCacheTest
    {
        private OpenWeatherMap.Standard.Current cache;
        private OpenWeatherMapService service;

        public OpenWeatherMapCacheTest()
        {
            var key = ApiKeys.OpenWeatherMapApi;
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("Open Weather Map API key must not be null!");
            }

            this.cache = new OpenWeatherMap.Standard.Current(key);
            this.service = new OpenWeatherMapService(this.cache);
        }

        [DataRow(42.384080, -71.178179)] // Watertown, MA. United States.
        [DataTestMethod]
        public async Task GetWeatherAsyncTest(double latitude, double longitude)
        {
            var result = await this.service.GetWeatherAsync(new Coordinate(latitude, longitude));
            Assert.IsNotNull(result);
        }
    }
}
