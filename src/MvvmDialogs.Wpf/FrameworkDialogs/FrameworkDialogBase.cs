using System;
using System.Threading.Tasks;
using MvvmDialogs.FrameworkDialogs;

namespace MvvmDialogs.Wpf.FrameworkDialogs
{
    /// <summary>
    /// Interface representing a framework dialog.
    /// </summary>
    public abstract class FrameworkDialogBase<TSettings> : IFrameworkDialog
    {
        /// <summary>
        /// Gets the settings for the framework dialog.
        /// </summary>
        protected TSettings Settings { get; }
        /// <summary>
        /// Gets application-wide settings.
        /// </summary>
        protected AppDialogSettings AppSettings { get; }

        /// <summary>
        /// Initializes a new instance of a FrameworkDialog.
        /// </summary>
        /// <param name="settings">The settings for the framework dialog.</param>
        /// <param name="appSettings">Application-wide settings configured on the DialogService.</param>
        protected FrameworkDialogBase(TSettings settings, AppDialogSettings appSettings)
        {
            Settings = settings ?? throw new ArgumentNullException(nameof(settings));
            AppSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));
        }

        /// <inheritdoc />
        public Task<bool?> ShowDialogAsync(IWindow owner)
        {
            if (owner == null) throw new ArgumentNullException(nameof(owner));
            if (owner is not WindowWrapper window) throw new ArgumentException($"{nameof(owner)} must be of type {nameof(WindowWrapper)}");
            return ShowDialogAsync(window);
        }

        /// <summary>
        /// Opens a framework dialog with specified owner.
        /// </summary>
        /// <param name="owner">Handle to the window that owns the dialog.</param>
        /// <returns>true if user clicks the OK button; otherwise false.</returns>
        public abstract Task<bool?> ShowDialogAsync(WindowWrapper owner);
    }
}
