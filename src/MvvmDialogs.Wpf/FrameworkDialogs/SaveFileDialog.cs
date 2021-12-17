using System.Threading.Tasks;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.Wpf.FrameworkDialogs.Api;
using Win32SaveFileDialog = System.Windows.Forms.SaveFileDialog;

namespace MvvmDialogs.Wpf.FrameworkDialogs;

/// <summary>
/// Class wrapping <see cref="System.Windows.Forms.SaveFileDialog"/>.
/// </summary>
internal class SaveFileDialog : FileDialogBase<SaveFileDialogSettings, string?>
{
    /// <inheritdoc />
    public SaveFileDialog(IFrameworkDialogsApi api, IPathInfoFactory pathInfo, SaveFileDialogSettings settings, AppDialogSettings appSettings)
        : base(api, pathInfo, settings, appSettings)
    {
    }

    /// <inheritdoc />
    public override Task<string?> ShowDialogAsync(WindowWrapper owner)
    {
        var apiSettings = GetApiSettings();
        return Api.ShowSaveFileDialogAsync(owner.Ref, apiSettings);
        // return Task.FromResult(Api.ShowSaveFileDialog(owner.Ref, apiSettings));
    }

    private SaveFileApiSettings GetApiSettings()
    {
        var d = new SaveFileApiSettings()
        {
            CheckFileExists = Settings.CheckFileExists,
            CreatePrompt = Settings.CreatePrompt,
            OverwritePrompt = Settings.OverwritePrompt
        };
        AddSharedSettings(d);
        return d;
    }
}