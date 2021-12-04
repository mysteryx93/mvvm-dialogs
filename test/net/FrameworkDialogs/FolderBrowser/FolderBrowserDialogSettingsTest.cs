using System.Linq;
using System.Windows.Forms;
using MvvmDialogs.Wpf.FrameworkDialogs.Utils;
using NUnit.Framework;

namespace MvvmDialogs.Wpf.FrameworkDialogs.FolderBrowser
{
    [TestFixture]
    public class FolderBrowserDialogSettingsTest
    {
        [Test]
        public void NativeDialogSettingsParity()
        {
            // Arrange
            var settingsPropertyNames = string.Join(
                ", ",
                DialogSettings.GetPropertyNames(typeof(FolderBrowserDialogSettings)));

            var dialogPropertyNames = string.Join(
                ", ",
                DialogSettings.GetPropertyNames(typeof(FolderBrowserDialog)).Except(DialogSettings.ExcludedPropertyNames));

            // Assert
            Assert.That(settingsPropertyNames, Is.EqualTo(dialogPropertyNames));
        }
    }
}
