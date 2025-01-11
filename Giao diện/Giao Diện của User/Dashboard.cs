using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User.All_form_tráng_miệng; // Namespace của TrangMiengUser
using OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User.All_form_TS;
using OrderMillTeaProgram.Giao_diện_của_User; // Namespace của TraSuaUser

namespace OrderMillTeaProgram.Giao_diện_của_User
{
    public partial class Hongtratac : Form
    {
        private string avatarFilePath; // Khai báo biến
        private readonly NumericUpDown numericProductPrice;
        private readonly TextBox txtProductName;
        private readonly List<CartItem> cartItems = new List<CartItem>();
        private List<Product> products;

        public Hongtratac()
        {
            InitializeComponent();
            EnsureFlowLayoutPanelInitialized(); // Đảm bảo flowLayoutPanelCart được khởi tạo
            RegisterProductEvents();
            InitializeProductList();
            DisplayProductsInPanel();
            DisplayProducts(); // Hiển thị tất cả sản phẩm khi mở form
            SetupButtons(); // Tạo nút và thêm vào giao diện
            // Khởi tạo numericProductPrice và txtProductName
            numericProductPrice = new NumericUpDown();
            txtProductName = new TextBox();
        }

        private FlowLayoutPanel flowPanelCart; // Khai báo FlowLayoutPanel bên trong Guna2Panel

        private void EnsureFlowLayoutPanelInitialized()
        {
            if (flowPanelCart == null)
            {
                flowPanelCart = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true
                };
                guna2Panel2.Controls.Add(flowPanelCart); // Thêm FlowLayoutPanel vào Guna2Panel
            }
        }

        private Label lblTotal; // Khai báo tổng giá trị

        public Action<string, decimal> ProductSelected { get; private set; }

        private void InitializeTotalLabel()
        {
            if (lblTotal == null)
            {
                lblTotal = new Label
                {
                    Text = "Tổng: 0 VND",
                    Dock = DockStyle.Bottom,
                    TextAlign = ContentAlignment.MiddleRight,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    Height = 30
                };
                guna2Panel2.Controls.Add(lblTotal); // Thêm vào Guna2Panel
            }
        }


        private void UpdateCartTotal()
        {
            decimal total = cartItems.Sum(item => item.Price * item.Quantity);
            lblTotal.Text = $"Tổng: {total:N0} VND";
        }

        private void BtnTraSua_Click(object sender, EventArgs e)
        {
            // Tạo instance của form TraSuaUser
            TraSuaUser traSuaForm = new TraSuaUser();

            // Đăng ký sự kiện ProductSelected để nhận dữ liệu từ tất cả các form trong TraSuaUser
            traSuaForm.ProductSelected += TraSuaForm_ProductSelected;

            // Hiển thị form TraSuaUser
            traSuaForm.ShowDialog();
        }

        private void TraSuaForm_ProductSelected(object sender, ProductSelectedEventArgs e)
        {
            // Gọi phương thức AddProductToCart để thêm sản phẩm vào giỏ hàng
            AddProductToCart(e.ProductName, e.TotalPrice);
        }

        private void BtnTrangMieng_Click(object sender, EventArgs e)
        {
            // Tạo instance của form TrangMiengUser
            TrangMiengUser trangMiengForm = new TrangMiengUser();

            // Đăng ký sự kiện ProductSelected để nhận dữ liệu
            trangMiengForm.ProductSelected += (object s, object args) =>
            {
                if (args is ProductSelectedEventArgs productArgs)
                {
                    AddProductToCart(productArgs.ProductName, productArgs.TotalPrice);
                }
            };

            // Hiển thị form TrangMiengUser
            trangMiengForm.ShowDialog();
        }

        // Tạo danh sách sản phẩm
        private void InitializeProductList()
        {
            products = new List<Product>
            {
            new Product { Name = "Trà Sữa Trân Châu", Price = 30000, Image = Image.FromFile("C:\\Users\\LE THIEN\\Source\\Repos\\MilkTeaOrder\\Resources\\trasuachantrau.png") },
            new Product { Name = "Trà Sữa Khoai Môn", Price = 35000, Image = Image.FromFile("C:\\Users\\LE THIEN\\Source\\Repos\\MilkTeaOrder\\Resources\\trasuakhoaimon (1) (1).png") },
            new Product { Name = "Hồng Trà Tắc", Price = 25000, Image = Image.FromFile("C:\\Users\\LE THIEN\\Source\\Repos\\MilkTeaOrder\\Resources\\hongtratac.jpg") },
            new Product { Name = "Oreo Cake Cream", Price = 30000, Image = Image.FromFile("C:\\Users\\LE THIEN\\Source\\Repos\\MilkTeaOrder\\Resources\\tra-sua-oreo-cake-cream-674310.jpg") },
            new Product { Name = "Trà Sữa Phô Mai", Price = 25000, Image = Image.FromFile("C:\\Users\\LE THIEN\\Source\\Repos\\MilkTeaOrder\\Resources\\trasuaphomai.png") },
            new Product { Name = "Trà Sữa Socola Mint", Price = 30000, Image = Image.FromFile("C:\\Users\\LE THIEN\\Source\\Repos\\MilkTeaOrder\\Resources\\tra_sua_socola-min (1).png") },
            new Product { Name = "Trà Đào Cam Sả", Price = 25000, Image = Image.FromFile("C:\\Users\\LE THIEN\\Source\\Repos\\MilkTeaOrder\\Resources\\tradaocamsa (1).jpg") },
            new Product { Name = "Trà Sữa Thái Xanh", Price = 30000, Image = Image.FromFile("C:\\Users\\LE THIEN\\Source\\Repos\\MilkTeaOrder\\Resources\\z6146294792187_ca06630f68215aeb8706890c1f7b64db.jpg") },
            new Product { Name = "Bánh Flan", Price = 20000, Image = Image.FromFile("C:\\Users\\LE THIEN\\Source\\Repos\\MilkTeaOrder\\Resources\\banhflan.jpg") },
            new Product { Name = "Tiramisu", Price = 25000, Image = Image.FromFile("C:\\Users\\LE THIEN\\Source\\Repos\\MilkTeaOrder\\Resources\\tiramisu.jpg") },
            new Product { Name = "Bánh Phô Mai", Price = 15000, Image = Image.FromFile("C:\\Users\\LE THIEN\\Source\\Repos\\MilkTeaOrder\\Resources\\cheesecake.jpg") },
            new Product { Name = "CupCake", Price = 17000, Image = Image.FromFile("C:\\Users\\LE THIEN\\Source\\Repos\\MilkTeaOrder\\Resources\\cupcake.jpg") },
            // thêm sản phẩm khác ......
            };
        }

        private void DisplayProductsInPanel()
        {
            // Tạo FlowLayoutPanel trong panelContent
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight,
            };

            // Thêm FlowLayoutPanel vào panelContent
            panelContent.Controls.Clear(); // Xóa nội dung cũ nếu có

            // Thêm hai nút chuyển đổi hiển thị
            Panel topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                Padding = new Padding(10)
            };

            Button btnShowTraSua = new Button
            {
                Text = "Hiển thị Trà Sữa",
                Width = 150,
                Dock = DockStyle.Left,
                Margin = new Padding(5),
            };
            btnShowTraSua.Click += (s, e) =>
            {
                DisplayFilteredProducts("Trà Sữa");
            };

            Button btnShowTrangMieng = new Button
            {
                Text = "Hiển thị Tráng Miệng",
                Width = 150,
                Dock = DockStyle.Left,
                Margin = new Padding(5),
            };
            btnShowTrangMieng.Click += (s, e) =>
            {
                DisplayFilteredProducts("Tráng Miệng");
            };

            topPanel.Controls.Add(btnShowTraSua);
            topPanel.Controls.Add(btnShowTrangMieng);
            panelContent.Controls.Add(topPanel);

            // Thêm FlowLayoutPanel chứa danh sách sản phẩm
            panelContent.Controls.Add(flowLayoutPanel);

            // Lặp qua danh sách sản phẩm và thêm vào FlowLayoutPanel
            foreach (var product in products)
            {
                // Tạo thẻ sản phẩm
                Panel productPanel = new Panel
                {
                    Width = 200,
                    Height = 250,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10)
                };

                // Hiển thị hình ảnh sản phẩm
                PictureBox pictureBox = new PictureBox
                {
                    Image = product.Image,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Dock = DockStyle.Top,
                    Height = 150
                };
                productPanel.Controls.Add(pictureBox);

                // Hiển thị tên sản phẩm
                Label lblName = new Label
                {
                    Text = product.Name,
                    Dock = DockStyle.Top,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 12, FontStyle.Bold)
                };
                productPanel.Controls.Add(lblName);

                // Hiển thị giá sản phẩm
                Label lblPrice = new Label
                {
                    Text = $"{product.Price:N0} VND",
                    Dock = DockStyle.Bottom,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.Green
                };
                productPanel.Controls.Add(lblPrice);

                // Nút thêm vào giỏ hàng
                Button btnAddToCart = new Button
                {
                    Text = "Thêm vào giỏ hàng",
                    Dock = DockStyle.Bottom
                };
                btnAddToCart.Click += (s, e) =>
                {
                    var existingItem = cartItems.FirstOrDefault(ci => ci.Name == product.Name);

                    if (existingItem != null)
                    {
                        // Tăng số lượng nếu sản phẩm đã có trong giỏ hàng
                        existingItem.Quantity++;
                    }
                    else
                    {
                        // Thêm sản phẩm mới vào giỏ hàng
                        cartItems.Add(new CartItem
                        {
                            Name = product.Name,
                            Price = product.Price,
                            Quantity = 1,
                            Image = product.Image
                        });
                    }

                    MessageBox.Show($"{product.Name} đã được thêm vào giỏ hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateCartDisplay(); // Cập nhật giao diện giỏ hàng
                };
                productPanel.Controls.Add(btnAddToCart);

                // Nút mua hàng
                Button btnBuyNow = new Button
                {
                    Text = "Mua ngay",
                    Dock = DockStyle.Bottom,
                    BackColor = Color.LightBlue
                };
                btnBuyNow.Click += (s, e) =>
                {
                    MessageBox.Show($"Bạn đã mua {product.Name} với giá {product.Price:N0} VND!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
                productPanel.Controls.Add(btnBuyNow);

                // Thêm sản phẩm vào FlowLayoutPanel
                flowLayoutPanel.Controls.Add(productPanel);
            }
        }

        // Phương thức lọc và hiển thị sản phẩm theo danh mục
        private void DisplayFilteredProducts(string category)
        {
            // Lọc sản phẩm theo danh mục
            var filteredProducts = products.Where(p => p.Category == category).ToList();

            // Tạo FlowLayoutPanel để hiển thị sản phẩm
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(10)
            };

            // Xóa nội dung cũ và thêm FlowLayoutPanel mới
            panelContent.Controls.Clear();
            panelContent.Controls.Add(flowLayoutPanel);

            // Hiển thị danh sách sản phẩm đã lọc
            foreach (var product in filteredProducts)
            {
                AddProductToPanel(flowLayoutPanel, product);
            }
        }

        private void AddProductToPanel(FlowLayoutPanel flowLayoutPanel, Product product)
        {
            // Tạo thẻ sản phẩm
            Panel productPanel = new Panel
            {
                Width = 200,
                Height = 250,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10)
            };

            // Hiển thị hình ảnh sản phẩm
            PictureBox pictureBox = new PictureBox
            {
                Image = product.Image,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.Top,
                Height = 150
            };
            productPanel.Controls.Add(pictureBox);

            // Hiển thị tên sản phẩm
            Label lblName = new Label
            {
                Text = product.Name,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            productPanel.Controls.Add(lblName);

            // Hiển thị giá sản phẩm
            Label lblPrice = new Label
            {
                Text = $"{product.Price:N0} VND",
                Dock = DockStyle.Bottom,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Green
            };
            productPanel.Controls.Add(lblPrice);

            // Nút "Mua ngay" để mở form tương ứng
            Button btnBuyNow = new Button
            {
                Text = "Mua ngay",
                Dock = DockStyle.Bottom
            };
            btnBuyNow.Click += (s, e) =>
            {
                OpenProductForm(product.FormName);
            };
            productPanel.Controls.Add(btnBuyNow);

            // Thêm sản phẩm vào FlowLayoutPanel
            flowLayoutPanel.Controls.Add(productPanel);
        }

        private void OpenProductForm(string formName)
        {
            if (string.IsNullOrEmpty(formName))
            {
                MessageBox.Show("Sản phẩm này chưa có form chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Sử dụng Reflection để tạo instance form
            var formType = Type.GetType($"OrderMillTeaProgram.Giao_diện_của_User.All_form_TS.{formName}") ?? Type.GetType($"OrderMillTeaProgram.Giao_diện_của_User.All_form_tráng_miệng.{formName}");
            if (formType != null)
            {
                Form form = (Form)Activator.CreateInstance(formType);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không tìm thấy form tương ứng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayProducts(string category = null)
        {
            // Lọc sản phẩm theo danh mục (nếu có)
            var filteredProducts = string.IsNullOrEmpty(category)
                ? products
                : products.Where(p => p.Category == category).ToList();

            // Tạo FlowLayoutPanel để hiển thị sản phẩm
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(10)
            };

            // Xóa nội dung cũ và thêm FlowLayoutPanel mới
            panelContent.Controls.Clear();

            // Thêm nút "Trà Sữa" và "Tráng Miệng" ở trên cùng
            FlowLayoutPanel buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(5)
            };

            Button btnShowTea = new Button { Text = "Trà Sữa" };
            btnShowTea.Click += (s, e) => DisplayProducts("Trà Sữa");
            buttonPanel.Controls.Add(btnShowTea);

            Button btnShowDesserts = new Button { Text = "Tráng Miệng" };
            btnShowDesserts.Click += (s, e) => DisplayProducts("Tráng Miệng");
            buttonPanel.Controls.Add(btnShowDesserts);

            if (!string.IsNullOrEmpty(category))
            {
                Button btnBack = new Button { Text = "Trở về" };
                btnBack.Click += (s, e) => DisplayProducts(); // Quay lại hiển thị tất cả sản phẩm
                buttonPanel.Controls.Add(btnBack);
            }

            panelContent.Controls.Add(buttonPanel);
            panelContent.Controls.Add(flowLayoutPanel);

            // Hiển thị sản phẩm
            foreach (var product in filteredProducts)
            {
                AddProductToPanel(flowLayoutPanel, product);
            }
        }

        private void BtnShowTea_Click(object sender, EventArgs e)
        {
            DisplayProducts("Trà Sữa");
        }

        private void BtnShowDesserts_Click(object sender, EventArgs e)
        {
            DisplayProducts("Tráng Miệng");
        }

        private void SetupButtons()
        {
            // Tạo panel chứa nút
            Panel buttonPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50 // Đặt chiều cao để không ảnh hưởng đến phần hiển thị sản phẩm
            };

            Button btnShowTea = new Button
            {
                Text = "Trà Sữa",
                Width = 100,
                Height = 40,
                Margin = new Padding(5)
            };
            btnShowTea.Click += (s, e) => DisplayProducts("Trà Sữa");

            Button btnShowDesserts = new Button
            {
                Text = "Tráng Miệng",
                Width = 100,
                Height = 40,
                Margin = new Padding(5)
            };
            btnShowDesserts.Click += (s, e) => DisplayProducts("Tráng Miệng");

            buttonPanel.Controls.Add(btnShowTea);
            buttonPanel.Controls.Add(btnShowDesserts);

            // Thêm buttonPanel vào form hoặc container của bạn
            panelContent.Controls.Add(buttonPanel);
        }

        private void RegisterProductEvents()
        {
            // Khởi tạo các form từ thư mục All form TS
            Hongtratac hongtracForm = new Hongtratac();
            var khoaimonForm = new Tskhoaimon();
            var oreoForm = new TSOreoCakeCream();
            var phomaiForm = new TSPhoMai();
            var socolaForm = new TSSocolaMin();
            var tranchauForm = new TSTranChau();
            var tradaoForm = new TraDaoCamSa();
            var thaixanhForm = new TraSuaThaiXanh();

            // Đăng ký sự kiện ProductSelected
            hongtracForm.ProductSelected += AddProductToCart;
            khoaimonForm.ProductSelected += AddProductToCart;
            oreoForm.ProductSelected += AddProductToCart;
            phomaiForm.ProductSelected += AddProductToCart;
            socolaForm.ProductSelected += AddProductToCart;
            tranchauForm.ProductSelected += AddProductToCart;
            tradaoForm.ProductSelected += AddProductToCart;
            thaixanhForm.ProductSelected += AddProductToCart;
            // Nếu cần hiển thị các form con trong tab hoặc giao diện chính, thêm chúng
            // Example: this.tabControl1.TabPages.Add(new TabPage("Hồng Trà Tắc") { Controls = { hongtracForm } });
        }

        private void UpdateCartDisplay()
        {
            EnsureFlowLayoutPanelInitialized();
            InitializeTotalLabel();

            flowPanelCart.Controls.Clear(); // Xóa nội dung cũ

            foreach (var item in cartItems)
            {
                Panel itemPanel = new Panel
                {
                    Width = flowPanelCart.Width - 20,
                    Height = 100,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10)
                };

                // Hiển thị hình ảnh sản phẩm
                PictureBox pictureBox = new PictureBox
                {
                    Image = item.Image,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Width = 80,
                    Height = 80,
                    Dock = DockStyle.Left
                };
                itemPanel.Controls.Add(pictureBox);

                // Hiển thị thông tin sản phẩm
                Label lblInfo = new Label
                {
                    Text = $"{item.Name}\nGiá: {item.Price:N0} VND\nSố lượng: {item.Quantity}",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft
                };
                itemPanel.Controls.Add(lblInfo);

                // Nút xóa sản phẩm khỏi giỏ hàng
                Button btnRemove = new Button
                {
                    Text = "Xóa",
                    Dock = DockStyle.Right,
                    Width = 80
                };
                btnRemove.Click += (s, e) =>
                {
                    cartItems.Remove(item);
                    UpdateCartDisplay(); // Cập nhật lại giỏ hàng
                    UpdateCartTotal();   // Cập nhật tổng giá trị
                };
                itemPanel.Controls.Add(btnRemove);

                flowPanelCart.Controls.Add(itemPanel);
            }

            UpdateCartTotal(); // Cập nhật tổng giá trị
        }

        private void AddProductToCart(string productName, decimal totalPrice)
        {
            MessageBox.Show($"Đang thêm {productName} với giá {totalPrice:N0} VNĐ vào giỏ hàng."); // Debug

            // Đảm bảo FlowLayoutPanel không bị null
            EnsureFlowLayoutPanelInitialized();

            // Kiểm tra sản phẩm đã tồn tại chưa
            var existingProduct = cartItems.FirstOrDefault(p => p.Name == productName);

            if (existingProduct != null)
            {
                // Cập nhật tổng giá (hoặc tăng số lượng)
                existingProduct.TotalPrice += totalPrice;
            }
            else
            {
                // Thêm sản phẩm mới
                cartItems.Add(new CartItem { Name = productName, TotalPrice = totalPrice });
            }

            // Tạo một Panel để chứa thông tin sản phẩm
            Panel productPanel = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                AutoSize = true,
                Margin = new Padding(5)
            };

            // Tạo nhãn để hiển thị tên sản phẩm và giá
            Label lblProduct = new Label
            {
                Text = $"{productName}: {totalPrice:N0} VNĐ",
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Margin = new Padding(5)
            };

            // Tạo nút "Xoá" để người dùng có thể xoá sản phẩm khỏi giỏ hàng
            Button btnRemove = new Button
            {
                Text = "Xoá",
                AutoSize = true,
                Margin = new Padding(5)
            };

            // Xử lý sự kiện xoá sản phẩm
            btnRemove.Click += (s, e) => guna2Panel2.Controls.Remove(productPanel);

            // Thêm nhãn và nút vào Panel sản phẩm
            productPanel.Controls.Add(lblProduct);
            productPanel.Controls.Add(btnRemove);

            // Thêm Panel sản phẩm vào FlowLayoutPanel
            guna2Panel2.Controls.Add(productPanel);

            // Tùy chọn: Cập nhật giao diện giỏ hàng
            UpdateCartUI();
        }

        private void UpdateCartUI()
        {
            guna2Panel2.Controls.Clear(); // Xóa giao diện cũ

            foreach (var item in cartItems)
            {
                // Tạo một panel sản phẩm
                Panel productPanel = new Panel
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    AutoSize = true,
                    Margin = new Padding(5)
                };

                // Thêm các thành phần vào panel
                Label lblProduct = new Label
                {
                    Text = $"{item.Name}: {item.TotalPrice:N0} VNĐ",
                    AutoSize = true
                };
                productPanel.Controls.Add(lblProduct);

                // Thêm panel vào FlowLayoutPanel
                guna2Panel2.Controls.Add(productPanel);
            }
        }


        private void BtnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    avatarFilePath = openFileDialog.FileName;
                    picAvatar.Image = Image.FromFile(avatarFilePath);
                }
            }
        }

        // Example usage of AddProductToCart method
        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            string productName = txtProductName.Text; // Lấy tên sản phẩm từ textbox
            decimal productPrice = numericProductPrice.Value; // Lấy giá từ input giá
            AddProductToCart(productName, productPrice); // Thêm sản phẩm vào giỏ hàng
        }
    }

    public class ProductSelectedEventArgs : EventArgs
    {
        public string ProductName { get; set; }
        public decimal TotalPrice { get; set; }
    }
    public class CartItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Image Image { get; set; }
        public decimal TotalPrice { get; internal set; }
    }


    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Image Image { get; set; }
        public string Category { get; set; } // "Trà Sữa" hoặc "Tráng Miệng"
        public string FormName { get; set; } // Tên form tương ứng
    }
}

public class TraSuaUser : Form
{
    public event EventHandler<ProductSelectedEventArgs> ProductSelected;

    public TraSuaUser()
    {
        // Giả sử có các form con được tạo tại đây
        Button btnSubForm = new Button { Text = "Open Sub Form" };
        btnSubForm.Click += (s, e) =>
        Controls.Add(btnSubForm);
    }

    // Method to raise the ProductSelected event
    protected virtual void OnProductSelected(ProductSelectedEventArgs e)
    {
        ProductSelected?.Invoke(this, e);
    }
}