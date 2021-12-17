using System;
using System.Threading.Tasks;
using MvvmDialogs;
using MvvmDialogs.Wpf;

namespace Demo.ModalCustomDialog;

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
        get => dialog.Owner.AsWrapper();
        set => dialog.Owner = value.AsWrapper()?.Ref;
    }

    Task<bool?> IWindow.ShowDialogAsync() => dialog.ShowDialogAsync();
    public void Activate() => dialog.Activate();
    public void Close() => dialog.Close();

    void IWindow.Show() => dialog.Show();
}