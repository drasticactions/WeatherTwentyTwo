// <copyright file="BasePage.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace WeatherTwentyTwo;

/// <summary>
/// Base Page.
/// </summary>
public class BasePage : ContentPage
{
    public BasePage(IServiceProvider services)
    {
        this.Services = services;
    }

    /// <summary>
    /// Gets the service provider.
    /// </summary>
    internal IServiceProvider Services { get; private set; }

    /// <inheritdoc/>
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // If we have a "BaseViewModel" as our binding context.
        // Then fire OnLoad whenever we navigate to the page.
        if (this.BindingContext is BaseViewModel viewModel)
        {
            viewModel.OnLoad().FireAndForgetSafeAsync(viewModel.ErrorHandler);
        }
    }
}