using System.Threading.Tasks;
using MvvmDialogs.FrameworkDialogs;
using AvaloniaSaveFileDialog = Avalonia.Controls.SaveFileDialog;

namespace MvvmDialogs.Avalonia.FrameworkDialogs
{
    /// <summary>
    /// Class wrapping <see cref="AvaloniaSaveFileDialog"/>.
    /// </summary>
    internal sealed class SaveFileDialog : FrameworkDialogBase<SaveFileDialogSettings>
    {
        /// <inheritdoc />
        public SaveFileDialog(SaveFileDialogSettings settings, AppDialogSettings appSettings)
            : base(settings, appSettings)
        {
        }

        /// <inheritdoc />
        public override async Task<bool?> ShowDialogAsync(WindowWrapper owner)
        {
            var dialog = new AvaloniaSaveFileDialog();
            ToDialog(dialog);

            Settings.FileName = await dialog.ShowAsync(owner.Ref);

            return !string.IsNullOrEmpty(Settings.FileName);
        }

        private void ToDialog(global::Avalonia.Controls.SaveFileDialog d)
        {
            OpenFileDialog.ToDialogShared(Settings, d);
            // d.CreatePrompt = Settings.CreatePrompt;
            // d.OverwritePrompt = Settings.OverwritePrompt;
            d.DefaultExtension = Settings.DefaultExtension;
        }
    }
}
