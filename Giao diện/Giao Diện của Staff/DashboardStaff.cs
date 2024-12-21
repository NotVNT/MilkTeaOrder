using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderMillTeaProgram.Giao_diện;
using OrderMillTeaProgram.Giao_diện.Giao_Diện_của_Admin;



namespace OrderMillTeaProgram.Giao_diện_của_User
{
    public partial class DashboardStaff : Form
    {
        BangDieuKhien bangdieukhien;
        TraSuaAdmin trasuaAdmin;
        AnVatAdmin anvatAdmin;
        ToppingAdmin toppingAdmin;
        public DashboardStaff()
        {
            InitializeComponent();
            mdiProp();
        }
      
        bool menuExpand = false;

        private void mdiProp()
        {
            this.SetBevel(false);
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.FromArgb(232, 234, 237);
        }

        private void menuTransition_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                menuContainer.Height += 10;
                if(menuContainer.Height >= 187)
                {
                    menuTransition.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                menuContainer.Height -= 10;
                if(menuContainer.Height <= 46)
                {
                    menuTransition.Stop();
                    menuExpand = false;
                }
            }
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            menuTransition.Start();
        }

        bool sidebarExpand = true;

        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if(sidebarExpand )
            {
                sidebar.Width -= 5;
                if(sidebar.Width <= 54)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();

                    //btnDashboard.Width = sidebar.Width;
                    //btnQLDT.Width = sidebar.Width;
                    //btnQLTK.Width = sidebar.Width;
                    //btnNhaCungCap.Width = sidebar.Width;
                    //btnDonhang.Width = sidebar.Width;
                    //btnThongBao.Width = sidebar.Width;
                    //btnLogout.Width = sidebar.Width;
                    //menuContainer.Width = sidebar.Width;


                    //btnDashboard.Text = "";
                    //btnQLDT.Text = "";
                    //btnQLTK.Text = "";
                    //btnNhaCungCap.Text = "";
                    //btnDonhang.Text = "";
                    //btnThongBao.Text = "";
                    //btnLogout.Text = "";
                    //menuContainer.Text = "";


                }
            } else
            {
                sidebar.Width += 5;
                if(sidebar.Width >= 220)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();

                  
                }
            }
        }

        private void sidebarclick_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if(bangdieukhien == null)
            {
                bangdieukhien = new BangDieuKhien();
                bangdieukhien.FormClosed += BangDieuKhien_FormClosed;
                bangdieukhien.MdiParent = this;
                bangdieukhien.Dock = DockStyle.Fill;
                bangdieukhien.Show();

            }    
            else
            {
                bangdieukhien.Activate();
            }
        }
        private void BangDieuKhien_FormClosed(object sender, FormClosedEventArgs e)
        {
            bangdieukhien = null;
        }

        private void btnTraSua_Click(object sender, EventArgs e)
        {
            if (trasuaAdmin == null)
            {
                trasuaAdmin = new TraSuaAdmin();
                trasuaAdmin.FormClosed += TraSuaAdmin_FormClosed;
                trasuaAdmin.MdiParent = this;
                trasuaAdmin.Dock = DockStyle.Fill;
                trasuaAdmin.Show();
            }
            else
            {
                trasuaAdmin.Activate();
            }
        }
        private void TraSuaAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            trasuaAdmin = null;
        }

        private void btnTrangMieng_Click(object sender, EventArgs e)
        {
            if (anvatAdmin == null)
            {
                anvatAdmin = new AnVatAdmin();
                anvatAdmin.FormClosed += TraSuaAdmin_FormClosed;
                anvatAdmin.MdiParent = this;
                anvatAdmin.Dock = DockStyle.Fill;
                anvatAdmin.Show();
            }
            else
            {
                anvatAdmin.Activate();
            }
        }
        private void AnVatAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            anvatAdmin = null;
        }

        private void btnTopping_Click(object sender, EventArgs e)
        {
            if (toppingAdmin == null)
            {
                toppingAdmin = new ToppingAdmin();
                toppingAdmin.FormClosed += TraSuaAdmin_FormClosed;
                toppingAdmin.MdiParent = this;
                toppingAdmin.Dock = DockStyle.Fill;
                toppingAdmin.Show();
            }
            else
            {
                toppingAdmin.Activate();
            }
        }

        private void ToppingAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            toppingAdmin = null;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes )
            {
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
            }
        }
    }
}
