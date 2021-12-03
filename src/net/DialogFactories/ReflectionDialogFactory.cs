using System;
using System.Windows;

namespace MvvmDialogs.DialogFactories
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
            if (instance is IWindow window)
            {
                return window;
            }
            else
            {
                throw new ArgumentException($"Only dialogs of type {typeof(IWindow)} are supported.");
            }
        }
    }
}
