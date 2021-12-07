
using System.Linq;

namespace MvvmDialogs.FrameworkDialogs
{
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
        /// Gets or sets a value indicating whether the read-only check box displayed by the open
        /// file dialog is selected.
        /// </summary>
        /// <value>
        /// <c>true</c> if the checkbox is selected; otherwise, <c>false</c>. The default is
        /// <c>false</c>.
        /// </value>
        public bool ReadOnlyChecked { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the open file dialog contains a read-only check
        /// box.
        /// </summary>
        /// <value>
        /// <c>true</c> if the checkbox is displayed; otherwise, <c>false</c>. The default is
        /// <c>false</c>.
        /// </value>
        public bool ShowReadOnly { get; set; }

        /// <summary>
        /// Gets or sets a string containing the full path of the file selected in a file dialog.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> that is the full path of the file selected in the file dialog.
        /// The default is <see cref="string.Empty"/>.
        /// </value>
        /// <remarks>
        /// If more than one file name is selected (length of <see cref="FileNames"/> is greater
        /// than one) then <see cref="FileName"/> contains the first selected file name. If no file
        /// name is selected, this property contains <see cref="string.Empty"/> rather than
        /// <c>null</c>.
        /// </remarks>
        public string? FileName => FileNames.FirstOrDefault();

        /// <summary>
        /// Gets an array that contains one file name for each selected file.
        /// </summary>
        /// <value>
        /// An array of <see cref="string"/> that contains one file name for each selected file.
        /// The default is an array with a single item whose value is <see cref="string.Empty"/>.
        /// </value>
        public string[] FileNames { get; set; } = { string.Empty };
    }
}
