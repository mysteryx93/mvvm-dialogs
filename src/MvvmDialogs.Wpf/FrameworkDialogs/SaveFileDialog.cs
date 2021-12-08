using System.Threading.Tasks;
using System.Windows.Forms;
using MvvmDialogs.FrameworkDialogs;
using Win32SaveFileDialog = System.Windows.Forms.SaveFileDialog;

namespace MvvmDialogs.Wpf.FrameworkDialogs
{
    /// <summary>
    /// Class wrapping <see cref="System.Windows.Forms.SaveFileDialog"/>.
    /// </summary>
    internal class SaveFileDialog : FrameworkDialogBase<SaveFileDialogSettings, string?>
    {
        /// <inheritdoc />
        public SaveFileDialog(SaveFileDialogSettings settings, AppDialogSettings appSettings)
            : base(settings, appSettings)
        {
        }

        /// <inheritdoc />
        public override Task<string?> ShowDialogAsync(WindowWrapper owner) =>
            Task.Run(
                () =>
                {
                    var dialog = new Win32SaveFileDialog();
                    ToDialog(dialog);

                    var result = dialog.ShowDialog(owner.Win32Window);

                    return result == DialogResult.OK ? dialog.FileName : null;
                });

        private void ToDialog(System.Windows.Forms.SaveFileDialog d)
        {
            OpenFileDialog.ToDialogShared(Settings, AppSettings, d);
            d.CheckFileExists = Settings.CheckFileExists;
            d.CreatePrompt = Settings.CreatePrompt;
            d.OverwritePrompt = Settings.OverwritePrompt;
        }
    }
}
