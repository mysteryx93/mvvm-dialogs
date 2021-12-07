using Avalonia.Controls;
using MvvmDialogs.DialogTypeLocators;

namespace MvvmDialogs.Avalonia
{
    /// <inheritdoc />
    public class ReflectionDialogFactory : ReflectionDialogFactoryBase<Window>
    {
        /// <inheritdoc />
        protected override IWindow CreateWrapper(Window window) => window.AsWrapper();
    }
}
