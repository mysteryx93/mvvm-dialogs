using System.Reflection;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs;
using IOPath = System.IO.Path;

namespace Demo.CustomFolderBrowserDialog;

public class MainWindowViewModel : ViewModelBase
{
    private readonly IDialogService dialogService;

    private string path;

    public MainWindowViewModel(IDialogService dialogService)
    {
        this.dialogService = dialogService;

        BrowseFolderCommand = new RelayCommand(BrowseFolder);
    }

    public string Path
    {
        get => path;
        private set { Set(() => Path, ref path, value); }
    }

    public ICommand BrowseFolderCommand { get; }

    private void BrowseFolder()
    {
        var settings = new OpenFolderDialogSettings
        {
            Description = "This is a description",
            InitialPath = IOPath.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!
        };

        var success = dialogService.ShowFolderBrowserDialog(this, settings);
        if (success == true)
        {
            Path = settings.InitialPath;
        }
    }
}