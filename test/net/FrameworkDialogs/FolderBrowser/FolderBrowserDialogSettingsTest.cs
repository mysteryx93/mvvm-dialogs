using System.Linq;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.Wpf.FrameworkDialogs.Utils;
using NUnit.Framework;

namespace MvvmDialogs.Wpf.FrameworkDialogs.FolderBrowser;

[TestFixture]
public class FolderBrowserDialogSettingsTest
{
    [Test]
    public void NativeDialogSettingsParity()
    {
        // Arrange
        var settingsPropertyNames = string.Join(
            ", ",
            AppDialogSettings.GetPropertyNames(typeof(OpenFolderDialogSettings)));

        var dialogPropertyNames = string.Join(
            ", ",
            AppDialogSettings.GetPropertyNames(typeof(System.Windows.Forms.FolderBrowserDialog)).Except(AppDialogSettings.ExcludedPropertyNames));

        // Assert
        Assert.That(settingsPropertyNames, Is.EqualTo(dialogPropertyNames));
    }
}