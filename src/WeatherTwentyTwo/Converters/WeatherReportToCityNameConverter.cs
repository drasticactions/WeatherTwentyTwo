// <copyright file="WeatherReportToCityNameConverter.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System.Globalization;

namespace WeatherTwentyTwo
{
    public class WeatherReportToCityNameConverter : IValueConverter
    {
        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ForecastResponse weatherResponse)
            {
                return $"{weatherResponse.CityName}, {weatherResponse.CountryCode}";
            }

            // If we can't get it, return the name of the app.
            return "WeatherTwentyTwo";
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
