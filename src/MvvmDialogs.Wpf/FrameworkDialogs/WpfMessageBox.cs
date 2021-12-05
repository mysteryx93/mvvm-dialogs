﻿using MvvmDialogs.Core.FrameworkDialogs;
using MvvmDialogs.Wpf.DialogFactories;
using Win32Button = System.Windows.MessageBoxButton;
using Win32Image = System.Windows.MessageBoxImage;
using Win32Result = System.Windows.MessageBoxResult;
using Win32Options = System.Windows.MessageBoxOptions;

namespace MvvmDialogs.Wpf.FrameworkDialogs.MessageBox
{
    /// <summary>
    /// Class wrapping <see cref="System.Windows.MessageBox"/>.
    /// </summary>
    public sealed class WpfMessageBox : WpfFrameworkDialogBase<MessageBoxSettings>
    {
        /// <inheritdoc />
        public WpfMessageBox(MessageBoxSettings settings)
            : base(settings)
        {
        }

        /// <inheritdoc />
        public override bool? ShowDialog(WpfWindow owner)
        {
            var result = System.Windows.MessageBox.Show(
                owner.Ref,
                Settings.MessageBoxText,
                Settings.Caption,
                SyncButton(Settings.Button),
                SyncImage(Settings.Icon),
                SyncDefault(Settings.DefaultResult),
                SyncOptions());

            return result switch
            {
                Win32Result.Yes => true,
                Win32Result.OK => true,
                Win32Result.No => false,
                Win32Result.Cancel => null,
                _ => null
            };
        }

        private static Win32Button SyncButton(MessageBoxButton value) =>
            (value) switch
            {
                MessageBoxButton.OK => Win32Button.OK,
                MessageBoxButton.YesNo => Win32Button.YesNo,
                MessageBoxButton.OKCancel => Win32Button.OKCancel,
                MessageBoxButton.YesNoCancel => Win32Button.YesNoCancel,
                _ => Win32Button.OK
            };

        private static Win32Image SyncImage(MessageBoxImage value) =>
            (value) switch
            {
                MessageBoxImage.None => Win32Image.None,
                MessageBoxImage.Asterisk => Win32Image.Asterisk,
                MessageBoxImage.Error => Win32Image.Error,
                MessageBoxImage.Exclamation => Win32Image.Exclamation,
                MessageBoxImage.Hand => Win32Image.Hand,
                MessageBoxImage.Information => Win32Image.Information,
                MessageBoxImage.Question => Win32Image.Question,
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
            EvalOption(Settings.DefaultDesktopOnly, Win32Options.DefaultDesktopOnly) |
            EvalOption(Settings.RightAlign, Win32Options.RightAlign) |
            EvalOption(Settings.RtlReading, Win32Options.RtlReading) |
            EvalOption(Settings.ServiceNotification, Win32Options.ServiceNotification);

        private static Win32Options EvalOption(bool cond, Win32Options option) =>
            cond ? option : Win32Options.None;
    }
}