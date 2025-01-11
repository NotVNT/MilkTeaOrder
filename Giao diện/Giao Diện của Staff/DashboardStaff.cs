using MailChimp.Net.Models;
using OrderMillTeaProgram.Giao_diện.Giao_Diện_của_Admin;
using OrderMillTeaProgram.Giao_diện_của_User;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User.DashboardStaff;

namespace OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User
{
    public partial class DashboardStaff : Form
    {
        private readonly Cart sharedCart;
        private Button btnCheckout;
        private Label lblTotalPrice;

        // Các biến cho menu và sidebar
        private readonly Timer MenuTransition = new Timer();
        private readonly Timer SidebarTransition = new Timer();
        private readonly Panel MenuContainer;
        private readonly Panel Sidebar;
        private readonly bool MenuExpand = false;
        private bool sidebarExpand = true;

        public DashboardStaff(Cart cart)
        {
            sharedCart = cart ?? throw new ArgumentNullException(nameof(Cart));
            InitializeComponent();
            InitializeCustomComponents();
            InitializeMenuSidebar();
            UpdateCartView();

            // Thêm ListViewCart vào Form
            listViewCart = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                Dock = DockStyle.Bottom,  // Đặt ở cuối form
                Height = 200  // Chiều cao của ListView
            };
            Controls.Add(listViewCart);

            // Cấu hình cột cho ListView
            listViewCart.Columns.Add("Tên Món", 150);
            listViewCart.Columns.Add("Size", 100);
            listViewCart.Columns.Add("Topping", 150);
            listViewCart.Columns.Add("Số Lượng", 100);
            listViewCart.Columns.Add("Đơn Giá", 100);
            listViewCart.Columns.Add("Tổng Giá", 100);
            listViewCart.Columns.Add("Hình Ảnh", 80);

            // Gán sự kiện cho các mục được chọn trong listViewCart
            listViewCart.SelectedIndexChanged += listViewCart_SelectedIndexChanged;
            listViewCart.DrawSubItem += ListView_DrawSubItem;
        }


        public DashboardStaff() : this(new Cart())
        {
        }

        private void InitializeCustomComponents()
        {
            // Tạo nút Thanh Toán
            btnCheckout = new Button
            {
                Text = "Thanh Toán",
                Location = new Point(10, 10),
                Size = new Size(100, 30)
            };

            // Tạo Label hiển thị tổng giá
            lblTotalPrice = new Label
            {
                Text = "Tổng giá: 0 VNĐ",
                Location = new Point(120, 10),
                Size = new Size(200, 30),
                TextAlign = ContentAlignment.MiddleRight
            };

            // Thêm các điều khiển vào Form
            this.Controls.Add(btnCheckout);
            this.Controls.Add(lblTotalPrice);

            // Gán sự kiện cho các nút
            btnCheckout.Click += BtnCheckout_Click;

            // Cấu hình Form
            this.Text = "Dashboard Staff";
            this.Size = new Size(650, 400);
        }

        private void InitializeMenuSidebar()
        {
            menuContainer = new FlowLayoutPanel
            {
                Location = new Point(0, 0),
                Size = new Size(220, 46),
                BackColor = Color.LightGray
            };
            this.Controls.Add(menuContainer);

            sidebar = new FlowLayoutPanel
            {
                Location = new Point(0, 46),
                Size = new Size(220, this.ClientSize.Height - 46),
                BackColor = Color.DarkGray
            };
            this.Controls.Add(sidebar);

            menuTransition.Interval = 10;
            menuTransition.Tick += MenuTransition_Tick;

            sidebarTransition.Interval = 10;
            sidebarTransition.Tick += SidebarTransition_Tick;
        }

        private void MenuTransition_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                menuContainer.Height += 10;
                if (menuContainer.Height >= 187)
                {
                    menuTransition.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                menuContainer.Height -= 10;
                if (menuContainer.Height <= 46)
                {
                    menuTransition.Stop();
                    menuExpand = false;
                }
            }
        }

        private void SidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 5;
                if (sidebar.Width <= 54)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                }
            }
            else
            {
                sidebar.Width += 5;
                if (sidebar.Width >= 220)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();
                }
            }
        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            if (sharedCart.Items.Any())
            {
                // Logic thanh toán
                MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sharedCart.Clear();
                UpdateCartView();
            }
            else
            {
                MessageBox.Show("Giỏ hàng trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Sidebarclick_Click(object sender, EventArgs e)
        {
            // Logic xử lý khi nút sidebar được click
            sidebarTransition.Start(); // Khởi động hiệu ứng chuyển đổi sidebar
        }
        private void BtnDashboard_Click(object sender, EventArgs e)
        {             // Logic xử lý khi nút Dashboard được click
            MessageBox.Show("Dashboard", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void BtnDanhMuc_Click(object sender, EventArgs e)
        {
            menuTransition.Start();
        }

        private void btnTraSua_Click(object sender, EventArgs e)
        {
            var traSuaForm = new TraSuaStaff(); // Giả sử bạn đã tạo form TraSuaStaff
            traSuaForm.Show();
        }

        private void btnTrangMieng_Click(object sender, EventArgs e)
        {
            var trangMiengForm = new TrangMiengStaff(); // Giả sử bạn đã tạo form TrangMiengStaff
            trangMiengForm.Show();
        }

        public void UpdateCartView()
        {
            listViewCart.Items.Clear();  // Xóa tất cả các mục cũ trong listView
            decimal totalCartPrice = 0;

            foreach (var item in sharedCart.Items)
            {
                var listViewItem = new ListViewItem
                {
                    Tag = item,
                    Text = "" // Hình ảnh sẽ được vẽ ở đây
                };
                listViewItem.SubItems.Add(item.ProductName);
                listViewItem.SubItems.Add(item.Size);
                listViewItem.SubItems.Add(item.Toppings);
                listViewItem.SubItems.Add(item.Quantity.ToString());
                listViewItem.SubItems.Add($"{item.UnitPrice:N0} VNĐ");
                listViewItem.SubItems.Add($"{item.TotalPrice:N0} VNĐ");

                listViewCart.Items.Add(listViewItem);
                totalCartPrice += item.TotalPrice;  // Cộng tổng giá các mặt hàng
            }

            lblTotalPrice.Text = $"Tổng giá: {totalCartPrice:N0} VNĐ";  // Cập nhật tổng giá
            btnCheckout.Enabled = sharedCart.Items.Any();  // Kiểm tra nếu giỏ hàng có sản phẩm
        }

        private void ListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex == 0) // Cột hình ảnh
            {
                var item = e.Item.Tag as CartItem;
                if (item?.ProductImage != null)
                {
                    try
                    {
                        var resizedImage = new Bitmap(item.ProductImage, new Size(80, 80));
                        e.Graphics.DrawImage(resizedImage, e.Bounds.X, e.Bounds.Y);
                    }
                    catch (Exception ex)
                    {
                        e.DrawDefault = true; // Trường hợp lỗi, vẽ mặc định
                        Console.WriteLine($"Error drawing image: {ex.Message}");
                    }
                }
                else
                {
                    e.DrawDefault = true;
                }
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        public class CartItem
        {
            private ListView listViewCart;

            public string ProductName { get; set; }
            public string Size { get; set; }
            public string Toppings { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal TotalPrice => UnitPrice * Quantity;
            public System.Drawing.Image ProductImage { get; set; }
            public ListView ListViewCart
            {
                get { return listViewCart; }
            }


            public CartItem() { }

            public CartItem(string productName, string size, string toppings, int quantity, decimal unitPrice, System.Drawing.Image productImage = null)
            {
                ProductName = productName;
                Size = size;
                Toppings = toppings;
                Quantity = quantity;
                UnitPrice = unitPrice;
                ProductImage = productImage;
            }
        }

        public class Cart
        {
            public ObservableCollection<DashboardStaff.CartItem> Items { get; private set; } = new ObservableCollection<DashboardStaff.CartItem>();
            public string Id { get; private set; }
            public Customer Customer { get; private set; }
            public IEnumerable<object> Lines { get; private set; }

            public void AddItem(string productName, int quantity, decimal unitPrice, string size = "S", string toppings = "", System.Drawing.Image productImage = null)
            {
                var existingItem = Items.FirstOrDefault(item =>
                    item.ProductName == productName &&
                    item.Size == size &&
                    item.Toppings == toppings);

                if (existingItem != null)
                {
                    // Nếu sản phẩm đã tồn tại trong giỏ hàng, tăng số lượng
                    existingItem.Quantity += quantity;
                }
                else
                {
                    // Nếu sản phẩm chưa tồn tại, thêm mới
                    Items.Add(new DashboardStaff.CartItem
                    {
                        ProductName = productName,
                        Quantity = quantity,
                        UnitPrice = unitPrice,
                        Size = size,
                        Toppings = toppings,
                        ProductImage = productImage
                    });
                }
            }

            public void Remove(DashboardStaff.CartItem item)
            {
                Items.Remove(item);
            }

            public void Clear()
            {
                Items.Clear();
            }

            public static implicit operator MailChimp.Net.Models.Cart(Cart v)
            {
                if (v == null)
                {
                    return null;
                }

                return new MailChimp.Net.Models.Cart
                {
                    Id = v.Id, // Ánh xạ thuộc tính Id
                    Customer = v.Customer, // Ánh xạ thuộc tính Customer

                };
            }
        }

        private void btnTraSua_Click_1(object sender, EventArgs e)
        {
            // Khởi tạo form TraSuaStaff và hiển thị
            var traSuaForm = new TraSuaStaff();
            traSuaForm.ShowDialog(); // Hoặc sử dụng Show() nếu không cần modal
        }

        private void btnTrangMieng_Click_1(object sender, EventArgs e)
        {
            // Khởi tạo form TrangMiengStaff và hiển thị
            var trangMiengForm = new TrangMiengStaff();
            trangMiengForm.ShowDialog(); // Hoặc sử dụng Show() nếu không cần modal
        }

        public void listViewCart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCart.SelectedItems.Count > 0)
            {
                var selectedItem = listViewCart.SelectedItems[0];
                if (selectedItem.Tag is CartItem item)
                {
                    var dialogResult = MessageBox.Show(
                        "Bạn có muốn xóa sản phẩm này khỏi giỏ hàng không?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                    if (dialogResult == DialogResult.Yes)
                    {
                        sharedCart.Remove(item); // Xóa sản phẩm khỏi giỏ
                        UpdateCartView(); // Cập nhật lại giao diện giỏ hàng
                    }
                }
            }
        }

        public void AddToCart(string productName, string size, string toppings, string totalPriceText)
        {
            try
            {
                // Kiểm tra và chuyển đổi tổng giá thành số
                if (!decimal.TryParse(totalPriceText.Replace("VNĐ", "").Trim(), out decimal totalPrice))
                {
                    MessageBox.Show("Tổng giá không hợp lệ. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Đơn giá sẽ là tổng giá trong trường hợp này
                var unitPrice = totalPrice;  // Đơn giá giả định

                // Thêm sản phẩm vào giỏ hàng
                sharedCart.AddItem(productName, 1, unitPrice, size, toppings);
                UpdateCartView();  // Cập nhật giao diện giỏ hàng
                MessageBox.Show("Thêm sản phẩm vào giỏ hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
