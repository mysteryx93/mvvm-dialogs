
namespace MvvmDialogs.FrameworkDialogs
{
    /// <summary>
    /// Interface responsible for creating framework dialogs.
    /// </summary>
    public interface IFrameworkDialogFactory
    {
        /// <summary>
        /// Creates an <see cref="IFrameworkDialog"/> with specified settings,
        /// based on settings type as configured in the implementation of this class.
        /// </summary>
        /// <param name="settings">The settings to pass to the <see cref="IFrameworkDialog"/></param>
        /// <param name="appSettings">Application-wide settings configured on the DialogService.</param>
        /// <typeparam name="T">The settings type used to determine the implementation of <see cref="IFrameworkDialog"/> to create.</typeparam>
        /// <returns>A framework dialog implementing <see cref="IFrameworkDialog"/>.</returns>
        IFrameworkDialog Create<T>(T settings, AppDialogSettingsBase appSettings);
    }
}
