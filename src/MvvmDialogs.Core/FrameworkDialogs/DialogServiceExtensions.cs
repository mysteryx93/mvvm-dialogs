using System;
using System.ComponentModel;
using System.Threading.Tasks;
using MvvmDialogs.Core.FrameworkDialogs;

namespace MvvmDialogs.Core
{
    /// <summary>
    /// Provides IDialogService extensions for standard dialog methods.
    /// </summary>
    public static class FrameworkDialogsExtensions
    {
        /// <summary>
        /// Displays the FolderBrowserDialog.
        /// </summary>
        /// <param name="service">The IDialogService on which to attach the extension method.</param>
        /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
        /// <param name="settings">The settings for the folder browser dialog.</param>
        /// <returns>If the user clicks the OK button of the dialog that is displayed, true is returned; otherwise false.</returns>
        /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
        public static Task<bool?> ShowFolderBrowserDialogAsync(this IDialogService service, INotifyPropertyChanged ownerViewModel, FolderBrowserDialogSettings settings)
        {
            if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            DialogLogger.Write($"Description: {settings.Description}");

            return service.FrameworkDialogFactory.Create(settings)
                .ShowDialogAsync(ViewLocator.FindView(ownerViewModel));
        }

        /// <summary>
        /// Displays a message box that has a message, title bar caption, button, and icon; and
        /// that accepts a default message box result and returns a result.
        /// </summary>
        /// <param name="service">The IDialogService on which to attach the extension method.</param>
        /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
        /// <param name="messageBoxText">A <see cref="string"/> that specifies the text to display.</param>
        /// <param name="caption">A <see cref="string"/> that specifies the title bar caption to display. Default value is an empty string.</param>
        /// <param name="button">A <see cref="MessageBoxButton"/> value that specifies which button or buttons to display.
        /// Default value is <see cref="MessageBoxButton.OK"/>.</param>
        /// <param name="icon">A <see cref="MessageBoxImage"/> value that specifies the icon to display.
        /// Default value is <see cref="MessageBoxImage.None"/>.</param>
        /// <param name="defaultResult">A <see cref="MessageBoxResult"/> value that specifies the default result of the message box.
        /// Default value is <see cref="MessageBoxResult.None"/>.</param>
        /// <returns>A <see cref="MessageBoxResult"/> value that specifies which message box button is clicked by the user.</returns>
        /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
        public static Task<bool?> ShowMessageBoxAsync(
            this IDialogService service,
            INotifyPropertyChanged ownerViewModel,
            string? messageBoxText,
            string caption = "",
            MessageBoxButton button = MessageBoxButton.OK,
            MessageBoxImage icon = MessageBoxImage.None,
            MessageBoxResult defaultResult = MessageBoxResult.None)
        {
            var settings = new MessageBoxSettings
            {
                MessageBoxText = messageBoxText,
                Caption = caption,
                Button = button,
                Icon = icon,
                DefaultResult = defaultResult
            };

            return ShowMessageBoxAsync(service, ownerViewModel, settings);
        }

        /// <summary>
        /// Displays a message box that has a message, title bar caption, button, and icon; and
        /// that accepts a default message box result and returns a result.
        /// </summary>
        /// <param name="service">The IDialogService on which to attach the extension method.</param>
        /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
        /// <param name="settings">The settings for the message box dialog.</param>
        /// <returns>A <see cref="MessageBoxResult"/> value that specifies which message box button is clicked by the user.</returns>
        /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
        public static Task<bool?> ShowMessageBoxAsync(this IDialogService service, INotifyPropertyChanged ownerViewModel, MessageBoxSettings settings)
        {
            if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            DialogLogger.Write($"Caption: {settings.Caption}; Message: {settings.MessageBoxText}");

            return service.FrameworkDialogFactory.Create(settings)
                .ShowDialogAsync(ViewLocator.FindView(ownerViewModel));
        }

        /// <summary>
        /// Displays the OpenFileDialog.
        /// </summary>
        /// <param name="service">The IDialogService on which to attach the extension method.</param>
        /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
        /// <param name="settings">The settings for the open file dialog.</param>
        /// <returns>If the user clicks the OK button of the dialog that is displayed, true is returned; otherwise false.</returns>
        /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
        public static Task<bool?> ShowOpenFileDialog(this IDialogService service, INotifyPropertyChanged ownerViewModel, OpenFileDialogSettings settings)
        {
            if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            DialogLogger.Write($"Title: {settings.Title}");

            return service.FrameworkDialogFactory.Create(settings)
                .ShowDialogAsync(ViewLocator.FindView(ownerViewModel));
        }

        /// <summary>
        /// Displays the SaveFileDialog.
        /// </summary>
        /// <param name="service">The IDialogService on which to attach the extension method.</param>
        /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
        /// <param name="settings">The settings for the save file dialog.</param>
        /// <returns>If the user clicks the OK button of the dialog that is displayed, true is returned; otherwise false.</returns>
        /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
        public static Task<bool?> ShowSaveFileDialogAsync(this IDialogService service, INotifyPropertyChanged ownerViewModel, SaveFileDialogSettings settings)
        {
            if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            DialogLogger.Write($"Title: {settings.Title}");

            return service.FrameworkDialogFactory.Create(settings)
                .ShowDialogAsync(ViewLocator.FindView(ownerViewModel));
        }
    }
}
