using MvvmDialogs.Core.FrameworkDialogs;
using MvvmDialogs.Wpf.FrameworkDialogs;

namespace Demo.CustomOpenFileDialog
{
    public class CustomFrameworkDialogFactory : WpfFrameworkDialogFactory
    {
        public override IFrameworkDialog CreateOpenFileDialog(OpenFileDialogSettings settings) =>
            new CustomOpenFileDialog(settings);
    }
}
