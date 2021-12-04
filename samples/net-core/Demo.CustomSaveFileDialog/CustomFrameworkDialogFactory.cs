using MvvmDialogs.Core.FrameworkDialogs;
using MvvmDialogs.Core.FrameworkDialogs.SaveFile;

namespace Demo.CustomSaveFileDialog
{
    public class CustomFrameworkDialogFactory : DefaultFrameworkDialogFactory
    {
        public override IFrameworkDialog CreateSaveFileDialog(SaveFileDialogSettings settings)
        {
            return new CustomSaveFileDialog(settings);
        }
    }
}
