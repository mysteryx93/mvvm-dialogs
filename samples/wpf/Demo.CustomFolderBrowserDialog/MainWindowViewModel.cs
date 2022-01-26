using System.Reflection;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs;
using IOPath = System.IO.Path;

namespace Demo.CustomFolderBrowserDialog
{
    public class MainWindowViewModel : ObservableObject
    {
        private readonly IDialogService dialogService;

        private string? path;

        public MainWindowViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            BrowseFolderCommand = new RelayCommand(BrowseFolder);
        }

        public string? Path
        {
            get => path;
            private set => SetProperty(ref path, value);
        }

        public ICommand BrowseFolderCommand { get; }

        private void BrowseFolder()
        {
            var settings = new OpenFolderDialogSettings
            {
                Title = "This is a description",
                InitialPath = IOPath.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            };

            var result = dialogService.ShowOpenFolderDialog(this, settings);
            if (result != null)
            {
                Path = result;
            }
        }
    }
}
