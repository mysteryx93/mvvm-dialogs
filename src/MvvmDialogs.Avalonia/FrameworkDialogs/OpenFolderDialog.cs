using System.Threading.Tasks;
using MvvmDialogs.FrameworkDialogs;
using AvaloniaOpenFolderDialog = Avalonia.Controls.OpenFolderDialog;

namespace MvvmDialogs.Avalonia.FrameworkDialogs
{
    /// <summary>
    /// Class wrapping <see cref="OpenFolderDialog"/>.
    /// </summary>
    public class OpenFolderDialog : FrameworkDialogBase<OpenFolderDialogSettings, string?>
    {
        /// <inheritdoc />
        public OpenFolderDialog(OpenFolderDialogSettings settings, AppDialogSettings appSettings)
            : base(settings, appSettings)
        {
        }

        /// <inheritdoc />
        public override async Task<string?> ShowDialogAsync(WindowWrapper owner)
        {
            var dialog = new AvaloniaOpenFolderDialog();
            ToDialog(dialog);

            var result = await dialog.ShowAsync(owner.Ref);
            return result;
        }

        private void ToDialog(AvaloniaOpenFolderDialog d)
        {
            d.Title = Settings.Title;
            d.Directory = Settings.SelectedPath;
            // d.Description = Settings.Description;
            // d.RootFolder = Settings.RootFolder;
            // d.ShowNewFolderButton = Settings.ShowNewFolderButton;
        }
    }
}
