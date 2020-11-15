#region Using Statements
using System;
using System.Threading;
using System.Globalization;
using System.Reflection;
using Microsoft.Xna.Framework;
using System.Text;
#endregion

namespace ExampleFNA
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                InitDllMap();
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

        public static void InitDllMap()
        {
            CoreDllMap.Init();
            Assembly fnaAssembly = Assembly.GetAssembly(typeof(Game));
            CoreDllMap.Register(fnaAssembly);
        }
    }
}
