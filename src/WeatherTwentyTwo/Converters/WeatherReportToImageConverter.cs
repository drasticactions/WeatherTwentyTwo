// <copyright file="WeatherReportToImageConverter.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System.Globalization;

namespace WeatherTwentyTwo
{
    public class WeatherReportToImageConverter : IValueConverter
    {
        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // TODO: This is very specific for OpenWeatherMap.
            // I'm cheating...
            var baseApiAddress = "http://openweathermap.org/img/wn/{0}@2x.png";
            if (value is WeatherResponse report && report.DefaultCondition is not null)
            {
                return string.Format(baseApiAddress, report.DefaultCondition.IconId);
            }

            return "dotnet_bot.png";
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
