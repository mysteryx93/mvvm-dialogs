using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs;

namespace Demo.MessageBox
{
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

        private async void ShowMessageBoxWithMessage()
        {
            var result = await dialogService.ShowMessageBoxAsync(
                this,
                "This is the text.");

            UpdateResult(result);
        }

        private async void ShowMessageBoxWithCaption()
        {
            var result = await dialogService.ShowMessageBoxAsync(
                this,
                "This is the text.",
                "This Is The Caption");

            UpdateResult(result);
        }

        private async void ShowMessageBoxWithButton()
        {
            var result = await dialogService.ShowMessageBoxAsync(
                this,
                "This is the text.",
                "This Is The Caption",
                MessageBoxButton.OkCancel);

            UpdateResult(result);
        }

        private async void ShowMessageBoxWithIcon()
        {
            var result = await dialogService.ShowMessageBoxAsync(
                this,
                "This is the text.",
                "This Is The Caption",
                MessageBoxButton.OkCancel,
                MessageBoxImage.Information);

            UpdateResult(result);
        }

        private async void ShowMessageBoxWithDefaultResult()
        {
            var result = await dialogService.ShowMessageBoxAsync(
                this,
                "This is the text.",
                "This Is The Caption",
                MessageBoxButton.OkCancel,
                MessageBoxImage.Information,
                null);

            UpdateResult(result);
        }

        private void UpdateResult(bool? result) =>
            Confirmation = result == true ? "We got confirmation to continue!" : string.Empty;
    }
}
