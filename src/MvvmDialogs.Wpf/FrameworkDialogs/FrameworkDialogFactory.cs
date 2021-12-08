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
        public virtual IFrameworkDialog Create<T>(T settings, AppDialogSettingsBase appSettings)
            where T : DialogSettingsBase
        {
            var s2 = (AppDialogSettings)appSettings;
            return settings switch
            {
                MessageBoxSettings s => new MessageBox(s, s2),
                OpenFileDialogSettings s => new OpenFileDialog(s, s2),
                SaveFileDialogSettings s => new SaveFileDialog(s, s2),
                OpenFolderDialogSettings s => new OpenFolderDialog(s, s2),
                _ => throw new NotSupportedException()
            };
        }
    }
}
