using System;
using System.ComponentModel;
using MvvmDialogs.Core.DialogTypeLocators;
using MvvmDialogs.Core.FrameworkDialogs;

namespace MvvmDialogs.Core
{
    /// <summary>
    /// Class abstracting the interaction between view models and views when it comes to
    /// opening dialogs using the MVVM pattern in WPF.
    /// </summary>
    public abstract class DialogServiceBase : IDialogService
    {
        /// <summary>
        /// Factory responsible for creating framework dialogs.
        /// </summary>
        public IFrameworkDialogFactory FrameworkDialogFactory { get; }
        /// <summary>
        /// Factory responsible for creating dialogs.
        /// </summary>
        protected readonly IDialogFactory DialogFactory;
        /// <summary>
        /// Locator responsible for finding a dialog type matching a view model.
        /// </summary>
        protected readonly IDialogTypeLocator DialogTypeLocator;

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogServiceBase"/> class.
        /// </summary>
        /// <param name="dialogFactory">Factory responsible for creating dialogs.</param>
        /// <param name="dialogTypeLocator">Locator responsible for finding a dialog type matching a view model.</param>
        /// <param name="frameworkDialogFactory">Factory responsible for creating framework dialogs.</param>
        protected DialogServiceBase(IDialogFactory dialogFactory, IDialogTypeLocator dialogTypeLocator, IFrameworkDialogFactory frameworkDialogFactory)
        {
            DialogFactory = dialogFactory;
            DialogTypeLocator = dialogTypeLocator;
            FrameworkDialogFactory = frameworkDialogFactory;
        }

        /// <inheritdoc />
        public void Show(INotifyPropertyChanged ownerViewModel, INotifyPropertyChanged viewModel)
        {
            if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            Type dialogType = DialogTypeLocator.Locate(viewModel);
            ShowInternal(ownerViewModel, viewModel, dialogType);
        }

        /// <inheritdoc />
        public void Show<T>(INotifyPropertyChanged ownerViewModel, INotifyPropertyChanged viewModel)
        {
            if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            ShowInternal(ownerViewModel, viewModel, typeof(T));
        }

        /// <inheritdoc />
        public void ShowCustom<T>(INotifyPropertyChanged ownerViewModel, INotifyPropertyChanged viewModel)
            where T : IWindow
        {
            if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            ShowInternal(ownerViewModel, viewModel, typeof(T));
        }

        /// <summary>
        /// Displays a non-modal dialog of specified type.
        /// </summary>
        /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
        /// <param name="viewModel">The view model of the new dialog.</param>
        /// <param name="dialogType">The type of the dialog to show.</param>
        /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
        protected void ShowInternal(INotifyPropertyChanged ownerViewModel, INotifyPropertyChanged viewModel, Type dialogType)
        {
            DialogLogger.Write($"Dialog: {dialogType}; View model: {viewModel.GetType()}; Owner: {ownerViewModel.GetType()}");

            IWindow dialog = CreateDialog(dialogType, ownerViewModel, viewModel);
            dialog.Show();
        }

        /// <inheritdoc />
        public bool? ShowDialog(INotifyPropertyChanged ownerViewModel, IModalDialogViewModel viewModel)
        {
            if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            Type dialogType = DialogTypeLocator.Locate(viewModel);
            return ShowDialogInternal(ownerViewModel, viewModel, dialogType);
        }

        /// <inheritdoc />
        public bool? ShowDialog<T>(INotifyPropertyChanged ownerViewModel, IModalDialogViewModel viewModel)
        {
            if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            return ShowDialogInternal(ownerViewModel, viewModel, typeof(T));
        }

        /// <inheritdoc />
        public bool? ShowCustomDialog<T>(INotifyPropertyChanged ownerViewModel, IModalDialogViewModel viewModel)
            where T : IWindow
        {
            if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            return ShowDialogInternal(ownerViewModel, viewModel, typeof(T));
        }

        /// <summary>
        /// Displays a modal dialog of specified type.
        /// </summary>
        /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
        /// <param name="viewModel">The view model of the new dialog.</param>
        /// <param name="dialogType">The type of the dialog to show.</param>
        /// <returns>A nullable value of type <see cref="bool"/> that signifies how a window was closed by the user.</returns>
        /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
        protected bool? ShowDialogInternal(INotifyPropertyChanged ownerViewModel, IModalDialogViewModel viewModel, Type dialogType)
        {
            DialogLogger.Write($"Dialog: {dialogType}; View model: {viewModel.GetType()}; Owner: {ownerViewModel.GetType()}");

            IWindow dialog = CreateDialog(dialogType, ownerViewModel, viewModel);

            PropertyChangedEventHandler handler = RegisterDialogResult(dialog, viewModel);
            dialog.ShowDialog();
            UnregisterDialogResult(viewModel, handler);

            return viewModel.DialogResult;
        }

        private IWindow CreateDialog(Type dialogType, INotifyPropertyChanged ownerViewModel, INotifyPropertyChanged viewModel)
        {
            var dialog = DialogFactory.Create(dialogType);
            dialog.Owner = ViewLocator.FindView(ownerViewModel);
            dialog.DataContext = viewModel;

            return dialog;
        }

        private static PropertyChangedEventHandler RegisterDialogResult(IWindow dialog, IModalDialogViewModel viewModel)
        {
            void Handler(object? sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName != Reflection.DialogResultPropertyName || dialog.DialogResult == viewModel.DialogResult)
                    return;

                DialogLogger.Write($"Dialog: {dialog.GetType()}; Result: {viewModel.DialogResult}");
                dialog.DialogResult = viewModel.DialogResult;
            }

            viewModel.PropertyChanged += Handler;

            return Handler;
        }

        private static void UnregisterDialogResult(IModalDialogViewModel viewModel, PropertyChangedEventHandler handler) =>
            viewModel.PropertyChanged -= handler;

        /// <inheritdoc />
        public abstract bool Activate(INotifyPropertyChanged viewModel);

        /// <inheritdoc />
        public abstract bool Close(INotifyPropertyChanged viewModel);
    }
}
