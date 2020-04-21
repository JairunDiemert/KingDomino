using System;
using System.Windows.Forms;

namespace KingDomino
{
#if WINDOWS || LINUX
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.Run(new Menu());
            using (var game = new Game1())
                game.Run();
        }
    }
#endif
}
