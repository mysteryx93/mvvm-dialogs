using System.Windows.Forms;
using MvvmDialogs.Core.FrameworkDialogs;
using MvvmDialogs.Wpf.DialogFactories;

namespace MvvmDialogs.Wpf.FrameworkDialogs
{
    /// <summary>
    /// Class wrapping <see cref="FolderBrowserDialog"/>.
    /// </summary>
    public class WpfFolderBrowserDialog : WpfFrameworkDialogBase<FolderBrowserDialogSettings>
    {
        /// <inheritdoc />
        public WpfFolderBrowserDialog(FolderBrowserDialogSettings settings)
            : base(settings)
        {
        }

        /// <inheritdoc />
        public override bool? ShowDialog(WpfWindow owner)
        {
            using var dialog = new FolderBrowserDialog();
            ToDialog(dialog);

            var result = dialog.ShowDialog(owner.Win32Window);

            ToSettings(dialog);
            return result.AsBool();
        }

        private void ToDialog(FolderBrowserDialog d)
        {
            d.Description = Settings.Description;
            d.RootFolder = Settings.RootFolder;
            d.SelectedPath = Settings.SelectedPath;
            d.ShowNewFolderButton = Settings.ShowNewFolderButton;
        }

        private void ToSettings(FolderBrowserDialog d) => Settings.SelectedPath = d.SelectedPath;
    }
}
