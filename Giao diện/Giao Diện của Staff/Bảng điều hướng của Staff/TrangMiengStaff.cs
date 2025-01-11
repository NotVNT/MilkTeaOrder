using OrderMillTeaProgram;
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
    public partial class TrangMiengStaff : Form
    {
        public Action<object, object> ProductSelected { get; internal set; }

        public TrangMiengStaff()
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

    public partial class TiramisuStaff : Form
    {
        protected int BasePrice;
        protected NumericUpDown numericQuantity;
        protected Label lblTotalPrice;
        protected Button btnAddToInventory;
        protected Button btnUpdateInventory;
        protected Button btnClose;
        protected Label lblTitle;
        protected Label lblSubtitle;
        protected PictureBox PictureBox;

        public TiramisuStaff()
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
            this.btnAddToInventory = new Button();
            this.btnUpdateInventory = new Button();
            this.btnClose = new Button();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.PictureBox = new PictureBox();

            // Setup các thành phần (ví dụ)
            this.numericQuantity.Location = new Point(50, 100);
            this.numericQuantity.ValueChanged += (s, e) => UpdateTotalPrice();

            this.lblTotalPrice.Location = new Point(50, 150);
            this.lblTotalPrice.Text = "Tổng giá trị nhập: 0 VND";

            this.btnAddToInventory.Location = new Point(50, 200);
            this.btnAddToInventory.Text = "Thêm vào kho";
            this.btnAddToInventory.Click += (s, e) => MessageBox.Show("Đã thêm vào kho hàng!");

            this.btnUpdateInventory.Location = new Point(200, 200);
            this.btnUpdateInventory.Text = "Cập nhật kho";
            this.btnUpdateInventory.Click += (s, e) => MessageBox.Show("Kho hàng đã được cập nhật!");

            this.Controls.Add(numericQuantity);
            this.Controls.Add(lblTotalPrice);
            this.Controls.Add(btnAddToInventory);
            this.Controls.Add(btnUpdateInventory);
        }

        private void InitializeEvents()
        {
            btnClose.Click += (s, e) => Close();
        }

        private void UpdateTotalPrice()
        {
            int quantity = (int)numericQuantity.Value;
            int totalPrice = quantity * BasePrice;
            lblTotalPrice.Text = $"Tổng giá trị nhập: {totalPrice} VND";
        }

        // Rest of the code...
    }

    public partial class BanhFlanStaff : TiramisuStaff
    {
        public BanhFlanStaff() : base()
        {
            BasePrice = 7000;
            lblTitle.Text = "Bánh Flan (Staff)";
            this.PictureBox.Image = Properties.Resources.banhflan;
        }
    }

    public partial class BanhPhoMaiStaff : TiramisuStaff
    {
        public BanhPhoMaiStaff() : base()
        {
            BasePrice = 15000;
            lblTitle.Text = "Bánh Phô Mai (Staff)";
            this.PictureBox.Image = Properties.Resources.cheesecake;
        }
    }

    public partial class CupCakeStaff : TiramisuStaff
    {
        public CupCakeStaff() : base()
        {
            BasePrice = 17000;
            lblTitle.Text = "CupCake (Staff)";
            this.PictureBox.Image = Properties.Resources.cupcake;
        }
    }
}
