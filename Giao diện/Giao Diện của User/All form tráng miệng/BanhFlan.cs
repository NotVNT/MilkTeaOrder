using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User.All_form_tráng_miệng
{
    public partial class BanhFlan : Form
    {
        protected const int BasePrice = 7000;

        // Dictionary lưu topping và giá cả
        private readonly Dictionary<string, (int Quantity, int Price)> toppings = new Dictionary<string, (int Quantity, int Price)>();

        private ContextMenuStrip toppingContextMenu;

        private readonly DashboardStaff parentForm; // Tham chiếu tới form cha

        public BanhFlan(DashboardStaff parent)
        {
            InitializeComponent();
            this.parentForm = parent; // Gán form cha vào biến
            LoadFormData();
            InitializeContextMenu();
            InitializeEvents();
            UpdateTotalPrice();
        }

        private void LoadFormData()
        {
            try
            {
                // Cấu hình topping và giá cả
                toppings["Caramel"] = (1, 2000);
                toppings["Dừa nạo"] = (1, 1500);
                toppings["Đậu phộng"] = (1, 1000);

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
                string selectedToppingKey = clbTopping.SelectedItem.ToString().Split('x')[0].Trim();
                if (toppings.ContainsKey(selectedToppingKey))
                {
                    var (Quantity, Price) = toppings[selectedToppingKey];
                    toppings[selectedToppingKey] = (Math.Max(1, Quantity + adjustment), Price);
                    RefreshToppingItem(selectedToppingKey);
                    UpdateTotalPrice();
                }
            }
        }

        private void RefreshToppingDisplay()
        {
            clbTopping.Items.Clear();

            foreach (var topping in toppings)
            {
                clbTopping.Items.Add($"{topping.Key} x{topping.Value.Quantity}");
            }
        }

        private void RefreshToppingItem(string toppingKey)
        {
            if (toppings.TryGetValue(toppingKey, out var value))
            {
                for (int i = 0; i < clbTopping.Items.Count; i++)
                {
                    if (clbTopping.Items[i].ToString().StartsWith(toppingKey))
                    {
                        clbTopping.Items[i] = $"{toppingKey} x{value.Quantity}";
                        break;
                    }
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

                lblTotalPrice.Text = string.Format(CultureInfo.GetCultureInfo("vi-VN"), "Tổng giá: {0:C0}", totalPrice);
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

            if (parentForm != null)
            {
                // Thêm sản phẩm vào ListViewCart
                ListViewItem item = new ListViewItem("Bánh Flan");
                item.SubItems.Add(quantity.ToString());
                item.SubItems.Add(toppingsText);
                item.SubItems.Add(totalPrice);

                parentForm.listViewCart_SelectedIndexChanged.Items.Add(item); // Sửa lỗi: Sử dụng thuộc tính ListViewCart
            }

            MessageBox.Show(
                $"Thêm vào giỏ hàng:\nBánh Flan\nSố lượng: {quantity}\nTopping: {toppingsText}\n{totalPrice}",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
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

            MessageBox.Show($"Đặt món thành công:\nBánh Flan\nSố lượng: {quantity}\nTopping: {toppingsText}\n{totalPrice}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}