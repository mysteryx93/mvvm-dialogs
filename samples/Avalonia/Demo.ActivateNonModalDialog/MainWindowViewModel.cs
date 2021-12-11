using System.ComponentModel;
using System.Reactive.Linq;
using MvvmDialogs;
using ReactiveUI;

namespace Demo.ActivateNonModalDialog
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDialogService dialogService;

        private INotifyPropertyChanged? dialogViewModel;
        protected INotifyPropertyChanged? DialogViewModel
        {
            get => dialogViewModel;
            set => this.RaiseAndSetIfChanged(ref dialogViewModel, value, nameof(DialogViewModel));
        }
        public IReactiveCommand ShowCommand { get; }
        public IReactiveCommand ActivateCommand { get; }

        public MainWindowViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            var canShow = this.WhenAnyValue(x => x.DialogViewModel).Select(x => x == null);
            ShowCommand = ReactiveCommand.Create(Show, canShow);

            var canActivate = this.WhenAnyValue(x => x.DialogViewModel).Select(x => x != null);
            ActivateCommand = ReactiveCommand.Create(Activate, canActivate);
        }

        public void Show()
        {
            DialogViewModel = ViewLocator.CurrentTimeDialogViewModel;
            dialogService.Show(this, DialogViewModel);
        }

        public void Activate() => dialogService.Activate(DialogViewModel!);
    }
}
