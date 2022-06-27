// <copyright file="Coordinate.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace WeatherTwentyTwo
{
    public struct Coordinate
    {
        public double Latitude;
        public double Longitude;

        public Coordinate(double x, double y)
        {
            this.Latitude = x;
            this.Longitude = y;
        }

        public static bool TryParse(string input, out Coordinate coordinate)
        {
            coordinate = default;
            var splitArray = input.Split(new[] { ',' }, 2);

            if (splitArray.Length != 2)
            {
                return false;
            }

            if (!double.TryParse(splitArray[0], out var lat))
            {
                return false;
            }

            if (!double.TryParse(splitArray[1], out var lon))
            {
                return false;
            }

            coordinate = new Coordinate(lat, lon);
            return true;
        }

        public override string ToString()
        {
            return $"{this.Latitude},{this.Longitude}";
        }
    }
}
