using MvvmDialogs.Core.FrameworkDialogs;
using MvvmDialogs.Wpf.FrameworkDialogs.MessageBox;

namespace MvvmDialogs.Wpf.FrameworkDialogs
{
    /// <summary>
    /// Default framework dialog factory that will create instances of standard Windows dialogs.
    /// </summary>
    public class WpfFrameworkDialogFactory : IFrameworkDialogFactory
    {
        /// <inheritdoc />
        public virtual IFrameworkDialog CreateMessageBox(MessageBoxSettings settings) => new WpfMessageBox(settings);

        /// <inheritdoc />
        public virtual IFrameworkDialog CreateOpenFileDialog(OpenFileDialogSettings settings) => new WpfOpenFileDialog(settings);

        /// <inheritdoc />
        public virtual IFrameworkDialog CreateSaveFileDialog(SaveFileDialogSettings settings) => new SaveFileDialogWrapper(settings);

        /// <inheritdoc />
        public virtual IFrameworkDialog CreateFolderBrowserDialog(FolderBrowserDialogSettings settings) => new WpfBrowserDialog(settings);
    }
}
