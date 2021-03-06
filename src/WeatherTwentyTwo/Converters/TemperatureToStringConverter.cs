// <copyright file="TemperatureToStringConverter.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System.Globalization;
using UnitsNet;
using UnitsNet.Units;

namespace WeatherTwentyTwo
{
    public class TemperatureToStringConverter : IValueConverter
    {
        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Temperature temp)
            {
                return string.Format("{0:F0}°", temp.ToUnit(TemperatureUnit.DegreeCelsius).Value);
            }

            return "NaN℉";
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
