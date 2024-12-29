using OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User.All_form_TS;
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
        public TraSuaUser()
        {
            InitializeComponent();
            InitializeEvents();
            this.Load += TraSuaUser_Load; // Đăng ký sự kiện Load
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
            picTSKhoaiMon.Click += (s, e) => OpenTeaForm(new TSKhoaiMon());
            lblTSKhoaiMon.Click += (s, e) => OpenTeaForm(new TSKhoaiMon());

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


        private void OpenTeaForm(Form teaForm)
        {
            try
            {
                this.Show(); // Ẩn form chính khi mở form con
                teaForm.FormClosed += (s, e) => this.Show();
                teaForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }

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
            // Kích hoạt thanh cuộn cho Panel
            panel1.AutoScroll = false; // Tắt AutoScroll để điều khiển thủ công

            // Cấu hình vScrollBar1
            VScrollBar1.Minimum = 0;
            VScrollBar1.Maximum = Math.Max(0, panel1.DisplayRectangle.Height - panel1.ClientSize.Height);
            VScrollBar1.LargeChange = panel1.ClientSize.Height;
            VScrollBar1.SmallChange = 20;

            // Cấu hình hScrollBar1
            HScrollBar1.Minimum = 0;
            HScrollBar1.Maximum = Math.Max(0, panel1.DisplayRectangle.Width - panel1.ClientSize.Width);
            HScrollBar1.LargeChange = panel1.ClientSize.Width;
            HScrollBar1.SmallChange = 20;
        }

        private void VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            // Thay đổi vị trí nội dung trong Panel theo giá trị vScrollBar
            panel1.VerticalScroll.Value = VScrollBar1.Value;
            panel1.PerformLayout(); // Cập nhật lại layout
        }

        private void HScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            // Thay đổi vị trí nội dung trong Panel theo giá trị hScrollBar
            panel1.HorizontalScroll.Value = HScrollBar1.Value;
            panel1.PerformLayout(); // Cập nhật lại layout
        }
    }

    public partial class HongTraTac : Form
    {
        private readonly int BasePrice = 25000;
        private NumericUpDown numericQuantity;
        private Label lblTotalPrice;
        private Button btnAddToCart;
        private Button btnClose;

        public HongTraTac()
        {
            InitializeComponent();
            InitializeEvents();
            UpdateTotalPrice();
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
            numericQuantity.ValueChanged += (s, e) => UpdateTotalPrice();
            btnAddToCart.Click += (s, e) => MessageBox.Show("Đã thêm vào giỏ hàng!");
            btnClose.Click += (s, e) => Close();
        }

        private void UpdateTotalPrice()
        {
            int quantity = (int)numericQuantity.Value;
            int totalPrice = quantity * BasePrice;
            lblTotalPrice.Text = $"Tổng tiền: {totalPrice} VND";
        }
    }

    public partial class TSTranChau : Form
    {
        private readonly int BasePrice = 30000;
        private NumericUpDown numericQuantity;
        private Label lblTotalPrice;
        private Button btnAddToCart;
        private Button btnClose;

        public TSTranChau()
        {
            InitializeComponent();
            InitializeEvents();
            UpdateTotalPrice();
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
            numericQuantity.ValueChanged += (s, e) => UpdateTotalPrice();
            btnAddToCart.Click += (s, e) => MessageBox.Show("Đã thêm vào giỏ hàng!");
            btnClose.Click += (s, e) => Close();
        }

        private void UpdateTotalPrice()
        {
            int quantity = (int)numericQuantity.Value;
            int totalPrice = quantity * BasePrice;
            lblTotalPrice.Text = $"Tổng tiền: {totalPrice} VND";
        }
    }

    public partial class TSKhoaiMon : Form
    {
        private readonly int BasePrice = 28000;
        private NumericUpDown numericQuantity;
        private Label lblTotalPrice;
        private Button btnAddToCart;
        private Button btnClose;

        public TSKhoaiMon()
        {
            InitializeComponent();
            InitializeEvents();
            UpdateTotalPrice();
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
            numericQuantity.ValueChanged += (s, e) => UpdateTotalPrice();
            btnAddToCart.Click += (s, e) => MessageBox.Show("Đã thêm vào giỏ hàng!");
            btnClose.Click += (s, e) => Close();
        }

        private void UpdateTotalPrice()
        {
            int quantity = (int)numericQuantity.Value;
            int totalPrice = quantity * BasePrice;
            lblTotalPrice.Text = $"Tổng tiền: {totalPrice} VND";
        }
    }
}
