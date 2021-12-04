using System;
using MvvmDialogs.Core;
using MvvmDialogs.Core.FrameworkDialogs;
using MvvmDialogs.Wpf.DialogFactories;

namespace MvvmDialogs.Wpf.FrameworkDialogs
{
    /// <summary>
    /// Interface representing a framework dialog.
    /// </summary>
    public abstract class WpfFrameworkDialogBase<TSettings> : IFrameworkDialog
    {
        /// <summary>
        /// Gets the settings for the framework dialog.
        /// </summary>
        protected TSettings Settings { get; }

        /// <summary>
        /// Initializes a new instance of a FrameworkDialog.
        /// </summary>
        /// <param name="settings">The settings for the framework dialog.</param>
        protected WpfFrameworkDialogBase(TSettings settings) => Settings = settings ?? throw new ArgumentNullException(nameof(settings));

        /// <inheritdoc />
        public bool? ShowDialog(IWindow owner)
        {
            if (owner == null) throw new ArgumentNullException(nameof(owner));
            if (owner is not WpfWindow window) throw new ArgumentException($"{nameof(owner)} must be of type {nameof(WpfWindow)}");
            return ShowDialog(window);
        }

        /// <summary>
        /// Opens a framework dialog with specified owner.
        /// </summary>
        /// <param name="owner">Handle to the window that owns the dialog.</param>
        /// <returns>true if user clicks the OK button; otherwise false.</returns>
        public abstract bool? ShowDialog(WpfWindow owner);
    }
}
