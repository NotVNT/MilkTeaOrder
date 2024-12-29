using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User.All_form_tráng_miệng
{
    public partial class Tiramisu : Form
    {
        protected const int BasePrice = 7000;

        public Tiramisu()
        {
            InitializeComponent();
            InitializeEvents();
            UpdateTotalPrice();
        }

        private void InitializeEvents()
        {
            numericQuantity.ValueChanged += (s, e) => UpdateTotalPrice();
            btnAddToCart.Click += AddToCart;
            btnPlaceOrder.Click += PlaceOrder;
            btnClose.Click += CloseForm;
        }

        private void UpdateTotalPrice()
        {
            try
            {
                int quantity = (int)numericQuantity.Value;
                int totalPrice = BasePrice * quantity;

                lblTotalPrice.Text = $"Tổng giá: {totalPrice:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật tổng giá: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToCart(object sender, EventArgs e)
        {
            int quantity = (int)numericQuantity.Value;

            if (quantity <= 0)
            {
                MessageBox.Show("Vui lòng chọn số lượng hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string totalPrice = lblTotalPrice.Text;

            MessageBox.Show($"Thêm vào giỏ hàng:\nSố lượng: {quantity}\n{totalPrice}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PlaceOrder(object sender, EventArgs e)
        {
            int quantity = (int)numericQuantity.Value;

            if (quantity <= 0)
            {
                MessageBox.Show("Vui lòng chọn số lượng hợp lệ để đặt món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string totalPrice = lblTotalPrice.Text;

            MessageBox.Show($"Đặt món thành công:\nSố lượng: {quantity}\n{totalPrice}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
}
