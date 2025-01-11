using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User.All_form_tráng_miệng
{
    public partial class Tiramisu : Form
    {
        protected const int BasePrice = 8000; // Giá cơ bản của bánh Tiramisu

        // Dictionary lưu topping và giá cả
        private readonly Dictionary<string, (int Quantity, int Price)> toppings = new Dictionary<string, (int Quantity, int Price)>();

        private ContextMenuStrip toppingContextMenu;

        public Tiramisu(DashboardStaff dashboardStaff)
        {
            InitializeComponent();
            LoadFormData();
            InitializeContextMenu();
            InitializeEvents();
            UpdateTotalPrice();
        }

        private void LoadFormData()
        {
            try
            {
                // Cấu hình topping và giá cả dành riêng cho bánh Tiramisu
                toppings["Bột cacao"] = (1, 3000);
                toppings["Kem tươi"] = (1, 4000);
                toppings["Hạt điều"] = (1, 2500);

                // Hiển thị topping ban đầu
                RefreshToppingDisplay();

                numericQuantity.Value = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeContextMenu()
        {
            toppingContextMenu = new ContextMenuStrip();
            toppingContextMenu.Items.Add("Tăng số lượng", null, (s, e) => AdjustToppingQuantity(1));
            toppingContextMenu.Items.Add("Giảm số lượng", null, (s, e) => AdjustToppingQuantity(-1));
        }

        private void AdjustToppingQuantity(int adjustment)
        {
            if (clbTopping.SelectedIndex >= 0)
            {
                string selectedItem = clbTopping.SelectedItem.ToString().Split('x')[0].Trim();
                if (toppings.ContainsKey(selectedItem))
                {
                    var (Quantity, Price) = toppings[selectedItem];
                    toppings[selectedItem] = (Math.Max(1, Quantity + adjustment), Price);
                    RefreshToppingDisplay();
                    UpdateTotalPrice();
                }
            }
        }

        private void RefreshToppingDisplay()
        {
            var checkedIndices = clbTopping.CheckedIndices.Cast<int>().ToList();
            clbTopping.Items.Clear();

            foreach (var topping in toppings)
            {
                clbTopping.Items.Add($"{topping.Key} x{topping.Value.Quantity}");
            }

            foreach (var index in checkedIndices)
            {
                if (index < clbTopping.Items.Count)
                {
                    clbTopping.SetItemCheckState(index, CheckState.Checked);
                }
            }
        }

        private void InitializeEvents()
        {
            clbTopping.MouseUp += (s, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    int index = clbTopping.IndexFromPoint(e.Location);
                    if (index != ListBox.NoMatches)
                    {
                        clbTopping.SelectedIndex = index;
                        toppingContextMenu.Show(clbTopping, e.Location);
                    }
                }
            };

            numericQuantity.ValueChanged += (s, e) => UpdateTotalPrice();
            btnAddToCart.Click += AddToCart;
            btnPlaceOrder.Click += PlaceOrder;
            btnClose.Click += CloseForm;
        }

        private void UpdateTotalPrice()
        {
            try
            {
                int totalPrice = BasePrice;

                foreach (var topping in toppings)
                {
                    string toppingName = topping.Key;
                    int quantity = topping.Value.Quantity;

                    int index = clbTopping.Items.IndexOf($"{toppingName} x{quantity}");
                    if (index >= 0 && clbTopping.GetItemCheckState(index) == CheckState.Checked)
                    {
                        totalPrice += topping.Value.Price * quantity;
                    }
                }

                totalPrice *= (int)numericQuantity.Value;

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

            string toppingsText = string.Join(", ", toppings.Where(t =>
                clbTopping.CheckedItems.Contains($"{t.Key} x{t.Value.Quantity}"))
                .Select(t => $"{t.Key} x{t.Value.Quantity}"));

            string totalPrice = lblTotalPrice.Text;

            MessageBox.Show($"Thêm vào giỏ hàng:\nBánh Tiramisu\nSố lượng: {quantity}\nTopping: {toppingsText}\n{totalPrice}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PlaceOrder(object sender, EventArgs e)
        {
            int quantity = (int)numericQuantity.Value;

            if (quantity <= 0)
            {
                MessageBox.Show("Vui lòng chọn số lượng hợp lệ để đặt món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string toppingsText = string.Join(", ", toppings.Where(t =>
                clbTopping.CheckedItems.Contains($"{t.Key} x{t.Value.Quantity}"))
                .Select(t => $"{t.Key} x{t.Value.Quantity}"));

            string totalPrice = lblTotalPrice.Text;

            MessageBox.Show($"Đặt món thành công:\nBánh Tiramisu\nSố lượng: {quantity}\nTopping: {toppingsText}\n{totalPrice}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CloseForm(object sender, EventArgs e)
        {
            Close();
        }
    }
}
