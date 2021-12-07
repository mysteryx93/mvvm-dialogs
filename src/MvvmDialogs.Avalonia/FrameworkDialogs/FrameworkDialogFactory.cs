using System;
using MvvmDialogs.FrameworkDialogs;

namespace MvvmDialogs.Avalonia.FrameworkDialogs
{
    /// <summary>
    /// Default framework dialog factory that will create instances of standard Windows dialogs.
    /// </summary>
    public class FrameworkDialogFactory : IFrameworkDialogFactory
    {
        /// <inheritdoc />
        public IFrameworkDialog Create<T>(T settings, AppDialogSettingsBase appSettings)
            where T : DialogSettingsBase
        {
            var s2 = (AppDialogSettings)appSettings;
            return settings switch
            {
                MessageBoxSettings s => new MessageBox(s, s2),
                OpenFileDialogSettings s => new OpenFileDialog(s, s2),
                SaveFileDialogSettings s => new SaveFileDialog(s, s2),
                FolderBrowserDialogSettings s => new FolderBrowserDialog(s, s2),
                _ => throw new NotSupportedException()
            };
        }
    }
}
