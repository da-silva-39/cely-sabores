using System;
using System.Windows.Forms;

namespace Cely_Sabores
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormularioLogin());
        }
    }
}
