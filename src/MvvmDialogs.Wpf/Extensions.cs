using System.Windows;
using MvvmDialogs.Wpf.DialogFactories;

namespace MvvmDialogs.Wpf
{
    /// <summary>
    /// Extension methods.
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// Gets the owner of a <see cref="FrameworkElement"/> wrapped in a <see cref="WpfWindow"/>.
        /// </summary>
        /// <param name="frameworkElement">
        /// The <see cref="FrameworkElement"/> to find the <see cref="WpfWindow"/> for.
        /// </param>
        /// <returns>The owning <see cref="WpfWindow"/> if found; otherwise null.</returns>
        // TODO: Fix possible 'null' assignment to non-nullable entity by making the entity nullable
        internal static WpfWindow? GetOwner(this FrameworkElement frameworkElement)
        {
            var owner = frameworkElement as Window ?? Window.GetWindow(frameworkElement);
            return owner != null ? new WpfWindow(owner) : null;
        }
    }
}
