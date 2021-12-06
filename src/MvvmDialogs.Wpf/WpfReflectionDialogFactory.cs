using System.Windows;
using MvvmDialogs.DialogTypeLocators;

namespace MvvmDialogs.Wpf
{
    /// <inheritdoc />
    public class WpfReflectionDialogFactory : ReflectionDialogFactoryBase<Window>
    {
        /// <inheritdoc />
        protected override IWindow CreateWrapper(Window window) => new WpfWindow(window);
    }
}
