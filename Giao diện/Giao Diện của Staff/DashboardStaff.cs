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
        BangDieuKhienStaff bangdieukhienstaff;
        TraSuaAdmin trasuastaff;
        ChinhSuaMonAn anvatAdmin;
  
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
            if(bangdieukhienstaff == null)
            {
                bangdieukhienstaff = new BangDieuKhienStaff();
                bangdieukhienstaff.FormClosed += BangDieuKhien_FormClosed;
                bangdieukhienstaff.MdiParent = this;
                bangdieukhienstaff.Dock = DockStyle.Fill;
                bangdieukhienstaff.Show();

            }    
            else
            {
                bangdieukhienstaff.Activate();
            }
        }
        private void BangDieuKhien_FormClosed(object sender, FormClosedEventArgs e)
        {
            bangdieukhienstaff = null;
        }

        private void btnTraSua_Click(object sender, EventArgs e)
        {
            if (trasuastaff == null)
            {
                trasuastaff = new TraSuaAdmin();
                trasuastaff.FormClosed += TraSuaAdmin_FormClosed;
                trasuastaff.MdiParent = this;
                trasuastaff.Dock = DockStyle.Fill;
                trasuastaff.Show();
            }
            else
            {
                trasuastaff.Activate();
            }
        }
        private void TraSuaAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            trasuastaff = null;
        }

        private void btnTrangMieng_Click(object sender, EventArgs e)
        {
            if (anvatAdmin == null)
            {
                anvatAdmin = new ChinhSuaMonAn();
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
