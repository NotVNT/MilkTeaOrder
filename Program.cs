using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User;
using OrderMillTeaProgram.Giao_diện_của_User;
using OrderMillTeaProgram.Giao_diện.Giao_Diện_của_Admin;
using OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User.All_form_TS;
using OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User.All_form_tráng_miệng;
using MailChimp.Net.Models;

namespace OrderMillTeaProgram
{
    internal static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new DashboardStaff());
        }
    }
}
