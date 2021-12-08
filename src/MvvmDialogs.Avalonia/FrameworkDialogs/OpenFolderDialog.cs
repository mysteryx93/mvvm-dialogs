using System.Threading.Tasks;
using MvvmDialogs.FrameworkDialogs;
using AvaloniaOpenFolderDialog = Avalonia.Controls.OpenFolderDialog;

namespace MvvmDialogs.Avalonia.FrameworkDialogs
{
    /// <summary>
    /// Class wrapping <see cref="OpenFolderDialog"/>.
    /// </summary>
    public class OpenFolderDialog : FrameworkDialogBase<OpenFolderDialogSettings>
    {
        /// <inheritdoc />
        public OpenFolderDialog(OpenFolderDialogSettings settings, AppDialogSettings appSettings)
            : base(settings, appSettings)
        {
        }

        /// <inheritdoc />
        public override Task<bool?> ShowDialogAsync(WindowWrapper owner) =>
            Task.Run(
                () =>
                {
                    using var dialog = new OpenFolderDialog();
                    ToDialog(dialog);

                    var result = dialog.ShowDialog(owner.Win32Window);

                    ToSettings(dialog);
                    return result.AsBool();
                });


        private void ToDialog(OpenFolderDialog d)
        {
            d.Description = Settings.Description;
            d.RootFolder = Settings.RootFolder;
            d.SelectedPath = Settings.SelectedPath;
            d.ShowNewFolderButton = Settings.ShowNewFolderButton;
        }

        private void ToSettings(OpenFolderDialog d) => Settings.SelectedPath = d.SelectedPath;
    }
}
