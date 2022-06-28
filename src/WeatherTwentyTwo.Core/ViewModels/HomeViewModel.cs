// <copyright file="HomeViewModel.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace WeatherTwentyTwo
{
    /// <summary>
    /// Home View Model.
    /// </summary>
    public class HomeViewModel : BaseViewModel
    {
        private ForecastResponse? weatherReport;
        private Coordinate? coordinate;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeViewModel"/> class.
        /// </summary>
        /// <param name="services"><see cref="IServiceProvider"/>.</param>
        public HomeViewModel(IServiceProvider services)
            : base(services)
        {
        }

        /// <summary>
        /// Gets or sets the home weather report.
        /// </summary>
        public ForecastResponse? WeatherReport
        {
            get { return this.weatherReport; }
            set { this.SetProperty(ref this.weatherReport, value); }
        }

        /// <summary>
        /// Gets or sets the current coordiante.
        /// </summary>
        public Coordinate? Coordinate
        {
            get { return this.coordinate; }
            set { this.SetProperty(ref this.coordinate, value); }
        }

        /// <inheritdoc/>
        public override async Task OnLoad()
        {
            await base.OnLoad();
            if (this.WeatherReport is null)
            {
                await this.RefreshWeatherReport();
            }
        }

        private async Task RefreshWeatherReport()
        {
            this.Coordinate = await this.GetCurrentLocationAsync();

            // If we can't get the local coordiante (User hasn't allowed it, etc)
            // Then use this as the default for now.
            this.WeatherReport = await this.Weather.GetWeatherAsync(this.Coordinate ?? new Coordinate(42.344903, -71.126069));
        }

        /// <summary>
        /// Gets the users current location.
        /// </summary>
        /// <returns><see cref="Coordinate"/>.</returns>
        private async Task<Coordinate> GetCurrentLocationAsync()
        {
            return await this.Platform.GetLocationAsync();
        }
    }
}
