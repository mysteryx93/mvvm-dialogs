using System.Threading.Tasks;
using System.Windows.Forms;
using MvvmDialogs.FrameworkDialogs;
using Win32FolderBrowserDialog = System.Windows.Forms.FolderBrowserDialog;

namespace MvvmDialogs.Wpf.FrameworkDialogs
{
    /// <summary>
    /// Class wrapping <see cref="System.Windows.Forms.FolderBrowserDialog"/>.
    /// </summary>
    internal class OpenFolderDialog : FrameworkDialogBase<OpenFolderDialogSettings, string?>
    {
        /// <inheritdoc />
        public OpenFolderDialog(OpenFolderDialogSettings settings, AppDialogSettings appSettings)
            : base(settings, appSettings)
        {
        }

        /// <inheritdoc />
        public override Task<string?> ShowDialogAsync(WindowWrapper owner) =>
            Task.Run(
                () =>
                {
                    using var dialog = new Win32FolderBrowserDialog();
                    ToDialog(dialog);

                    var result = dialog.ShowDialog(owner.Win32Window);

                    return result == DialogResult.OK ? dialog.SelectedPath : null;
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
