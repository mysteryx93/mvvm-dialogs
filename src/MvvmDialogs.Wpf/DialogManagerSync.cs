using System;
using System.ComponentModel;
using MvvmDialogs.DialogTypeLocators;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.Wpf.FrameworkDialogs;

namespace MvvmDialogs.Wpf
{
    /// <summary>
    /// DialogManager that supports extra sync methods to show dialogs.
    /// </summary>
    public class DialogManager : DialogManagerBase, IDialogManagerSync
    {
        /// <inheritdoc />
        public DialogManager(IDialogFactory? dialogFactory, IFrameworkDialogFactory? frameworkDialogFactory) :
            base(dialogFactory ?? new ReflectionDialogFactory(), frameworkDialogFactory ?? new FrameworkDialogFactory())
        {
        }

        /// <inheritdoc />
        public virtual bool? ShowDialog(INotifyPropertyChanged ownerViewModel, INotifyPropertyChanged viewModel, Type dialogType)
        {
            var dialog = CreateDialog(ownerViewModel, viewModel, dialogType);
            return dialog.AsSync().ShowDialog();
        }

        /// <inheritdoc />
        public TResult ShowFrameworkDialog<TSettings, TResult>(INotifyPropertyChanged ownerViewModel, TSettings settings, AppDialogSettingsBase appSettings)
            where TSettings : DialogSettingsBase
        {
            var dialog = FrameworkDialogFactory.Create<TSettings, TResult>(settings, appSettings);
            return dialog.AsSync().ShowDialog(ViewRegistration.FindView(ownerViewModel));
        }
    }
}
