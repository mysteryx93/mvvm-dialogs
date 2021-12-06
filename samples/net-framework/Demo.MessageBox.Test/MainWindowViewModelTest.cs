using Moq;
using MvvmDialogs.Core;
using MvvmDialogs.Core.FrameworkDialogs;
using NUnit.Framework;

namespace Demo.MessageBox
{
    [TestFixture]
    public class MainWindowViewModelTest
    {
        private Mock<IDialogService> dialogService;
        private MainWindowViewModel viewModel;

        [SetUp]
        public void SetUp()
        {
            dialogService = new Mock<IDialogService>();
            viewModel = new MainWindowViewModel(dialogService.Object);
        }

        [Test]
        public void ShowMessageBoxWithMessage()
        {
            // Arrange
            dialogService
                .Setup(mock =>
                    mock.ShowMessageBox(
                        viewModel,
                        It.IsAny<string>(),
                        "",
                        MessageBoxButton.OK,
                        MessageBoxImage.None,
                        MessageBoxResult.None))
                .Returns(true);

            // Act
            viewModel.ShowMessageBoxWithMessageCommand.Execute(null);

            // Assert
            dialogService.VerifyAll();
        }

        [Test]
        public void ShowMessageBoxWithCaption()
        {
            // Arrange
            dialogService
                .Setup(mock =>
                    mock.ShowMessageBox(
                        viewModel,
                        It.IsAny<string>(),
                        It.IsAny<string>(),
                        MessageBoxButton.OK,
                        MessageBoxImage.None,
                        MessageBoxResult.None))
                .Returns(true);

            // Act
            viewModel.ShowMessageBoxWithCaptionCommand.Execute(null);

            // Assert
            dialogService.VerifyAll();
        }

        [Test]
        public void ShowMessageBoxWithButton()
        {
            // Arrange
            dialogService
                .Setup(mock =>
                    mock.ShowMessageBox(
                        viewModel,
                        It.IsAny<string>(),
                        It.IsAny<string>(),
                        MessageBoxButton.OKCancel,
                        MessageBoxImage.None,
                        MessageBoxResult.None))
                .Returns(true); ;

            // Act
            viewModel.ShowMessageBoxWithButtonCommand.Execute(null);

            // Assert
            dialogService.VerifyAll();
        }

        [Test]
        public void ShowMessageBoxWithIcon()
        {
            // Arrange
            dialogService
                .Setup(mock =>
                    mock.ShowMessageBox(
                        viewModel,
                        It.IsAny<string>(),
                        It.IsAny<string>(),
                        MessageBoxButton.OKCancel,
                        MessageBoxImage.Information,
                        MessageBoxResult.None))
                .Returns(true); ;

            // Act
            viewModel.ShowMessageBoxWithIconCommand.Execute(null);

            // Assert
            dialogService.VerifyAll();
        }

        [Test]
        public void ShowMessageBoxWithDefaultResult()
        {
            // Arrange
            dialogService
                .Setup(mock =>
                    mock.ShowMessageBox(
                        viewModel,
                        It.IsAny<string>(),
                        It.IsAny<string>(),
                        MessageBoxButton.OKCancel,
                        MessageBoxImage.Information,
                        MessageBoxResult.Cancel))
                .Returns(true); ;

            // Act
            viewModel.ShowMessageBoxWithDefaultResultCommand.Execute(null);

            // Assert
            dialogService.VerifyAll();
        }
    }
}
