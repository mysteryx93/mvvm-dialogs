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

        /// <summary>
        /// Creates a copy of this class. Useful to customize settings for specific calls.
        /// </summary>
        /// <returns>A copy of this class.</returns>
        public AppDialogSettings Clone() => (AppDialogSettings)this.MemberwiseClone();
    }
}
