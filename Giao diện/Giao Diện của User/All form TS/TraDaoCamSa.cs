using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User.All_form_TS
{
    public partial class TraDaoCamSa : Form
    {
        private const int BasePrice = 25000;
        public event Action<string, decimal> ProductSelected; // Sự kiện gửi dữ liệu về form chính
        private readonly Dictionary<string, int> toppingQuantities = new Dictionary<string, int>();
        private readonly Dictionary<string, int> toppingPrices = new Dictionary<string, int>();
        private readonly Dictionary<string, int> sizePrices = new Dictionary<string, int>();
        private bool isHandlingItemCheck = false;
        private ContextMenuStrip toppingContextMenu;

        public TraDaoCamSa()
        {
            InitializeComponent();
            LoadFormData();
            InitializeContextMenu();
            InitializeEvents();
        }

        private void LoadFormData()
        {
            toppingQuantities["Hạt thủy tinh (+3.000 vnd)"] = 1;
            toppingPrices["Hạt thủy tinh (+3.000 vnd)"] = 3000;

            toppingQuantities["Phô mai jelly (+4.000 vnd)"] = 1;
            toppingPrices["Phô mai jelly (+4.000 vnd)"] = 4000;

            toppingQuantities["Trân châu đường đen (+3.000 vnd)"] = 1;
            toppingPrices["Trân châu đường đen (+3.000 vnd)"] = 3000;

            toppingQuantities["Thạch đào (+2.000 vnd)"] = 1;
            toppingPrices["Thạch đào (+2.000 vnd)"] = 2000;

            toppingQuantities["Thạch dừa (+2.000 vnd)"] = 1;
            toppingPrices["Thạch dừa (+2.000 vnd)"] = 2000;

            toppingQuantities["Pudding dưa lưới (+5.000 vnd)"] = 1;
            toppingPrices["Pudding dưa lưới (+5.000 vnd)"] = 5000;

            sizePrices["S"] = 0;
            sizePrices["M (+7.000 vnd)"] = 7000;
            sizePrices["L (+15.000 vnd)"] = 15000;

            RefreshToppingDisplay();

            clbSize.Items.Add("S");
            clbSize.Items.Add("M (+7.000 vnd)");
            clbSize.Items.Add("L (+15.000 vnd)");

            clbDuong.Items.Add("0% Đường");
            clbDuong.Items.Add("30% Đường");
            clbDuong.Items.Add("50% Đường");
            clbDuong.Items.Add("70% Đường");
            clbDuong.Items.Add("100% Đường");

            clbDa.Items.Add("0% Đá");
            clbDa.Items.Add("30% Đá");
            clbDa.Items.Add("50% Đá");
            clbDa.Items.Add("70% Đá");
            clbDa.Items.Add("100% Đá");

            numericQuantity.Value = 1;
            UpdateTotalPrice();
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
                if (toppingQuantities.ContainsKey(selectedItem))
                {
                    toppingQuantities[selectedItem] = Math.Max(1, toppingQuantities[selectedItem] + adjustment);
                    RefreshToppingDisplay();
                    UpdateTotalPrice();
                }
            }
        }

        private void RefreshToppingDisplay()
        {
            var checkedIndices = clbTopping.CheckedIndices.Cast<int>().ToList();
            clbTopping.Items.Clear();

            foreach (var topping in toppingQuantities)
            {
                clbTopping.Items.Add($"{topping.Key} x{topping.Value}");
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

            clbSize.ItemCheck += (s, e) => BeginInvoke((Action)UpdateTotalPrice);
            clbSize.ItemCheck += SingleSelectionCheck;
            clbDuong.ItemCheck += SingleSelectionCheck;
            clbDa.ItemCheck += SingleSelectionCheck;
            numericQuantity.ValueChanged += (s, e) => UpdateTotalPrice();
            btnDatMon.Click += PlaceOrder;
            btnExit.Click += BtnExit_Click;
        }

        private void UpdateTotalPrice()
        {
            try
            {
                int totalPrice = BasePrice;

                foreach (var topping in toppingQuantities)
                {
                    string toppingName = topping.Key;
                    int quantity = topping.Value;

                    int index = clbTopping.Items.IndexOf($"{toppingName} x{quantity}");
                    if (index >= 0 && clbTopping.GetItemCheckState(index) == CheckState.Checked)
                    {
                        totalPrice += toppingPrices[toppingName] * quantity;
                    }
                }

                if (clbSize.CheckedItems.Count > 0)
                {
                    string selectedItem = clbSize.CheckedItems[0].ToString();
                    totalPrice += sizePrices[selectedItem];
                }

                totalPrice *= (int)numericQuantity.Value;

                lbBasePrice.Text = $"Tổng giá: {totalPrice:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật tổng giá: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SingleSelectionCheck(object sender, ItemCheckEventArgs e)
        {
            if (isHandlingItemCheck) return;
            isHandlingItemCheck = true;

            if (sender is CheckedListBox listBox)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    foreach (int index in listBox.CheckedIndices)
                    {
                        if (index != e.Index)
                        {
                            listBox.SetItemCheckState(index, CheckState.Unchecked);
                        }
                    }
                }
            }

            isHandlingItemCheck = false;
        }

        private void PlaceOrder(object sender, EventArgs e)
        {
            MessageBox.Show("Đặt món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {

            {
                Close();
            }
        }

        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                string toppings = string.Join(", ", toppingQuantities.Where(t =>
                    clbTopping.CheckedItems.Contains($"{t.Key} x{t.Value}"))
                    .Select(t => $"{t.Key} x{t.Value}"));

                string size = clbSize.CheckedItems.Count > 0 ? clbSize.CheckedItems[0].ToString() : "S";
                int quantity = (int)numericQuantity.Value;

                UpdateTotalPrice();
                string totalPriceText = lbBasePrice.Text.Replace("Tổng giá: ", "").Replace(" VNĐ", "").Replace(",", "");
                decimal totalPrice = decimal.Parse(totalPriceText);

                ProductSelected?.Invoke($"Trà Đào Cam Sả - {size} ({toppings})", totalPrice);

                MessageBox.Show($"Sản phẩm đã được thêm vào giỏ hàng:\n" +
                                $"Size: {size}\n" +
                                $"Topping: {toppings}\n" +
                                $"Số lượng: {quantity}\n" +
                                $"{lbBasePrice.Text}",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm vào giỏ hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
