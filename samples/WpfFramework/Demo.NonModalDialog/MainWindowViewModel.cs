using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmDialogs;

namespace Demo.NonModalDialog;

public class MainWindowViewModel : ViewModelBase
{
    private readonly IDialogService dialogService;

    public MainWindowViewModel(IDialogService dialogService)
    {
        this.dialogService = dialogService;

        ImplicitShowCommand = new RelayCommand(ImplicitShow);
        ExplicitShowCommand = new RelayCommand(ExplicitShow);
    }

    public ICommand ImplicitShowCommand { get; }

    public ICommand ExplicitShowCommand { get; }

    private void ImplicitShow()
    {
        Show(viewModel => dialogService.Show(this, viewModel));
    }

    private void ExplicitShow()
    {
        Show(viewModel => dialogService.Show<CurrentTimeDialog>(this, viewModel));
    }

    private static void Show(Action<CurrentTimeDialogViewModel> show)
    {
        var dialogViewModel = new CurrentTimeDialogViewModel();
        show(dialogViewModel);
    }
}