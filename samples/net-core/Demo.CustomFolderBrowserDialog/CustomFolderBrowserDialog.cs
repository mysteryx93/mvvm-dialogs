using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.Wpf;
using MvvmDialogs.Wpf.FrameworkDialogs;
using Ookii.Dialogs.Wpf;

namespace Demo.CustomFolderBrowserDialog
{
    public class CustomFolderBrowserDialog : WpfFrameworkDialogBase<FolderBrowserDialogSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FolderBrowserDialogWrapper"/> class.
        /// </summary>
        /// <param name="settings">The settings for the folder browser dialog.</param>
        public CustomFolderBrowserDialog(FolderBrowserDialogSettings settings)
            : base(settings)
        {
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
        public override bool? ShowDialogAsync(WpfWindow owner)
        {
            var folderBrowserDialog = new VistaFolderBrowserDialog
            {
                Description = Settings.Description, SelectedPath = Settings.SelectedPath, ShowNewFolderButton = Settings.ShowNewFolderButton
            };

            var result = folderBrowserDialog.ShowDialog(owner.Ref);

            Settings.SelectedPath = folderBrowserDialog.SelectedPath;
            return result;
        }
    }
}
