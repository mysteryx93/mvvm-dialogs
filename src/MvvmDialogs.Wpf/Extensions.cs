using System.Windows;
using System.Windows.Forms;

namespace MvvmDialogs.Wpf
{
    /// <summary>
    /// Extension methods.
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// Gets the owner of a <see cref="FrameworkElement"/> wrapped in a <see cref="WindowWrapper"/>.
        /// </summary>
        /// <param name="frameworkElement">
        /// The <see cref="FrameworkElement"/> to find the <see cref="WindowWrapper"/> for.
        /// </param>
        /// <returns>The owning <see cref="WindowWrapper"/> if found; otherwise null.</returns>
        // TODO: Fix possible 'null' assignment to non-nullable entity by making the entity nullable
        internal static WindowWrapper? GetOwner(this FrameworkElement frameworkElement)
        {
            var owner = frameworkElement as Window ?? Window.GetWindow(frameworkElement);
            return owner != null ? new WindowWrapper(owner) : null;
        }

        /// <summary>
        /// Returns true if DialogResult is Yes or OK; false if No or Abort; otherwise null.
        /// </summary>
        /// <param name="result">The DialogResult to evaluate.</param>
        /// <returns>Whether the value is Yes or OK.</returns>
        internal static bool? AsBool(this DialogResult result) =>
            result switch
            {
                DialogResult.OK => true,
                DialogResult.Yes => true,
                DialogResult.No => false,
                DialogResult.Abort => false,
                _ => null
            };
    }
}
