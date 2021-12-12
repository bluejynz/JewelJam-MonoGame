using System;

namespace JewelJam
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new JewelJam())
                game.Run();
        }
    }
}
