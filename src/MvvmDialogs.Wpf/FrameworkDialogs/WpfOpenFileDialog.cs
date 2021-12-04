using System.Windows.Forms;
using MvvmDialogs.Core.FrameworkDialogs;
using MvvmDialogs.Wpf.DialogFactories;
using FileDialogCustomPlaces = MvvmDialogs.Core.FrameworkDialogs.FileDialogCustomPlaces;
using Win32CustomPlace = System.Windows.Forms.FileDialogCustomPlace;
using Win32CustomPlaces = Microsoft.Win32.FileDialogCustomPlaces;

namespace MvvmDialogs.Wpf.FrameworkDialogs
{
    /// <summary>
    /// Class wrapping <see cref="OpenFileDialog"/>.
    /// </summary>
    internal sealed class WpfOpenFileDialog : WpfFrameworkDialogBase<OpenFileDialogSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WpfOpenFileDialog"/> class.
        /// </summary>
        /// <param name="settings">The settings for the open file dialog.</param>
        public WpfOpenFileDialog(OpenFileDialogSettings settings)
            : base(settings)
        {
        }

        /// <inheritdoc />
        public override bool? ShowDialog(WpfWindow owner)
        {
            var dialog = new OpenFileDialog();
            ToDialog(dialog);

            var result = dialog.ShowDialog(owner.Win32Window);

            ToSettings(dialog);
            return result.AsBool();
        }

        private void ToDialog(OpenFileDialog d)
        {
            ToDialogShared(Settings, d);
            d.CheckFileExists = Settings.CheckFileExists;
            d.Multiselect = Settings.Multiselect;
            d.ReadOnlyChecked = Settings.ReadOnlyChecked;
            d.ShowReadOnly = Settings.ShowReadOnly;
        }

        private void ToSettings(OpenFileDialog d)
        {
            ToSettingsShared(d, Settings);
            Settings.SafeFileName = d.SafeFileName;
            Settings.SafeFileNames = d.SafeFileNames;
        }

        internal static void ToDialogShared(FileDialogSettings s, FileDialog d)
        {
            d.AddExtension = s.AddExtension;
            d.CheckFileExists = s.CheckFileExists;
            d.CheckPathExists = s.CheckPathExists;
            foreach (var item in s.CustomPlaces)
            {
                if (item.KnownFolder.HasValue)
                {
                    d.CustomPlaces.Add(SyncCustomPlace(item.KnownFolder.Value));
                }
                else if (!string.IsNullOrWhiteSpace(item.Path))
                {
                    d.CustomPlaces.Add(item.Path);
                }
            }
            d.DefaultExt = s.DefaultExt;
            d.DereferenceLinks = s.DereferenceLinks;
            d.FileName = s.FileName;
            d.Filter = s.Filter;
            d.FilterIndex = s.FilterIndex;
            d.InitialDirectory = s.InitialDirectory;
            d.RestoreDirectory = s.RestoreDirectory;
            d.ShowHelp = s.ShowHelp;
            d.SupportMultiDottedExtensions = s.SupportMultiDottedExtensions;
            d.Title = s.Title;
            d.ValidateNames = s.ValidateNames;
        }

        private static Win32CustomPlace? SyncCustomPlace(FileDialogCustomPlaces value)
        {
            var result = value switch
            {
                FileDialogCustomPlaces.Contacts => Win32CustomPlaces.Contacts,
                FileDialogCustomPlaces.Cookies => Win32CustomPlaces.Cookies,
                FileDialogCustomPlaces.Desktop => Win32CustomPlaces.Desktop,
                FileDialogCustomPlaces.Documents => Win32CustomPlaces.Documents,
                FileDialogCustomPlaces.Favorites => Win32CustomPlaces.Favorites,
                FileDialogCustomPlaces.LocalApplicationData => Win32CustomPlaces.LocalApplicationData,
                FileDialogCustomPlaces.Music => Win32CustomPlaces.Music,
                FileDialogCustomPlaces.Pictures => Win32CustomPlaces.Pictures,
                FileDialogCustomPlaces.ProgramFiles => Win32CustomPlaces.ProgramFiles,
                FileDialogCustomPlaces.ProgramFilesCommon => Win32CustomPlaces.ProgramFilesCommon,
                FileDialogCustomPlaces.Programs => Win32CustomPlaces.Programs,
                FileDialogCustomPlaces.RoamingApplicationData => Win32CustomPlaces.RoamingApplicationData,
                FileDialogCustomPlaces.SendTo => Win32CustomPlaces.SendTo,
                FileDialogCustomPlaces.StartMenu => Win32CustomPlaces.StartMenu,
                FileDialogCustomPlaces.Startup => Win32CustomPlaces.Startup,
                FileDialogCustomPlaces.System => Win32CustomPlaces.System,
                FileDialogCustomPlaces.Templates => Win32CustomPlaces.Templates,
                _ => null
            };
            return result != null ? new Win32CustomPlace(result.KnownFolder) : null;
        }

        internal static void ToSettingsShared(FileDialog d, FileDialogSettings s)
        {
            s.FileName = d.FileName;
            s.FileNames = d.FileNames;
            s.FilterIndex = d.FilterIndex;
        }
    }
}
