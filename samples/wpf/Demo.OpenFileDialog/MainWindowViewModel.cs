using System.Reflection;
using System.Linq;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs;
using IOPath = System.IO.Path;

namespace Demo.OpenFileDialog
{
    public class MainWindowViewModel : ObservableObject
    {
        private readonly IDialogService dialogService;

        private string path;

        public MainWindowViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            OpenFileCommand = new RelayCommand(OpenFile);
        }

        public string Path
        {
            get => path;
            private set => SetProperty(ref path, value);
        }

        public ICommand OpenFileCommand { get; }

        private void OpenFile()
        {
            var settings = new OpenFileDialogSettings
            {
                Title = "This Is The Title",
                InitialPath = IOPath.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                // Filter = "Text Documents (*.txt)|*.txt|All Files (*.*)|*.*"
            };

            var result = dialogService.ShowOpenFileDialog(this, settings);
            if (result.Any())
            {
                Path = result.First();
            }
        }
    }
}
