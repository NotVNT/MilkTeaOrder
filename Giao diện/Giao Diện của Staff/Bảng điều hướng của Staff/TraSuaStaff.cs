using OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User.All_form_TS;
using OrderMillTeaProgram.Giao_diện_của_User;
using System;
using System.Drawing;
using System.Windows.Forms;
using Hongtratac = OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User.All_form_TS.Hongtratac;

namespace OrderMillTeaProgram.Giao_diện.Giao_Diện_của_Admin
{
    public partial class TraSuaStaff : Form
    {
        public Action<object, ProductSelectedEventArgs> ProductSelected { get; internal set; }

        public TraSuaStaff()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            // Sự kiện mở form Hồng Trà Tắc
            picHongTraTac.Click += (s, e) => OpenTeaForm(new Hongtratac());
            lblHongTraTac.Click += (s, e) => OpenTeaForm(new Hongtratac());

            // Sự kiện mở form Trà Sữa Chân Trâu
            picTSChanTrau.Click += (s, e) => OpenTeaForm(new TSTranChau());
            lblTSChanTrau.Click += (s, e) => OpenTeaForm(new TSTranChau());

            // Sự kiện mở form Trà Sữa Khoai Môn
            pictskhoaimon.Click += (s, e) => OpenTeaForm(new Tskhoaimon());
            lbltskhoaimon.Click += (s, e) => OpenTeaForm(new Tskhoaimon());

            // Sự kiện mở form Trà Sữa Oreo Cake Cream
            picTSOreoCakeCream.Click += (s, e) => OpenTeaForm(new TSOreoCakeCream());
            lblTSOreoCakeCream.Click += (s, e) => OpenTeaForm(new TSOreoCakeCream());

            // Sự kiện mở form Trà Sữa Phô Mai
            picTSPhoMai.Click += (s, e) => OpenTeaForm(new TSPhoMai());
            lblTSPhoMai.Click += (s, e) => OpenTeaForm(new TSPhoMai());

            // Sự kiện mở form Trà Sữa Socola Min
            picTSSocolaMin.Click += (s, e) => OpenTeaForm(new TSSocolaMin());
            lblTSSocolaMin.Click += (s, e) => OpenTeaForm(new TSSocolaMin());

            // Sự kiện mở form Trà Đào Cam Sả
            picTraDaoCamSa.Click += (s, e) => OpenTeaForm(new TraDaoCamSa());
            lblTraDaoCamSa.Click += (s, e) => OpenTeaForm(new TraDaoCamSa());

            // Sự kiện mở form Trà Sữa Thái Xanh
            picTraSuaThaiXanh.Click += (s, e) => OpenTeaForm(new TraSuaThaiXanh());
            lblTraSuaThaiXanh.Click += (s, e) => OpenTeaForm(new TraSuaThaiXanh());

            // Sự kiện đóng form
            btnClose.Click += CloseForm;
        }

        // Phương thức mở form trà sữa
        private void OpenTeaForm(Form teaForm)
        {
            try
            {
                // Thêm lớp phủ làm mờ form chính
                AddOverlay();

                // Sự kiện khi đóng form con sẽ gỡ lớp phủ
                teaForm.FormClosed += (s, e) =>
                {
                    RemoveOverlay();
                };

                // Sự kiện đóng form con để hiển thị lại form chính
                teaForm.FormClosed += (s, e) =>
                {
                    this.Enabled = true; // Bật lại form chính
                    this.BringToFront(); // Đưa form chính ra trước
                };

                // Nếu form con hỗ trợ sự kiện ProductSelected, đăng ký sự kiện này
                if (teaForm is IProductSelectable selectableForm)
                {
                    selectableForm.ProductSelected += AddProductToCart;
                }

                teaForm.Show();
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi nếu xảy ra
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
                RemoveOverlay(); // Gỡ lớp phủ nếu lỗi
            }
        }

        private Panel overlayPanel;

        private void AddOverlay()
        {
            // Tạo một lớp phủ
            overlayPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(50, 0, 0, 0), // Màu đen, alpha = 100 (bán trong suốt)
            };

            // Thêm lớp phủ lên form chính
            this.Controls.Add(overlayPanel);
            overlayPanel.BringToFront(); // Đưa lên trên cùng
        }

        private void RemoveOverlay()
        {
            if (overlayPanel != null)
            {
                this.Controls.Remove(overlayPanel); // Loại bỏ lớp phủ
                overlayPanel.Dispose(); // Giải phóng bộ nhớ
                overlayPanel = null;
            }
        }

        // Thêm sản phẩm vào giỏ hàng
        private void AddProductToCart(string productName, decimal totalPrice)
        {
            MessageBox.Show($"Đã thêm {productName} vào giỏ hàng với giá: {totalPrice:N0} VND", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Đóng form chính
        private void CloseForm(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
    }

    // Giao diện hỗ trợ sự kiện chọn sản phẩm
    public interface IProductSelectable
    {
        event Action<string, decimal> ProductSelected;
    }
}
