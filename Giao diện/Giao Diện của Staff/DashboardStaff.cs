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
        AnVatAdmin anvatAdmin;
        ToppingAdmin toppingAdmin;
        public DashboardStaff()
        {
            InitializeComponent();
            MdiProp();
        }
    
        bool menuExpand = false;

        private void MdiProp()
        {
            this.SetBevel(false);
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.FromArgb(232, 234, 237);
        }

        private void MenuTransition_Tick(object sender, EventArgs e)
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

        private void BtnDanhMuc_Click(object sender, EventArgs e)
        {
            menuTransition.Start();
        }

        bool sidebarExpand = true;

        private void SidebarTransition_Tick(object sender, EventArgs e)
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

        private void Sidebarclick_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
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

        private Form trasuaAdminForm = null; // Biến tham chiếu đến form TraSuaAdmin

        private void BtnTraSua_Click(object sender, EventArgs e)
        {
            if (trasuaAdminForm == null) // Nếu form chưa được tạo
            {
                trasuaAdminForm = new TraSuaAdmin(); // Tạo instance của TraSuaAdmin
                trasuaAdminForm.FormClosed += TraSuaAdmin_FormClosed; // Gắn sự kiện FormClosed
                trasuaAdminForm.MdiParent = this; // Đặt TraSuaAdmin làm form con trong MDI
                trasuaAdminForm.Dock = DockStyle.Fill; // Hiển thị form full màn hình trong container
                trasuaAdminForm.Show(); // Hiển thị form
            }
            else
            {
                trasuaAdminForm.Activate(); // Nếu đã có, đưa form ra phía trước
            }
        }

        private void TraSuaAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            trasuaAdminForm = null; // Khi form đóng, set tham chiếu về null để có thể mở lại
        }


        private void BtnTrangMieng_Click(object sender, EventArgs e)
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

        private void BtnTopping_Click(object sender, EventArgs e)
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

        private void BtnLogout_Click(object sender, EventArgs e)
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
