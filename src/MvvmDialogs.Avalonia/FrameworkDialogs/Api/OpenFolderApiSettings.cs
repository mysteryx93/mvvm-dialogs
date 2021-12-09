﻿using AvaloniaOpenFolderDialog = Avalonia.Controls.OpenFolderDialog;

namespace MvvmDialogs.Avalonia.FrameworkDialogs.Api
{
    internal class OpenFolderApiSettings
    {
        public string? Title { get; set; }
        public string? Directory { get; set; }

        internal void ApplyTo(AvaloniaOpenFolderDialog d)
        {
            d.Title = Title;
            d.Directory = Directory;
        }
    }
}
