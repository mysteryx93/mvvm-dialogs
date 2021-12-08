using System;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.Wpf;
using Ookii.Dialogs.Wpf;

namespace Demo.CustomFolderBrowserDialog
{
    public class CustomFolderBrowserDialog : IFrameworkDialog
    {
        private readonly OpenFolderDialogSettings settings;
        private readonly VistaFolderBrowserDialog folderBrowserDialog;

        /// <summary>
        /// Initializes a new instance of the <see cref="FolderBrowserDialogWrapper"/> class.
        /// </summary>
        /// <param name="settings">The settings for the folder browser dialog.</param>
        public CustomFolderBrowserDialog(OpenFolderDialogSettings settings)
        {
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));

            folderBrowserDialog = new VistaFolderBrowserDialog
            {
                Description = settings.Description,
                SelectedPath = settings.SelectedPath,
                ShowNewFolderButton = settings.ShowNewFolderButton
            };
        }

        /// <summary>
        /// Opens a folder browser dialog with specified owner.
        /// </summary>
        /// <param name="owner">
        /// Handle to the window that owns the dialog.
        /// </param>
        /// <returns>
        /// true if user clicks the OK or YES button; otherwise false.
        /// </returns>
        public bool? ShowDialog(IWindow owner)
        {
            if (owner == null) throw new ArgumentNullException(nameof(owner));
            if (owner is not WindowWrapper w) throw new ArgumentException($"{nameof(owner)} must be of type {nameof(WindowWrapper)}");

            var result = folderBrowserDialog.ShowDialog(w.Ref);

            // Update settings
            settings.SelectedPath = folderBrowserDialog.SelectedPath;

            return result;
        }
    }
}
