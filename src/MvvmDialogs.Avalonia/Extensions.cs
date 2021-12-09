﻿using System.Diagnostics.CodeAnalysis;
using Avalonia;
using Avalonia.Controls;
using Avalonia.LogicalTree;

namespace MvvmDialogs.Avalonia
{
    /// <summary>
    /// Extension methods.
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// Gets the owner of a <see cref="StyledElement"/> wrapped in a <see cref="WindowWrapper"/>.
        /// </summary>
        /// <param name="frameworkElement">
        /// The <see cref="StyledElement"/> to find the <see cref="WindowWrapper"/> for.
        /// </param>
        /// <returns>The owning <see cref="WindowWrapper"/> if found; otherwise null.</returns>
        internal static WindowWrapper? GetOwner(this StyledElement frameworkElement)
        {
            var owner = frameworkElement as Window ?? frameworkElement.FindLogicalAncestorOfType<Window>();
            return owner.AsWrapper();
        }

        /// <summary>
        /// Creates a WindowWrapper around specified window.
        /// </summary>
        /// <param name="window">The Window to get a wrapper for.</param>
        /// <returns>A WindowWrapper referencing the window.</returns>
        [return: NotNullIfNotNull("window")]
        internal static WindowWrapper? AsWrapper(this Window? window) =>
            window != null ? new WindowWrapper(window) : null;

        /// <summary>
        /// Converts an IWindow into a WindowWrapper.
        /// </summary>
        /// <param name="window">The IWindow to convert.</param>
        /// <returns>A WindowWrapper referencing the window.</returns>
        [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull("window")]
        public static WindowWrapper? AsWrapper(this IWindow? window) =>
            (WindowWrapper?)window;

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