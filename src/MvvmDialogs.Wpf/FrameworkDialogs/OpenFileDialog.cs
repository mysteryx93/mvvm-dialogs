using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MvvmDialogs.FrameworkDialogs;
using Win32CustomPlace = System.Windows.Forms.FileDialogCustomPlace;
using Win32CustomPlaces = Microsoft.Win32.FileDialogCustomPlaces;

namespace MvvmDialogs.Wpf.FrameworkDialogs
{
    /// <summary>
    /// Class wrapping <see cref="System.Windows.Forms.OpenFileDialog"/>.
    /// </summary>
    internal sealed class OpenFileDialog : FrameworkDialogBase<OpenFileDialogSettings>
    {
        /// <inheritdoc />
        public OpenFileDialog(OpenFileDialogSettings settings, AppDialogSettings appSettings)
            : base(settings, appSettings)
        {
        }

        /// <inheritdoc />
        public override Task<bool?> ShowDialogAsync(WindowWrapper owner) =>
            Task.Run(
                () =>
                {
                    var dialog = new System.Windows.Forms.OpenFileDialog();
                    ToDialog(dialog);

                    var result = dialog.ShowDialog(owner.Win32Window);

                    Settings.FileNames = dialog.FileNames;
                    return result.AsBool();
                });

        private void ToDialog(System.Windows.Forms.OpenFileDialog d)
        {
            ToDialogShared(Settings, AppSettings, d);
            d.Multiselect = Settings.AllowMultiple;
            d.ReadOnlyChecked = Settings.ReadOnlyChecked;
            d.ShowReadOnly = Settings.ShowReadOnly;
        }

        internal static void ToDialogShared(FileDialogSettings s, AppDialogSettings s2, FileDialog d)
        {
            d.DefaultExt = s.DefaultExtension;
            d.AddExtension = !string.IsNullOrEmpty(s.DefaultExtension);
            d.CheckFileExists = s.CheckFileExists;
            d.CheckPathExists = s.CheckPathExists;
            foreach (var item in s2.CustomPlaces)
            {
                if (!string.IsNullOrWhiteSpace(item.Path))
                {
                    d.CustomPlaces.Add(item.Path);
                }
                else
                {
                    d.CustomPlaces.Add(item.KnownFolderGuid);
                }
            }
            var file = new FileInfo(s.InitialPath);
            d.InitialDirectory = file.DirectoryName;
            d.FileName = file.Name;
            d.DereferenceLinks = s.DereferenceLinks;
            d.Filter = SyncFilters(s.Filters);
            d.Title = s.Title;
            d.ShowHelp = s2.FileShowHelp;
        }

        /// <summary>
        /// Encodes the list of filters in the Win32 API format:
        /// "Image Files (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*"
        /// </summary>
        /// <param name="filters">The list of filters to encode.</param>
        /// <returns>A string representation of the list compatible with Win32 API.</returns>
        private static string SyncFilters(List<FileFilter> filters)
        {
            StringBuilder result = new StringBuilder();
            foreach (var item in filters)
            {
                // Add separator.
                if (result.Length > 0)
                {
                    result.Append('|');
                }

                // Get all extensions as a string.
                var extDesc = item.ExtensionsToString();
                // Get name including extensions.
                var name = item.NameToString(extDesc);
                // Add name+extensions for display.
                result.Append(name);
                // Add extensions again for the API.
                result.Append("|");
                result.Append(extDesc);
            }
            return result.ToString();
        }
    }
}
