﻿using System.Collections.Generic;

namespace MvvmDialogs.FrameworkDialogs
{
    /// <summary>
    /// Settings for FileDialog.
    /// </summary>
    public abstract class FileDialogSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether a file dialog automatically adds an extension
        /// to a file name if the user omits an extension.
        /// </summary>
        /// <value>
        /// <c>true</c> if extensions are added; otherwise, <c>false</c>. The default is
        /// <c>true</c>.
        /// </value>
        public bool AddExtension { get; set; } = true;

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
         /// Gets or sets the list of custom places for file dialog boxes.
         /// </summary>
         /// <value>
         /// The list of custom places.
         /// </value>
         /// <remarks>
         /// Starting in Windows Vista, open and save file dialog boxes have a <b>Favorite Links</b>
         /// panel on the left side of the dialog box that allows the user to quickly navigate to a
         /// different location. These links are called custom places. This property allows you to
         /// modify the list that appears when your application uses a file dialog box.
         /// </remarks>
         public IList<FileDialogCustomPlace> CustomPlaces { get; set; } = new List<FileDialogCustomPlace>();



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
        /// Gets or sets a value indicating whether whether the Help button is displayed in the file dialog.
        /// </summary>
        public bool ShowHelp { get; set; }

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
