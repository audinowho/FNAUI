using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Logging.Serilog;
using Avalonia.ReactiveUI;
using ExampleFNA;
using FNAAvalonia.ViewModels;
using FNAAvalonia.Views;

namespace FNAAvalonia
{
    class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main(string[] args)
        {
            AppBuilder builder = BuildAvaloniaApp();
            builder.SetupWithoutStarting();

            Avalonia.Controls.Window window = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
            window.Show();

            try
            {

                using (GameBase game = new GameBase())
                    game.Run();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            //builder.StartWithClassicDesktopLifetime(args);
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToDebug()
                .UseReactiveUI();
    }
}
