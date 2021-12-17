using System;
using MvvmDialogs;
using MvvmDialogs.Wpf;

namespace Demo.NonModalCustomDialog;

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
        get => dialog.Owner.AsWrapper();
        set => dialog.Owner = value.AsWrapper()?.Ref;
    }

    bool? IWindow.ShowDialog() => dialog.ShowDialog();

    void IWindow.Show() => dialog.Show();
}