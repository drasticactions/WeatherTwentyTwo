// <copyright file="CurrentWidget.xaml.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace WeatherTwentyTwo;

public partial class CurrentWidget : ContentView
{

    public CurrentWidget()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty WeatherReportProperty = BindableProperty.Create(nameof(WeatherReport), typeof(WeatherResponse), typeof(WeatherResponse), default);

    public WeatherResponse WeatherReport
    {
        get => (WeatherResponse)GetValue(CurrentWidget.WeatherReportProperty);
        set => SetValue(CurrentWidget.WeatherReportProperty, value);
    }
}