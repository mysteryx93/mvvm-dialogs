﻿using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using MvvmDialogs.Core;

namespace MvvmDialogs.Avalonia
{
    /// <summary>
    /// Class wrapping an instance of Avalonia <see cref="Window"/> within <see cref="IWindow"/>.
    /// </summary>
    /// <seealso cref="IWindow" />
    public class AvaloniaWindow : IWindow
    {
        /// <summary>
        /// Gets the Window reference held by this class.
        /// </summary>
        public Window Ref { get; private set; }

        /// <inheritdoc />
        public IWindow? Owner { get; set; }

        public event EventHandler? Closed
        {
            add => Ref.Closed += value;
            remove => Ref.Closed -= value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AvaloniaWindow"/> class.
        /// </summary>
        /// <param name="window">The window.</param>
        public AvaloniaWindow(Window window)
        {
            Ref = window ?? throw new ArgumentNullException(nameof(window));
            Owner = window.Owner is Window w ? new AvaloniaWindow(w) : null;
        }

        /// <inheritdoc />
        public object? DataContext
        {
            get => Ref.DataContext;
            set => Ref.DataContext = value;
        }

        /// <inheritdoc />
        public Task<bool?> ShowDialogAsync()
        {
            if (Owner is not AvaloniaWindow w) throw new InvalidOperationException("{nameof(Owner)} must be set before calling {nameof(ShowDialogAsync)}");

            return Ref.ShowDialog<bool?>(w.Ref);
        }

        /// <inheritdoc />
        public void Show() => Ref.Show();
    }
}
