using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace MvvmDialogs.Wpf.FrameworkDialogs.Api
{
    /// <inheritdoc />
    internal class FrameworkDialogsApi : IFrameworkDialogsApi
    {

    public Task<MessageBoxResult> ShowMessageBoxAsync(Window owner, MessageBoxApiSettings settings) =>
        Task.FromResult(
            System.Windows.MessageBox.Show(
                owner,
                settings.MessageBoxText,
                settings.Caption,
                settings.Buttons,
                settings.Icon,
                settings.DefaultButton));

    public async Task<string[]?> ShowOpenFileDialogAsync(Window owner, OpenFileApiSettings settings)
        {
            var dialog = new System.Windows.Forms.OpenFileDialog();
            settings.ApplyTo(dialog);
            var result = await dialog.ShowDialogAsync(owner);
            return result == DialogResult.OK ? dialog.FileNames : null;
        }

        public async Task<string?> ShowSaveFileDialogAsync(Window owner, SaveFileApiSettings settings)
        {
            var dialog = new System.Windows.Forms.SaveFileDialog();
            settings.ApplyTo(dialog);
            var result = await dialog.ShowDialogAsync(owner);
            return result == DialogResult.OK ? dialog.FileName : null;
        }

        public async Task<string?> ShowOpenFolderDialogAsync(Window owner, OpenFolderApiSettings settings)
        {
            var dialog = new FolderBrowserDialog();
            settings.ApplyTo(dialog);
            var result = await dialog.ShowDialogAsync(owner);
            return result == DialogResult.OK ? dialog.SelectedPath : null;
        }
    }
}
