using System.Windows;
using MvvmDialogs.DialogTypeLocators;

namespace MvvmDialogs.Wpf
{
    /// <inheritdoc />
    public class ReflectionDialogFactory : ReflectionDialogFactoryBase<Window>
    {
        /// <inheritdoc />
        protected override IWindow CreateWrapper(Window window) => new WindowWrapper(window);
    }
}
