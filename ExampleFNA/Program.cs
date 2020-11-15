#region Using Statements
using System;
using System.Threading;
using System.Globalization;
using System.Reflection;
using Microsoft.Xna.Framework;
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
            InitDllMap();
            using (GameBase game = new GameBase())
                game.Run();
        }

        public static void InitDllMap()
        {
            CoreDllMap.Init();
            Assembly fnaAssembly = Assembly.GetAssembly(typeof(Game));
            CoreDllMap.Register(fnaAssembly);
        }
    }
}
