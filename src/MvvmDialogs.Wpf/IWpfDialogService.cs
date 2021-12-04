using System.ComponentModel;
using System.Windows;
using MvvmDialogs.Core;
using MvvmDialogs.Wpf.FrameworkDialogs.FolderBrowser;
using MvvmDialogs.Wpf.FrameworkDialogs.MessageBox;
using MvvmDialogs.Wpf.FrameworkDialogs.OpenFile;
using MvvmDialogs.Wpf.FrameworkDialogs.SaveFile;

namespace MvvmDialogs.Wpf
{
    public interface IWpfDialogService
    {
        /// <summary>
        /// Displays a message box that has a message, title bar caption, button, and icon; and
        /// that accepts a default message box result and returns a result.
        /// </summary>
        /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
        /// <param name="messageBoxText">A <see cref="string"/> that specifies the text to display.</param>
        /// <param name="caption">A <see cref="string"/> that specifies the title bar caption to display. Default valueis an empty string.</param>
        /// <param name="button">A <see cref="MessageBoxButton"/> value that specifies which button or buttons to display.
        /// Default value is <see cref="MessageBoxButton.OK"/>.</param>
        /// <param name="icon">A <see cref="MessageBoxImage"/> value that specifies the icon to display.
        /// Default value is <see cref="MessageBoxImage.None"/>.
        /// </param>
        /// <param name="defaultResult">A <see cref="MessageBoxResult"/> value that specifies the default result of the message box.
        /// Default value is <see cref="MessageBoxResult.None"/>.</param>
        /// <returns>A <see cref="MessageBoxResult"/> value that specifies which message box button is clicked by the user.</returns>
        /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
        public MessageBoxResult ShowMessageBox(
            INotifyPropertyChanged ownerViewModel,
            string? messageBoxText,
            string caption = "",
            MessageBoxButton button = MessageBoxButton.OK,
            MessageBoxImage icon = MessageBoxImage.None,
            MessageBoxResult defaultResult = MessageBoxResult.None);

        /// <summary>
        /// Displays a message box that has a message, title bar caption, button, and icon; and
        /// that accepts a default message box result and returns a result.
        /// </summary>
        /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
        /// <param name="settings">The settings for the message box dialog.</param>
        /// <returns>A <see cref="MessageBoxResult"/> value that specifies which message box button is clicked by the user.</returns>
        /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
        public MessageBoxResult ShowMessageBox(INotifyPropertyChanged ownerViewModel, MessageBoxSettings settings);

        /// <summary>
        /// Displays the <see cref="OpenFileDialog"/>.
        /// </summary>
        /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
        /// <param name="settings">The settings for the open file dialog.</param>
        /// <returns>If the user clicks the OK button of the dialog that is displayed, true is returned; otherwise false.</returns>
        /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
        public bool? ShowOpenFileDialog(INotifyPropertyChanged ownerViewModel, OpenFileDialogSettings settings);

        /// <summary>
        /// Displays the <see cref="SaveFileDialog"/>.
        /// </summary>
        /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
        /// <param name="settings">The settings for the save file dialog.</param>
        /// <returns>If the user clicks the OK button of the dialog that is displayed, true is returned; otherwise false.</returns>
        /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
        public bool? ShowSaveFileDialog(INotifyPropertyChanged ownerViewModel, SaveFileDialogSettings settings);

        /// <summary>
        /// Displays the <see cref="FolderBrowserDialog"/>.
        /// </summary>
        /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
        /// <param name="settings">The settings for the folder browser dialog.</param>
        /// <returns>If the user clicks the OK button of the dialog that is displayed, true is returned; otherwise false.</returns>
        /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
        public bool? ShowFolderBrowserDialog(INotifyPropertyChanged ownerViewModel, FolderBrowserDialogSettings settings);
    }
}
