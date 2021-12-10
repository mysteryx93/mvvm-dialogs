using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmDialogs;

namespace Demo.ModalDialog
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDialogService dialogService;

        public MainWindowViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            ImplicitShowDialogCommand = new RelayCommand(ImplicitShowDialog);
            ExplicitShowDialogCommand = new RelayCommand(ExplicitShowDialog);
        }

        public ObservableCollection<string> Texts { get; } = new ObservableCollection<string>();

        public ICommand ImplicitShowDialogCommand { get; }

        public ICommand ExplicitShowDialogCommand { get; }

        private void ImplicitShowDialog()
        {
            ShowDialog(viewModel => dialogService.ShowDialogAsync(this, viewModel));
        }

        private void ExplicitShowDialog()
        {
            ShowDialog(viewModel => dialogService.ShowDialogAsync(this, viewModel));
        }

        private void ShowDialog(Func<AddTextDialogViewModel, Task<bool?>> showDialog)
        {
            var dialogViewModel = new AddTextDialogViewModel();

            showDialog(dialogViewModel);
            // bool? success = showDialog(dialogViewModel);
            // if (success == true)
            // {
            //     Texts.Add(dialogViewModel.Text);
            // }
        }
    }
}
