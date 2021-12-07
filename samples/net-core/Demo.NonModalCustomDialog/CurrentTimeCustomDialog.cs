using System;
using MvvmDialogs;
using MvvmDialogs.Wpf;

namespace Demo.NonModalCustomDialog
{
    public class CurrentTimeCustomDialog : IWindow
    {
        private readonly CurrentTimeDialog dialog;

        public CurrentTimeCustomDialog()
        {
            dialog = new CurrentTimeDialog();
        }

        event EventHandler IWindow.Closed
        {
            add => dialog.Closed += value;
            remove => dialog.Closed += value;
        }

        object IWindow.DataContext
        {
            get => dialog.DataContext;
            set => dialog.DataContext = value;
        }

        bool? IWindow.DialogResult
        {
            get => dialog.DialogResult;
            set => dialog.DialogResult = value;
        }

        IWindow IWindow.Owner
        {
            get => new WindowWrapper(dialog.Owner);
            set => dialog.Owner = ((WindowWrapper)value).Ref;
        }

        bool? IWindow.ShowDialog() => dialog.ShowDialog();

        void IWindow.Show() => dialog.Show();
    }
}
