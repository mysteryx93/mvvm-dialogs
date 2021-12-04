using System.Windows.Forms;
using MvvmDialogs.Core.FrameworkDialogs;
using MvvmDialogs.Wpf.DialogFactories;

namespace MvvmDialogs.Wpf.FrameworkDialogs
{
    /// <summary>
    /// Class wrapping <see cref="SaveFileDialog"/>.
    /// </summary>
    internal sealed class SaveFileDialogWrapper : WpfFrameworkDialogBase<SaveFileDialogSettings>
    {
        /// <inheritdoc />
        public SaveFileDialogWrapper(SaveFileDialogSettings settings)
            : base(settings)
        {
        }

        /// <inheritdoc />
        public override bool? ShowDialog(WpfWindow owner)
        {
            var dialog = new SaveFileDialog();
            ToDialog(dialog);

            var result = dialog.ShowDialog(owner.Win32Window);

            WpfOpenFileDialog.ToSettingsShared(dialog, Settings);
            return result.AsBool();
        }

        private void ToDialog(SaveFileDialog d)
        {
            WpfOpenFileDialog.ToDialogShared(Settings, d);
            d.CheckFileExists = Settings.CheckFileExists;
            d.CreatePrompt = Settings.CreatePrompt;
            d.OverwritePrompt = Settings.OverwritePrompt;
        }
    }
}
