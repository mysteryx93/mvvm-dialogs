using System.Threading.Tasks;
using MvvmDialogs.FrameworkDialogs;

namespace MvvmDialogs.Wpf.FrameworkDialogs
{
    /// <summary>
    /// Class wrapping <see cref="System.Windows.Forms.SaveFileDialog"/>.
    /// </summary>
    internal sealed class SaveFileDialog : FrameworkDialogBase<SaveFileDialogSettings>
    {
        /// <inheritdoc />
        public SaveFileDialog(SaveFileDialogSettings settings)
            : base(settings)
        {
        }

        /// <inheritdoc />
        public override Task<bool?> ShowDialogAsync(WindowWrapper owner) =>
            Task.Run(
                () =>
                {
                    var dialog = new System.Windows.Forms.SaveFileDialog();
                    ToDialog(dialog);

                    var result = dialog.ShowDialog(owner.Win32Window);

                    Settings.FileName = dialog.FileName;
                    return result.AsBool();
                });

        private void ToDialog(System.Windows.Forms.SaveFileDialog d)
        {
            OpenFileDialog.ToDialogShared(Settings, d);
            // d.AddExtension
            d.DefaultExt = Settings.DefaultExt;
            d.CheckFileExists = Settings.CheckFileExists;
            d.CreatePrompt = Settings.CreatePrompt;
            d.OverwritePrompt = Settings.OverwritePrompt;
        }
    }
}
