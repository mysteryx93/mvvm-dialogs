﻿using System;
using System.Windows.Input;
using MvvmDialogs;
using ReactiveUI;

namespace Demo.ModalCustomDialog;

public class AddTextCustomDialogViewModel : ViewModelBase, ICloseable
{
    private string text = string.Empty;
    private bool? dialogResult;
    public ICommand OkCommand { get; }
    public event EventHandler? RequestClose;

    public AddTextCustomDialogViewModel()
    {
        OkCommand = ReactiveCommand.Create(Ok);
    }

    public string Text
    {
        get => text;
        set => this.RaiseAndSetIfChanged(ref text, value, nameof(Text));
    }

    public bool? DialogResult
    {
        get => dialogResult;
        private set => this.RaiseAndSetIfChanged(ref dialogResult, value, nameof(DialogResult));
    }

    private void Ok()
    {
        if (!string.IsNullOrEmpty(Text))
        {
            DialogResult = true;
            RequestClose?.Invoke(this, EventArgs.Empty);
        }
    }

    public void Cancel()
    {
        DialogResult = false;
        RequestClose?.Invoke(this, EventArgs.Empty);
    }
}
