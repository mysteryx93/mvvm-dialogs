using System.Threading.Tasks;
using System.Windows.Input;
using Demo.CustomDialogTypeLocator.ComponentA;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmDialogs;

namespace Demo.CustomDialogTypeLocator
{
    public class MainWindowVM : ViewModelBase
    {
        private readonly IDialogService dialogService;

        public MainWindowVM()
        {
            dialogService = new WpfDialogService(dialogTypeLocator: new MyCustomDialogTypeLocator());

            ShowDialogCommand = new RelayCommand(ShowDialogAsync);
        }

        public ICommand ShowDialogCommand { get; }

        private Task ShowDialogAsync()
        {
            var dialogViewModel = new MyDialogVM();
            return dialogService.ShowDialogAsync(this, dialogViewModel);
        }
    }
}
