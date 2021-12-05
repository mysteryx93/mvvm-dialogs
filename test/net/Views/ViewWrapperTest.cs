using System.Threading;
using System.Windows;
using MvvmDialogs.Wpf;
using NUnit.Framework;

namespace MvvmDialogs.Views
{
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class WpfViewTest
    {
        private FrameworkElement frameworkElement;

        [SetUp]
        public void SetUp() => frameworkElement = new FrameworkElement();

        [Test]
        public void Source()
        {
            // Arrange
            var view = new WpfView(frameworkElement);

            // Assert
            Assert.That(view.Source, Is.EqualTo(frameworkElement));
        }

        [Test]
        public void GetHashCodeOverride()
        {
            // Arrange
            var viewA = new WpfView(frameworkElement);
            var viewB = new WpfView(frameworkElement);

            // Act
            var hashCodeA = viewA.GetHashCode();
            var hashCodeB = viewB.GetHashCode();

            // Assert
            Assert.That(hashCodeA, Is.EqualTo(hashCodeB));
        }

        [Test]
        public void EqualsOverride()
        {
            // Arrange
            var viewA = new WpfView(frameworkElement);
            var viewB = new WpfView(frameworkElement);

            // Act
            var equals = viewA.Equals(viewB);

            // Assert
            Assert.That(equals, Is.True);
        }
    }
}
