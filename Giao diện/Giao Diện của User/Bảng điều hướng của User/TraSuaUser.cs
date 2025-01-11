using OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User;
using OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User.All_form_TS;
using OrderMillTeaProgram.Giao_diện_của_User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderMillTeaProgram
{
    public partial class TraSuaUser : Form
    {
        public Action<object, ProductSelectedEventArgs> ProductSelected { get; internal set; }

        public TraSuaUser()
        {
            InitializeComponent();
            InitializeEvents();
            this.Load += TraSuaUser_Load; // Đăng ký sự kiện Load
        }

        private void InitializeEvents()
        {
            // Sự kiện mở form Hồng Trà Tắc
            picHongTraTac.Click += (s, e) => OpenTeaForm(new Giao_diện.Giao_Diện_của_User.All_form_TS.Hongtratac());
            lblHongTraTac.Click += (s, e) => OpenTeaForm(new Giao_diện.Giao_Diện_của_User.All_form_TS.Hongtratac());

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

        private void TraSuaUser_Load(object sender, EventArgs e)
        {
            // Cấu hình thanh cuộn theo kích thước nội dung Panel
            panel1.AutoScroll = false;

            VScrollBar1.Minimum = 0;
            VScrollBar1.Maximum = Math.Max(0, panel1.DisplayRectangle.Height - panel1.ClientSize.Height);
            VScrollBar1.LargeChange = panel1.ClientSize.Height;
            VScrollBar1.SmallChange = 20;

            HScrollBar1.Minimum = 0;
            HScrollBar1.Maximum = Math.Max(0, panel1.DisplayRectangle.Width - panel1.ClientSize.Width);
            HScrollBar1.LargeChange = panel1.ClientSize.Width;
            HScrollBar1.SmallChange = 20;
        }

        private void VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            // Cập nhật vị trí cuộn dọc của Panel
            panel1.VerticalScroll.Value = VScrollBar1.Value;
            panel1.PerformLayout();
        }

        private void HScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            // Cập nhật vị trí cuộn ngang của Panel
            panel1.HorizontalScroll.Value = HScrollBar1.Value;
            panel1.PerformLayout();
        }
    }

    // Giao diện hỗ trợ sự kiện chọn sản phẩm
    public interface IProductSelectable
    {
        event Action<string, decimal> ProductSelected;
    }

    public partial class HongTraTac : Form, IProductSelectable
    {
        private readonly int BasePrice = 25000; // Giá cơ bản của sản phẩm
        private NumericUpDown numericQuantity; // Điều chỉnh số lượng
        private Label lblTotalPrice; // Hiển thị tổng giá tiền
        private Button btnAddToCart; // Nút thêm vào giỏ hàng
        private Button btnClose; // Nút đóng form
        private DashboardStaff.Cart sharedCart;

        public event Action<string, decimal> ProductSelected; // Sự kiện chọn sản phẩm

        public HongTraTac(MailChimp.Net.Models.Cart sharedCart)
        {
            if (sharedCart is null)
            {
                throw new ArgumentNullException(nameof(sharedCart));
            }

            InitializeComponent();
            InitializeEvents();
            UpdateTotalPrice();
        }

        public HongTraTac(DashboardStaff.Cart sharedCart)
        {
            this.sharedCart = sharedCart;
        }

        private void InitializeComponent()
        {
            numericQuantity = new NumericUpDown();
            lblTotalPrice = new Label();
            btnAddToCart = new Button();
            btnClose = new Button();

            numericQuantity.Location = new Point(50, 50);
            lblTotalPrice.Location = new Point(50, 100);
            lblTotalPrice.Text = "Tổng tiền: 0 VND";

            btnAddToCart.Location = new Point(50, 150);
            btnAddToCart.Text = "Thêm vào giỏ hàng";

            btnClose.Location = new Point(150, 150);
            btnClose.Text = "Đóng";

            Controls.Add(numericQuantity);
            Controls.Add(lblTotalPrice);
            Controls.Add(btnAddToCart);
            Controls.Add(btnClose);
        }

        private void InitializeEvents()
        {
            numericQuantity.ValueChanged += (s, e) => UpdateTotalPrice(); // Cập nhật giá khi thay đổi số lượng

            btnAddToCart.Click += (s, e) =>
            {
                int quantity = (int)numericQuantity.Value;
                decimal totalPrice = quantity * BasePrice;

                // Kích hoạt sự kiện ProductSelected khi thêm vào giỏ hàng
                ProductSelected?.Invoke("Hồng Trà Tắc", totalPrice);
                Close(); // Đóng form sau khi thêm
            };

            btnClose.Click += (s, e) => Close(); // Đóng form khi nhấn nút đóng
        }

        private void UpdateTotalPrice()
        {
            int quantity = (int)numericQuantity.Value;
            decimal totalPrice = quantity * BasePrice;
            lblTotalPrice.Text = $"Tổng tiền: {totalPrice:N0} VND"; // Hiển thị giá tiền cập nhật
        }
    }
}
