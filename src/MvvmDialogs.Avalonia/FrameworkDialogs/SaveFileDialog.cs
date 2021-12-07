using System.Threading.Tasks;
using MvvmDialogs.FrameworkDialogs;

namespace MvvmDialogs.Avalonia.FrameworkDialogs
{
    /// <summary>
    /// Class wrapping <see cref="Avalonia.Controls.SaveFileDialog"/>.
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
            var dialog = new global::Avalonia.Controls.SaveFileDialog();
            ToDialog(dialog);

            Settings.FileName = await dialog.ShowAsync(owner.Ref);

            return !string.IsNullOrEmpty(Settings.FileName);
        }

        private void ToDialog(global::Avalonia.Controls.SaveFileDialog d)
        {
            OpenFileDialog.ToDialogShared(Settings, d);
            // d.CreatePrompt = Settings.CreatePrompt;
            // d.OverwritePrompt = Settings.OverwritePrompt;
            d.DefaultExtension = s.DefaultExt;
        }
    }
}
