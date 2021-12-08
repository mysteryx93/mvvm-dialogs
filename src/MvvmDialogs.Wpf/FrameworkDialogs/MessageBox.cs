﻿using System.Threading.Tasks;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.Wpf.FrameworkDialogs.Api;
using Win32Button = System.Windows.MessageBoxButton;
using Win32Image = System.Windows.MessageBoxImage;
using Win32Result = System.Windows.MessageBoxResult;
using Win32Options = System.Windows.MessageBoxOptions;
using Win32MessageBox = System.Windows.MessageBox;

namespace MvvmDialogs.Wpf.FrameworkDialogs
{
    /// <summary>
    /// Class wrapping <see cref="System.Windows.MessageBox"/>.
    /// </summary>
    internal class MessageBox : FrameworkDialogBase<MessageBoxSettings, MessageBoxResult>
    {
        /// <inheritdoc />
        public MessageBox(IFrameworkDialogsApi api, MessageBoxSettings settings, AppDialogSettings appSettings)
            : base(api, settings, appSettings)
        {
        }

        /// <inheritdoc />
        public override Task<MessageBoxResult> ShowDialogAsync(WindowWrapper owner) =>
            Task.Run(
                () =>
                {
                    var apiSettings = GetApiSettings();
                    var result = Api.ShowMessageBox(owner.Ref, apiSettings);

                    return result switch
                    {
                        Win32Result.Yes => MessageBoxResult.Yes,
                        Win32Result.OK => MessageBoxResult.Ok,
                        Win32Result.No => MessageBoxResult.No,
                        Win32Result.Cancel => MessageBoxResult.Cancel,
                        _ => MessageBoxResult.None
                    };
                });

        // Convert platform-agnostic types into Win32 types.

        private MessageBoxApiSettings GetApiSettings() =>
            new MessageBoxApiSettings()
            {
                MessageBoxText = Settings.Text,
                Caption = Settings.Title,
                Buttons = SyncButton(Settings.Button),
                Icon = SyncIcon(Settings.Icon),
                DefaultButton = SyncDefault(Settings.DefaultResult),
                Options = SyncOptions()
            };

        private static Win32Button SyncButton(MessageBoxButton value) =>
            (value) switch
            {
                MessageBoxButton.Ok => Win32Button.OK,
                MessageBoxButton.YesNo => Win32Button.YesNo,
                MessageBoxButton.OkCancel => Win32Button.OKCancel,
                MessageBoxButton.YesNoCancel => Win32Button.YesNoCancel,
                _ => Win32Button.OK
            };

        private static Win32Image SyncIcon(MessageBoxImage value) =>
            (value) switch
            {
                MessageBoxImage.None => Win32Image.None,
                MessageBoxImage.Asterisk => Win32Image.Asterisk,
                MessageBoxImage.Error => Win32Image.Error,
                MessageBoxImage.Exclamation => Win32Image.Exclamation,
                MessageBoxImage.Hand => Win32Image.Hand,
                MessageBoxImage.Information => Win32Image.Information,
                MessageBoxImage.Stop => Win32Image.Stop,
                MessageBoxImage.Warning => Win32Image.Warning,
                _ => Win32Image.None
            };

        private static Win32Result SyncDefault(MessageBoxResult value) =>
            (value) switch
            {
                MessageBoxResult.None => Win32Result.None,
                MessageBoxResult.Ok => Win32Result.OK,
                MessageBoxResult.Cancel => Win32Result.Cancel,
                MessageBoxResult.Yes => Win32Result.Yes,
                MessageBoxResult.No => Win32Result.No,
                _ => Win32Result.None
            };

        private Win32Options SyncOptions() =>
            EvalOption(AppSettings.MessageBoxDefaultDesktopOnly, Win32Options.DefaultDesktopOnly) |
            EvalOption(AppSettings.MessageBoxRightToLeft, Win32Options.RightAlign) |
            EvalOption(AppSettings.MessageBoxRightToLeft, Win32Options.RtlReading) |
            EvalOption(AppSettings.MessageBoxServiceNotification, Win32Options.ServiceNotification);

        private static Win32Options EvalOption(bool cond, Win32Options option) =>
            cond ? option : Win32Options.None;
    }
}
