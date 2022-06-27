// <copyright file="OpenWeatherMapConditions.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace WeatherTwentyTwo
{
    public class OpenWeatherMapConditions : WeatherCondition
    {
        public OpenWeatherMapConditions(OpenWeatherMap.Cache.Models.WeatherCondition condition)
        {
            this.Main = condition.Main;
            this.ConditionId = condition.ConditionId;
            this.IconId = condition.IconId;
            this.Description = condition.Description;
            this.WeatherType = this.GetWeatherType(this.ConditionId);
        }

        private WeatherType GetWeatherType(int weatherId)
        {
            if (weatherId >= 200 && weatherId < 300)
            {
                return WeatherType.Thunder;
            }

            if (weatherId == 300 || weatherId == 301)
            {
                return WeatherType.Clearing;
            }

            if (weatherId >= 300 && weatherId < 600)
            {
                return WeatherType.Rain;
            }

            if ((new[] { 600, 601, 611, 612, 615, 616, 620, 621 }).Contains(weatherId))
            {
                return WeatherType.Snowlight;
            }

            if ((new[] { 602, 622 }).Contains(weatherId))
            {
                return WeatherType.Blizzard;
            }

            if (weatherId == 741)
            {
                return WeatherType.Foggy;
            }

            if (weatherId == 711)
            {
                return WeatherType.Smog;
            }

            if (weatherId == 800)
            {
                return WeatherType.Extrasunny;
            }

            if (weatherId > 800 && weatherId < 804)
            {
                return WeatherType.Clear;
            }

            if (weatherId == 804)
            {
                return WeatherType.Clouds;
            }

            return WeatherType.Clear;
        }
    }
}
