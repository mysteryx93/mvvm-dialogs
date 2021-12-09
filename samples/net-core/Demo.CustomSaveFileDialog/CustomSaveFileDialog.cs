using System.IO;
using System.Threading.Tasks;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.Wpf;
using MvvmDialogs.Wpf.FrameworkDialogs;
using Ookii.Dialogs.Wpf;

namespace Demo.CustomSaveFileDialog
{
    public class CustomSaveFileDialog : FrameworkDialogBase<SaveFileDialogSettings, string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomSaveFileDialog"/> class.
        /// </summary>
        /// <param name="settings">The settings for the save file dialog.</param>
        /// <param name="appSettings">Application-wide settings configured on the DialogService.</param>
        public CustomSaveFileDialog(SaveFileDialogSettings settings, AppDialogSettings appSettings)
            : base(settings, appSettings)
        {
        }

        /// <summary>
        /// Opens a save file dialog with specified owner.
        /// </summary>
        /// <param name="owner">
        /// Handle to the window that owns the dialog.
        /// </param>
        /// <returns>
        /// true if user clicks the OK button; otherwise false.
        /// </returns>
        public override Task<string> ShowDialogAsync(WindowWrapper owner)
        {
            var s = Settings;
            var fileInfo = !string.IsNullOrEmpty(s.InitialPath) ? new FileInfo(s.InitialPath) : null;
            var saveFileDialog = new VistaSaveFileDialog
            {
                AddExtension = !string.IsNullOrEmpty(s.DefaultExtension),
                CheckFileExists = s.CheckFileExists,
                CheckPathExists = s.CheckPathExists,
                CreatePrompt = s.CreatePrompt,
                DefaultExt = s.DefaultExtension,
                FileName = fileInfo?.Name,
                InitialDirectory = fileInfo?.DirectoryName,
                OverwritePrompt = s.OverwritePrompt,
                Title = s.Title
                // Filter = s.Filter,
            };

            var result = saveFileDialog.ShowDialog(owner.Ref);
            return Task.FromResult(result == true ? saveFileDialog.FileName : null);
        }
    }
}
