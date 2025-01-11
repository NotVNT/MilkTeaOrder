using OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User;
using OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User.All_form_tráng_miệng;
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
    public partial class TrangMiengUser : Form
    {
        public Action<object, object> ProductSelected { get; internal set; }

        public TrangMiengUser()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            // Sự kiện mở form Bánh Flan
            picBanhFlan.Click += (s, e) => OpenDessertForm(new BanhFlan(new DashboardStaff()));
            lblBanhFlan.Click += (s, e) => OpenDessertForm(new BanhFlan(new DashboardStaff()));

            // Sự kiện mở form Tiramisu
            picBanhTiramisu.Click += (s, e) => OpenDessertForm(new Tiramisu(new DashboardStaff()));
            lblBanhTiramisu.Click += (s, e) => OpenDessertForm(new Tiramisu(new DashboardStaff()));

            // Sự kiện mở form Bánh Phô Mai
            picBanhPhoMai.Click += (s, e) => OpenDessertForm(new CheeseCake(new DashboardStaff()));
            lblBanhPhoMai.Click += (s, e) => OpenDessertForm(new CheeseCake(new DashboardStaff()));

            // Sự kiện mở form CupCake
            picCupCake.Click += (s, e) => OpenDessertForm(new CupCake(new DashboardStaff()));
            lblCupCake.Click += (s, e) => OpenDessertForm(new CupCake(new DashboardStaff()));

            // Sự kiện đóng form
            btnClose.Click += CloseForm;
        }

        private void OpenDessertForm(Form dessertForm)
        {
            try
            {
                this.Show(); // Ẩn form chính khi mở form con
                dessertForm.FormClosed += (s, e) => this.Show();
                dessertForm.Show();
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
    }

    public partial class TiramisuOrder : Form
    {
        protected int BasePrice;
        protected NumericUpDown numericQuantity;
        protected Label lblTotalPrice;
        protected Button btnAddToCart;
        protected Button btnPlaceOrder;
        protected Button btnClose;
        protected Label lblTitle;
        protected Label lblSubtitle;
        protected PictureBox PictureBox;

        public TiramisuOrder()
        {
            BasePrice = 18000;
            InitializeComponent();
            InitializeEvents();
            UpdateTotalPrice();
        }

        private void InitializeComponent()
        {
            this.numericQuantity = new NumericUpDown();
            this.lblTotalPrice = new Label();
            this.btnAddToCart = new Button();
            this.btnPlaceOrder = new Button();
            this.btnClose = new Button();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.PictureBox = new PictureBox();

            // Setup các thành phần (ví dụ)
            this.numericQuantity.Location = new Point(50, 100);
            this.numericQuantity.ValueChanged += (s, e) => UpdateTotalPrice();

            this.lblTotalPrice.Location = new Point(50, 150);
            this.lblTotalPrice.Text = "Tổng tiền: 0 VND";

            this.btnAddToCart.Location = new Point(50, 200);
            this.btnAddToCart.Text = "Thêm vào giỏ hàng";
            this.btnAddToCart.Click += (s, e) => MessageBox.Show("Đã thêm vào giỏ hàng!");

            this.Controls.Add(numericQuantity);
            this.Controls.Add(lblTotalPrice);
            this.Controls.Add(btnAddToCart);
        }

        private void InitializeEvents()
        {
            btnClose.Click += (s, e) => Close();
            // btnAddToCart đã được thêm sự kiện ở InitializeComponent, không cần thêm lại
        }

        private void UpdateTotalPrice()
        {
            int quantity = (int)numericQuantity.Value;
            int totalPrice = quantity * BasePrice;
            lblTotalPrice.Text = $"Tổng tiền: {totalPrice} VND";
        }

        // Rest of the code...
    }

    public partial class BanhFlanOrder : TiramisuOrder
    {
        public BanhFlanOrder() : base()
        {
            BasePrice = 7000;
            lblTitle.Text = "Bánh Flan";
            this.PictureBox.Image = Properties.Resources.banhflan;
        }
    }

    public partial class BanhPhoMaiOrder : TiramisuOrder
    {
        public BanhPhoMaiOrder() : base()
        {
            BasePrice = 15000;
            lblTitle.Text = "Bánh Phô Mai";
            this.PictureBox.Image = Properties.Resources.cheesecake;
        }
    }

    public partial class CupCake : TiramisuOrder
    {
        public CupCake(Giao_diện.Giao_Diện_của_User.DashboardStaff dashboardStaff) : base()
        {
            BasePrice = 17000;
            lblTitle.Text = "CupCake";
            this.PictureBox.Image = Properties.Resources.cupcake;
        }
    }
}