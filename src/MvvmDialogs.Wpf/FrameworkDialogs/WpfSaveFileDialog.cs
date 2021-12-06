using System.Threading.Tasks;
using System.Windows.Forms;
using MvvmDialogs.Core.FrameworkDialogs;
using MvvmDialogs.Wpf.DialogFactories;

namespace MvvmDialogs.Wpf.FrameworkDialogs
{
    /// <summary>
    /// Class wrapping <see cref="SaveFileDialog"/>.
    /// </summary>
    internal sealed class WpfSaveFileDialog : WpfFrameworkDialogBase<SaveFileDialogSettings>
    {
        /// <inheritdoc />
        public WpfSaveFileDialog(SaveFileDialogSettings settings)
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

                    WpfOpenFileDialog.ToSettingsShared(dialog, Settings);
                    return result.AsBool();
                });

        private void ToDialog(SaveFileDialog d)
        {
            WpfOpenFileDialog.ToDialogShared(Settings, d);
            d.CheckFileExists = Settings.CheckFileExists;
            d.CreatePrompt = Settings.CreatePrompt;
            d.OverwritePrompt = Settings.OverwritePrompt;
        }
    }
}
