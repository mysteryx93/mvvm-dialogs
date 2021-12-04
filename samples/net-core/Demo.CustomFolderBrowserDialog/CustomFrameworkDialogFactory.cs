using MvvmDialogs.Core.FrameworkDialogs;
using MvvmDialogs.Core.FrameworkDialogs.FolderBrowser;

namespace Demo.CustomFolderBrowserDialog
{
    public class CustomFrameworkDialogFactory : DefaultFrameworkDialogFactory
    {
        public override IFrameworkDialog CreateFolderBrowserDialog(FolderBrowserDialogSettings settings)
        {
            return new CustomFolderBrowserDialog(settings);
        }
    }
}
