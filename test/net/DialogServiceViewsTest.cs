using System.Threading;
using System.Windows;
using Moq;
using MvvmDialogs.Wpf;
using NUnit.Framework;

namespace MvvmDialogs
{
    // ReSharper disable UnusedVariable
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class DialogServiceViewsTest
    {
        [TearDown]
        public void TearDown() => ViewLocator.Clear();

        [Test]
        public void RegisterWindowUsingAttachedProperty()
        {
            // Arrange
            var window = new Window();

            var expected = new[]
            {
                new ViewWrapper(window)
            };

            // Act
            window.SetValue(DialogServiceViews.IsRegisteredProperty, true);

            // Assert
            Assert.That(ViewLocator.Views, Is.EqualTo(expected));
        }

        [Test]
        public void UnregisterWindowUsingAttachedProperty()
        {
            // Arrange
            var window = new Window();
            window.SetValue(DialogServiceViews.IsRegisteredProperty, true);

            // Act
            window.SetValue(DialogServiceViews.IsRegisteredProperty, false);

            // Assert
            Assert.That(ViewLocator.Views, Is.Empty);
        }

        [Test]
        public void RegisterFrameworkElementUsingAttachedProperty()
        {
            // Arrange
            var frameworkElement = new FrameworkElement();

            var window = new Window
            {
                Content = frameworkElement
            };

            var expected = new[]
            {
                new ViewWrapper(frameworkElement)
            };

            // Act
            frameworkElement.SetValue(DialogServiceViews.IsRegisteredProperty, true);

            // Assert
            Assert.That(ViewLocator.Views, Is.EqualTo(expected));
        }

        [Test]
        public void UnregisterFrameworkElementUsingAttachedProperty()
        {
            // Arrange
            var frameworkElement = new FrameworkElement();


            var window = new Window
            {
                Content = frameworkElement
            };

            frameworkElement.SetValue(DialogServiceViews.IsRegisteredProperty, true);

            // Act
            frameworkElement.SetValue(DialogServiceViews.IsRegisteredProperty, false);

            // Assert
            Assert.That(ViewLocator.Views, Is.Empty);
        }

        [Test]
        public void RegisterLoadedView()
        {
            // Arrange
            var view = new Mock<ViewMock>();
            view
                .Setup(mock => mock.IsAlive)
                .Returns(true);
            view
                .Setup(mock => mock.GetOwner())
                .Returns(new WindowWrapper(new Window()));

            var expected = new[]
            {
                view.Object
            };

            // Act
            ViewLocator.Register(view.Object);

            // Assert
            Assert.That(ViewLocator.Views, Is.EqualTo(expected));
        }

        [Test]
        public void UnregisterLoadedView()
        {
            // Arrange
            var view = new Mock<ViewMock>();
            view
                .Setup(mock => mock.IsAlive)
                .Returns(true);
            view
                .Setup(mock => mock.GetOwner())
                .Returns(new WindowWrapper(new Window()));

            DialogServiceViews.SetIsRegistered((FrameworkElement)view.Object.SourceObj, true);

            // Act
            DialogServiceViews.SetIsRegistered((FrameworkElement)view.Object.SourceObj, false);

            // Assert
            Assert.That(ViewLocator.Views, Is.Empty);
        }

        [Test]
        public void RegisterViewThatNeverGetsLoaded()
        {
            // Arrange
            var view = new Mock<ViewMock>();
            view
                .Setup(mock => mock.IsAlive)
                .Returns(true);

            // Act
            ViewLocator.Register(view.Object);

            // Assert
            Assert.That(ViewLocator.Views, Is.Empty);
        }

        [Test]
        public void RegisterViewThatGetsLoaded()
        {
            // Arrange
            var view = new Mock<ViewMock>();
            view
                .Setup(mock => mock.IsAlive)
                .Returns(true);

            // At time of register the view has no parent, thus is not loaded
            ViewLocator.Register(view.Object);

            // After register we can simulate that the view gets loaded
            view
                .Setup(mock => mock.GetOwner())
                .Returns(new WindowWrapper(new Window()));

            var expected = new[]
            {
                view.Object
            };

            // Act
            view.Raise(mock => mock.Loaded += null, new RoutedEventArgs(null, view.Object));

            // Assert
            Assert.That(ViewLocator.Views, Is.EqualTo(expected));
        }

        [Test]
        public void UnregisterWhenClosingOwner()
        {
            // Arrange
            var window = new Window();

            var view = new Mock<ViewMock>();
            view
                .Setup(mock => mock.IsAlive)
                .Returns(true);
            view
                .Setup(mock => mock.GetOwner())
                .Returns(new WindowWrapper(window));

            ViewLocator.Register(view.Object);

            // Act
            window.Close();

            // Assert
            Assert.That(ViewLocator.Views, Is.Empty);
        }

        public abstract class ViewMock : ViewBase
        {
            protected ViewMock()
                : base(new FrameworkElement())
            {
            }
        }
    }
}
