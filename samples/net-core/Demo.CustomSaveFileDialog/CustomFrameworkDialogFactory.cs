using MvvmDialogs.Core.FrameworkDialogs;
using MvvmDialogs.Wpf.FrameworkDialogs;

namespace Demo.CustomSaveFileDialog
{
    public class CustomFrameworkDialogFactory : WpfFrameworkDialogFactory
    {
        public override IFrameworkDialog Create<T>(T settings) =>
            settings switch
            {
                SaveFileDialogSettings s => new CustomSaveFileDialog(s),
                _ => base.Create(settings)
            };
    }
}
