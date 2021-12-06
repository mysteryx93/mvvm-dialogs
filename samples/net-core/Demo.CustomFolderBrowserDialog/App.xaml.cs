using System.Windows;
using GalaSoft.MvvmLight.Ioc;
using MvvmDialogs;
using MvvmDialogs.Wpf.FrameworkDialogs;

namespace Demo.CustomFolderBrowserDialog
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            SimpleIoc.Default.Register<IDialogService>(
                () => new WpfDialogService(frameworkDialogFactory: new WpfFrameworkDialogFactory()));
        }
    }
}
