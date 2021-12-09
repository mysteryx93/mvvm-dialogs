using Avalonia.Controls;
using MessageBox.Avalonia.Enums;

namespace MvvmDialogs.Avalonia.FrameworkDialogs.Api
{
    internal class MessageBoxApiSettings
    {
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public ButtonEnum Buttons { get; set; } = ButtonEnum.Ok;
        public Icon Icon { get; set; } = Icon.None;
        public WindowStartupLocation StartupLocation { get; set; } = WindowStartupLocation.CenterScreen;
        public Style Style { get; set; } = Style.None;
    }
}
