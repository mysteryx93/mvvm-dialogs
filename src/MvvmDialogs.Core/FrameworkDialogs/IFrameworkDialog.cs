
namespace MvvmDialogs.Core.FrameworkDialogs
{
    /// <summary>
    /// Interface representing a framework dialog.
    /// </summary>
    public interface IFrameworkDialog
    {
        /// <summary>
        /// Opens a framework dialog with specified owner.
        /// </summary>
        /// <param name="owner">Handle to the window that owns the dialog.</param>
        /// <returns>true if user clicks Yes or OK; false if user clicks No; null if user cancels.</returns>
        bool? ShowDialog(IWindow owner);
    }
}
