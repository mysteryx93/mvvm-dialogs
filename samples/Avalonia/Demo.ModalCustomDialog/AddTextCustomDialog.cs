﻿using System;
using System.Threading.Tasks;
using MvvmDialogs;
using MvvmDialogs.Avalonia;

namespace Demo.ModalCustomDialog;

public class AddTextCustomDialog : IWindow
{
    private readonly AddTextDialog dialog = new();

    event EventHandler IWindow.Closed
    {
        add => dialog.Closed += value;
        remove => dialog.Closed -= value;
    }

    object? IWindow.DataContext
    {
        get => dialog.DataContext;
        set => dialog.DataContext = value;
    }

    public IWindow? Owner { get; set; }

    Task<bool?> IWindow.ShowDialogAsync() => dialog.ShowDialog<bool?>(Owner.AsWrapper()!.Ref);

    void IWindow.Show() => dialog.Show();

    public void Activate() => dialog.Activate();

    public void Close() => dialog.Close();
}