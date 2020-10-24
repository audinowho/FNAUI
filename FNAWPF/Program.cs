using System;
using ExampleFNA;

namespace FNAWPF
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            MainWindow window = new MainWindow();
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

        }
    }
}
