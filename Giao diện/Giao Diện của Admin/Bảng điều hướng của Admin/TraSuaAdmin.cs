using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User.All_form_TS;

namespace OrderMillTeaProgram.Giao_diện.Giao_Diện_của_Admin
{
    public partial class TraSuaAdmin : Form
    {
        public TraSuaAdmin()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            // Gắn sự kiện mở form con
            btnTraSuaThaiXanh.Click += (s, e) => OpenAdminForm(new TraSuaThaiXanh());
            btnTraSuaTruyenThong.Click += (s, e) => OpenAdminForm(new TSTranChau());
            btnTraSuaKhoaiMon.Click += (s, e) => OpenAdminForm(new tskhoaimon());
            btnTraSuaChocolate.Click += (s, e) => OpenAdminForm(new TSSocolaMin());
            btnTraSuaPhoMai.Click += (s, e) => OpenAdminForm(new TSPhoMai());
            btnTraSuaOreo.Click += (s, e) => OpenAdminForm(new TSOreoCakeCream());
            btnTraDaoCamSa.Click += (s, e) => OpenAdminForm(new TraDaoCamSa());
            btnHongTraTac.Click += (s, e) => OpenAdminForm(new HongTraTac());

            // Sự kiện đóng form chính
            btnClose.Click += CloseForm;
        }

        private Panel overlayPanel;

        // Mở form con
        private void OpenAdminForm(Form adminForm)
        {
            try
            {
                AddOverlay(); // Thêm lớp phủ

                // Gỡ lớp phủ và kích hoạt lại form chính khi form con đóng
                adminForm.FormClosed += (s, e) =>
                {
                    RemoveOverlay();
                    this.Enabled = true;
                };

                adminForm.Show(); // Hiển thị form con
                this.Enabled = false; // Vô hiệu hóa form chính
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RemoveOverlay();
                this.Enabled = true;
            }
        }

        private void AddOverlay()
        {
            overlayPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(50, 0, 0, 0), // Màu đen bán trong suốt
            };
            this.Controls.Add(overlayPanel);
            overlayPanel.BringToFront();
        }

        private void RemoveOverlay()
        {
            if (overlayPanel != null)
            {
                this.Controls.Remove(overlayPanel);
                overlayPanel.Dispose();
                overlayPanel = null;
            }
        }

        private void CloseForm(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void TraSuaAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void TraSuaAdmin_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void BtnTraSuaThaiXanh_MouseHover(object sender, EventArgs e)
        {
            btnTraSuaThaiXanh.BackColor = Color.LightGray;
        }

        private void BtnTraSuaThaiXanh_MouseLeave(object sender, EventArgs e)
        {
            btnTraSuaThaiXanh.BackColor = SystemColors.Control;
        }

        private void BtnTraSuaTruyenThong_MouseHover(object sender, EventArgs e)
        {
            btnTraSuaTruyenThong.BackColor = Color.LightGray;
        }

        private void BtnTraSuaTruyenThong_MouseLeave(object sender, EventArgs e)
        {
            btnTraSuaTruyenThong.BackColor = SystemColors.Control;
        }

        private void BtnTraSuaKhoaiMon_MouseHover(object sender, EventArgs e)
        {
            btnTraSuaKhoaiMon.BackColor = Color.LightGray;
        }

        private void BtnTraSuaKhoaiMon_MouseLeave(object sender, EventArgs e)
        {
            btnTraSuaKhoaiMon.BackColor = SystemColors.Control;
        }

        private void BtnTraSuaChocolate_MouseHover(object sender, EventArgs e)
        {
            btnTraSuaChocolate.BackColor = Color.LightGray;
        }

        private void BtnTraSuaChocolate_MouseLeave(object sender, EventArgs e)
        {
            btnTraSuaChocolate.BackColor = SystemColors.Control;
        }

        private void BtnTraSuaPhoMai_MouseHover(object sender, EventArgs e)
        {
            btnTraSuaPhoMai.BackColor = Color.LightGray;
        }

        private void BtnTraSuaPhoMai_MouseLeave(object sender, EventArgs e)
        {
            btnTraSuaPhoMai.BackColor = SystemColors.Control;
        }

        private void BtnTraSuaOreo_MouseHover(object sender, EventArgs e)
        {
            btnTraSuaOreo.BackColor = Color.LightGray;
        }

        private void BtnTraSuaOreo_MouseLeave(object sender, EventArgs e)
        {
            btnTraSuaOreo.BackColor = SystemColors.Control;
        }

        private void BtnTraDaoCamSa_MouseHover(object sender, EventArgs e)
        {
            btnTraDaoCamSa.BackColor = Color.LightGray;
        }

        private void BtnTraDaoCamSa_MouseLeave(object sender, EventArgs e)
        {
            btnTraDaoCamSa.BackColor = SystemColors.Control;
        }

        private void BtnHongTraTac_MouseHover(object sender, EventArgs e)
        {
            btnHongTraTac.BackColor = Color.LightGray;
        }

        private void BtnHongTraTac_MouseLeave(object sender, EventArgs e)
        {
            btnHongTraTac.BackColor = SystemColors.Control;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
