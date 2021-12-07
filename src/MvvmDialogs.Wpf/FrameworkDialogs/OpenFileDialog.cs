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
            d.Multiselect = Settings.Multiselect;
            d.ReadOnlyChecked = Settings.ReadOnlyChecked;
            d.ShowReadOnly = Settings.ShowReadOnly;
        }

        internal static void ToDialogShared(FileDialogSettings s, AppDialogSettings s2, FileDialog d)
        {
            d.DefaultExt = s.DefaultExt;
            d.AddExtension = !string.IsNullOrEmpty(s.DefaultExt);
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
            d.DereferenceLinks = s.DereferenceLinks;
            // d.FileName = s.FileName;
            d.Filter = s.Filter;
            d.InitialDirectory = s.InitialDirectory;
            d.ShowHelp = s2.FileShowHelp;
            d.Title = s.Title;
        }
    }
}
