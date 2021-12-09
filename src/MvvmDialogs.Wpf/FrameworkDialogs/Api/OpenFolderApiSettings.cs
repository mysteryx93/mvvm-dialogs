
using System;

namespace MvvmDialogs.Wpf.FrameworkDialogs.Api
{
    internal class OpenFolderApiSettings
    {
        public string Description { get; set; } = string.Empty;
        public string? SelectedPath { get; set; } = string.Empty;
        public bool ShowNewFolderButton { get; set; } = true;
        public EventHandler? HelpRequest { get; set; }

        internal void ApplyTo(System.Windows.Forms.FolderBrowserDialog d)
        {
            d.Description = Description;
            d.SelectedPath = SelectedPath;
            d.ShowNewFolderButton = ShowNewFolderButton;
            if (HelpRequest != null)
            {
                d.HelpRequest += HelpRequest;
            }
        }
    }
}
