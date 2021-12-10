using System.Reflection;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs;
using IOPath = System.IO.Path;

namespace Demo.SaveFileDialog
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDialogService dialogService;

        private string path;

        public MainWindowViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            SaveFileCommand = new RelayCommand(SaveFileAsync);
        }

        public string Path
        {
            get => path;
            private set { Set(() => Path, ref path, value); }
        }

        public ICommand SaveFileCommand { get; }

        private async void SaveFileAsync()
        {
            var settings = new SaveFileDialogSettings
            {
                Title = "This Is The Title",
                InitialPath = IOPath.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
                // Filter = "Text Documents (*.txt)|*.txt|All Files (*.*)|*.*",
                CheckFileExists = false
            };

            var result = await dialogService.ShowSaveFileDialogAsync(this, settings);
            if (result != null)
            {
                Path = result;
            }
        }
    }
}
