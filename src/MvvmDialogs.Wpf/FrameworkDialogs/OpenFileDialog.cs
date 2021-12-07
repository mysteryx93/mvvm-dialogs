using System.Threading.Tasks;
using System.Windows.Forms;
using MvvmDialogs.FrameworkDialogs;
using FileDialogCustomPlaces = MvvmDialogs.FrameworkDialogs.FileDialogCustomPlaces;
using Win32CustomPlace = System.Windows.Forms.FileDialogCustomPlace;
using Win32CustomPlaces = Microsoft.Win32.FileDialogCustomPlaces;

namespace MvvmDialogs.Wpf.FrameworkDialogs
{
    /// <summary>
    /// Class wrapping <see cref="System.Windows.Forms.OpenFileDialog"/>.
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
            ToDialogShared(Settings, d);
            d.Multiselect = Settings.Multiselect;
            d.ReadOnlyChecked = Settings.ReadOnlyChecked;
            d.ShowReadOnly = Settings.ShowReadOnly;
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
            d.DereferenceLinks = s.DereferenceLinks;
            // d.FileName = s.FileName;
            d.Filter = s.Filter;
            d.InitialDirectory = s.InitialDirectory;
            d.ShowHelp = s.ShowHelp;
            d.Title = s.Title;
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
    }
}
