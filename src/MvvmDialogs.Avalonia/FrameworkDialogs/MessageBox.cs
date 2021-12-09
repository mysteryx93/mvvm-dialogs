using System.Threading.Tasks;
using MessageBox.Avalonia;
using MessageBox.Avalonia.Enums;
using MvvmDialogs.Avalonia.FrameworkDialogs.Api;
using MvvmDialogs.FrameworkDialogs;

namespace MvvmDialogs.Avalonia.FrameworkDialogs
{
    /// <summary>
    /// Class wrapping <see cref="MessageBoxManager"/>.
    /// </summary>
    internal class MessageBox : FrameworkDialogBase<MessageBoxSettings, MessageBoxResult>
    {
        /// <inheritdoc />
        public MessageBox(IFrameworkDialogsApi api, MessageBoxSettings settings, AppDialogSettings appSettings)
            : base(api, settings, appSettings)
        {
        }

        /// <inheritdoc />
        public override async Task<MessageBoxResult> ShowDialogAsync(WindowWrapper owner)
        {
            var apiSettings = GetApiSettings();
            var result = await Api.ShowMessageBox(owner.Ref, apiSettings).ConfigureAwait(false);

            return result switch
            {
                ButtonResult.Yes => MessageBoxResult.Yes,
                ButtonResult.Ok => MessageBoxResult.Ok,
                ButtonResult.No => MessageBoxResult.No,
                ButtonResult.Cancel => MessageBoxResult.Cancel,
                _ => MessageBoxResult.None
            };
        }

        private MessageBoxApiSettings GetApiSettings() =>
            new()
            {
                Title = Settings.Title,
                Text = Settings.Text,
                Buttons = SyncButton(Settings.Button),
                Icon = SyncIcon(Settings.Icon),
                Style = AppSettings.MessageBoxStyle
                // SyncDefault(Settings.DefaultResult),
                // SyncOptions());
            };

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
    }
}
