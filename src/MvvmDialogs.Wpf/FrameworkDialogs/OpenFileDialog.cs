using System;
using System.Threading.Tasks;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.Wpf.FrameworkDialogs.Api;
using Win32CustomPlace = System.Windows.Forms.FileDialogCustomPlace;
using Win32CustomPlaces = Microsoft.Win32.FileDialogCustomPlaces;
using Win32OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace MvvmDialogs.Wpf.FrameworkDialogs;

/// <summary>
/// Class wrapping <see cref="System.Windows.Forms.OpenFileDialog"/>.
/// </summary>
internal class OpenFileDialog : FileDialogBase<OpenFileDialogSettings, string[]>
{
    /// <inheritdoc />
    public OpenFileDialog(IFrameworkDialogsApi api, IPathInfoFactory pathInfo, OpenFileDialogSettings settings, AppDialogSettings appSettings)
        : base(api, pathInfo, settings, appSettings)
    {
    }

    /// <inheritdoc />
    public override async Task<string[]> ShowDialogAsync(WindowWrapper owner)
    {
        var apiSettings = GetApiSettings();
        return await Api.ShowOpenFileDialogAsync(owner.Ref, apiSettings) ?? Array.Empty<string>();
    }

    private OpenFileApiSettings GetApiSettings()
    {
        var d = new OpenFileApiSettings()
        {
            Multiselect = Settings.AllowMultiple,
            ReadOnlyChecked = Settings.ReadOnlyChecked,
            ShowReadOnly = Settings.ShowReadOnly
        };
        AddSharedSettings(d);
        return d;
    }
}