using AvaloniaSaveFileDialog = Avalonia.Controls.SaveFileDialog;

namespace MvvmDialogs.Avalonia.FrameworkDialogs.Api;

internal class SaveFileApiSettings : FileApiSettings
{
    public string? DefaultExtension { get; set; }

    internal void ApplyTo(AvaloniaSaveFileDialog d)
    {
        base.ApplyTo(d);
        d.DefaultExtension = DefaultExtension;
    }
}