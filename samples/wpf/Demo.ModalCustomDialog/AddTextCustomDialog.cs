using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using MvvmDialogs;
using MvvmDialogs.Wpf;

namespace Demo.ModalCustomDialog
{
    public class AddTextCustomDialog : ObservableObject, IWindow, IWindowSync, IModalDialogViewModel
    {
        private readonly AddTextDialog dialog;

        public AddTextCustomDialog()
        {
            dialog = new AddTextDialog();
        }

        public bool? DialogResult
        {
            get => dialog.DialogResult;
            set => SetProperty(dialog.DialogResult, value, (v) => dialog.DialogResult = v);
        }

        event EventHandler? IWindow.Closed
        {
            add => dialog.Closed += value;
            remove => dialog.Closed -= value;
        }

        object? IWindow.DataContext
        {
            get => dialog.DataContext;
            set => SetProperty(dialog.DataContext, value, (v) => dialog.DataContext = v);
        }

        IWindow? IWindow.Owner
        {
            get => dialog.Owner?.AsWrapper();
            set => SetProperty(dialog.Owner?.AsWrapper(), value, (v) => dialog.Owner = (v as WindowWrapper)?.Ref ?? null);
        }

        void IWindow.Show() => dialog.Show();

        public Task<bool?> ShowDialogAsync() => dialog.Owner.RunUiAsync(ShowDialog);

        public bool? ShowDialog() => dialog.ShowDialog();

        void IWindow.Activate() => dialog.Activate();

        void IWindow.Close() => dialog.Close();
    }
}
