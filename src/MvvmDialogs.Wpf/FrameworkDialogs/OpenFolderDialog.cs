using System.Threading.Tasks;
using MvvmDialogs.FrameworkDialogs;

namespace MvvmDialogs.Wpf.FrameworkDialogs
{
    /// <summary>
    /// Class wrapping <see cref="System.Windows.Forms.FolderBrowserDialog"/>.
    /// </summary>
    public class OpenFolderDialog : FrameworkDialogBase<OpenFolderDialogSettings>
    {
        /// <inheritdoc />
        public OpenFolderDialog(OpenFolderDialogSettings settings, AppDialogSettings appSettings)
            : base(settings, appSettings)
        {
        }

        /// <inheritdoc />
        public override Task<bool?> ShowDialogAsync(WindowWrapper owner) =>
            Task.Run(
                () =>
                {
                    using var dialog = new System.Windows.Forms.FolderBrowserDialog();
                    ToDialog(dialog);

                    var result = dialog.ShowDialog(owner.Win32Window);

                    ToSettings(dialog);
                    return result.AsBool();
                });


        private void ToDialog(System.Windows.Forms.FolderBrowserDialog d)
        {

            d.Description = Settings.Title;
            d.RootFolder = Settings.RootFolder;
            d.SelectedPath = Settings.SelectedPath;
            d.ShowNewFolderButton = Settings.ShowNewFolderButton;
        }

        private void ToSettings(System.Windows.Forms.FolderBrowserDialog d) => Settings.SelectedPath = d.SelectedPath;
    }
}
