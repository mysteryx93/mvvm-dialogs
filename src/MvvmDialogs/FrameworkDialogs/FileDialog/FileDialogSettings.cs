
using System.Collections.Generic;

namespace MvvmDialogs.FrameworkDialogs
{
    /// <summary>
    /// Settings for FileDialog.
    /// </summary>
    public abstract class FileDialogSettings : DialogSettingsBase
    {
        /// <summary>
        /// Gets or sets the default extension to be used to save the file (including the period ".").
        /// </summary>
        public string DefaultExtension { get; set; } = string.Empty;

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
        /// Gets or sets a collection of filters which determine the types of files displayed in an
        /// OpenFileDialog or SaveFileDialog.
        /// </summary>
        public List<FileFilter> Filters { get; set; } = new List<FileFilter>();

        /// <summary>
        /// Gets or sets the initial path that is displayed by a file dialog.
        /// It will set both the initial directory and initial file name.
        /// </summary>
        public string InitialPath { get; set; } = string.Empty;
    }
}
