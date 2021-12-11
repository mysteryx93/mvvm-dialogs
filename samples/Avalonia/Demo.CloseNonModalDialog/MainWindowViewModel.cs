using System.ComponentModel;
using System.Reactive.Linq;
using MvvmDialogs;
using ReactiveUI;

namespace Demo.CloseNonModalDialog
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDialogService dialogService;
        private INotifyPropertyChanged? dialogViewModel;
        public INotifyPropertyChanged? DialogViewModel
        {
            get => dialogViewModel;
            set => this.RaiseAndSetIfChanged(ref dialogViewModel, value, nameof(DialogViewModel));
        }
        public IReactiveCommand ShowCommand { get; }
        public IReactiveCommand CloseCommand { get; }

        public MainWindowViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            var canShow = this.WhenAnyValue(x => x.DialogViewModel).Select(d => d == null);
            ShowCommand = ReactiveCommand.Create(Show, canShow);

            var canClose = this.WhenAnyValue(x => x.DialogViewModel).Select(d => d != null);
            CloseCommand = ReactiveCommand.Create(Close, canClose);
        }

        private void Show()
        {
            DialogViewModel = ViewLocator.CurrentTimeDialog;
            dialogService.Show(this, DialogViewModel);
        }

        private void Close()
        {
            dialogService.Close(DialogViewModel!);
            DialogViewModel = null;
        }
    }
}
