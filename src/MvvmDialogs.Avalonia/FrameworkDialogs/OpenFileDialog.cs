using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using MvvmDialogs.FrameworkDialogs;
using AvaloniaOpenFileDialog = Avalonia.Controls.OpenFileDialog;

namespace MvvmDialogs.Avalonia.FrameworkDialogs
{
    /// <summary>
    /// Class wrapping <see cref="AvaloniaOpenFileDialog"/>.
    /// </summary>
    internal sealed class OpenFileDialog : FrameworkDialogBase<OpenFileDialogSettings>
    {
        /// <inheritdoc />
        public OpenFileDialog(OpenFileDialogSettings settings, AppDialogSettings appSettings)
            : base(settings, appSettings)
        {
        }

        /// <inheritdoc />
        public override async Task<bool?> ShowDialogAsync(WindowWrapper owner)
        {
            var dialog = new AvaloniaOpenFileDialog();
            ToDialog(dialog);

            Settings.FileNames = await dialog.ShowAsync(owner.Ref) ?? Array.Empty<string>();

            return Settings.FileNames.Length > 0;
        }

        private void ToDialog(global::Avalonia.Controls.OpenFileDialog d)
        {
            ToDialogShared(Settings, d);
            d.AllowMultiple = Settings.AllowMultiple;
            // d.ShowReadOnly = Settings.ShowReadOnly;
            // d.ReadOnlyChecked = Settings.ReadOnlyChecked;
        }

        internal static void ToDialogShared(FileDialogSettings s, FileDialog d)
        {
            // s.DefaultExt
            // d.AddExtension = s.AddExtension;
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
