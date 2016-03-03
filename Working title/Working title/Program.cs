using System;
using Working_title.Forms;

namespace Working_title
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {

        [STAThread]
        static void Main()
        {
            LoginForm.ShowDialog();
            if (Game1.CurrentGameState != GameState.Closing)
            {
                using (var game = new Game1())
                    game.Run();
            }
        }
    }
#endif
}
