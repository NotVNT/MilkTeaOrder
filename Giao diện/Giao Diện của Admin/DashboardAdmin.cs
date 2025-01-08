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
    public partial class DashboardAdmin : Form
    {
        BangDieuKhien bangdieukhien;
        ThongTinDanhMuc thongtindanhmuc;
        ChinhSuaMonAn chinhsuamonan;
        QLDT qldt;
        QLTK qltk;
        HoaDonFromAdmin hoadonfromadmin;
        public DashboardAdmin()
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
                if(menuContainer.Height >= 140)
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


        private void btnLogout_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK )
            {
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
            }
        }

        private void btnQLDT_Click(object sender, EventArgs e)
        {
            if (qldt == null)
            {
                qldt = new QLDT();
                qldt.FormClosed += QLDT_FormClosed;
                qldt.MdiParent = this;
                qldt.Dock = DockStyle.Fill;
                qldt.Show();
            }
            else
            {
                qldt.Activate();
            }
        }
        private void QLDT_FormClosed(object sender, FormClosedEventArgs e)
        {
            hoadonfromadmin = null;
        }

        private void btnQLTK_Click(object sender, EventArgs e)
        {
            if (qltk == null)
            {
                qltk = new QLTK();
                qltk.FormClosed += QLTK_FormClosed;
                qltk.MdiParent = this;
                qltk.Dock = DockStyle.Fill;
                qltk.Show();
            }
            else
            {
                qltk.Activate();
            }
        }
        private void QLTK_FormClosed(object sender, FormClosedEventArgs e)
        {
            qltk = null;
        }

        private void btnChinhDanhMuc_Click(object sender, EventArgs e)
        {
            if (thongtindanhmuc == null)
            {
                thongtindanhmuc = new ThongTinDanhMuc();
                thongtindanhmuc.FormClosed += ThongTinDanhMuc_FormClosed;
                thongtindanhmuc.MdiParent = this;
                thongtindanhmuc.Dock = DockStyle.Fill;
                thongtindanhmuc.Show();
            }
            else
            {
                thongtindanhmuc.Activate();
            }
        }

        private void ThongTinDanhMuc_FormClosed(object sender, FormClosedEventArgs e)
        {
            thongtindanhmuc = null;
        }

        private void btnChinhSuaMon_Click(object sender, EventArgs e)
        {
            if (chinhsuamonan == null)
            {
                chinhsuamonan = new ChinhSuaMonAn();
                chinhsuamonan.FormClosed += ChinhSuaMonAn_FormClosed;
                chinhsuamonan.MdiParent = this;
                chinhsuamonan.Dock = DockStyle.Fill;
                chinhsuamonan.Show();
            }
            else
            {
                chinhsuamonan.Activate();
            }
        }

        private void ChinhSuaMonAn_FormClosed(object sender, FormClosedEventArgs e)
        {
            chinhsuamonan = null;
        }

        private void btnDonhang_Click(object sender, EventArgs e)
        {
            if (hoadonfromadmin == null)
            {
                hoadonfromadmin = new HoaDonFromAdmin();
                hoadonfromadmin.FormClosed += HoaDonFromAdmin_FormClosed;
                hoadonfromadmin.MdiParent = this;
                hoadonfromadmin.Dock = DockStyle.Fill;
                hoadonfromadmin.Show();
            }
            else
            {
                qldt.Activate();
            }
        }


        private void HoaDonFromAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            chinhsuamonan = null;
        }


    }
}
