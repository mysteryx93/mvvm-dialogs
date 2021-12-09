using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using MvvmDialogs.Avalonia.FrameworkDialogs.Api;
using MvvmDialogs.FrameworkDialogs;
using AvaloniaOpenFileDialog = Avalonia.Controls.OpenFileDialog;

namespace MvvmDialogs.Avalonia.FrameworkDialogs
{
    /// <summary>
    /// Class wrapping <see cref="AvaloniaOpenFileDialog"/>.
    /// </summary>
    internal class OpenFileDialog : FrameworkDialogBase<OpenFileDialogSettings, string[]>
    {
        /// <inheritdoc />
        public OpenFileDialog(IFrameworkDialogsApi api, OpenFileDialogSettings settings, AppDialogSettings appSettings)
            : base(api, settings, appSettings)
        {
        }

        /// <inheritdoc />
        public override async Task<string[]> ShowDialogAsync(WindowWrapper owner)
        {
            var apiSettings = GetApiSettings();
            var result = await Api.ShowOpenFileDialog(owner.Ref, apiSettings).ConfigureAwait(false);
            return result ?? Array.Empty<string>();
        }

        private OpenFileApiSettings GetApiSettings()
        {
            var d = new OpenFileApiSettings()
            {
                AllowMultiple = Settings.AllowMultiple
                // d.ShowReadOnly = Settings.ShowReadOnly;
                // d.ReadOnlyChecked = Settings.ReadOnlyChecked;
            };
            ToDialogShared(Settings, d);
            return d;
        }

        internal static void ToDialogShared(FileDialogSettings s, FileApiSettings d)
        {
            // s.DefaultExtension
            // d.DereferenceLinks = s.DereferenceLinks;
            // d.CheckFileExists = s.CheckFileExists;
            // d.CheckPathExists = s.CheckPathExists;
            var file = new FileInfo(s.InitialPath);
            d.Directory = file.DirectoryName;
            d.InitialFileName = file.Name;
            d.Filters = SyncFilters(s.Filters);
            d.Title = s.Title;
        }

        private static List<FileDialogFilter> SyncFilters(List<FileFilter> filters) =>
            filters.Select(
                x => new FileDialogFilter()
                {
                    Name = x.NameToString(x.ExtensionsToString()), Extensions = x.Extensions
                }).ToList();
    }
}
