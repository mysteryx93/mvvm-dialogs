﻿using System;
using System.ComponentModel;
using MvvmDialogs.FrameworkDialogs;

namespace MvvmDialogs;

/// <summary>
/// Provides IDialogService extensions for standard dialog methods.
/// This provides sync compatibility methods only for WPF.
/// </summary>
public static class FrameworkDialogsExtensions
{
    /// <summary>
    /// Displays a message box that has a message, title bar caption, button, and icon; and
    /// that accepts a default message box result and returns a result.
    /// </summary>
    /// <param name="service">The IDialogService on which to attach the extension method.</param>
    /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
    /// <param name="text">A <see cref="string"/> that specifies the text to display.</param>
    /// <param name="title">A <see cref="string"/> that specifies the title bar caption to display. Default value is an empty string.</param>
    /// <param name="button">A <see cref="MessageBoxButton"/> value that specifies which button or buttons to display.
    /// Default value is <see cref="MessageBoxButton.Ok"/>.</param>
    /// <param name="icon">A <see cref="MessageBoxImage"/> value that specifies the icon to display.
    /// Default value is <see cref="MessageBoxImage.None"/>.</param>
    /// <param name="defaultResult">Specifies the value of the button selected by default. Default value is true.</param>
    /// <param name="appSettings">Overrides application-wide settings configured on <see cref="IDialogService"/>.</param>
    /// <returns>A value that specifies which message box button is clicked by the user. True=OK/Yes, False=No, Null=Cancel</returns>
    /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
    public static bool? ShowMessageBox(
        this IDialogService service,
        INotifyPropertyChanged ownerViewModel,
        string text,
        string title = "",
        MessageBoxButton button = MessageBoxButton.Ok,
        MessageBoxImage icon = MessageBoxImage.None,
        bool? defaultResult = true,
        AppDialogSettingsBase? appSettings = null)
    {
        var settings = new MessageBoxSettings
        {
            Text = text,
            Title = title,
            Button = button,
            Icon = icon,
            DefaultValue = defaultResult
        };

        return ShowMessageBox(service, ownerViewModel, settings, appSettings ?? service.AppSettings);
    }

    /// <summary>
    /// Displays a message box that has a message, title bar caption, button, and icon; and
    /// that accepts a default message box result and returns a result.
    /// </summary>
    /// <param name="service">The IDialogService on which to attach the extension method.</param>
    /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
    /// <param name="settings">The settings for the message box dialog.</param>
    /// <param name="appSettings">Overrides application-wide settings configured on <see cref="IDialogService"/>.</param>
    /// <returns>A value that specifies which message box button is clicked by the user. True=OK/Yes, False=No, Null=Cancel</returns>
    /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
    public static bool? ShowMessageBox(this IDialogService service, INotifyPropertyChanged ownerViewModel,
        MessageBoxSettings? settings = null, AppDialogSettingsBase? appSettings = null)
    {
        if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));

        DialogLogger.Write($"Caption: {settings?.Title}; Message: {settings?.Text}");

        return service.FrameworkDialogFactory.AsSync().Show<MessageBoxSettings, bool?>(
            ownerViewModel, settings ?? new MessageBoxSettings(), appSettings ?? service.AppSettings);
    }

    /// <summary>
    /// Displays the OpenFileDialog.
    /// </summary>
    /// <param name="service">The IDialogService on which to attach the extension method.</param>
    /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
    /// <param name="settings">The settings for the open file dialog.</param>
    /// <param name="appSettings">Overrides application-wide settings configured on <see cref="IDialogService"/>.</param>
    /// <returns>The list of files selected by the user, or null if the user cancelled.</returns>
    /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
    public static string[] ShowOpenFileDialog(this IDialogService service, INotifyPropertyChanged ownerViewModel,
        OpenFileDialogSettings? settings = null, AppDialogSettingsBase? appSettings = null)
    {
        if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));

        DialogLogger.Write($"Title: {settings?.Title}");

        return service.FrameworkDialogFactory.AsSync().Show<OpenFileDialogSettings, string[]>(
            ownerViewModel, settings ?? new OpenFileDialogSettings(), appSettings ?? service.AppSettings);
    }

    /// <summary>
    /// Displays the SaveFileDialog.
    /// </summary>
    /// <param name="service">The IDialogService on which to attach the extension method.</param>
    /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
    /// <param name="settings">The settings for the save file dialog.</param>
    /// <param name="appSettings">Overrides application-wide settings configured on <see cref="IDialogService"/>.</param>
    /// <returns>The path to the file selected by the user, or null if the user cancelled.</returns>
    /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
    public static string? ShowSaveFileDialog(this IDialogService service, INotifyPropertyChanged ownerViewModel,
        SaveFileDialogSettings? settings = null, AppDialogSettingsBase? appSettings = null)
    {
        if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));

        DialogLogger.Write($"Title: {settings?.Title}");

        return service.FrameworkDialogFactory.AsSync().Show<SaveFileDialogSettings, string?>(
            ownerViewModel, settings ?? new SaveFileDialogSettings(), appSettings ?? service.AppSettings);
    }

    /// <summary>
    /// Displays the FolderBrowserDialog.
    /// </summary>
    /// <param name="service">The IDialogService on which to attach the extension method.</param>
    /// <param name="ownerViewModel">A view model that represents the owner window of the dialog.</param>
    /// <param name="settings">The settings for the folder browser dialog.</param>
    /// <param name="appSettings">Overrides application-wide settings configured on <see cref="IDialogService"/>.</param>
    /// <returns>The path of the folder selected by the user, or null if the user cancelled.</returns>
    /// <exception cref="ViewNotRegisteredException">No view is registered with specified owner view model as data context.</exception>
    public static string? ShowOpenFolderDialog(this IDialogService service, INotifyPropertyChanged ownerViewModel,
        OpenFolderDialogSettings? settings = null, AppDialogSettingsBase? appSettings = null)
    {
        if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));

        DialogLogger.Write($"Title: {settings?.Title}");

        return service.FrameworkDialogFactory.AsSync().Show<OpenFolderDialogSettings, string?>(
            ownerViewModel, settings ?? new OpenFolderDialogSettings(), appSettings ?? service.AppSettings);
    }
}
