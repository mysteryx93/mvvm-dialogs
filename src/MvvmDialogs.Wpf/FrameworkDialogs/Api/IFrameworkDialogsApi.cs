using System.Windows;
using System.Windows.Forms;

namespace MvvmDialogs.Wpf.FrameworkDialogs.Api
{
    /// <summary>
    /// Wrapper around Win32 dialogs API that can be replaced by a mock for testing.
    /// </summary>
    public interface IFrameworkDialogsApi
    {
        MessageBoxResult ShowMessageBox(Window owner, MessageBoxApiSettings settings);
        DialogResult ShowOpenFileDialog(Window owner, OpenFileApiSettings settings);
        DialogResult ShowSaveFileDialog(Window owner, SaveFileApiSettings settings);
        DialogResult ShowFolderBrowserDialog(Window owner, FolderBrowserApiSettings settings);
    }
}
