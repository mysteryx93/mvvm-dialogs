using System;
using System.Threading.Tasks;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.Wpf;
using Ookii.Dialogs.Wpf;

namespace Demo.CustomSaveFileDialog
{
    public class CustomSaveFileDialog : IFrameworkDialog
    {
        private readonly SaveFileDialogSettings settings;
        private readonly VistaSaveFileDialog saveFileDialog;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomSaveFileDialog"/> class.
        /// </summary>
        /// <param name="settings">The settings for the save file dialog.</param>
        public CustomSaveFileDialog(SaveFileDialogSettings settings)
        {
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));

            saveFileDialog = new VistaSaveFileDialog
            {
                AddExtension = settings.AddExtension,
                CheckFileExists = settings.CheckFileExists,
                CheckPathExists = settings.CheckPathExists,
                CreatePrompt = settings.CreatePrompt,
                DefaultExt = settings.DefaultExt,
                FileName = settings.FileName,
                Filter = settings.Filter,
                FilterIndex = settings.FilterIndex,
                InitialDirectory = settings.InitialDirectory,
                OverwritePrompt = settings.OverwritePrompt,
                Title = settings.Title
            };
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
        public async Task<bool?> ShowDialogAsync(IWindow owner)
        {
            if (owner == null) throw new ArgumentNullException(nameof(owner));
            if (owner is not WpfWindow w) throw new ArgumentException($"{nameof(owner)} must be of type {typeof(WpfWindow)}");

            var result = await Task.Run(() => saveFileDialog.ShowDialog(w.Ref));

            // Update settings
            settings.FileName = saveFileDialog.FileName;
            settings.FileNames = saveFileDialog.FileNames;
            settings.FilterIndex = saveFileDialog.FilterIndex;

            return result;
        }
    }
}
