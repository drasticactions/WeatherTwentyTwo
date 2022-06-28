// <copyright file="TempSpanConverter.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System.Globalization;
using UnitsNet;

namespace WeatherTwentyTwo
{
    public class TempSpanConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 2)
                return 0;

            var val1 = values[0];
            var val2 = values[1];

            if (val1 is not Temperature temp1 || val2 is not Temperature temp2)
                return 0;

            var fTemp = temp1.DegreesFahrenheit * 3;
            var fTemp2 = temp2.DegreesFahrenheit * 3;

            return fTemp2 - fTemp;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
