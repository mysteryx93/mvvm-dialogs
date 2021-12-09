﻿using AvaloniaOpenFileDialog = Avalonia.Controls.OpenFileDialog;

namespace MvvmDialogs.Avalonia.FrameworkDialogs.Api
{
    internal class OpenFileApiSettings : FileApiSettings
    {
        public bool AllowMultiple { get; set; }

        internal void ApplyTo(AvaloniaOpenFileDialog d)
        {
            base.ApplyTo(d);
            d.AllowMultiple = AllowMultiple;
        }
    }
}
