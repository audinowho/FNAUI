using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using ExampleFNA;
using Avalonia.Threading;
using System.Text;

namespace FNAAvalonia.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }


        public static void LoadGame()
        {
            try
            {
                using (GameBase game = new GameBase())
                    game.Run();
            }
            catch (Exception exception)
            {
                StringBuilder errorMsg = new StringBuilder();
                errorMsg.Append(String.Format("[{0}] {1}", String.Format("{0:yyyy/MM/dd HH:mm:ss.FFF}", DateTime.Now), exception.Message));
                errorMsg.Append("\n");
                Exception innerException = exception;
                int depth = 0;
                while (innerException != null)
                {
                    errorMsg.Append("Exception Depth: " + depth);
                    errorMsg.Append("\n");

                    errorMsg.Append(innerException.ToString());
                    errorMsg.Append("\n\n");

                    innerException = innerException.InnerException;
                    depth++;
                }

                Console.Write(errorMsg);
            }
        }

        public void Window_Loaded(object sender, EventArgs e)
        {
            if (Design.IsDesignMode)
                return;
            Dispatcher.UIThread.Post(LoadGame, DispatcherPriority.Background);
        }

        public void Window_Closed(object sender, EventArgs e)
        {
        }
    }
}
