using System;
using MvvmDialogs.Core;
using MvvmDialogs.Core.FrameworkDialogs.MessageBox;
using MvvmDialogs.Wpf.DialogFactories;
using MessageBoxResult = MvvmDialogs.Core.FrameworkDialogs.MessageBox.MessageBoxResult;

namespace MvvmDialogs.Wpf.FrameworkDialogs.MessageBox
{
    /// <summary>
    /// Class wrapping <see cref="System.Windows.MessageBox"/>.
    /// </summary>
    internal sealed class MessageBoxWrapper : IMessageBox
    {
        private readonly MessageBoxSettings settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxWrapper"/> class.
        /// </summary>
        /// <param name="settings">The settings for the folder browser dialog.</param>
        public MessageBoxWrapper(MessageBoxSettings settings)
        {
            this.settings = settings;
        }

        /// <inheritdoc />
        public MessageBoxResult Show(IWindow owner)
        {
            if (owner == null) throw new ArgumentNullException(nameof(owner));
            if (owner is not WpfWindow window) throw new ArgumentException($"{nameof(owner)} must be of type {nameof(WpfWindow)}");

            return (MessageBoxResult)System.Windows.MessageBox.Show(
                window.Ref,
                settings.MessageBoxText,
                settings.Caption,
                settings.Button,
                settings.Icon,
                settings.DefaultResult,
                settings.Options);
        }
    }
}
