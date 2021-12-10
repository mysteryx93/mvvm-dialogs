using System.Reflection;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs;
using IOPath = System.IO.Path;

namespace Demo.CustomSaveFileDialog
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDialogService dialogService;

        private string path;

        public MainWindowViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            SaveFileCommand = new RelayCommand(SaveFile);
        }

        public string Path
        {
            get => path;
            private set { Set(() => Path, ref path, value); }
        }

        public ICommand SaveFileCommand { get; }

        private void SaveFile()
        {
            var settings = new SaveFileDialogSettings
            {
                Title = "This Is The Title",
                InitialPath = IOPath.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
                // Filter = "Text Documents (*.txt)|*.txt|All Files (*.*)|*.*",
                CheckFileExists = false
            };

            var result = dialogService.ShowSaveFileDialogAsync(this, settings).Result;
            if (result != null)
            {
                Path = result;
            }
        }
    }
}
