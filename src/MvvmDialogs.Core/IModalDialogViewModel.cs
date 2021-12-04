using System.ComponentModel;

namespace MvvmDialogs.Core
{
    /// <summary>
    /// A view model representing a modal dialog opened using <see cref="DialogServiceBase{TWindow}"/>.
    /// </summary>
    public interface IModalDialogViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets the dialog result value, which is the value that is returned from the
        /// <see cref="DialogServiceBase{TWindow}.ShowDialog"/> and <see cref="DialogServiceBase{TWindow}.ShowDialog{T}"/>
        /// methods.
        /// </summary>
        bool? DialogResult { get; }
    }
}
