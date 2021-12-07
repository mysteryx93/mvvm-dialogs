﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using MvvmDialogs.DialogTypeLocators;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.Wpf;
using MvvmDialogs.Wpf.FrameworkDialogs;
using Application = System.Windows.Application;

namespace MvvmDialogs
{
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
        /// <see cref="NamingConventionDialogTypeLocator"/> is used as dialog type locator
        /// and <see cref="FrameworkDialogFactory"/> is used as framework dialog factory.
        /// </remarks>
        public DialogService()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogService"/> class.
        /// </summary>
        /// <param name="dialogFactory">Factory responsible for creating dialogs. Default value is an instance of
        /// <see cref="ReflectionDialogFactory"/>.</param>
        /// <param name="dialogTypeLocator">Locator responsible for finding a dialog type matching a view model. Default value is
        /// an instance of <see cref="NamingConventionDialogTypeLocator"/>.</param>
        /// <param name="frameworkDialogFactory">Factory responsible for creating framework dialogs. Default value is an instance of
        /// <see cref="FrameworkDialogFactory"/>.</param>
        public DialogService(
            IDialogFactory? dialogFactory = null,
            IDialogTypeLocator? dialogTypeLocator = null,
            IFrameworkDialogFactory? frameworkDialogFactory = null)
            : base(dialogFactory ?? new ReflectionDialogFactory(),
                dialogTypeLocator ?? new NamingConventionDialogTypeLocator(),
                frameworkDialogFactory ?? new FrameworkDialogFactory())
        {
        }

        /// <summary>
        /// Returns the list of windows in the application.
        /// </summary>
        private static IEnumerable<Window> Windows =>
            Application.Current.Windows.Cast<Window>();

        /// <inheritdoc />
        protected override IWindow? FindWindowByViewModel(INotifyPropertyChanged viewModel) =>
            Windows.FirstOrDefault(x => ReferenceEquals(viewModel, x.DataContext)).AsWrapper();

        protected Window? FindOwnerWindow(INotifyPropertyChanged ownerViewModel) =>
            (ViewLocator.FindView(ownerViewModel) as WindowWrapper)?.Ref;
    }
}
