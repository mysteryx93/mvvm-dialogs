using System;
using System.Threading.Tasks;
using MvvmDialogs;
using MvvmDialogs.Wpf;

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

        IWindow IWindow.Owner
        {
            get => new WpfWindow(dialog.Owner);
            set => dialog.Owner = ((WpfWindow)value).Ref;
        }

        Task<bool?> IWindow.ShowDialogAsync() =>
            Task.Run(() => dialog.ShowDialog());

        void IWindow.Show() => dialog.Show();
    }
}
