using System;
using System.Linq;
using MvvmDialogs.Core.FrameworkDialogs;
using MvvmDialogs.Wpf;
using MvvmDialogs.Wpf.FrameworkDialogs;
using Ookii.Dialogs.Wpf;

namespace Demo.CustomMessageBox
{
    public class CustomMessageBox : WpfFrameworkDialogBase<MessageBoxSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomMessageBox"/> class.
        /// </summary>
        /// <param name="settings">The settings for the folder browser dialog.</param>
        public CustomMessageBox(MessageBoxSettings settings)
            : base(settings)
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
        public override bool? ShowDialogAsync(WpfWindow owner)
        {
            var messageBox = new TaskDialog
            {
                Content = Settings.MessageBoxText
            };

            messageBox.WindowTitle = SyncTitle();
            SyncButtons(messageBox);
            messageBox.MainIcon = SyncIcon();
            var defaultButton = messageBox.Buttons.SingleOrDefault(x => x.ButtonType == SyncDefault());
            if (defaultButton != null)
            {
                defaultButton.Default = true;
            }

            if (owner == null) throw new ArgumentNullException(nameof(owner));

            var result = messageBox.ShowDialog(owner.Ref);
            return ToMessageBoxResult(result);
        }

        private string SyncTitle() =>
            string.IsNullOrEmpty(Settings.Caption) ? " " : Settings.Caption;

        private void SyncButtons(TaskDialog messageBox)
        {
            switch (Settings.Button)
            {
                case MessageBoxButton.OKCancel:
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

        private TaskDialogIcon SyncIcon() =>
            Settings.Icon switch
            {
                MessageBoxImage.Error => TaskDialogIcon.Error,
                MessageBoxImage.Information => TaskDialogIcon.Information,
                MessageBoxImage.Warning => TaskDialogIcon.Warning,
                _ => TaskDialogIcon.Custom
            };

        private ButtonType SyncDefault() =>
            Settings.DefaultResult switch
            {
                MessageBoxResult.Cancel => ButtonType.Cancel,
                MessageBoxResult.None => ButtonType.No,
                MessageBoxResult.Ok => ButtonType.Ok,
                MessageBoxResult.Yes => ButtonType.Yes,
                _ => ButtonType.Ok
            };

        private static bool? ToMessageBoxResult(TaskDialogButton button) =>
            button.ButtonType switch
            {
                ButtonType.Cancel => null,
                ButtonType.No => false,
                ButtonType.Ok => true,
                ButtonType.Yes => true,
                _ => null
            };
    }
}
