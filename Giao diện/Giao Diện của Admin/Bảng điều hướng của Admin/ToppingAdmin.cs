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
    public partial class ToppingAdmin : Form
    {
        public ToppingAdmin()
        {
            InitializeComponent();
        }


        private void ToppingAdmin_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void ToppingAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {

        }



        private void btnThachDao_MouseHover(object sender, EventArgs e)
        {
            btnThachDao.BackColor = Color.LightGray;
        }

        private void btnThachDao_MouseLeave(object sender, EventArgs e)
        {
            btnThachDao.BackColor = SystemColors.Control;
        }

        private void btnPhoMaiJelly_MouseHover(object sender, EventArgs e)
        {
            btnPhoMaiJelly.BackColor = Color.LightGray;
        }

        private void btnPhoMaiJelly_MouseLeave(object sender, EventArgs e)
        {
            btnPhoMaiJelly.BackColor = SystemColors.Control;
        }

        private void btnHatThuyTinh_MouseHover(object sender, EventArgs e)
        {
            btnHatThuyTinh.BackColor = Color.LightGray;
        }

        private void btnHatThuyTinh_MouseLeave(object sender, EventArgs e)
        {
            btnHatThuyTinh.BackColor = SystemColors.Control;
        }

        private void btnTranChauDuongDen_MouseHover(object sender, EventArgs e)
        {
            btnTranChauDuongDen.BackColor = Color.LightGray;
        }

        private void btnTranChauDuongDen_MouseLeave(object sender, EventArgs e)
        {
            btnTranChauDuongDen.BackColor = SystemColors.Control;
        }

        private void btnThachDua_MouseHover(object sender, EventArgs e)
        {
            btnThachDua.BackColor = Color.LightGray;
        }

        private void btnThachDua_MouseLeave(object sender, EventArgs e)
        {
            btnThachDua.BackColor = SystemColors.Control;
        }

        private void btnPuddingDuaLuoi_MouseHover(object sender, EventArgs e)
        {
            btnPuddingDuaLuoi.BackColor = Color.LightGray;
        }

        private void btnPuddingDuaLuoi_MouseLeave(object sender, EventArgs e)
        {
            btnPuddingDuaLuoi.BackColor = SystemColors.Control;
        }
    }
}
