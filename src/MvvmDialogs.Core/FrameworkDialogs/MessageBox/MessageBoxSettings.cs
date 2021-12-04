
namespace MvvmDialogs.Core.FrameworkDialogs
{
    /// <summary>
    /// Settings for a MessageBox.
    /// </summary>
    public class MessageBoxSettings
    {
        /// <summary>
        /// Gets or sets the <see cref="MessageBoxButton"/> value that specifies which button or
        /// buttons to display. Default value is <see cref="MessageBoxButton.OK"/>.
        /// </summary>
        public MessageBoxButton Button { get; set; } = MessageBoxButton.OK;

        /// <summary>
        /// Gets or sets the <see cref="string"/> that specifies the title bar caption to display.
        /// Default value is an empty string.
        /// </summary>
        public string Caption { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the <see cref="MessageBoxResult"/> value that specifies the default result
        /// of the message box. Default value is <see cref="MessageBoxResult.None"/>.
        /// </summary>
        public MessageBoxResult DefaultResult { get; set; } = MessageBoxResult.None;

        /// <summary>
        /// Gets or sets the <see cref="MessageBoxImage"/> value that specifies the icon to
        /// display. Default value is <see cref="MessageBoxImage.None"/>.
        /// </summary>
        public MessageBoxImage Icon { get; set; } = MessageBoxImage.None;

        /// <summary>
        /// Gets or sets the <see cref="string"/> that specifies the text to display.
        /// </summary>
        public string? MessageBoxText { get; set; }

        /// <summary>
        /// Gets or sets whether to display on the default desktop of the interactive window station. Specifies that the message box is displayed from a .NET Windows Service application in order to notify the user of an event.
        /// </summary>
        public bool DefaultDesktopOnly { get; set; }

        /// <summary>
        /// Gets or sets whether the message box text and title bar caption are right-aligned.
        /// </summary>
        public bool RightAlign { get; set; }

        /// <summary>
        /// Gets or sets whether all text, buttons, icons, and title bars are displayed right-to-left.
        /// </summary>
        public bool RtlReading { get; set; }

        /// <summary>
        /// Gets or sets whether to display on the currently active desktop even if a user is not logged on to the computer. Specifies that the message box is displayed from a .NET Windows Service application in order to notify the user of an event.
        /// </summary>
        public bool ServiceNotification { get; set; }
    }
}
