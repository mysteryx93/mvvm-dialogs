using System;
using System.IO;
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
            d.Filters = s.Filter;
            d.Title = s.Title;
        }
    }
}
