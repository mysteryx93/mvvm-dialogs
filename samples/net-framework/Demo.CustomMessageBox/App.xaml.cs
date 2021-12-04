using System.Windows;
using GalaSoft.MvvmLight.Ioc;
using MvvmDialogs.Core;

namespace Demo.CustomMessageBox
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            SimpleIoc.Default.Register<IDialogService>(
                () => new DialogServiceBase(frameworkDialogFactory: new CustomFrameworkDialogFactory()));
        }
    }
}
