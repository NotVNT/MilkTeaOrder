using MailChimp.Net.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using static OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User.DashboardStaff;

namespace OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User.All_form_TS
{
    public partial class Hongtratac : Form
    {
        private const int BasePrice = 25000; // Giá cơ bản của sản phẩm

        // Event khi sản phẩm được chọn
        public event Action<string, decimal> ProductSelected;

        // Dictionary lưu trữ thông tin topping và giá cả
        private readonly Dictionary<string, (int Quantity, int Price)> toppings = new Dictionary<string, (int Quantity, int Price)>();
        private readonly Dictionary<string, int> sizePrices = new Dictionary<string, int>();

        // Biến trạng thái để ngăn chặn các sự kiện lặp
        private bool isHandlingItemCheck = false;

        // Menu chuột phải để điều chỉnh số lượng topping
        private ContextMenuStrip toppingContextMenu;

        // Đối tượng giỏ hàng chia sẻ giữa các form
        public DashboardStaff.Cart SharedCart { get; private set; }

        public Hongtratac(DashboardStaff.Cart sharedCart)
        {
            SharedCart = sharedCart ?? throw new ArgumentNullException(nameof(sharedCart));
            InitializeComponent();
            LoadFormData();
            InitializeContextMenu();
            InitializeEvents();
        }

        public Hongtratac() : this(new DashboardStaff.Cart())
        {
        }

        private void LoadFormData()
        {
            try
            {
                // Cấu hình topping và giá cả
                toppings["Hạt thủy tinh"] = (1, 3000);
                toppings["Phô mai jelly"] = (1, 4000);
                toppings["Trân châu đường đen"] = (1, 3000);
                toppings["Thạch đào"] = (1, 2000);
                toppings["Thạch dừa"] = (1, 2000);
                toppings["Pudding dưa lưới"] = (1, 5000);

                // Cấu hình giá size
                sizePrices["S"] = 0;
                sizePrices["M"] = 7000;
                sizePrices["L"] = 15000;

                // Hiển thị topping ban đầu
                RefreshToppingDisplay();

                // Thêm các lựa chọn size, đường, đá
                clbSize.Items.AddRange(new[] { "S", "M (+7.000 vnd)", "L (+15.000 vnd)" });
                clbDuong.Items.AddRange(new[] { "0% Đường", "30% Đường", "50% Đường", "70% Đường", "100% Đường" });
                clbDa.Items.AddRange(new[] { "0% Đá", "30% Đá", "50% Đá", "70% Đá", "100% Đá" });

                numericQuantity.Value = 1;
                UpdateTotalPrice();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong LoadFormData: {ex.Message}");
            }
        }

        private void InitializeContextMenu()
        {
            // Tạo menu ngữ cảnh để tăng giảm số lượng topping
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
            // Xử lý chuột phải trên danh sách topping
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

            // Liên kết các sự kiện cập nhật giá
            clbSize.ItemCheck += (s, e) => BeginInvoke((Action)UpdateTotalPrice);
            clbSize.ItemCheck += SingleSelectionCheck;
            clbDuong.ItemCheck += SingleSelectionCheck;
            clbDa.ItemCheck += SingleSelectionCheck;
            numericQuantity.ValueChanged += (s, e) => UpdateTotalPrice();

            // Liên kết sự kiện nút bấm
            btnDatMon.Click += PlaceOrder;
            btnAddToCart.Click += BtnAddToCart_Click;
            btnExit.Click += BtnExit_Click;
        }

        private void UpdateTotalPrice()
        {
            try
            {
                int totalPrice = BasePrice;

                // Tính giá topping
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

                // Tính giá size
                if (clbSize.CheckedItems.Count > 0)
                {
                    string selectedItem = clbSize.CheckedItems[0].ToString();
                    if (sizePrices.ContainsKey(selectedItem))
                    {
                        totalPrice += sizePrices[selectedItem];
                    }
                }

                // Nhân số lượng
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
            Close();
        }

        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                string toppingsText = string.Join(", ", toppings.Where(t =>
                    clbTopping.CheckedItems.Contains($"{t.Key} x{t.Value.Quantity}"))
                    .Select(t => $"{t.Key} x{t.Value.Quantity}"));

                string size = clbSize.CheckedItems.Count > 0 ? clbSize.CheckedItems[0].ToString() : "S";
                int quantity = (int)numericQuantity.Value;

                UpdateTotalPrice();

                string totalPriceText = lbBasePrice.Text.Replace("Tổng giá: ", "").Replace(" VNĐ", "").Replace(",", "");
                if (!decimal.TryParse(totalPriceText, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal totalPrice))
                {
                    throw new FormatException("Giá tổng không hợp lệ.");
                }

                string productName = $"Hồng trà tắc - {size} ({toppingsText})";
                decimal unitPrice = totalPrice / quantity;
                SharedCart.AddItem(productName, quantity, unitPrice);

                // Trigger the ProductSelected event
                ProductSelected?.Invoke(productName, totalPrice);

                MessageBox.Show($"Sản phẩm đã được thêm vào giỏ hàng:\n" +
                                $"Tên: {productName}\n" +
                                $"Size: {size}\n" +
                                $"Topping: {toppingsText}\n" +
                                $"Số lượng: {quantity}\n" +
                                $"{lbBasePrice.Text}",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                ((DashboardStaff)this.MdiParent)?.UpdateCartView();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm vào giỏ hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
