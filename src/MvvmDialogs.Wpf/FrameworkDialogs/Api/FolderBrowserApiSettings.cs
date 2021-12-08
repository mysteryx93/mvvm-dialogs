
namespace MvvmDialogs.Wpf.FrameworkDialogs.Api
{
    public class FolderBrowserApiSettings
    {
        public string Description { get; set; } = string.Empty;
        public string? SelectedPath { get; set; } = string.Empty;
        public bool ShowNewFolderButton { get; set; } = true;

        internal void ApplyTo(System.Windows.Forms.FolderBrowserDialog d)
        {
            d.Description = Description;
            d.SelectedPath = SelectedPath;
            d.ShowNewFolderButton = ShowNewFolderButton;
        }

        internal void ResultsFrom(System.Windows.Forms.FolderBrowserDialog d) => SelectedPath = d.SelectedPath;
    }
}
