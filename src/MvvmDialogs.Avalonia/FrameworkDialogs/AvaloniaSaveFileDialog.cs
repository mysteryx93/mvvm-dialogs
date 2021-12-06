using System.Threading.Tasks;
using Avalonia.Controls;
using MvvmDialogs.Avalonia.FrameworkDialogs;
using MvvmDialogs.Core.FrameworkDialogs;

namespace MvvmDialogs.Wpf.FrameworkDialogs
{
    /// <summary>
    /// Class wrapping <see cref="SaveFileDialog"/>.
    /// </summary>
    internal sealed class AvaloniaSaveFileDialog : AvaloniaFrameworkDialogBase<SaveFileDialogSettings>
    {
        /// <inheritdoc />
        public AvaloniaSaveFileDialog(SaveFileDialogSettings settings)
            : base(settings)
        {
        }

        /// <inheritdoc />
        public override Task<bool?> ShowDialogAsync(WpfWindow owner) =>
            Task.Run(
                () =>
                {
                    var dialog = new SaveFileDialog();
                    ToDialog(dialog);

                    var result = dialog.ShowDialog(owner.Win32Window);

                    AvaloniaOpenFileDialog.ToSettingsShared(dialog, Settings);
                    return result.AsBool();
                });

        private void ToDialog(SaveFileDialog d)
        {
            AvaloniaOpenFileDialog.ToDialogShared(Settings, d);
            d.CheckFileExists = Settings.CheckFileExists;
            d.CreatePrompt = Settings.CreatePrompt;
            d.OverwritePrompt = Settings.OverwritePrompt;
        }
    }
}
