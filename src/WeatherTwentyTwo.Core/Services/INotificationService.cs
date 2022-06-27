// <copyright file="INotificationService.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace WeatherTwentyTwo.Services;

/// <summary>
/// Notification Service.
/// </summary>
public interface INotificationService
{
    /// <summary>
    /// Show a notification.
    /// </summary>
    /// <param name="title">Title of the notification.</param>
    /// <param name="body">Body of the notification.</param>
    void ShowNotification(string title, string body);
}
