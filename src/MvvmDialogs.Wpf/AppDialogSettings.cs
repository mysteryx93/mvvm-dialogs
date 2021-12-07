namespace MvvmDialogs.Wpf
{
    /// <summary>
    /// Provides WPF-specific application-wide settings.
    /// Settings can be overriden for individual calls by specifying the optional appSettings parameter.
    /// </summary>
    public class AppDialogSettings : AppDialogSettingsBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether whether the Help button is displayed in the file dialog.
        /// </summary>
        public bool FileShowHelp { get; set; }
        /// <summary>
        /// Gets or sets whether message boxes are displayed right-to-left (RightAlign+RtlReading).
        /// </summary>
        public bool MessageBoxRightToLeft { get; set; }
    }
}
