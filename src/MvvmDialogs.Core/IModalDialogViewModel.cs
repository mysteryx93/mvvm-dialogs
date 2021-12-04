using System.ComponentModel;

namespace MvvmDialogs.Core
{
    /// <summary>
    /// A view model representing a modal dialog opened using <see cref="DialogServiceBase"/>.
    /// </summary>
    public interface IModalDialogViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets the dialog result value, which is the value that is returned from the
        /// <see cref="DialogServiceBase.ShowDialog"/> and <see cref="DialogServiceBase.ShowDialog{T}"/>
        /// methods.
        /// </summary>
        bool? DialogResult { get; }
    }
}
