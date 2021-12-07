using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.Wpf;
using MvvmDialogs.Wpf.FrameworkDialogs;
using Ookii.Dialogs.Wpf;

namespace Demo.CustomOpenFileDialog
{
    public class CustomOpenFileDialog : FrameworkDialogBase<OpenFileDialogSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomOpenFileDialog"/> class.
        /// </summary>
        /// <param name="settings">The settings for the open file dialog.</param>
        public CustomOpenFileDialog(OpenFileDialogSettings settings)
            : base(settings)
        {
        }

        /// <summary>
        /// Opens a open file dialog with specified owner.
        /// </summary>
        /// <param name="owner">
        /// Handle to the window that owns the dialog.
        /// </param>
        /// <returns>
        /// true if user clicks the OK button; otherwise false.
        /// </returns>
        public override bool? ShowDialogAsync(WindowWrapper owner)
        {
            var openFileDialog = new VistaOpenFileDialog
            {
                AddExtension = Settings.AddExtension,
                CheckFileExists = Settings.CheckFileExists,
                CheckPathExists = Settings.CheckPathExists,
                DefaultExt = Settings.DefaultExt,
                FileName = Settings.FileName,
                Filter = Settings.Filter,
                FilterIndex = Settings.FilterIndex,
                InitialDirectory = Settings.InitialDirectory,
                Multiselect = Settings.Multiselect,
                Title = Settings.Title
            };

            var result = openFileDialog.ShowDialog(owner.Ref);

            // Update settings
            Settings.FileName = openFileDialog.FileName;
            Settings.FileNames = openFileDialog.FileNames;
            Settings.FilterIndex = openFileDialog.FilterIndex;

            return result;
        }
    }
}
