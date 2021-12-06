using System.Linq;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.Wpf.FrameworkDialogs.Utils;
using NUnit.Framework;

namespace MvvmDialogs.Wpf.FrameworkDialogs.MessageBox
{
    [TestFixture]
    public class MessageBoxSettingsTest
    {
        [Test]
        public void NativeDialogSettingsParity()
        {
            // Arrange
            var messageBoxSettingsPropertyNames = string.Join(
                ", ",
                DialogSettings.GetPropertyNames(typeof(MessageBoxSettings)));

            var messageBoxPropertyNames = string.Join(
                ", ",
                DialogSettings.GetMessageBoxParameters().Except(DialogSettings.ExcludedMessageBoxPropertyNames));

            // Assert
            Assert.That(messageBoxSettingsPropertyNames, Is.EqualTo(messageBoxPropertyNames));
        }
    }
}
