using System.ComponentModel;
using MvvmDialogs.Core.FrameworkDialogs;

namespace MvvmDialogs.Core
{
    /// <summary>
    /// Interface abstracting the interaction between view models and views when it comes to
    /// opening dialogs using the MVVM pattern in WPF.
    /// </summary>
    public interface IDialogService
    {
        /// <summary>
        /// Displays a non-modal dialog of a type that is determined by the dialog type locator.
        /// </summary>
        /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
        /// <param name="viewModel">The view model of the new dialog.</param>
        /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
        void Show(INotifyPropertyChanged ownerViewModel, INotifyPropertyChanged viewModel);

        /// <summary>
        /// Displays a non-modal dialog of specified type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
        /// <param name="viewModel">The view model of the new dialog.</param>
        /// <typeparam name="T">The type of the dialog to show.</typeparam>
        /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
        void Show<T>(INotifyPropertyChanged ownerViewModel, INotifyPropertyChanged viewModel); //where T : TWindow;

        /// <summary>
        /// Displays a non-modal dialog of specified type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
        /// <param name="viewModel">The view model of the new dialog.</param>
        /// <typeparam name="T">The type of the dialog to show.</typeparam>
        /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
        void ShowCustom<T>(INotifyPropertyChanged ownerViewModel, INotifyPropertyChanged viewModel) where T : IWindow;

        /// <summary>
        /// Displays a modal dialog of a type that is determined by the dialog type locator.
        /// </summary>
        /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
        /// <param name="viewModel">The view model of the new dialog.</param>
        /// <returns>A nullable value of type <see cref="bool"/> that signifies how a window was closed by the user.</returns>
        /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
        bool? ShowDialog(INotifyPropertyChanged ownerViewModel, IModalDialogViewModel viewModel);

        /// <summary>
        /// Displays a modal dialog of specified type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
        /// <param name="viewModel">The view model of the new dialog.</param>
        /// <typeparam name="T">The type of the dialog to show.</typeparam>
        /// <returns>A nullable value of type <see cref="bool"/> that signifies how a window was closed by the user.</returns>
        /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
        bool? ShowDialog<T>(INotifyPropertyChanged ownerViewModel, IModalDialogViewModel viewModel); // where T : TWindow;

        /// <summary>
        /// Displays a modal dialog of specified type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
        /// <param name="viewModel">The view model of the new dialog.</param>
        /// <typeparam name="T">The type of the dialog to show.</typeparam>
        /// <returns>A nullable value of type <see cref="bool"/> that signifies how a window was closed by the user.</returns>
        /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
        bool? ShowCustomDialog<T>(INotifyPropertyChanged ownerViewModel, IModalDialogViewModel viewModel) where T : IWindow;

        /// <summary>
        /// Attempts to bring the window to the foreground and activates it.
        /// </summary>
        /// <param name="viewModel">The view model of the window.</param>
        /// <returns>true if the window was successfully activated; otherwise, false.</returns>
        bool Activate(INotifyPropertyChanged viewModel);

        /// <summary>
        /// Closes a non-modal dialog that previously was opened using <see cref="Show"/>,
        /// <see cref="Show{T}"/> or <see cref="ShowCustom{T}"/>.
        /// </summary>
        /// <param name="viewModel">The view model of the dialog to close.</param>
        /// <returns>true if the window was successfully closed; otherwise, false.</returns>
        bool Close(INotifyPropertyChanged viewModel);

        /// <summary>
        /// Displays a message box that has a message, title bar caption, button, and icon; and
        /// that accepts a default message box result and returns a result.
        /// </summary>
        /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
        /// <param name="messageBoxText">A <see cref="string"/> that specifies the text to display.</param>
        /// <param name="caption">A <see cref="string"/> that specifies the title bar caption to display. Default value is an empty string.</param>
        /// <param name="button">A <see cref="MessageBoxButton"/> value that specifies which button or buttons to display.
        /// Default value is <see cref="MessageBoxButton.OK"/>.</param>
        /// <param name="icon">A <see cref="MessageBoxImage"/> value that specifies the icon to display.
        /// Default value is <see cref="MessageBoxImage.None"/>.
        /// </param>
        /// <param name="defaultResult">A <see cref="MessageBoxResult"/> value that specifies the default result of the message box.
        /// Default value is <see cref="MessageBoxResult.None"/>.</param>
        /// <returns>A <see cref="MessageBoxResult"/> value that specifies which message box button is clicked by the user.</returns>
        /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
        public bool? ShowMessageBox(
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
        public bool? ShowMessageBox(INotifyPropertyChanged ownerViewModel, MessageBoxSettings settings);

        /// <summary>
        /// Displays the OpenFileDialog.
        /// </summary>
        /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
        /// <param name="settings">The settings for the open file dialog.</param>
        /// <returns>If the user clicks the OK button of the dialog that is displayed, true is returned; otherwise false.</returns>
        /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
        public bool? ShowOpenFileDialog(INotifyPropertyChanged ownerViewModel, OpenFileDialogSettings settings);

        /// <summary>
        /// Displays the SaveFileDialog.
        /// </summary>
        /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
        /// <param name="settings">The settings for the save file dialog.</param>
        /// <returns>If the user clicks the OK button of the dialog that is displayed, true is returned; otherwise false.</returns>
        /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
        public bool? ShowSaveFileDialog(INotifyPropertyChanged ownerViewModel, SaveFileDialogSettings settings);

        /// <summary>
        /// Displays the FolderBrowserDialog.
        /// </summary>
        /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
        /// <param name="settings">The settings for the folder browser dialog.</param>
        /// <returns>If the user clicks the OK button of the dialog that is displayed, true is returned; otherwise false.</returns>
        /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
        public bool? ShowFolderBrowserDialog(INotifyPropertyChanged ownerViewModel, FolderBrowserDialogSettings settings);
    }
}
