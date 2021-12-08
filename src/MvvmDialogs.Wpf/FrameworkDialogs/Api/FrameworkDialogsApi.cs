using System.Windows;
using System.Windows.Forms;

namespace MvvmDialogs.Wpf.FrameworkDialogs.Api
{
    /// <inheritdoc />
    internal class FrameworkDialogsApi : IFrameworkDialogsApi
    {
        public MessageBoxResult ShowMessageBox(Window owner, MessageBoxApiSettings settings) =>
            System.Windows.MessageBox.Show(
                owner,
                settings.MessageBoxText,
                settings.Caption,
                settings.Buttons,
                settings.Icon,
                settings.DefaultButton);

        public DialogResult ShowOpenFileDialog(Window owner, OpenFileApiSettings settings)
        {
            var dialog = new System.Windows.Forms.OpenFileDialog();
            settings.ApplyTo(dialog);
            var result = dialog.ShowDialog();
            settings.ResultsFrom(dialog);
            return result;
        }

        public DialogResult ShowSaveFileDialog(Window owner, SaveFileApiSettings settings)
        {
            var dialog = new System.Windows.Forms.SaveFileDialog();
            settings.ApplyTo(dialog);
            var result = dialog.ShowDialog();
            settings.ResultsFrom(dialog);
            return result;
        }

        public DialogResult ShowFolderBrowserDialog(Window owner, FolderBrowserApiSettings settings)
        {
            var dialog = new FolderBrowserDialog();
            settings.ApplyTo(dialog);
            var result = dialog.ShowDialog();
            settings.ResultsFrom(dialog);
            return result;
        }
    }
}
