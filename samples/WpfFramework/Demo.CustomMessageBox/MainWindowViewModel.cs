using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs;

namespace Demo.CustomMessageBox;

public class MainWindowViewModel : ViewModelBase
{
    private readonly IDialogService dialogService;

    private string confirmation;

    public MainWindowViewModel(IDialogService dialogService)
    {
        this.dialogService = dialogService;

        ShowMessageBoxWithMessageCommand = new RelayCommand(ShowMessageBoxWithMessage);
        ShowMessageBoxWithCaptionCommand = new RelayCommand(ShowMessageBoxWithCaption);
        ShowMessageBoxWithButtonCommand = new RelayCommand(ShowMessageBoxWithButton);
        ShowMessageBoxWithIconCommand = new RelayCommand(ShowMessageBoxWithIcon);
        ShowMessageBoxWithDefaultResultCommand = new RelayCommand(ShowMessageBoxWithDefaultResult);
    }

    public ICommand ShowMessageBoxWithMessageCommand { get; }

    public ICommand ShowMessageBoxWithCaptionCommand { get; }

    public ICommand ShowMessageBoxWithButtonCommand { get; }

    public ICommand ShowMessageBoxWithIconCommand { get; }

    public ICommand ShowMessageBoxWithDefaultResultCommand { get; }

    public string Confirmation
    {
        get => confirmation;
        private set => Set(() => Confirmation, ref confirmation, value);
    }

    private void ShowMessageBoxWithMessage()
    {
        var result = dialogService.ShowMessageBoxAsync(
            this,
            "This is the text.").Result;

        UpdateResult(result);
    }

    private void ShowMessageBoxWithCaption()
    {
        var result = dialogService.ShowMessageBoxAsync(
            this,
            "This is the text.",
            "This Is The Caption").Result;

        UpdateResult(result);
    }

    private void ShowMessageBoxWithButton()
    {
        var result = dialogService.ShowMessageBoxAsync(
            this,
            "This is the text.",
            "This Is The Caption",
            MessageBoxButton.OkCancel).Result;

        UpdateResult(result);
    }

    private void ShowMessageBoxWithIcon()
    {
        var result = dialogService.ShowMessageBoxAsync(
            this,
            "This is the text.",
            "This Is The Caption",
            MessageBoxButton.OkCancel,
            MessageBoxImage.Information).Result;

        UpdateResult(result);
    }

    private void ShowMessageBoxWithDefaultResult()
    {
        var result = dialogService.ShowMessageBoxAsync(
            this,
            "This is the text.",
            "This Is The Caption",
            MessageBoxButton.OkCancel,
            MessageBoxImage.Information,
            MessageBoxResult.Cancel).Result;

        UpdateResult(result);
    }

    private void UpdateResult(MessageBoxResult result) =>
        Confirmation = result == MessageBoxResult.Ok ? "We got confirmation to continue!" : string.Empty;
}