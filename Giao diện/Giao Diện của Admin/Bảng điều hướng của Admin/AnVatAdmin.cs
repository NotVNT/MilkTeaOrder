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
    public partial class AnVatAdmin : Form
    {
        public AnVatAdmin()
        {
            InitializeComponent();
        }

        private void AnVatAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void AnVatAdmin_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void btnBanhFlan_MouseHover(object sender, EventArgs e)
        {
            btnBanhFlan.BackColor = Color.LightGray;
        }

        private void btnBanhFlan_MouseLeave(object sender, EventArgs e)
        {
            btnBanhFlan.BackColor = SystemColors.Control;
        }

        private void btnTiramisu_MouseHover(object sender, EventArgs e)
        {
            btnTiramisu.BackColor = Color.LightGray;
        }

        private void btnTiramisu_MouseLeave(object sender, EventArgs e)
        {
            btnTiramisu.BackColor = SystemColors.Control;
        }

        private void btnBanhPhoMai_MouseHover(object sender, EventArgs e)
        {
            btnBanhPhoMai.BackColor = Color.LightGray;
        }

        private void btnBanhPhoMai_MouseLeave(object sender, EventArgs e)
        {
            btnBanhPhoMai.BackColor = SystemColors.Control;
        }

        private void btnCupCake_MouseHover(object sender, EventArgs e)
        {
            btnCupCake.BackColor = Color.LightGray;
        }

        private void btnCupCake_MouseLeave(object sender, EventArgs e)
        {
            btnCupCake.BackColor = SystemColors.Control;
        }
    }
}
