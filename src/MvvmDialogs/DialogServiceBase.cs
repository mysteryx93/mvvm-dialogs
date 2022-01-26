﻿using System;
using System.ComponentModel;
using System.Threading.Tasks;
using MvvmDialogs.DialogTypeLocators;

namespace MvvmDialogs;

/// <summary>
/// Class abstracting the interaction between view models and views when it comes to
/// opening dialogs using the MVVM pattern in WPF.
/// </summary>
public abstract class DialogServiceBase : IDialogService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DialogServiceBase"/> class.
    /// </summary>
    /// <param name="appSettings">Set application-wide settings.</param>
    /// <param name="dialogManager">Class responsible to manage UI interactions.</param>
    /// <param name="dialogTypeLocator">Locator responsible for finding a dialog type matching a view model.</param>
    protected DialogServiceBase(AppDialogSettingsBase appSettings, IDialogManager dialogManager, IDialogTypeLocator dialogTypeLocator)
    {
        AppSettings = appSettings;
        DialogManager = dialogManager;
        DialogTypeLocator = dialogTypeLocator;
    }

    /// <summary>
    /// Set application-wide settings.
    /// </summary>
    public AppDialogSettingsBase AppSettings { get; }

    /// <summary>
    /// Factory responsible for creating dialogs.
    /// </summary>
    public IDialogManager DialogManager { get; }

    /// <summary>
    /// Locator responsible for finding a dialog type matching a view model.
    /// </summary>
    protected IDialogTypeLocator DialogTypeLocator { get; }

    /// <inheritdoc />
    public void Show(INotifyPropertyChanged ownerViewModel, INotifyPropertyChanged viewModel) =>
        ShowInternal(ownerViewModel, viewModel, DialogTypeLocator.Locate(viewModel));

    /// <inheritdoc />
    public void Show<T>(INotifyPropertyChanged ownerViewModel, INotifyPropertyChanged viewModel) =>
        ShowInternal(ownerViewModel, viewModel, typeof(T));

    /// <inheritdoc />
    public Task<bool?> ShowDialogAsync(INotifyPropertyChanged ownerViewModel, IModalDialogViewModel viewModel) =>
        ShowDialogInternalAsync(ownerViewModel, viewModel, DialogTypeLocator.Locate(viewModel));

    /// <inheritdoc />
    public Task<bool?> ShowDialogAsync<T>(INotifyPropertyChanged ownerViewModel, IModalDialogViewModel viewModel) =>
        ShowDialogInternalAsync(ownerViewModel, viewModel, typeof(T));

    /// <summary>
    /// Attempts to bring the window to the foreground and activates it.
    /// </summary>
    /// <param name="viewModel">The view model of the window.</param>
    /// <returns>true if the Window was successfully activated; otherwise, false.</returns>
    public bool Activate(INotifyPropertyChanged viewModel)
    {
        if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

        var window = FindWindowByViewModel(viewModel);
        window?.Activate();
        return window != null;
    }

    /// <summary>
    /// Closes a non-modal dialog that previously was opened using <see cref="DialogServiceBase.Show"/>,
    /// <see cref="DialogServiceBase.Show{T}"/>.
    /// </summary>
    /// <param name="viewModel">The view model of the dialog to close.</param>
    /// <returns>true if the Window was successfully closed; otherwise, false.</returns>
    public bool Close(INotifyPropertyChanged viewModel)
    {
        if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

        var window = FindWindowByViewModel(viewModel);
        if (window != null)
        {
            try
            {
                window.Close();
                return true;
            }
            catch (Exception e)
            {
                DialogLogger.Write($"Failed to close dialog: {e}");
            }
        }
        return false;
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
        if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));
        if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

        DialogLogger.Write($"Dialog: {dialogType}; View model: {viewModel.GetType()}; Owner: {ownerViewModel.GetType()}");
        DialogManager.Show(ownerViewModel, viewModel, dialogType);
    }

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
        await DialogManager.ShowDialogAsync(ownerViewModel, viewModel, dialogType);
        DialogLogger.Write($"Dialog: {dialogType}; Result: {viewModel.DialogResult}");
        return viewModel.DialogResult;
    }

    /// <summary>
    /// Returns the window with a DataContext equal to specified ViewModel.
    /// </summary>
    /// <param name="viewModel">The ViewModel to search for.</param>
    /// <returns>A Window, or null.</returns>
    protected abstract IWindow? FindWindowByViewModel(INotifyPropertyChanged viewModel);
}
