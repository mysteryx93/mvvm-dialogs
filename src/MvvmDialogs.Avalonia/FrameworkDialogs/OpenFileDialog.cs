using System;
using System.Threading.Tasks;
using MvvmDialogs.Avalonia.FrameworkDialogs.Api;
using MvvmDialogs.FrameworkDialogs;
using AvaloniaOpenFileDialog = Avalonia.Controls.OpenFileDialog;

namespace MvvmDialogs.Avalonia.FrameworkDialogs;

/// <summary>
/// Class wrapping <see cref="AvaloniaOpenFileDialog"/>.
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
        var result = await Api.ShowOpenFileDialog(owner.Ref, apiSettings).ConfigureAwait(false);
        return result ?? Array.Empty<string>();
    }

    private OpenFileApiSettings GetApiSettings()
    {
        var d = new OpenFileApiSettings()
        {
            AllowMultiple = Settings.AllowMultiple
            // d.ShowReadOnly = Settings.ShowReadOnly;
            // d.ReadOnlyChecked = Settings.ReadOnlyChecked;
        };
        AddSharedSettings(d);
        return d;
    }
}