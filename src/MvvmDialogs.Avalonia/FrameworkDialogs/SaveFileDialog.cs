﻿using System.Threading.Tasks;
using MvvmDialogs.Avalonia.FrameworkDialogs.Api;
using MvvmDialogs.FrameworkDialogs;
using AvaloniaSaveFileDialog = Avalonia.Controls.SaveFileDialog;

namespace MvvmDialogs.Avalonia.FrameworkDialogs
{
    /// <summary>
    /// Class wrapping <see cref="AvaloniaSaveFileDialog"/>.
    /// </summary>
    internal class SaveFileDialog : FileDialogBase<SaveFileDialogSettings, string?>
    {
        /// <inheritdoc />
        public SaveFileDialog(IFrameworkDialogsApi api, IPathInfoFactory pathInfo, SaveFileDialogSettings settings, AppDialogSettings appSettings)
            : base(api, pathInfo, settings, appSettings)
        {
        }

        /// <inheritdoc />
        public override async Task<string?> ShowDialogAsync(WindowWrapper owner)
        {
            var apiSettings = GetApiSettings();
            var result = await Api.ShowSaveFileDialog(owner.Ref, apiSettings).ConfigureAwait(false);
            return result;
        }

        private SaveFileApiSettings GetApiSettings()
        {
            var d = new SaveFileApiSettings()
            {
                DefaultExtension = Settings.DefaultExtension
                // d.CreatePrompt = Settings.CreatePrompt;
                // d.OverwritePrompt = Settings.OverwritePrompt;
            };
            AddSharedSettings(d);
            return d;
        }
    }
}
