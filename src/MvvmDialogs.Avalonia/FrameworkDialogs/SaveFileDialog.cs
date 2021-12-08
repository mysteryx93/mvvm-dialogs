using System.Threading.Tasks;
using MvvmDialogs.FrameworkDialogs;
using AvaloniaSaveFileDialog = Avalonia.Controls.SaveFileDialog;

namespace MvvmDialogs.Avalonia.FrameworkDialogs
{
    /// <summary>
    /// Class wrapping <see cref="AvaloniaSaveFileDialog"/>.
    /// </summary>
    internal class SaveFileDialog : FrameworkDialogBase<SaveFileDialogSettings, string?>
    {
        /// <inheritdoc />
        public SaveFileDialog(SaveFileDialogSettings settings, AppDialogSettings appSettings)
            : base(settings, appSettings)
        {
        }

        /// <inheritdoc />
        public override async Task<string?> ShowDialogAsync(WindowWrapper owner)
        {
            var dialog = new AvaloniaSaveFileDialog();
            ToDialog(dialog);

            var result = await dialog.ShowAsync(owner.Ref);
            return result;
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
