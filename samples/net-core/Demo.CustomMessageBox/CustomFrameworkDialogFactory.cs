using MvvmDialogs.Core.FrameworkDialogs;
using MvvmDialogs.Wpf.FrameworkDialogs;

namespace Demo.CustomMessageBox
{
    public class CustomFrameworkDialogFactory : WpfFrameworkDialogFactory
    {
        public override IFrameworkDialog CreateMessageBox(MessageBoxSettings settings) =>
            new CustomMessageBox(settings);
    }
}
