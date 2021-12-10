using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MvvmDialogs.Wpf.FrameworkDialogs;

namespace MvvmDialogs.Wpf
{
    /// <summary>
    /// Extension methods.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Shows a modal dialog in an asynchronous way.
        /// </summary>
        /// <param name="window">The window to show.</param>
        public static Task<bool?> ShowDialogAsync(this Window window) =>
            window.RunUiAsync(window.ShowDialog);

        /// <summary>
        /// Shows a modal dialog in an asynchronous way.
        /// </summary>
        /// <param name="dialog">The dialog to show.</param>
        /// <param name="owner">The owner of the modal dialog.</param>
        public static Task<DialogResult> ShowDialogAsync(this CommonDialog dialog, Window owner) =>
            owner.RunUiAsync(() => dialog.ShowDialog(new Win32Window(owner)));

    /// <summary>
    /// Runs a synchronous action asynchronously on the UI thread.
    /// </summary>
    /// <param name="window">Any window to get the dispatcher from.</param>
    /// <param name="action">The action to run asynchronously.</param>
    /// <typeparam name="T">The return type of the action.</typeparam>
    /// <returns>The result of the action.</returns>
        public static Task<T> RunUiAsync<T>(this Window window, Func<T> action)
        {
            if (window == null) throw new ArgumentNullException(nameof(window));
            TaskCompletionSource<T> completion = new();
            window.Dispatcher.BeginInvoke(new Action(() => completion.SetResult(action())));
            return completion.Task;
        }

        /// <summary>
        /// Creates a WindowWrapper around specified window.
        /// </summary>
        /// <param name="window">The Window to get a wrapper for.</param>
        /// <returns>A WindowWrapper referencing the window.</returns>
        [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull("window")]
        public static WindowWrapper? AsWrapper(this Window? window) =>
            window != null ? new WindowWrapper(window) : null;

        /// <summary>
        /// Converts an IWindow into a WindowWrapper.
        /// </summary>
        /// <param name="window">The IWindow to convert.</param>
        /// <returns>A WindowWrapper referencing the window.</returns>
        [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull("window")]
        public static WindowWrapper? AsWrapper(this IWindow? window) =>
            (WindowWrapper?)window;

        /// <summary>
        /// Gets the owner of a <see cref="FrameworkElement"/> wrapped in a <see cref="WindowWrapper"/>.
        /// </summary>
        /// <param name="frameworkElement">
        /// The <see cref="FrameworkElement"/> to find the <see cref="WindowWrapper"/> for.
        /// </param>
        /// <returns>The owning <see cref="WindowWrapper"/> if found; otherwise null.</returns>
        internal static WindowWrapper GetOwner(this FrameworkElement frameworkElement)
        {
            var owner = frameworkElement as Window ?? Window.GetWindow(frameworkElement);
            return owner.AsWrapper();
        }
    }
}
