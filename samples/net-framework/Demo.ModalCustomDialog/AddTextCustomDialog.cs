using System;
using MvvmDialogs.Core;
using MvvmDialogs.Wpf.DialogFactories;

namespace Demo.ModalCustomDialog
{
    public class AddTextCustomDialog : IWindow
    {
        private readonly AddTextDialog dialog;

        public AddTextCustomDialog()
        {
            dialog = new AddTextDialog();
        }

        event EventHandler IWindow.Closed
        {
            add => dialog.Closed += value;
            remove => dialog.Closed -= value;
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
            get => new WpfWindow(dialog.Owner);
            set => dialog.Owner = ((WpfWindow)value).Ref;
        }

        bool? IWindow.ShowDialog() => dialog.ShowDialog();

        void IWindow.Show() => dialog.Show();
    }
}
