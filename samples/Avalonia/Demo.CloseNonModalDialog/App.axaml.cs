using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MvvmDialogs;
using MvvmDialogs.Avalonia;
using Splat;

namespace Demo.CloseNonModalDialog
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
            var build = Locator.CurrentMutable;
            // build.RegisterViewsForViewModels(Assembly.GetCallingAssembly());
            build.Register(() => new MainWindowViewModel(new DialogService()));
            build.Register(() => new CurrentTimeDialogViewModel());
            build.RegisterLazySingleton(() => (IDialogService)new DialogService());
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = ViewLocator.MainWindowViewModel
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
