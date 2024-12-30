using System;
using System.Drawing;
using System.Windows.Forms;
using OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User.All_form_tráng_miệng; // Namespace của TrangMiengUser
using OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User.All_form_TS;
using OrderMillTeaProgram.Giao_diện_của_User; // Namespace của TraSuaUser

namespace OrderMillTeaProgram.Giao_diện_của_User
{
    public partial class Dashboard : Form
    {
        private string avatarFilePath; // Declare the variable

        public Dashboard()
        {
            InitializeComponent();
            EnsureFlowLayoutPanelInitialized(); // Ensure flowLayoutPanelCart is initialized
        }

        private void EnsureFlowLayoutPanelInitialized()
        {
            if (flowLayoutPanelCart == null)
            {
                flowLayoutPanelCart = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true
                };
                this.Controls.Add(flowLayoutPanelCart);
            }
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

        private void AddProductToCart(string productName, decimal totalPrice)
        {
            // Đảm bảo FlowLayoutPanel không bị null
            EnsureFlowLayoutPanelInitialized();

            // Kiểm tra nếu sản phẩm đã tồn tại trong giỏ hàng
            foreach (Control control in flowLayoutPanelCart.Controls)
            {
                if (control is Panel panel)
                {
                    foreach (Control panelChild in panel.Controls)
                    {
                        if (panelChild is Label label && label.Text.StartsWith(productName))
                        {
                            MessageBox.Show($"{productName} đã tồn tại trong giỏ hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
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
            btnRemove.Click += (s, e) => flowLayoutPanelCart.Controls.Remove(productPanel);

            // Thêm nhãn và nút vào Panel sản phẩm
            productPanel.Controls.Add(lblProduct);
            productPanel.Controls.Add(btnRemove);

            // Thêm Panel sản phẩm vào FlowLayoutPanel
            flowLayoutPanelCart.Controls.Add(productPanel);
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
            AddProductToCart("Product Name", 100000);
        }
    }

    public class ProductSelectedEventArgs : EventArgs
    {
        public string ProductName { get; set; }
        public decimal TotalPrice { get; set; }
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
        {
            // Ví dụ gọi form con
            TSKhoaiMon subForm = new TSKhoaiMon();
            subForm.ProductSelected += (sender, args) =>
            {
                // Kích hoạt sự kiện của form TraSuaUser
                ProductSelected?.Invoke(this, args);
            };
            subForm.ShowDialog();
        };
        Controls.Add(btnSubForm);
    }

    // Method to raise the ProductSelected event
    protected virtual void OnProductSelected(ProductSelectedEventArgs e)
    {
        ProductSelected?.Invoke(this, e);
    }
}

public class TSKhoaiMon : Form
{
    public event EventHandler<ProductSelectedEventArgs> ProductSelected;

    public TSKhoaiMon()
    {
        Button btnAddToCart = new Button { Text = "Thêm vào giỏ hàng" };
        btnAddToCart.Click += (s, e) =>
        {
            // Giả sử sản phẩm có tên "Khoai Môn" và giá là 20000
            ProductSelected?.Invoke(this, new ProductSelectedEventArgs { ProductName = "Khoai Môn", TotalPrice = 20000 });
        };
        Controls.Add(btnAddToCart);
    }
}
