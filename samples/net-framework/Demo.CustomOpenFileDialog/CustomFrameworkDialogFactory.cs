using MvvmDialogs.Core.FrameworkDialogs;
using MvvmDialogs.Wpf.FrameworkDialogs;

namespace Demo.CustomOpenFileDialog
{
    public class CustomFrameworkDialogFactory : WpfFrameworkDialogFactory
    {
        public override IFrameworkDialog Create<T>(T settings) =>
            settings switch
            {
                OpenFileDialogSettings s => new CustomOpenFileDialog(s),
                _ => base.Create(settings)
            };
    }
}
