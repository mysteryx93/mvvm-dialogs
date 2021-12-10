using System.Threading.Tasks;
using System.Windows;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.Wpf;
using MvvmDialogs.Wpf.FrameworkDialogs;
using Ookii.Dialogs.Wpf;

namespace Demo.CustomFolderBrowserDialog
{
    public class CustomOpenFolderDialog : FrameworkDialogBase<OpenFolderDialogSettings, string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomOpenFolderDialog"/> class.
        /// </summary>
        /// <param name="settings">The settings for the folder browser dialog.</param>
        /// <param name="appSettings">Application-wide settings configured on the DialogService.</param>
        public CustomOpenFolderDialog(OpenFolderDialogSettings settings, AppDialogSettings appSettings)
            : base(settings, appSettings)
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
        public override Task<string> ShowDialogAsync(WindowWrapper owner)
        {
            var folderBrowserDialog = new VistaFolderBrowserDialog
            {
                Description = Settings.Title,
                SelectedPath = Settings.InitialPath,
                ShowNewFolderButton = Settings.ShowNewFolderButton
            };

            var result = folderBrowserDialog.ShowDialog(owner.Ref);
            return Task.FromResult(result == true ? Settings.InitialPath : null);
        }

        public static async Task<bool?> ShowDialogAsync(VistaFolderBrowserDialog @this, Window owner)
        {
            await Task.Yield();
            if (!owner.IsLoaded)
                return false;
            return @this.ShowDialog(owner);
        }
    }
}
