// using System.Threading;
// using System.Windows;
// using Moq;
// using MvvmDialogs.FrameworkDialogs;
// using NUnit.Framework;
// using MessageBoxButton = System.Windows.MessageBoxButton;
// using MessageBoxImage = System.Windows.MessageBoxImage;
// using MessageBoxResult = System.Windows.MessageBoxResult;
//
// namespace MvvmDialogs.Wpf.FrameworkDialogs.MessageBox
// {
//     [TestFixture]
//     public class WpfMessageBoxTest
//     {
//         private MessageBoxSettings settings;
//         private Mock<IMessageBoxShow> messageBoxShow;
//         private WpfMessageBox dialog;
//
//         [SetUp]
//         public void SetUp()
//         {
//             settings = new MessageBoxSettings();
//             messageBoxShow = new Mock<IMessageBoxShow>();
//             dialog = new WpfMessageBox(messageBoxShow.Object, settings);
//         }
//
//         [Test]
//         [RequiresThread(ApartmentState.STA)]
//         public void Show()
//         {
//             // Arrange
//             settings.Button = MessageBoxButton.YesNoCancel;
//             settings.Caption = "Some caption";
//             settings.DefaultResult = MessageBoxResult.Yes;
//             settings.Icon = MessageBoxImage.Warning;
//             settings.MessageBoxText = "Some message box text";
//             settings.Options = MessageBoxOptions.RightAlign;
//
//             var owner = new Window();
//
//             messageBoxShow
//                 .Setup(mock =>
//                     mock.Show(
//                         owner,
//                         settings.MessageBoxText,
//                         settings.Caption,
//                         settings.Button,
//                         settings.Icon,
//                         settings.DefaultResult,
//                         settings.Options))
//                 .Returns(MessageBoxResult.Cancel);
//
//             // Act
//             dialog.Show(owner);
//
//             // Assert
//             messageBoxShow.VerifyAll();
//         }
//     }
// }
