using System.Threading.Tasks;
using System.Windows.Forms;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.Wpf.FrameworkDialogs.Api;
using Win32FolderBrowserDialog = System.Windows.Forms.FolderBrowserDialog;

namespace MvvmDialogs.Wpf.FrameworkDialogs
{
    /// <summary>
    /// Class wrapping <see cref="System.Windows.Forms.FolderBrowserDialog"/>.
    /// </summary>
    internal class OpenFolderDialog : FrameworkDialogBase<OpenFolderDialogSettings, string?>
    {
        /// <inheritdoc />
        public OpenFolderDialog(IFrameworkDialogsApi api, OpenFolderDialogSettings settings, AppDialogSettings appSettings)
            : base(api, settings, appSettings)
        {
        }

        /// <inheritdoc />
        public override Task<string?> ShowDialogAsync(WindowWrapper owner) =>
            Task.Run(
                () =>
                {
                    var apiSettings = GetApiSettings();
                    var result = Api.ShowFolderBrowserDialog(owner.Ref, apiSettings);
                    return result == DialogResult.OK ? apiSettings.SelectedPath : null;
                });

        private FolderBrowserApiSettings GetApiSettings() =>
            new FolderBrowserApiSettings
            {
                Description = Settings.Title,
                SelectedPath = Settings.SelectedPath,
                ShowNewFolderButton = Settings.ShowNewFolderButton
            };
    }
}
