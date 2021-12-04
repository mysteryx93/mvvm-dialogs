using MvvmDialogs.Wpf.FrameworkDialogs.FolderBrowser;
using MvvmDialogs.Wpf.FrameworkDialogs.MessageBox;
using MvvmDialogs.Wpf.FrameworkDialogs.OpenFile;
using MvvmDialogs.Wpf.FrameworkDialogs.SaveFile;

namespace MvvmDialogs.Wpf.FrameworkDialogs
{
    /// <summary>
    /// Interface responsible for creating framework dialogs.
    /// </summary>
    public interface IFrameworkDialogFactory
    {
        /// <summary>
        /// Create an instance of the Windows message box.
        /// </summary>
        /// <param name="settings">The settings for the message box.</param>
        IMessageBox CreateMessageBox(MessageBoxSettings settings);

        /// <summary>
        /// Create an instance of the Windows open file dialog.
        /// </summary>
        /// <param name="settings">The settings for the open file dialog.</param>
        IFrameworkDialog CreateOpenFileDialog(OpenFileDialogSettings settings);

        /// <summary>
        /// Create an instance of the Windows save file dialog.
        /// </summary>
        /// <param name="settings">The settings for the save file dialog.</param>
        IFrameworkDialog CreateSaveFileDialog(SaveFileDialogSettings settings);

        /// <summary>
        /// Create an instance of the Windows folder browser dialog.
        /// </summary>
        /// <param name="settings">The settings for the folder browser dialog.</param>
        IFrameworkDialog CreateFolderBrowserDialog(FolderBrowserDialogSettings settings);
    }
}
