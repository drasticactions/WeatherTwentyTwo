// <copyright file="AppDispatcher.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace WeatherTwentyTwo.Services
{
    /// <summary>
    /// MAUI App Dispatcher.
    /// </summary>
    public class AppDispatcher : IAppDispatcher
    {
        /// <inheritdoc/>
        public bool Dispatch(Action action)
        {
            // TODO: Use the current Window instance for getting the dispatcher.
            // Some platforms may not have Application.Current set.
            if (Application.Current is not null)
            {
                return Application.Current.Dispatcher.Dispatch(action);
            }

            return false;
        }
    }
}
