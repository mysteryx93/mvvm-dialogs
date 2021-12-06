using System;
using MvvmDialogs.Core;
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

        IWindow IWindow.Owner
        {
            get => new WpfWindow(dialog.Owner);
            set => dialog.Owner = value is WpfWindow w ? w.Ref : null;
        }

        bool? IWindow.ShowDialog() => dialog.ShowDialog();

        void IWindow.Show() => dialog.Show();
    }
}
