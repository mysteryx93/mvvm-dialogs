using System;
using System.ComponentModel;
using System.Threading.Tasks;
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
        public void Show(INotifyPropertyChanged ownerViewModel, INotifyPropertyChanged viewModel) =>
            ShowInternal(ownerViewModel, viewModel, DialogTypeLocator.Locate(viewModel));

        /// <inheritdoc />
        public void Show<T>(INotifyPropertyChanged ownerViewModel, INotifyPropertyChanged viewModel) =>
            ShowInternal(ownerViewModel, viewModel, typeof(T));

        /// <summary>
        /// Displays a non-modal dialog of specified type.
        /// </summary>
        /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
        /// <param name="viewModel">The view model of the new dialog.</param>
        /// <param name="dialogType">The type of the dialog to show.</param>
        /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
        protected void ShowInternal(INotifyPropertyChanged ownerViewModel, INotifyPropertyChanged viewModel, Type dialogType)
        {
            if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            DialogLogger.Write($"Dialog: {dialogType}; View model: {viewModel.GetType()}; Owner: {ownerViewModel.GetType()}");

            IWindow dialog = CreateDialog(dialogType, ownerViewModel, viewModel);
            dialog.Show();
        }

        /// <inheritdoc />
        public Task<bool?> ShowDialogAsync(INotifyPropertyChanged ownerViewModel, IModalDialogViewModel viewModel) =>
            Task.Run(() => ShowDialogInternalAsync(ownerViewModel, viewModel, DialogTypeLocator.Locate(viewModel)));

        /// <inheritdoc />
        public Task<bool?> ShowDialogAsync<T>(INotifyPropertyChanged ownerViewModel, IModalDialogViewModel viewModel) =>
            Task.Run(() => ShowDialogInternalAsync(ownerViewModel, viewModel, typeof(T)));

        /// <summary>
        /// Displays a modal dialog of specified type.
        /// </summary>
        /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
        /// <param name="viewModel">The view model of the new dialog.</param>
        /// <param name="dialogType">The type of the dialog to show.</param>
        /// <returns>A nullable value of type <see cref="bool"/> that signifies how a window was closed by the user.</returns>
        /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
        protected async Task<bool?> ShowDialogInternalAsync(INotifyPropertyChanged ownerViewModel, IModalDialogViewModel viewModel, Type dialogType)
        {
            if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            DialogLogger.Write($"Dialog: {dialogType}; View model: {viewModel.GetType()}; Owner: {ownerViewModel.GetType()}");

            IWindow dialog = CreateDialog(dialogType, ownerViewModel, viewModel);

            PropertyChangedEventHandler handler = RegisterDialogResult(dialog, viewModel);
            await dialog.ShowDialogAsync();
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
