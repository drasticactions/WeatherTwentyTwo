// <copyright file="BaseViewModel.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System.ComponentModel;
using System.Runtime.CompilerServices;
using WeatherTwentyTwo.Services;

namespace WeatherTwentyTwo
{
    /// <summary>
    /// Base View Model.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool isBusy;
        private string title = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseViewModel"/> class.
        /// </summary>
        /// <param name="services"><see cref="IServiceProvider"/>.</param>
        public BaseViewModel(IServiceProvider services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            this.Services = services;
            this.ErrorHandler = services.GetService(typeof(IErrorHandlerService)) as IErrorHandlerService ?? throw new NullReferenceException(nameof(IErrorHandlerService));
            this.Dispatcher = services.GetService(typeof(IAppDispatcher)) as IAppDispatcher ?? throw new NullReferenceException(nameof(IAppDispatcher));
            this.Weather = services.GetService(typeof(IWeatherService)) as IWeatherService ?? throw new NullReferenceException(nameof(IWeatherService));
            this.RefreshAsyncCommand = new AsyncCommand(this.RefreshAsync, this.CanRefresh, this.Dispatcher, this.ErrorHandler);
            this.QuitAsyncCommand = new AsyncCommand(this.QuitAsync, null, this.Dispatcher, this.ErrorHandler);
        }

        /// <inheritdoc/>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Gets the RefreshAsyncCommand Command.
        /// </summary>
        public AsyncCommand RefreshAsyncCommand { get; private set; }

        /// <summary>
        /// Gets the QuitAsyncCommand Command.
        /// </summary>
        public AsyncCommand QuitAsyncCommand { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether the VM is busy.
        /// </summary>
        public bool IsBusy
        {
            get { return this.isBusy; }
            set { this.SetProperty(ref this.isBusy, value); }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title
        {
            get { return this.title; }
            set { this.SetProperty(ref this.title, value); }
        }

        /// <summary>
        /// Gets the Dispatcher.
        /// </summary>
        public IAppDispatcher Dispatcher { get; }

        /// <summary>
        /// Gets the Error Handler.
        /// </summary>
        public IErrorHandlerService ErrorHandler { get; }

        /// <summary>
        /// Gets the Weather service.
        /// </summary>
        internal IWeatherService Weather { get; }

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/>.
        /// </summary>
        internal IServiceProvider Services { get; }

        /// <summary>
        /// Called on VM Load.
        /// </summary>
        /// <returns><see cref="Task"/>.</returns>
        public virtual Task OnLoad()
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Called when wanting to raise a Command Can Execute.
        /// </summary>
        public virtual void RaiseCanExecuteChanged()
        {
        }

        /// <summary>
        /// Called when the user wants to quit the application.
        /// </summary>
        public virtual Task QuitAsync()
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Called when RefreshCommand is run.
        /// </summary>
        /// <returns><see cref="Task"/>.</returns>
        internal virtual Task RefreshAsync()
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Can refresh.
        /// </summary>
        /// <returns>Bool if we can refresh the VM.</returns>
        internal virtual bool CanRefresh()
        {
            return true;
        }

#pragma warning disable SA1600 // Elements should be documented
        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action? onChanged = null)
#pragma warning restore SA1600 // Elements should be documented
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }

            backingStore = value;
            onChanged?.Invoke();
            this.OnPropertyChanged(propertyName);
            this.RaiseCanExecuteChanged();
            return true;
        }

        /// <summary>
        /// On Property Changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.Dispatcher?.Dispatch(() =>
            {
                var changed = this.PropertyChanged;
                if (changed == null)
                {
                    return;
                }

                changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
            });
        }
    }
}
