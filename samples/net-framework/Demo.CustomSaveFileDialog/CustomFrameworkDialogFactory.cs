using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.Wpf;
using MvvmDialogs.Wpf.FrameworkDialogs;

namespace Demo.CustomSaveFileDialog
{
    public class CustomFrameworkDialogFactory : FrameworkDialogFactory
    {
        public override IFrameworkDialog<TResult> Create<TSettings, TResult>(TSettings settings, AppDialogSettingsBase appSettings)
        {
            var s2 = (AppDialogSettings)appSettings;
            return settings switch
            {
                SaveFileDialogSettings s => (IFrameworkDialog<TResult>)new CustomSaveFileDialog(s, s2),
                _ => base.Create<TSettings, TResult>(settings, appSettings)
            };
        }
    }
}
