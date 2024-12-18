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
    public partial class BangDieuKhien : Form
    {
        public BangDieuKhien()
        {
            InitializeComponent();
        }

        private void BangDieuKhien_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void BangDieuKhien_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }
    }
}
