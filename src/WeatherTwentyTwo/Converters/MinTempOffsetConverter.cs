// <copyright file="MinTempOffsetConverter.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System.Globalization;
using UnitsNet;

namespace WeatherTwentyTwo
{
    public class MinTempOffsetConverter : IValueConverter
    {
        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // I _assume_ this to be Fahrenheit.
            const double min = 40 * 3;

            if (value is Temperature temp)
            {
                var minTemp = temp.ToUnit(UnitsNet.Units.TemperatureUnit.DegreeFahrenheit).Value * 3;
                var bottomMargin = minTemp - min;

                return new Thickness(0, 0, 0, bottomMargin);
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
