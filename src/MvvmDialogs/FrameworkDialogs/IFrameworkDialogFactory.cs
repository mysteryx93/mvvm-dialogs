
namespace MvvmDialogs.FrameworkDialogs
{
    /// <summary>
    /// Interface responsible for creating framework dialogs.
    /// </summary>
    public interface IFrameworkDialogFactory
    {
        /// <summary>
        /// Creates an <see cref="IFrameworkDialog"/> with specified settings,
        /// based on settings type as configured in the implementation of this class.
        /// </summary>
        /// <param name="settings">The settings to pass to the <see cref="IFrameworkDialog"/></param>
        /// <typeparam name="T">The settings type used to determine the implementation of <see cref="IFrameworkDialog"/> to create.</typeparam>
        /// <returns>A framework dialog implementing <see cref="IFrameworkDialog"/>.</returns>
        IFrameworkDialog Create<T>(T settings);

        // /// <summary>
        // /// Create an instance of the Windows message box.
        // /// </summary>
        // /// <param name="settings">The settings for the message box.</param>
        // IFrameworkDialog CreateMessageBox(MessageBoxSettings settings);
        //
        // /// <summary>
        // /// Create an instance of the Windows open file dialog.
        // /// </summary>
        // /// <param name="settings">The settings for the open file dialog.</param>
        // IFrameworkDialog CreateOpenFileDialog(OpenFileDialogSettings settings);
        //
        // /// <summary>
        // /// Create an instance of the Windows save file dialog.
        // /// </summary>
        // /// <param name="settings">The settings for the save file dialog.</param>
        // IFrameworkDialog CreateSaveFileDialog(SaveFileDialogSettings settings);
        //
        // /// <summary>
        // /// Create an instance of the Windows folder browser dialog.
        // /// </summary>
        // /// <param name="settings">The settings for the folder browser dialog.</param>
        // IFrameworkDialog CreateFolderBrowserDialog(FolderBrowserDialogSettings settings);
    }
}
