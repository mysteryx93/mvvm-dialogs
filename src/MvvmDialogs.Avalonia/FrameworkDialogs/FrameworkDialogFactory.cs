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
        public IFrameworkDialog<TResult> Create<TSettings, TResult>(TSettings settings, AppDialogSettingsBase appSettings)
            where TSettings : DialogSettingsBase
        {
            var s2 = (AppDialogSettings)appSettings;
            return settings switch
            {
                MessageBoxSettings s => (IFrameworkDialog<TResult>)new MessageBox(s, s2),
                OpenFileDialogSettings s => (IFrameworkDialog<TResult>)new OpenFileDialog(s, s2),
                SaveFileDialogSettings s => (IFrameworkDialog<TResult>)new SaveFileDialog(s, s2),
                OpenFolderDialogSettings s => (IFrameworkDialog<TResult>)new OpenFolderDialog(s, s2),
                _ => throw new NotSupportedException()
            };
        }
    }
}
