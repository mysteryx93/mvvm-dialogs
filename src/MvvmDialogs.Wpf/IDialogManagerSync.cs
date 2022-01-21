﻿using System;
using System.ComponentModel;
using MvvmDialogs.FrameworkDialogs;

namespace MvvmDialogs.Wpf;

public interface IDialogManagerSync
{
    /// <summary>
    /// Shows a new dialog of specified type.
    /// </summary>
    /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
    /// <param name="viewModel">The view model of the new dialog.</param>
    /// <param name="dialogType">The type of the dialog to show.</param>
    /// <returns>The dialog result.</returns>
    bool? ShowDialog(INotifyPropertyChanged ownerViewModel, INotifyPropertyChanged viewModel, Type dialogType);

    /// <summary>
    /// Shows a framework dialog whose type depends on the settings type.
    /// </summary>
    /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
    /// <param name="settings">The settings to pass to the <see cref="IFrameworkDialog{TResult}"/></param>
    /// <param name="appSettings">Application-wide settings configured on the DialogService.</param>
    /// <typeparam name="TSettings">The settings type used to determine the implementation of <see cref="IFrameworkDialog{TResult}"/> to create.</typeparam>
    /// <typeparam name="TResult">The data type returned by the dialog.</typeparam>
    /// <returns>A framework dialog implementing <see cref="IFrameworkDialog{TResult}"/>.</returns>
    TResult ShowFrameworkDialog<TSettings, TResult>(INotifyPropertyChanged ownerViewModel, TSettings settings, AppDialogSettingsBase appSettings)
        where TSettings : DialogSettingsBase;
}
