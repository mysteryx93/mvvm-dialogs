using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.Wpf;
using MvvmDialogs.Wpf.FrameworkDialogs;
using Ookii.Dialogs.Wpf;

namespace Demo.CustomSaveFileDialog
{
    public class CustomSaveFileDialog : FrameworkDialogBase<SaveFileDialogSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomSaveFileDialog"/> class.
        /// </summary>
        /// <param name="settings">The settings for the save file dialog.</param>
        public CustomSaveFileDialog(SaveFileDialogSettings settings)
            : base(settings)
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
        public override bool? ShowDialogAsync(WindowWrapper owner)
        {
            var saveFileDialog = new VistaSaveFileDialog
            {
                AddExtension = Settings.AddExtension,
                CheckFileExists = Settings.CheckFileExists,
                CheckPathExists = Settings.CheckPathExists,
                CreatePrompt = Settings.CreatePrompt,
                DefaultExt = Settings.DefaultExt,
                FileName = Settings.FileName,
                Filter = Settings.Filter,
                FilterIndex = Settings.FilterIndex,
                InitialDirectory = Settings.InitialDirectory,
                OverwritePrompt = Settings.OverwritePrompt,
                Title = Settings.Title
            };

            var result = saveFileDialog.ShowDialog(owner.Ref);

            // Update settings
            Settings.FileName = saveFileDialog.FileName;
            Settings.FileNames = saveFileDialog.FileNames;
            Settings.FilterIndex = saveFileDialog.FilterIndex;

            return result;
        }
    }
}
