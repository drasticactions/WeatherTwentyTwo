// <copyright file="MaxTempOffsetConverter.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System.Globalization;
using UnitsNet;

namespace WeatherTwentyTwo
{
    public class MaxTempOffsetConverter : IValueConverter
    {
        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // I _assume_ this to be Fahrenheit.
            const double max = 90 * 3;

            if (value is Temperature temp)
            {
                var maxTemp = temp.ToUnit(UnitsNet.Units.TemperatureUnit.DegreeFahrenheit).Value * 3;
                var topMargin = max - maxTemp;

                return new Thickness(0, topMargin, 0, 0);
            }

            return new Thickness(0, 0, 0, 0);
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
