using System;
using System.IO;
using System.Windows.Forms;
using RTTE.Forms.MainForm;

namespace RTTE
{
    static class Program
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
