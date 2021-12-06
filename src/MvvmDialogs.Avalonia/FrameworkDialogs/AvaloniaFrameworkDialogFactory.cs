using System;
using MvvmDialogs.Core.FrameworkDialogs;

namespace MvvmDialogs.Avalonia.FrameworkDialogs
{
    /// <summary>
    /// Default framework dialog factory that will create instances of standard Windows dialogs.
    /// </summary>
    public class AvaloniaFrameworkDialogFactory : IFrameworkDialogFactory
    {
        /// <inheritdoc />
        public virtual IFrameworkDialog Create<T>(T settings) =>
            settings switch
            {
                MessageBoxSettings s => new AvaloniaMessageBox(s),
                OpenFileDialogSettings s => new AvaloniaOpenFileDialog(s),
                SaveFileDialogSettings s => new AvaloniaSaveFileDialog(s),
                FolderBrowserDialogSettings s => new AvaloniaFolderBrowserDialog(s),
                _ => throw new NotSupportedException()
            };
    }
}
