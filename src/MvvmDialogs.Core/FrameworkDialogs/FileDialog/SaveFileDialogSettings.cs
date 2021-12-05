﻿
namespace MvvmDialogs.Core.FrameworkDialogs
{
    /// <summary>
    /// Settings for SaveFileDialog.
    /// </summary>
    public class SaveFileDialogSettings : FileDialogSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether the dialog box prompts the user for permission
        /// to create a file if the user specifies a file that does not exist.
        /// </summary>
        /// <value>
        /// <c>true</c> if dialog should prompt prior to saving to a filename that did not
        /// previously exist; otherwise, <c>false</c>. The default is <c>false</c>.
        /// </value>
        public bool CreatePrompt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the dialog box displays a warning if the user
        /// specifies the name of a file that already exists.
        /// </summary>
        /// <value>
        /// <c>true</c> if dialog should prompt prior to saving over a filename that previously
        /// existed; otherwise, <c>false</c>. The default is <c>true</c>.
        /// </value>
        public bool OverwritePrompt { get; set; }
    }
}