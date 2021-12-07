using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using MvvmDialogs.Avalonia.FrameworkDialogs;
using MvvmDialogs.DialogTypeLocators;
using MvvmDialogs.FrameworkDialogs;

namespace MvvmDialogs.Avalonia
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
        /// <see cref="WpfFrameworkDialogFactory"/>.</param>
        public DialogService(
            IDialogFactory? dialogFactory = null,
            IDialogTypeLocator? dialogTypeLocator = null,
            IFrameworkDialogFactory? frameworkDialogFactory = null)
            : base(dialogFactory ?? new ReflectionDialogFactory(),
                dialogTypeLocator ?? new NamingConventionDialogTypeLocator(),
                frameworkDialogFactory ?? new FrameworkDialogFactory())
        {
        }

        private IReadOnlyList<Window> Windows =>
            ((IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime).Windows;

        /// <summary>
        /// Attempts to bring the window to the foreground and activates it.
        /// </summary>
        /// <param name="viewModel">The view model of the window.</param>
        /// <returns>true if the <see cref="Window"/> was successfully activated; otherwise, false.</returns>
        public override bool Activate(INotifyPropertyChanged viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            var window = Windows.FirstOrDefault(x => ReferenceEquals(viewModel, x.DataContext));
            window?.Activate();
            return window != null;
        }

        /// <summary>
        /// Closes a non-modal dialog that previously was opened using <see cref="DialogServiceBase.Show"/>,
        /// <see cref="DialogServiceBase.Show{T}"/>.
        /// </summary>
        /// <param name="viewModel">The view model of the dialog to close.</param>
        /// <returns>true if the <see cref="Window"/> was successfully closed; otherwise, false.</returns>
        public override bool Close(INotifyPropertyChanged viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            var window = Windows.FirstOrDefault(x => ReferenceEquals(viewModel, x.DataContext));
            window?.Close();
            return window != null;
        }

        protected Window? FindOwnerWindow(INotifyPropertyChanged ownerViewModel) =>
            (ViewLocator.FindView(ownerViewModel) as WindowWrapper)?.Ref;
    }
}
