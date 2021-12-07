﻿using System.Threading.Tasks;
using MvvmDialogs.FrameworkDialogs;

namespace MvvmDialogs.Avalonia.FrameworkDialogs
{
    /// <summary>
    /// Class wrapping <see cref="FolderBrowserDialog"/>.
    /// </summary>
    public class FolderBrowserDialog : FrameworkDialogBase<FolderBrowserDialogSettings>
    {
        /// <inheritdoc />
        public FolderBrowserDialog(FolderBrowserDialogSettings settings, AppDialogSettings appSettings)
            : base(settings, appSettings)
        {
        }

        /// <inheritdoc />
        public override Task<bool?> ShowDialogAsync(WindowWrapper owner) =>
            Task.Run(
                () =>
                {
                    using var dialog = new FolderBrowserDialog();
                    ToDialog(dialog);

                    var result = dialog.ShowDialog(owner.Win32Window);

                    ToSettings(dialog);
                    return result.AsBool();
                });


        private void ToDialog(FolderBrowserDialog d)
        {
            d.Description = Settings.Description;
            d.RootFolder = Settings.RootFolder;
            d.SelectedPath = Settings.SelectedPath;
            d.ShowNewFolderButton = Settings.ShowNewFolderButton;
        }

        private void ToSettings(FolderBrowserDialog d) => Settings.SelectedPath = d.SelectedPath;
    }
}
