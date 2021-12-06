using Avalonia.Controls;
using MvvmDialogs.Core;
using MvvmDialogs.Core.DialogTypeLocators;

namespace MvvmDialogs.Avalonia
{
    /// <inheritdoc />
    public class AvaloniaReflectionDialogFactory : ReflectionDialogFactoryBase<Window>
    {
        /// <inheritdoc />
        protected override IWindow CreateWrapper(Window window) => new AvaloniaWindow(window);
    }
}
