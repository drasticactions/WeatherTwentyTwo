// <copyright file="MauiProgram.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>
using WeatherTwentyTwo.Services;

namespace WeatherTwentyTwo;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.Services.AddSingleton<IAppDispatcher, AppDispatcher>();
        builder.Services.AddSingleton<IErrorHandlerService, ErrorHandler>();
        builder.Services.AddSingleton<IWeatherService>(new OpenWeatherMapService(ApiKeys.OpenWeatherMapApi));
        builder.Services.AddTransient<HomePage>();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        return builder.Build();
    }
}
