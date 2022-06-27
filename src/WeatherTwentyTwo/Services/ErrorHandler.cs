// <copyright file="ErrorHandler.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace WeatherTwentyTwo.Services
{
    /// <summary>
    ///  MAUI Error Handler.
    /// </summary>
    public class ErrorHandler : IErrorHandlerService
    {
        /// <inheritdoc/>
        public event EventHandler<ErrorHandlerEventArgs>? OnError;

        /// <inheritdoc/>
        public void HandleError(Exception exception)
        {
            if (exception == null)
            {
                return;
            }

            this.OnError?.Invoke(this, new ErrorHandlerEventArgs(exception));
        }
    }
}
