
namespace MvvmDialogs.FrameworkDialogs;

/// <summary>
/// Settings for OpenFileDialog.
/// </summary>
public class OpenFileDialogSettings : FileDialogSettings
{
    /// <summary>
    /// Gets or sets a value indicating whether the user can select multiple files.
    /// </summary>
    public bool AllowMultiple { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the open file dialog contains a read-only check box.
    /// Only supported in WPF.
    /// </summary>
    public bool ShowReadOnly { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the read-only check box displayed by the open file dialog is selected.
    /// </summary>
    public bool ReadOnlyChecked { get; set; }
}