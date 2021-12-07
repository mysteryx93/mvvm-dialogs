using System.Threading.Tasks;
using MessageBox.Avalonia;
using MessageBox.Avalonia.Enums;
using MvvmDialogs.FrameworkDialogs;

namespace MvvmDialogs.Avalonia.FrameworkDialogs.MessageBox
{
    /// <summary>
    /// Class wrapping <see cref="MessageBoxManager"/>.
    /// </summary>
    public sealed class AvaloniaMessageBox : AvaloniaFrameworkDialogBase<MessageBoxSettings>
    {
        /// <inheritdoc />
        public AvaloniaMessageBox(MessageBoxSettings settings)
            : base(settings)
        {
        }

        /// <inheritdoc />
        public override async Task<bool?> ShowDialogAsync(AvaloniaWindow owner)
        {
            var messageBox = MessageBoxManager.GetMessageBoxStandardWindow(
                Settings.Caption,
                Settings.MessageBoxText,
                SyncButton(Settings.Button),
                SyncIcon(Settings.Icon));
            // SyncDefault(Settings.DefaultResult),
            // SyncOptions());

            var result = await messageBox.ShowDialog(owner.Ref);

            return result switch
            {
                ButtonResult.Yes => true,
                ButtonResult.Ok => true,
                ButtonResult.No => false,
                ButtonResult.Cancel => null,
                _ => null
            };
        }

        // Convert platform-agnostic types into Win32 types.

        private static ButtonEnum SyncButton(MessageBoxButton value) =>
            (value) switch
            {
                MessageBoxButton.Ok => ButtonEnum.Ok,
                MessageBoxButton.YesNo => ButtonEnum.YesNo,
                MessageBoxButton.OkCancel => ButtonEnum.OkCancel,
                MessageBoxButton.YesNoCancel => ButtonEnum.YesNoCancel,
                _ => ButtonEnum.Ok
            };

        private static Icon SyncIcon(MessageBoxImage value) =>
            (value) switch
            {
                MessageBoxImage.None => Icon.None,
                // MessageBoxImage.Asterisk => Icon.Asterisk,
                MessageBoxImage.Error => Icon.Error,
                // MessageBoxImage.Exclamation => Icon.Exclamation,
                // MessageBoxImage.Hand => Icon.Hand,
                // MessageBoxImage.Information => Icon.Information,
                MessageBoxImage.Stop => Icon.Stop,
                MessageBoxImage.Warning => Icon.Warning,
                _ => Icon.None
            };

        // private static Win32Result SyncDefault(MessageBoxResult value) =>
        //     (value) switch
        //     {
        //         MessageBoxResult.None => Win32Result.None,
        //         MessageBoxResult.Ok => Win32Result.OK,
        //         MessageBoxResult.Cancel => Win32Result.Cancel,
        //         MessageBoxResult.Yes => Win32Result.Yes,
        //         MessageBoxResult.No => Win32Result.No,
        //         _ => Win32Result.None
        //     };

        // private Win32Options SyncOptions() =>
        //     EvalOption(Settings.DefaultDesktopOnly, Win32Options.DefaultDesktopOnly) |
        //     EvalOption(Settings.RightAlign, Win32Options.RightAlign) |
        //     EvalOption(Settings.RtlReading, Win32Options.RtlReading) |
        //     EvalOption(Settings.ServiceNotification, Win32Options.ServiceNotification);
    }
}
