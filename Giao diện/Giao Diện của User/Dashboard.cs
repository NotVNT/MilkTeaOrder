using System;
using System.Drawing;
using System.Windows.Forms;
using OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User.All_form_tráng_miệng; // Namespace của TrangMiengUser
using OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User.All_form_TS; // Namespace của TraSuaUser

namespace OrderMillTeaProgram.Giao_diện_của_User
{
    public partial class Dashboard : Form
    {
        private string avatarFilePath; // Declare the variable

        public Dashboard()
        {
            InitializeComponent();
        }

        private void BtnTraSua_Click(object sender, EventArgs e)
        {
            // Tạo instance của form TraSuaUser
            TraSuaUser traSuaUser = new TraSuaUser();

            // Hiển thị form TraSuaUser
            traSuaUser.ShowDialog();
        }

        private void BtnTrangMieng_Click(object sender, EventArgs e)
        {
            // Tạo instance của form TrangMiengUser
            TrangMiengUser trangMiengUser = new TrangMiengUser();

            // Hiển thị form TrangMiengUser
            trangMiengUser.ShowDialog();
        }

        private void AddProductToCart(string productName, decimal totalPrice)
        {
            // Đảm bảo FlowLayoutPanel không bị null
            if (flowLayoutPanelCart == null)
            {
                MessageBox.Show("Giỏ hàng chưa được khởi tạo.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
}
