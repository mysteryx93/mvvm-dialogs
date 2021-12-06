using Avalonia;
using Avalonia.Controls;
using Avalonia.LogicalTree;
using MvvmDialogs.Avalonia;

namespace MvvmDialogs.Wpf
{
    /// <summary>
    /// Extension methods.
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// Gets the owner of a <see cref="StyledElement"/> wrapped in a <see cref="AvaloniaWindow"/>.
        /// </summary>
        /// <param name="frameworkElement">
        /// The <see cref="StyledElement"/> to find the <see cref="AvaloniaWindow"/> for.
        /// </param>
        /// <returns>The owning <see cref="AvaloniaWindow"/> if found; otherwise null.</returns>
        internal static AvaloniaWindow? GetOwner(this StyledElement frameworkElement)
        {
            var owner = frameworkElement as Window ?? frameworkElement.FindLogicalAncestorOfType<Window>();
            return owner != null ? new AvaloniaWindow(owner) : null;
        }

        // /// <summary>
        // /// Returns true if DialogResult is Yes or OK; false if No or Abort; otherwise null.
        // /// </summary>
        // /// <param name="result">The DialogResult to evaluate.</param>
        // /// <returns>Whether the value is Yes or OK.</returns>
        // internal static bool? AsBool(this DialogResult result) =>
        //     result switch
        //     {
        //         DialogResult.OK => true,
        //         DialogResult.Yes => true,
        //         DialogResult.No => false,
        //         DialogResult.Abort => false,
        //         _ => null
        //     };
    }
}
