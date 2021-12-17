using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MvvmDialogs;
using MvvmDialogs.Avalonia;
using Splat;

namespace Demo.MessageBox;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);

        var build = Locator.CurrentMutable;
        build.RegisterLazySingleton(() => (IDialogService)new DialogService());

        SplatRegistrations.Register<MainWindowViewModel>();
        SplatRegistrations.SetupIOC();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = MainWindow
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    public static MainWindowViewModel MainWindow => Locator.Current.GetService<MainWindowViewModel>();
}
