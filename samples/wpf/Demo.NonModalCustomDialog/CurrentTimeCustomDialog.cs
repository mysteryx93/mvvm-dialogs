using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using MvvmDialogs;
using MvvmDialogs.Wpf;

namespace Demo.NonModalCustomDialog
{
    public class CurrentTimeCustomDialog : ObservableObject, IWindow
    {
        private readonly CurrentTimeDialog dialog;

        public CurrentTimeCustomDialog()
        {
            dialog = new CurrentTimeDialog();
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
