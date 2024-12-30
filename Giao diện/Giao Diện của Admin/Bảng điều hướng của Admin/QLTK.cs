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
    public partial class QLTK : Form
    {
        public QLTK()
        {
            InitializeComponent();
        }

        private void QLTK_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void QLTK_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'userInfoDataSet.UserInfo' table. You can move, or remove it, as needed.
            this.ControlBox = false;
        }
    }
}
