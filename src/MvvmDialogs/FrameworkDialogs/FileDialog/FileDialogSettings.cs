﻿
using System;
using System.Collections.Generic;

namespace MvvmDialogs.FrameworkDialogs
{
    /// <summary>
    /// Settings for FileDialog.
    /// </summary>
    public abstract class FileDialogSettings : DialogSettingsBase
    {
        /// <summary>
        /// Gets or sets the default extension to be used (including the period ".")
        /// if not set by the user or by a filter
        /// </summary>
        public string DefaultExtension { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether a file dialog displays a warning if the user
        /// specifies a file name that does not exist.
        /// </summary>
        public bool CheckFileExists { get; set; } = true;

        /// <summary>
        /// Gets or sets a value that specifies whether warnings are displayed if the user types
        /// invalid paths and file names.
        /// </summary>
        public bool CheckPathExists { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether a file dialog returns either the location of
        /// the file referenced by a shortcut or the location of the shortcut file (.lnk).
        /// </summary>
        public bool DereferenceLinks { get; set; } = true;

        /// <summary>
        /// Gets or sets a collection of filters which determine the types of files displayed in an
        /// OpenFileDialog or SaveFileDialog.
        /// </summary>
        /// <remarks>
        /// The '.' in extensions is optional. Extensions will automatically be added
        /// to the descriptions unless it contains '('.
        /// If you do not wish to display extensions, end the name with '()' and it will be trimmed away.
        /// </remarks>
        public List<FileFilter> Filters { get; set; } = new List<FileFilter>();

        /// <summary>
        /// Gets or sets the initial path that is displayed by a file dialog.
        /// It will set both the initial directory and initial file name.
        /// </summary>
        public string InitialPath { get; set; } = string.Empty;

        /// <summary>
        /// Callback to invoke when the user clicks the help button. Setting this will display a help button.
        /// </summary>
        public EventHandler? HelpRequest { get; set; }
    }
}
