// <copyright file="IAppDispatcher.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace WeatherTwentyTwo.Services
{
    /// <summary>
    /// App Dispatcher.
    /// Runs tasks on the Apps UI Thread.
    /// </summary>
    public interface IAppDispatcher
    {
        /// <summary>
        /// Dispatch Thread.
        /// </summary>
        /// <param name="action">Action to be dispatched.</param>
        /// <returns>Bool if action completed and/or ran.</returns>
        bool Dispatch(Action action);
    }
}
