using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.Wpf.FrameworkDialogs.Api;
using Win32CustomPlace = System.Windows.Forms.FileDialogCustomPlace;
using Win32CustomPlaces = Microsoft.Win32.FileDialogCustomPlaces;
using Win32OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace MvvmDialogs.Wpf.FrameworkDialogs
{
    /// <summary>
    /// Class wrapping <see cref="System.Windows.Forms.OpenFileDialog"/>.
    /// </summary>
    internal class OpenFileDialog : FrameworkDialogBase<OpenFileDialogSettings, string[]>
    {
        /// <inheritdoc />
        public OpenFileDialog (IFrameworkDialogsApi api, OpenFileDialogSettings settings, AppDialogSettings appSettings)
            : base(api, settings, appSettings)
        {
        }

        /// <inheritdoc />
        public override Task<string[]> ShowDialogAsync(WindowWrapper owner) =>
            Task.Run(
                () =>
                {
                    var apiSettings = GetApiSettings();
                    var result = Api.ShowOpenFileDialog(owner.Ref, apiSettings);
                    return result == DialogResult.OK ? apiSettings.FileNames : Array.Empty<string>();
                });

        private OpenFileApiSettings GetApiSettings()
        {
            var d = new OpenFileApiSettings();
            GetApiSettingsShared(Settings, AppSettings, d);
            d.Multiselect = Settings.AllowMultiple;
            d.ReadOnlyChecked = Settings.ReadOnlyChecked;
            d.ShowReadOnly = Settings.ShowReadOnly;
            return d;
        }

        internal static void GetApiSettingsShared(FileDialogSettings s, AppDialogSettings s2, FileApiSettings d)
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
            d.InitialDirectory = file.DirectoryName ?? string.Empty;
            d.FileName = file.Name;
            d.DereferenceLinks = s.DereferenceLinks;
            d.Filter = SyncFilters(s.Filters);
            d.Title = s.Title;
            d.ShowHelp = s.HelpRequest != null;
            d.HelpRequest = s.HelpRequest;
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
