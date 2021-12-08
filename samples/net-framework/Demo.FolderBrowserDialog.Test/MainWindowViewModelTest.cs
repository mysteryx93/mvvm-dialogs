﻿using System.ComponentModel;
using Moq;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs;
using NUnit.Framework;

namespace Demo.FolderBrowserDialog
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
        public void BrowseFolderSuccessful()
        {
            // Arrange
            dialogService
                .Setup(mock => mock.ShowFolderBrowserDialog(viewModel, It.IsAny<OpenFolderDialogSettings>()))
                .Returns(true)
                .Callback((INotifyPropertyChanged _, OpenFolderDialogSettings settings) =>
                    settings.SelectedPath = @"C:\SomeFolder");

            // Act
            viewModel.BrowseFolderCommand.Execute(null);

            // Assert
            Assert.That(viewModel.Path, Is.EqualTo(@"C:\SomeFolder"));
        }

        [Test]
        public void BrowseFolderUnsuccessful()
        {
            // Arrange
            dialogService
                .Setup(mock => mock.ShowFolderBrowserDialog(viewModel, It.IsAny<OpenFolderDialogSettings>()))
                .Returns(false);

            // Act
            viewModel.BrowseFolderCommand.Execute(null);

            // Assert
            Assert.That(viewModel.Path, Is.Null);
        }
    }
}
