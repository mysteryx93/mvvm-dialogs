using System.Threading.Tasks;
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
        public OpenFolderDialog(IFrameworkDialogsApi api, IPathInfoFactory pathInfo, OpenFolderDialogSettings settings, AppDialogSettings appSettings)
            : base(settings, appSettings, pathInfo, api)
        {
        }

        /// <inheritdoc />
        public override Task<string?> ShowDialogAsync(WindowWrapper owner)
        {
            var apiSettings = GetApiSettings();
            return Task.FromResult(Api.ShowOpenFolderDialog(owner.Ref, apiSettings));
        }

        private OpenFolderApiSettings GetApiSettings() =>
            new()
            {
                Description = Settings.Title,
                SelectedPath = Settings.InitialPath,
                ShowNewFolderButton = Settings.ShowNewFolderButton,
                HelpRequest = Settings.HelpRequest
            };
    }
}
