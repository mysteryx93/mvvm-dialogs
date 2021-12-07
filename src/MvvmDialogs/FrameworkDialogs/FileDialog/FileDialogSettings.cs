
namespace MvvmDialogs.FrameworkDialogs
{
    /// <summary>
    /// Settings for FileDialog.
    /// </summary>
    public abstract class FileDialogSettings
    {
        /// <summary>
        /// Gets or sets a value that specifies the default extension string to use to filter the
        /// list of files that are displayed.
        /// </summary>
        /// <value>
        /// The default extension string. The default is <see cref="string.Empty"/>.
        /// </value>
        /// <remarks>
        /// The extension string must contain the leading period. For example, set the
        /// <see cref="DefaultExt"/> property to ".txt" to select all text files.
        /// <para/>
        /// </remarks>
        public string DefaultExt { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether a file dialog displays a warning if the user
        /// specifies a file name that does not exist.
        /// </summary>
        /// <value>
        /// <c>true</c> if warnings are displayed; otherwise, <c>false</c>. The default in this
        /// class is <c>true</c>.
        /// </value>
        public bool CheckFileExists { get; set; } = true;

        /// <summary>
        /// Gets or sets a value that specifies whether warnings are displayed if the user types
        /// invalid paths and file names.
        /// </summary>
        /// <value>
        /// <c>true</c> if warnings are displayed; otherwise, <c>false</c>. The default is
        /// <c>true</c>.
        /// </value>
        public bool CheckPathExists { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether a file dialog returns either the location of
        /// the file referenced by a shortcut or the location of the shortcut file (.lnk).
        /// </summary>
        /// <value>
        /// <c>true</c> to return the location referenced; <c>false</c> to return the shortcut
        /// location. The default is <c>true</c>.
        /// </value>
        public bool DereferenceLinks { get; set; } = true;

        /// <summary>
        ///
        /// </summary>
        public string Filter { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the initial directory that is displayed by a file dialog.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> that contains the initial directory. The default is
        /// <see cref="string.Empty"/>.
        /// </value>
        /// <remarks>
        /// If there is no initial directory set, this property will contain
        /// <see cref="string.Empty"/> rather than a <c>null</c> string.
        /// </remarks>
        public string InitialDirectory { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the text that appears in the title bar of a file dialog.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> that is the text that appears in the title bar of a file dialog.
        /// The default is <see cref="string.Empty"/>.
        /// </value>
        /// <remarks>
        /// If <see cref="Title"/> is <c>null</c> or <see cref="string.Empty"/>, a default,
        /// localized value is used, such as "Save As" or "Open".
        /// </remarks>
        public string Title { get; set; } = string.Empty;
    }
}
