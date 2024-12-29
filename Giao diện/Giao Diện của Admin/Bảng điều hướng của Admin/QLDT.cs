using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderMillTeaProgram.Giao_diện.Giao_Diện_của_Admin
{
    public partial class QLDT : Form
    {
        public QLDT()
        {
            InitializeComponent();
        }

        private void QLDT_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void QLDT_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }
    }
}
