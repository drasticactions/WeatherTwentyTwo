// <copyright file="ITrayService.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace WeatherTwentyTwo.Services;

/// <summary>
/// Tray Service.
/// </summary>
public interface ITrayService
{
    /// <summary>
    /// Gets or sets the click handler for Tray Icon.
    /// </summary>
    Action ClickHandler { get; set; }

    /// <summary>
    /// Initialize Tray Service.
    /// </summary>
    void Initialize();
}
