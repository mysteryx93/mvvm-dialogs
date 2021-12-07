using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using MvvmDialogs.FrameworkDialogs;

namespace MvvmDialogs.Avalonia.FrameworkDialogs
{
    /// <summary>
    /// Class wrapping <see cref="Avalonia.Controls.OpenFileDialog"/>.
    /// </summary>
    internal sealed class OpenFileDialog : FrameworkDialogBase<OpenFileDialogSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenFileDialog"/> class.
        /// </summary>
        /// <param name="settings">The settings for the open file dialog.</param>
        public OpenFileDialog(OpenFileDialogSettings settings)
            : base(settings)
        {
        }

        /// <inheritdoc />
        public override async Task<bool?> ShowDialogAsync(WindowWrapper owner)
        {
            var dialog = new global::Avalonia.Controls.OpenFileDialog();
            ToDialog(dialog);

            Settings.FileNames = await dialog.ShowAsync(owner.Ref) ?? Array.Empty<string>();

            return Settings.FileNames.Length > 0;
        }

        private void ToDialog(global::Avalonia.Controls.OpenFileDialog d)
        {
            ToDialogShared(Settings, d);
            d.AllowMultiple = Settings.Multiselect;
            // d.ShowReadOnly = Settings.ShowReadOnly;
                // d.ReadOnlyChecked = Settings.ReadOnlyChecked;
        }

        internal static void ToDialogShared(FileDialogSettings s, FileDialog d)
        {
            // d.AddExtension = s.AddExtension;
            // d.DereferenceLinks = s.DereferenceLinks;
            // d.CheckFileExists = s.CheckFileExists;
            // d.CheckPathExists = s.CheckPathExists;
            d.InitialFileName = s.FileName;
            d.Filter = s.Filter;
            d.FilterIndex = s.FilterIndex;
            d.Directory = s.InitialDirectory;
            // d.ShowHelp = s.ShowHelp;
            d.Title = s.Title;
        }
    }
}
