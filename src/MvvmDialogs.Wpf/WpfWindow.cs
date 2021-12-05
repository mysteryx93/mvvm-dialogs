﻿using System;
using System.Windows;
using System.Windows.Forms;
using MvvmDialogs.Core;
using MvvmDialogs.Wpf.FrameworkDialogs;

namespace MvvmDialogs.Wpf.DialogFactories
{
    /// <summary>
    /// Class wrapping an instance of WPF <see cref="Window"/> within <see cref="IWindow"/>.
    /// </summary>
    /// <seealso cref="IWindow" />
    public class WpfWindow : IWindow
    {
        /// <summary>
        /// Gets the Window reference held by this class.
        /// </summary>
        public Window Ref { get; private set; }

        /// <summary>
        /// Returns a IWin32Window class that can be used for API calls.
        /// </summary>
        public IWin32Window Win32Window => new Win32Window(Ref);

        public event EventHandler? Closed
        {
            add => Ref.Closed += value;
            remove => Ref.Closed -= value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WpfWindow"/> class.
        /// </summary>
        /// <param name="window">The window.</param>
        public WpfWindow(Window window) => this.Ref = window ?? throw new ArgumentNullException(nameof(window));

        /// <inheritdoc />
        public object DataContext
        {
            get => Ref.DataContext;
            set => Ref.DataContext = value;
        }

        /// <inheritdoc />
        public bool? DialogResult
        {
            get => Ref.DialogResult;
            set => Ref.DialogResult = value;
        }

        /// <inheritdoc />
        public IWindow? Owner
        {
            get => Ref.Owner != null ? new WpfWindow(Ref.Owner) : null;
            set =>
                Ref.Owner = value switch
                {
                    null => null,
                    WpfWindow w => w.Ref,
                    _ => throw new ArgumentException($"Owner must be of type {typeof(WpfWindow).FullName}")
                };
        }

        /// <inheritdoc />
        public bool? ShowDialog() => Ref.ShowDialog();

        /// <inheritdoc />
        public void Show() => Ref.Show();
    }
}