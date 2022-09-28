using System;
using System.Windows.Forms;
using NintendoWare_Audio_Player.Forms;

namespace NintendoWare_Audio_Player
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}