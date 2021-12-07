using System;
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
        /// Attempts to bring the window to the foreground and activates it.
        /// </summary>
        /// <param name="viewModel">The view model of the window.</param>
        /// <returns>true if the <see cref="Window"/> was successfully activated; otherwise, false.</returns>
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
        /// <see cref="DialogServiceBase.Show{T}"/>.
        /// </summary>
        /// <param name="viewModel">The view model of the dialog to close.</param>
        /// <returns>true if the <see cref="Window"/> was successfully closed; otherwise, false.</returns>
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

        protected Window? FindOwnerWindow(INotifyPropertyChanged ownerViewModel) =>
            (ViewLocator.FindView(ownerViewModel) as WindowWrapper)?.Ref;
    }
}
