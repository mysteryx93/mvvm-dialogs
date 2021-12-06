using System;
using MvvmDialogs.Core.FrameworkDialogs;

namespace MvvmDialogs.Wpf.FrameworkDialogs
{
    /// <summary>
    /// Default framework dialog factory that will create instances of standard Windows dialogs.
    /// </summary>
    public class WpfFrameworkDialogFactory : IFrameworkDialogFactory
    {
        /// <inheritdoc />
        public virtual IFrameworkDialog Create<T>(T settings) =>
            settings switch
            {
                MessageBoxSettings s => new WpfMessageBox(s),
                OpenFileDialogSettings s => new WpfOpenFileDialog(s),
                SaveFileDialogSettings s => new WpfSaveFileDialog(s),
                FolderBrowserDialogSettings s => new WpfFolderBrowserDialog(s),
                _ => throw new NotSupportedException()
            };
    }
}
