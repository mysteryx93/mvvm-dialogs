using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.Wpf.FrameworkDialogs;

namespace Demo.CustomMessageBox
{
    public class CustomFrameworkDialogFactory : WpfFrameworkDialogFactory
    {
        public override IFrameworkDialog Create<T>(T settings) =>
            settings switch
            {
                MessageBoxSettings s => new CustomMessageBox(s),
                _ => base.Create(settings)
            };
    }
}
