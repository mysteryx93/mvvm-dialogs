using System.Linq;
using Microsoft.Win32;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.Wpf.FrameworkDialogs.Utils;
using NUnit.Framework;

namespace MvvmDialogs.Wpf.FrameworkDialogs.SaveFile;

[TestFixture]
public class SaveFileDialogSettingsTest
{
    [Test]
    public void NativeDialogSettingsParity()
    {
        // Arrange
        var settingsPropertyNames = string.Join(
            ", ",
            AppDialogSettings.GetPropertyNames(typeof(SaveFileDialogSettings)));

        var dialogPropertyNames = string.Join(
            ", ",
            AppDialogSettings.GetPropertyNames(typeof(SaveFileDialog)).Except(AppDialogSettings.ExcludedPropertyNames));

        // Assert
        Assert.That(settingsPropertyNames, Is.EqualTo(dialogPropertyNames));
    }
}