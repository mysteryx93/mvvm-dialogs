﻿using System.Windows;
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

        public string[]? ShowOpenFileDialog(Window owner, OpenFileApiSettings settings)
        {
            var dialog = new System.Windows.Forms.OpenFileDialog();
            settings.ApplyTo(dialog);
            var result = dialog.ShowDialog();
            return result == DialogResult.OK ? dialog.FileNames : null;
        }

        public string? ShowSaveFileDialog(Window owner, SaveFileApiSettings settings)
        {
            var dialog = new System.Windows.Forms.SaveFileDialog();
            settings.ApplyTo(dialog);
            var result = dialog.ShowDialog();
            return result == DialogResult.OK ? dialog.FileName : null;
        }

        public string? ShowOpenFolderDialog(Window owner, OpenFolderApiSettings settings)
        {
            var dialog = new FolderBrowserDialog();
            settings.ApplyTo(dialog);
            var result = dialog.ShowDialog();
            return result == DialogResult.OK ? dialog.SelectedPath : null;
        }
    }
}
