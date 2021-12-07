using MessageBox.Avalonia.Enums;

namespace MvvmDialogs.Avalonia
{
    /// <summary>
    /// Provides Avalonia-specific application-wide settings.
    /// Settings can be overriden for individual calls by specifying the optional appSettings parameter.
    /// </summary>
    public class AppDialogSettings : AppDialogSettingsBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether whether the Help button is displayed in the file dialog.
        /// </summary>
        public Style MessageBoxStyle { get; set; }
    }
}
