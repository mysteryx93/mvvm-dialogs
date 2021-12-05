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
        /// Factory responsible for creating framework dialogs.
        /// </summary>
        IFrameworkDialogFactory FrameworkDialogFactory { get; }

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
    }
}
