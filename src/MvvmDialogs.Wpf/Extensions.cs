using System;
using System.Threading.Tasks;
using System.Windows;

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
        public static Task<bool?> ShowDialogAsync(this Window window)
        {
            if (window == null) throw new ArgumentNullException(nameof(window));

            TaskCompletionSource<bool?> completion = new TaskCompletionSource<bool?>();
            window.Dispatcher.BeginInvoke(new Action(() => completion.SetResult(window.ShowDialog())));
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
