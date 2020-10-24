using System;
using ExampleFNA;

namespace FNAWPF
{
    class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main(string[] args)
        {
			
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
