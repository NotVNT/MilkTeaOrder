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
    public partial class TraSuaStaff : Form
    {
        public TraSuaStaff()
        {
            InitializeComponent();
        }

        private void btnTraSuaThaiXanh_MouseHover(object sender, EventArgs e)
        {
            btnTraSuaThaiXanh.BackColor = Color.LightGray;
        }

        private void btnTraSuaThaiXanh_MouseLeave(object sender, EventArgs e)
        {
            btnTraSuaThaiXanh.BackColor = SystemColors.Control;
        }

        private void btnTraSuaTruyenThong_MouseHover(object sender, EventArgs e)
        {
            btnTraSuaTruyenThong.BackColor = Color.LightGray;
        }

        private void btnTraSuaTruyenThong_MouseLeave(object sender, EventArgs e)
        {
            btnTraSuaTruyenThong.BackColor = SystemColors.Control;
        }

        private void btnTraSuaKhoaiMon_MouseHover(object sender, EventArgs e)
        {
            btnTraSuaKhoaiMon.BackColor = Color.LightGray;
        }

        private void btnTraSuaKhoaiMon_MouseLeave(object sender, EventArgs e)
        {
            btnTraSuaKhoaiMon.BackColor = SystemColors.Control;
        }

        private void btnTraSuaChocolate_MouseHover(object sender, EventArgs e)
        {
            btnTraSuaChocolate.BackColor = Color.LightGray;
        }

        private void btnTraSuaChocolate_MouseLeave(object sender, EventArgs e)
        {
            btnTraSuaChocolate.BackColor = SystemColors.Control;
        }

        private void btnTraSuaPhoMai_MouseHover(object sender, EventArgs e)
        {
            btnTraSuaPhoMai.BackColor = Color.LightGray;
        }

        private void btnTraSuaPhoMai_MouseLeave(object sender, EventArgs e)
        {
            btnTraSuaPhoMai.BackColor = SystemColors.Control;
        }

        private void btnTraSuaOreo_MouseHover(object sender, EventArgs e)
        {
            btnTraSuaOreo.BackColor = Color.LightGray;
        }

        private void btnTraSuaOreo_MouseLeave(object sender, EventArgs e)
        {
            btnTraSuaOreo.BackColor = SystemColors.Control;
        }

        private void btnTraDaoCamSa_MouseHover(object sender, EventArgs e)
        {
            btnTraDaoCamSa.BackColor = Color.LightGray;
        }

        private void btnTraDaoCamSa_MouseLeave(object sender, EventArgs e)
        {
            btnTraDaoCamSa.BackColor = SystemColors.Control;
        }

        private void btnHongTraTac_MouseHover(object sender, EventArgs e)
        {
            btnHongTraTac.BackColor = Color.LightGray;
        }

        private void btnHongTraTac_MouseLeave(object sender, EventArgs e)
        {
            btnHongTraTac.BackColor = SystemColors.Control;
        }

        private void TraSuaStaff_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void TraSuaStaff_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }
    }
}
