﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using MvvmDialogs.Avalonia.FrameworkDialogs;
using MvvmDialogs.DialogTypeLocators;
using MvvmDialogs.FrameworkDialogs;

namespace MvvmDialogs.Avalonia;

/// <summary>
/// Class abstracting the interaction between view models and views when it comes to
/// opening dialogs using the MVVM pattern in WPF.
/// </summary>
public class DialogService : DialogServiceBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DialogServiceBase"/> class.
    /// </summary>
    /// <remarks>
    /// By default <see cref="ReflectionDialogFactory"/> is used as dialog factory,
    /// <see cref="DialogTypeLocatorBase"/> is used as dialog type locator
    /// and <see cref="FrameworkDialogFactory"/> is used as framework dialog factory.
    /// </remarks>
    public DialogService()
        : this(null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DialogService"/> class.
    /// </summary>
    /// <param name="settings">Set application-wide settings.</param>
    /// <param name="dialogFactory">Factory responsible for creating dialogs. Default value is an instance of
    /// <see cref="ReflectionDialogFactory"/>.</param>
    /// <param name="dialogTypeLocator">Locator responsible for finding a dialog type matching a view model. Default value is
    /// an instance of <see cref="DialogTypeLocatorBase"/>.</param>
    /// <param name="frameworkDialogFactory">Factory responsible for creating framework dialogs. Default value is an instance of
    /// <see cref="FrameworkDialogFactory"/>.</param>
    public DialogService(
        AppDialogSettings? settings = null,
        IDialogFactory? dialogFactory = null,
        IDialogTypeLocator? dialogTypeLocator = null,
        IFrameworkDialogFactory? frameworkDialogFactory = null)
        : base(settings ?? new AppDialogSettings(),
            dialogFactory ?? new ReflectionDialogFactory(),
            dialogTypeLocator ?? new NamingConventionDialogTypeLocator(),
            frameworkDialogFactory ?? new FrameworkDialogFactory())
    {
    }

    private static IEnumerable<Window> Windows =>
        ((IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime).Windows;

    /// <inheritdoc />
    protected override IWindow? FindWindowByViewModel(INotifyPropertyChanged viewModel) =>
        Windows.FirstOrDefault(x => ReferenceEquals(viewModel, x.DataContext)).AsWrapper();

    protected Window? FindOwnerWindow(INotifyPropertyChanged ownerViewModel) =>
        (ViewRegistration.FindView(ownerViewModel) as WindowWrapper)?.Ref;
}
