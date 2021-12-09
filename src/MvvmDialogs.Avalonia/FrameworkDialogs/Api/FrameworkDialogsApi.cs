
using System.Threading.Tasks;
using Avalonia.Controls;
using MessageBox.Avalonia;
using MessageBox.Avalonia.Enums;

namespace MvvmDialogs.Avalonia.FrameworkDialogs.Api
{
    /// <inheritdoc />
    internal class FrameworkDialogsApi : IFrameworkDialogsApi
    {
        public Task<ButtonResult> ShowMessageBox(Window owner, MessageBoxApiSettings settings) =>
            MessageBoxManager.GetMessageBoxStandardWindow(
                settings.Title,
                settings.Text,
                settings.Buttons,
                settings.Icon,
                settings.StartupLocation,
                settings.Style).ShowDialog(owner);

        public Task<string[]?> ShowOpenFileDialog(Window owner, OpenFileApiSettings settings)
        {
            var dialog = new global::Avalonia.Controls.OpenFileDialog();
            settings.ApplyTo(dialog);
            return dialog.ShowAsync(owner);
        }

        public Task<string?> ShowSaveFileDialog(Window owner, SaveFileApiSettings settings)
        {
            var dialog = new global::Avalonia.Controls.SaveFileDialog();
            settings.ApplyTo(dialog);
            return dialog.ShowAsync(owner);
        }

        public Task<string?> ShowOpenFolderDialog(Window owner, OpenFolderApiSettings settings)
        {
            var dialog = new global::Avalonia.Controls.OpenFolderDialog();
            settings.ApplyTo(dialog);
            return dialog.ShowAsync(owner);
        }
    }
}
