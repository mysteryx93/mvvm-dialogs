using System;
using MvvmDialogs.FrameworkDialogs;

namespace MvvmDialogs.Wpf.FrameworkDialogs
{
    /// <summary>
    /// Default framework dialog factory that will create instances of standard Windows dialogs.
    /// </summary>
    public class FrameworkDialogFactory : IFrameworkDialogFactory
    {
        /// <inheritdoc />
        public virtual IFrameworkDialog Create<T>(T settings) =>
            settings switch
            {
                MessageBoxSettings s => new MessageBox(s),
                OpenFileDialogSettings s => new OpenFileDialog(s),
                SaveFileDialogSettings s => new SaveFileDialog(s),
                FolderBrowserDialogSettings s => new FolderBrowserDialog(s),
                _ => throw new NotSupportedException()
            };
    }
}
