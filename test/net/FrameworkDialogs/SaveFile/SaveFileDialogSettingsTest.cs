using System.Linq;
using Microsoft.Win32;
using MvvmDialogs.Wpf.FrameworkDialogs.Utils;
using NUnit.Framework;

namespace MvvmDialogs.Wpf.FrameworkDialogs.SaveFile
{
    [TestFixture]
    public class SaveFileDialogSettingsTest
    {
        [Test]
        public void NativeDialogSettingsParity()
        {
            // Arrange
            var settingsPropertyNames = string.Join(
                ", ",
                DialogSettings.GetPropertyNames(typeof(SaveFileDialogSettings)));

            var dialogPropertyNames = string.Join(
                ", ",
                DialogSettings.GetPropertyNames(typeof(SaveFileDialog)).Except(DialogSettings.ExcludedPropertyNames));

            // Assert
            Assert.That(settingsPropertyNames, Is.EqualTo(dialogPropertyNames));
        }
    }
}
