using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs;

namespace Demo.MessageBox
{
    public class MainWindowViewModel : ObservableObject
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
            private set => SetProperty(ref confirmation, value);
        }

        private void ShowMessageBoxWithMessage()
        {
            var result = dialogService.ShowMessageBox(
                this,
                "This is the text.");

            UpdateResult(result);
        }

        private void ShowMessageBoxWithCaption()
        {
            var result = dialogService.ShowMessageBox(
                this,
                "This is the text.",
                "This Is The Caption");

            UpdateResult(result);
        }

        private void ShowMessageBoxWithButton()
        {
            var result = dialogService.ShowMessageBox(
                this,
                "This is the text.",
                "This Is The Caption",
                MessageBoxButton.OkCancel);

            UpdateResult(result);
        }

        private void ShowMessageBoxWithIcon()
        {
            var result = dialogService.ShowMessageBox(
                this,
                "This is the text.",
                "This Is The Caption",
                MessageBoxButton.OkCancel,
                MessageBoxImage.Information);

            UpdateResult(result);
        }

        private void ShowMessageBoxWithDefaultResult()
        {
            var result = dialogService.ShowMessageBox(
                this,
                "This is the text.",
                "This Is The Caption",
                MessageBoxButton.OkCancel,
                MessageBoxImage.Information,
                null);

            UpdateResult(result);
        }

        private void UpdateResult(bool? result)
        {
            Confirmation = result == true ? "We got confirmation to continue!" : string.Empty;
        }
    }
}
