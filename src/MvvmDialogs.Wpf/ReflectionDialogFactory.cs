using System;
using System.Windows;
using MvvmDialogs.Core;
using MvvmDialogs.Wpf.DialogFactories;

namespace MvvmDialogs.Wpf
{
    /// <summary>
    /// Class responsible for creating dialogs using reflection.
    /// </summary>
    public class ReflectionDialogFactory : IDialogFactory
    {
        /// <inheritdoc />
        public IWindow Create(Type dialogType)
        {
            if (dialogType == null) throw new ArgumentNullException(nameof(dialogType));

            var instance = Activator.CreateInstance(dialogType);
            if (instance is Window window)
            {
                return new WpfWindow(window);
            }
            else
            {
                throw new ArgumentException($"Only dialogs of type {typeof(Window)} are supported.");
            }
        }
    }
}
