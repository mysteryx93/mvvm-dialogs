using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.Wpf;
using MvvmDialogs.Wpf.FrameworkDialogs;
using Ookii.Dialogs.Wpf;

namespace Demo.CustomFolderBrowserDialog
{
    public class CustomOpenFolderDialog : IFrameworkDialog<string?>, IFrameworkDialogSync<string?>
    {
        private readonly OpenFolderDialogSettings settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="FolderBrowserDialogWrapper"/> class.
        /// </summary>
        /// <param name="settings">The settings for the folder browser dialog.</param>
        public CustomOpenFolderDialog(OpenFolderDialogSettings settings, AppDialogSettings appSettings)
        {
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public string? ShowDialog(IWindow owner)
        {
            if (owner == null) throw new ArgumentNullException(nameof(owner));

            var folderBrowserDialog = new VistaFolderBrowserDialog
            {
                Description = settings.Title,
                SelectedPath = settings.InitialPath
            };

            var wOwner = (WindowWrapper)owner;
            var wih = new WindowInteropHelper(wOwner.Ref);
            var result = folderBrowserDialog.ShowDialog(wih.Handle);
            return result == true ? folderBrowserDialog.SelectedPath : null;
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
        public async Task<string?> ShowDialogAsync(IWindow owner)
        {
            if (owner == null) throw new ArgumentNullException(nameof(owner));

            var folderBrowserDialog = new VistaFolderBrowserDialog
            {
                Description = settings.Title,
                SelectedPath = settings.InitialPath
            };

            var wOwner = (Window)owner;
            var wih = new WindowInteropHelper(wOwner);
            var result = await wOwner.RunUiAsync(() => folderBrowserDialog.ShowDialog(wih.Handle)).ConfigureAwait(true);
            return result == true ? folderBrowserDialog.SelectedPath : null;
        }
    }
}
