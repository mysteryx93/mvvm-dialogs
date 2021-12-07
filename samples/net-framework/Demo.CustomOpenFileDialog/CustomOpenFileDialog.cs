using System;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.Wpf;
using Ookii.Dialogs.Wpf;

namespace Demo.CustomOpenFileDialog
{
    public class CustomOpenFileDialog : IFrameworkDialog
    {
        private readonly OpenFileDialogSettings settings;
        private readonly VistaOpenFileDialog openFileDialog;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomOpenFileDialog"/> class.
        /// </summary>
        /// <param name="settings">The settings for the open file dialog.</param>
        public CustomOpenFileDialog(OpenFileDialogSettings settings)
        {
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));

            openFileDialog = new VistaOpenFileDialog
            {
                AddExtension = settings.AddExtension,
                CheckFileExists = settings.CheckFileExists,
                CheckPathExists = settings.CheckPathExists,
                DefaultExt = settings.DefaultExt,
                FileName = settings.FileName,
                Filter = settings.Filter,
                FilterIndex = settings.FilterIndex,
                InitialDirectory = settings.InitialDirectory,
                Multiselect = settings.Multiselect,
                Title = settings.Title
            };
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
        public bool? ShowDialog(IWindow owner)
        {
            if (owner == null) throw new ArgumentNullException(nameof(owner));
            if (owner is not WindowWrapper w) throw new ArgumentException($"{nameof(owner)} must be of type {typeof(WindowWrapper)}");

            var result = openFileDialog.ShowDialog(w.Ref);

            // Update settings
            settings.FileName = openFileDialog.FileName;
            settings.FileNames = openFileDialog.FileNames;
            settings.FilterIndex = openFileDialog.FilterIndex;

            return result;
        }
    }
}
