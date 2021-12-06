using System;
using System.Threading.Tasks;
using MvvmDialogs.Core;
using MvvmDialogs.Core.FrameworkDialogs;

namespace MvvmDialogs.Avalonia.FrameworkDialogs
{
    /// <summary>
    /// Interface representing a framework dialog.
    /// </summary>
    public abstract class AvaloniaFrameworkDialogBase<TSettings> : IFrameworkDialog
    {
        /// <summary>
        /// Gets the settings for the framework dialog.
        /// </summary>
        protected TSettings Settings { get; }

        /// <summary>
        /// Initializes a new instance of a FrameworkDialog.
        /// </summary>
        /// <param name="settings">The settings for the framework dialog.</param>
        protected AvaloniaFrameworkDialogBase(TSettings settings) =>
            Settings = settings ?? throw new ArgumentNullException(nameof(settings));

        /// <inheritdoc />
        public Task<bool?> ShowDialogAsync(IWindow owner)
        {
            if (owner == null) throw new ArgumentNullException(nameof(owner));
            if (owner is not AvaloniaWindow window) throw new ArgumentException($"{nameof(owner)} must be of type {nameof(AvaloniaWindow)}");
            return ShowDialogAsync(window);
        }

        /// <summary>
        /// Opens a framework dialog with specified owner.
        /// </summary>
        /// <param name="owner">Handle to the window that owns the dialog.</param>
        /// <returns>true if user clicks the OK button; otherwise false.</returns>
        public abstract Task<bool?> ShowDialogAsync(AvaloniaWindow owner);
    }
}
