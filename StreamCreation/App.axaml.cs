using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace StreamCreation;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
#if DEBUG
            desktop.MainWindow = new FrmLab1();
#elif RELEASE
            desktop.MainWindow = new FrmRegistration();
#endif
        }

        base.OnFrameworkInitializationCompleted();
    }
}