using MvvmDialogs.Wpf.FrameworkDialogs.FolderBrowser;
using MvvmDialogs.Wpf.FrameworkDialogs.MessageBox;
using MvvmDialogs.Wpf.FrameworkDialogs.OpenFile;
using MvvmDialogs.Wpf.FrameworkDialogs.SaveFile;

namespace MvvmDialogs.Wpf.FrameworkDialogs
{
    /// <summary>
    /// Default framework dialog factory that will create instances of standard Windows dialogs.
    /// </summary>
    public class DefaultFrameworkDialogFactory : IFrameworkDialogFactory
    {
        /// <inheritdoc />
        public virtual IMessageBox CreateMessageBox(MessageBoxSettings settings) => new MessageBoxWrapper(settings);

        /// <inheritdoc />
        public virtual IFrameworkDialog CreateOpenFileDialog(OpenFileDialogSettings settings) => new OpenFileDialogWrapper(settings);

        /// <inheritdoc />
        public virtual IFrameworkDialog CreateSaveFileDialog(SaveFileDialogSettings settings) => new SaveFileDialogWrapper(settings);

        /// <inheritdoc />
        public virtual IFrameworkDialog CreateFolderBrowserDialog(FolderBrowserDialogSettings settings) => new FolderBrowserDialogWrapper(settings);
    }
}
