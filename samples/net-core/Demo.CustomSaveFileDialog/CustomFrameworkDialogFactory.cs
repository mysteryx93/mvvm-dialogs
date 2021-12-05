using MvvmDialogs.Core.FrameworkDialogs;
using MvvmDialogs.Wpf.FrameworkDialogs;

namespace Demo.CustomSaveFileDialog
{
    public class CustomFrameworkDialogFactory : WpfFrameworkDialogFactory
    {
        public override IFrameworkDialog CreateSaveFileDialog(SaveFileDialogSettings settings) =>
            new CustomSaveFileDialog(settings);
    }
}
