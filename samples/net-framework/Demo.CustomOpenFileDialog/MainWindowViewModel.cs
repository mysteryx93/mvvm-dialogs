using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmDialogs.Core;
using MvvmDialogs.Core.FrameworkDialogs;
using IOPath = System.IO.Path;

namespace Demo.CustomOpenFileDialog
{
    public class MainWindowViewModel : ViewModelBase
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
            private set { Set(() => Path, ref path, value); }
        }

        public ICommand OpenFileCommand { get; }

        private async Task OpenFile()
        {
            var settings = new OpenFileDialogSettings
            {
                Title = "This Is The Title",
                InitialDirectory = IOPath.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
                Filter = "Text Documents (*.txt)|*.txt|All Files (*.*)|*.*"
            };

            var success = await dialogService.ShowOpenFileDialogAsync(this, settings);
            if (success == true)
            {
                Path = settings.FileName;
            }
        }
    }
}
