// <copyright file="Next7DWidget.xaml.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace WeatherTwentyTwo;

public partial class Next7DWidget : ContentView
{
    public Next7DWidget()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty WeatherReportProperty = BindableProperty.Create(nameof(WeatherReport), typeof(ForecastResponse), typeof(ForecastResponse), default);

    public ForecastResponse WeatherReport
    {
        get => (ForecastResponse)GetValue(Next7DWidget.WeatherReportProperty);
        set => SetValue(Next7DWidget.WeatherReportProperty, value);
    }
}