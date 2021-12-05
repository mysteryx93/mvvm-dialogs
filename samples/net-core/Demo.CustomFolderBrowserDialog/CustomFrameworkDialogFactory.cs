using MvvmDialogs.Core.FrameworkDialogs;
using MvvmDialogs.Wpf.FrameworkDialogs;

namespace Demo.CustomFolderBrowserDialog
{
    public class CustomFrameworkDialogFactory : WpfFrameworkDialogFactory
    {
        public override IFrameworkDialog CreateFolderBrowserDialog(FolderBrowserDialogSettings settings) =>
            new CustomFolderBrowserDialog(settings);
    }
}
