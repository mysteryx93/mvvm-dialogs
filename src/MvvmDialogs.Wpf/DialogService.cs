using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using MvvmDialogs.Core.DialogTypeLocators;
using MvvmDialogs.Core.FrameworkDialogs;
using MvvmDialogs.Wpf;
using MvvmDialogs.Wpf.DialogFactories;
using MvvmDialogs.Wpf.FrameworkDialogs;
using MessageBoxButton = MvvmDialogs.Core.FrameworkDialogs.MessageBoxButton;
using MessageBoxImage = MvvmDialogs.Core.FrameworkDialogs.MessageBoxImage;
using MessageBoxResult = MvvmDialogs.Core.FrameworkDialogs.MessageBoxResult;
using Application = System.Windows.Application;

namespace MvvmDialogs.Core
{
    /// <summary>
    /// Class abstracting the interaction between view models and views when it comes to
    /// opening dialogs using the MVVM pattern in WPF.
    /// </summary>
    public class DialogService : DialogServiceBase
    {
        /// <summary>
        /// Factory responsible for creating framework dialogs.
        /// </summary>
        protected readonly IFrameworkDialogFactory FrameworkDialogFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogServiceBase"/> class.
        /// </summary>
        /// <remarks>
        /// By default <see cref="WpfReflectionDialogFactory"/> is used as dialog factory,
        /// <see cref="NamingConventionDialogTypeLocator"/> is used as dialog type locator
        /// and <see cref="WpfFrameworkDialogFactory"/> is used as framework dialog factory.
        /// </remarks>
        public DialogService()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogService"/> class.
        /// </summary>
        /// <param name="dialogFactory">
        /// Factory responsible for creating dialogs. Default value is an instance of
        /// <see cref="WpfReflectionDialogFactory"/>.
        /// </param>
        /// <param name="dialogTypeLocator">
        /// Locator responsible for finding a dialog type matching a view model. Default value is
        /// an instance of <see cref="NamingConventionDialogTypeLocator"/>.
        /// </param>
        /// <param name="frameworkDialogFactory">
        /// Factory responsible for creating framework dialogs. Default value is an instance of
        /// <see cref="WpfFrameworkDialogFactory"/>.
        /// </param>
        public DialogService(
            IDialogFactory? dialogFactory = null,
            IDialogTypeLocator? dialogTypeLocator = null,
            IFrameworkDialogFactory? frameworkDialogFactory = null)
            : base(dialogFactory ?? new WpfReflectionDialogFactory(), dialogTypeLocator ?? new NamingConventionDialogTypeLocator())
        {
            FrameworkDialogFactory = frameworkDialogFactory ?? new WpfFrameworkDialogFactory();
        }

        /// <summary>
        /// Attempts to bring the window to the foreground and activates it.
        /// </summary>
        /// <param name="viewModel">The view model of the window.</param>
        /// <returns>
        /// true if the <see cref="Window"/> was successfully activated; otherwise, false.
        /// </returns>
        public override bool Activate(INotifyPropertyChanged viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            var windowToActivate =
                (
                    from Window? window in Application.Current.Windows
                    where window != null
                    where viewModel.Equals(window.DataContext)
                    select window
                )
                .FirstOrDefault();

            return windowToActivate?.Activate() ?? false;
        }

        /// <summary>
        /// Closes a non-modal dialog that previously was opened using <see cref="DialogServiceBase.Show"/>,
        /// <see cref="DialogServiceBase.Show{T}"/> or <see cref="DialogServiceBase.ShowCustom{T}"/>.
        /// </summary>
        /// <param name="viewModel">The view model of the dialog to close.</param>
        /// <returns>
        /// true if the <see cref="Window"/> was successfully closed; otherwise, false.
        /// </returns>
        public override bool Close(INotifyPropertyChanged viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            foreach (Window? window in Application.Current.Windows)
            {
                if (window == null || !viewModel.Equals(window.DataContext))
                {
                    continue;
                }

                try
                {
                    window.Close();
                    return true;
                }
                catch (Exception e)
                {
                    DialogLogger.Write($"Failed to close dialog: {e}");
                    break;
                }
            }

            return false;
        }

        /// <inheritdoc />
        public override bool? ShowMessageBox(
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

            return ShowMessageBox(ownerViewModel, settings);
        }

        /// <inheritdoc />
        public override bool? ShowMessageBox(INotifyPropertyChanged ownerViewModel, MessageBoxSettings settings)
        {
            if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            DialogLogger.Write($"Caption: {settings.Caption}; Message: {settings.MessageBoxText}");

            var messageBox = FrameworkDialogFactory.CreateMessageBox(settings);
            return messageBox.ShowDialog(ViewLocator.FindView(ownerViewModel));
        }

        /// <inheritdoc />
        public override bool? ShowOpenFileDialog(INotifyPropertyChanged ownerViewModel, OpenFileDialogSettings settings)
        {
            if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            DialogLogger.Write($"Title: {settings.Title}");

            return FrameworkDialogFactory
                .CreateOpenFileDialog(settings)
                .ShowDialog(ViewLocator.FindView(ownerViewModel));
        }

        /// <inheritdoc />
        public override bool? ShowSaveFileDialog(INotifyPropertyChanged ownerViewModel, SaveFileDialogSettings settings)
        {
            if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            DialogLogger.Write($"Title: {settings.Title}");

            return FrameworkDialogFactory
                .CreateSaveFileDialog(settings)
                .ShowDialog(ViewLocator.FindView(ownerViewModel));
        }

        /// <inheritdoc />
        public override bool? ShowFolderBrowserDialog(INotifyPropertyChanged ownerViewModel, FolderBrowserDialogSettings settings)
        {
            if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            DialogLogger.Write($"Description: {settings.Description}");

            return FrameworkDialogFactory
                .CreateFolderBrowserDialog(settings)
                .ShowDialog(ViewLocator.FindView(ownerViewModel));
        }

        protected Window? FindOwnerWindow(INotifyPropertyChanged ownerViewModel) =>
            (ViewLocator.FindView(ownerViewModel) as WpfWindow)?.Ref;
    }
}
