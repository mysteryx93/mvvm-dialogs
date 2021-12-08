using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.Wpf.FrameworkDialogs;

namespace Demo.CustomFolderBrowserDialog
{
    public class CustomFrameworkDialogFactory : FrameworkDialogFactory
    {
        public override IFrameworkDialog Create<T>(T settings) =>
            settings switch
            {
                OpenFolderDialogSettings s => new CustomFolderBrowserDialog(s),
                _ => base.Create(settings)
            };
    }
}
