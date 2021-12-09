using System;
using System.Threading.Tasks;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.Wpf;
using MvvmDialogs.Wpf.FrameworkDialogs;
using Ookii.Dialogs.Wpf;

namespace Demo.CustomMessageBox
{
    public class CustomMessageBox : FrameworkDialogBase<MessageBoxSettings, MessageBoxResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomMessageBox"/> class.
        /// </summary>
        /// <param name="settings">The settings for the folder browser dialog.</param>
        /// <param name="appSettings">Application-wide settings configured on the DialogService.</param>
        public CustomMessageBox(MessageBoxSettings settings, AppDialogSettings appSettings)
            : base(settings, appSettings)
        {
        }

        /// <summary>
        /// Opens a message box with specified owner.
        /// </summary>
        /// <param name="owner">
        /// Handle to the window that owns the dialog.
        /// </param>
        /// <returns>
        /// A <see cref="System.Windows.MessageBoxResult"/> value that specifies which message box button is
        /// clicked by the user.
        /// </returns>
        public override Task<MessageBoxResult> ShowDialogAsync(WindowWrapper owner)
        {
            using var messageBox = new TaskDialog
            {
                Content = Settings.Text
            };

            messageBox.WindowTitle = SyncTitle();
            SetUpButtons(messageBox);
            messageBox.MainIcon = SyncIcon(messageBox);

            if (owner == null) throw new ArgumentNullException(nameof(owner));

            var result = messageBox.ShowDialog(owner.Ref);
            return Task.FromResult(ToMessageBoxResult(result));
        }

        private string SyncTitle() => string.IsNullOrEmpty(Settings.Title) ? " " : Settings.Title;

        private void SetUpButtons(TaskDialog messageBox)
        {
            switch (Settings.Button)
            {
                case MessageBoxButton.OkCancel:
                    messageBox.Buttons.Add(new TaskDialogButton(ButtonType.Ok));
                    messageBox.Buttons.Add(new TaskDialogButton(ButtonType.Cancel));
                    break;

                case MessageBoxButton.YesNo:
                    messageBox.Buttons.Add(new TaskDialogButton(ButtonType.Yes));
                    messageBox.Buttons.Add(new TaskDialogButton(ButtonType.No));
                    break;

                case MessageBoxButton.YesNoCancel:
                    messageBox.Buttons.Add(new TaskDialogButton(ButtonType.Yes));
                    messageBox.Buttons.Add(new TaskDialogButton(ButtonType.No));
                    messageBox.Buttons.Add(new TaskDialogButton(ButtonType.Cancel));
                    break;

                default:
                    messageBox.Buttons.Add(new TaskDialogButton(ButtonType.Ok));
                    break;
            }
        }

        private TaskDialogIcon SyncIcon(TaskDialog messageBox) =>
            messageBox.MainIcon = Settings.Icon switch
            {
                MessageBoxImage.Error => TaskDialogIcon.Error,
                MessageBoxImage.Information => TaskDialogIcon.Information,
                MessageBoxImage.Warning => TaskDialogIcon.Warning,
                _ => TaskDialogIcon.Custom
            };

        private static MessageBoxResult ToMessageBoxResult(TaskDialogButton button) =>
            button.ButtonType switch
            {
                ButtonType.Cancel => MessageBoxResult.Cancel,
                ButtonType.No => MessageBoxResult.No,
                ButtonType.Ok => MessageBoxResult.Ok,
                ButtonType.Yes => MessageBoxResult.Yes,
                _ => MessageBoxResult.None
            };
    }
}
