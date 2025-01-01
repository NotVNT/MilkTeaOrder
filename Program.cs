using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User;
using OrderMillTeaProgram.Giao_diện_của_User;

namespace OrderMillTeaProgram
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HoaDon());
        }
    }
}
