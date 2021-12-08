using System.Threading.Tasks;
using System.Windows.Forms;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.Wpf.FrameworkDialogs.Api;
using Win32SaveFileDialog = System.Windows.Forms.SaveFileDialog;

namespace MvvmDialogs.Wpf.FrameworkDialogs
{
    /// <summary>
    /// Class wrapping <see cref="System.Windows.Forms.SaveFileDialog"/>.
    /// </summary>
    internal class SaveFileDialog : FrameworkDialogBase<SaveFileDialogSettings, string?>
    {
        /// <inheritdoc />
        public SaveFileDialog(IFrameworkDialogsApi api, SaveFileDialogSettings settings, AppDialogSettings appSettings)
            : base(api, settings, appSettings)
        {
        }

        /// <inheritdoc />
        public override Task<string?> ShowDialogAsync(WindowWrapper owner) =>
            Task.Run(
                () =>
                {
                    var apiSettings = GetApiSettings();
                    var result = Api.ShowSaveFileDialog(owner.Ref, apiSettings);
                    return result == DialogResult.OK ? apiSettings.FileName : null;
                });

        private SaveFileApiSettings GetApiSettings()
        {
            var d = new SaveFileApiSettings();
            OpenFileDialog.GetApiSettingsShared(Settings, AppSettings, d);
            d.CheckFileExists = Settings.CheckFileExists;
            d.CreatePrompt = Settings.CreatePrompt;
            d.OverwritePrompt = Settings.OverwritePrompt;
            return d;
        }
    }
}
