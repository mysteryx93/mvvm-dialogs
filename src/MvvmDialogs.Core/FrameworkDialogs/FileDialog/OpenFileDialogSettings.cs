
using System;

namespace MvvmDialogs.Core.FrameworkDialogs
{
    /// <summary>
    /// Settings for OpenFileDialog.
    /// </summary>
    public class OpenFileDialogSettings : FileDialogSettings
    {
        /// <summary>
        /// Gets or sets an option indicating whether the dialog box allows users to select
        /// multiple files.
        /// </summary>
        /// <value>
        /// <c>true</c> if multiple selections are allowed; otherwise, <c>false</c>. The default is
        /// <c>false</c>.
        /// </value>
        public bool Multiselect { get; set; }

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
        /// Gets a string that only contains the file name for the selected file.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> that only contains the file name for the selected file. The
        /// default is <see cref="string.Empty"/>, which is also the value when either no file is
        /// selected or a directory is selected.
        /// </value>
        /// <remarks>
        /// This value is the <see cref="FileDialogSettings.FileName"/> with all path information removed. Removing
        /// the paths makes the value appropriate for use in partial trust applications, since it
        /// prevents applications from discovering information about the local file system.
        /// <para/>
        /// If more than one file name is selected (length of <see cref="SafeFileNames"/> is
        /// greater than one) then this property contains only the first selected file name.
        /// </remarks>
        public string? SafeFileName { get; set; }

        /// <summary>
        /// Gets an array that contains one safe file name for each selected file.
        /// </summary>
        /// <value>
        /// An array of <see cref="string"/> that contains one safe file name for each selected
        /// file. The default is an array with a single item whose value is
        /// <see cref="string.Empty"/>.
        /// </value>
        /// <remarks>
        /// This value is the <see cref="FileDialogSettings.FileNames"/> with all path information removed. Removing
        /// the paths makes the value appropriate for use in partial trust applications, since it
        /// prevents applications from discovering information about the local file system.
        /// </remarks>
        public string[] SafeFileNames { get; set; } = Array.Empty<string>();
    }
}
