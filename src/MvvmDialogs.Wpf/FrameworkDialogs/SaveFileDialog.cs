using System.Threading.Tasks;
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
                    return Api.ShowSaveFileDialog(owner.Ref, apiSettings);
                });

        private SaveFileApiSettings GetApiSettings()
        {
            var d = new SaveFileApiSettings()
            {
                CheckFileExists = Settings.CheckFileExists,
                CreatePrompt = Settings.CreatePrompt,
                OverwritePrompt = Settings.OverwritePrompt
            };
            OpenFileDialog.GetApiSettingsShared(Settings, AppSettings, d);
            return d;
        }
    }
}
