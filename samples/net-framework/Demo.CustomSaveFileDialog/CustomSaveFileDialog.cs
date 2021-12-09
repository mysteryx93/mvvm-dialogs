﻿using System.Threading.Tasks;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.Wpf;
using MvvmDialogs.Wpf.FrameworkDialogs;
using Ookii.Dialogs.Wpf;

namespace Demo.CustomSaveFileDialog
{
    public class CustomSaveFileDialog : FrameworkDialogBase<SaveFileDialogSettings, string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomSaveFileDialog"/> class.
        /// </summary>
        /// <param name="settings">The settings for the save file dialog.</param>
        /// <param name="appSettings">Application-wide settings configured on the DialogService.</param>
        public CustomSaveFileDialog(SaveFileDialogSettings settings, AppDialogSettings appSettings)
            : base(settings, appSettings)
        {
        }

        public override Task<string> ShowDialogAsync(WindowWrapper owner)
        {
            var s = Settings;
            var fileInfo = !string.IsNullOrEmpty(s.InitialPath) ? new FileInfo(s.InitialPath) : null;
            var saveFileDialog = new VistaSaveFileDialog
            {
                AddExtension = !string.IsNullOrEmpty(s.DefaultExtension),
                CheckFileExists = s.CheckFileExists,
                CheckPathExists = s.CheckPathExists,
                CreatePrompt = s.CreatePrompt,
                DefaultExt = s.DefaultExtension,
                FileName = fileInfo?.FileName,
                InitialDirectory = fileInfo?.DirectoryName,
                OverwritePrompt = s.OverwritePrompt,
                Title = s.Title
                // Filter = s.Filter
            };
            var result = saveFileDialog.ShowDialog(owner.Ref);
            return Task.FromResult(result == true ? saveFileDialog.FileName : null);
        }
    }
}
