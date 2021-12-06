using System.Reactive;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;

namespace MvvmDialogs.Avalonia
{
    /// <summary>
    /// Class containing means to register a FrameworkElement as a view for a view
    /// model when using the MVVM pattern. The view will then be used by the
    /// <see cref="AvaloniaDialogService"/> when opening dialogs.
    /// </summary>
    public class DialogServiceViews : AvaloniaObject
    {
        static DialogServiceViews()
        {
            IsRegisteredProperty.Changed.Subscribe(
                new AnonymousObserver<AvaloniaPropertyChangedEventArgs<bool>>(IsRegisteredChanged));
        }

        /// <summary>
        /// Attached property describing whether a <see cref="Window"/> is acting as a
        /// view for a view model when using the MVVM pattern.
        /// </summary>
        public static readonly AttachedProperty<bool> IsRegisteredProperty =
            AvaloniaProperty.RegisterAttached<DialogServiceViews, Window, bool>("IsRegistered", defaultBindingMode: BindingMode.OneTime);

        /// <summary>
        /// Gets value describing whether <see cref="AvaloniaObject"/> is acting as a view for a
        /// view model when using the MVVM pattern
        /// </summary>
        public static bool GetIsRegistered(AvaloniaObject target) => target.GetValue(IsRegisteredProperty);

        /// <summary>
        /// Sets value describing whether <see cref="AvaloniaObject"/> is acting as a view for a
        /// view model when using the MVVM pattern
        /// </summary>
        public static void SetIsRegistered(AvaloniaObject target, bool value) => target.SetValue(IsRegisteredProperty, value);

        /// <summary>
        /// Is responsible for handling <see cref="IsRegisteredProperty"/> changes, i.e.
        /// whether <see cref="Window"/> is acting as a view for a view model when using
        /// the MVVM pattern.
        /// </summary>
        private static void IsRegisteredChanged(AvaloniaPropertyChangedEventArgs<bool> e)
        {
            // The Visual Studio Designer or Blend will run this code when setting the attached
            // property in XAML, however we wish to abort the execution since the behavior adds
            // nothing to a designer.
            // if (DesignerProperties.GetIsInDesignMode(target))
            //     return;

            if (e.Sender is Window view)
            {
                if (e.NewValue.Value)
                {
                    ViewLocator.Register(new AvaloniaView(view));
                }
                else
                {
                    ViewLocator.Unregister(new AvaloniaView(view));
                }
            }
        }
    }
}
