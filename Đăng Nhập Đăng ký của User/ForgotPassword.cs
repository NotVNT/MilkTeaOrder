using OrderMillTeaProgram.Đăng_Nhập_Đăng_ký_của_User;
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
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        Modify modify = new Modify();
        private void btnTieptuc_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Vui lòng nhập email đăng ký!");
            }
            else
            {
                string query = "SELECT * FROM UserInfo WHERE Email = '" + email + "'";

                // Sử dụng danh sách Account
                List<Account> accounts = modify.Accounts(query);

                if (accounts.Count > 0) // Email tồn tại
                {
                    FogotPassword_child forgotPasswordChild = new FogotPassword_child(email); // Truyền email sang form con
                    forgotPasswordChild.ShowDialog(); // Hiển thị form con
                    this.Hide(); // Ẩn form hiện tại (nếu cần)
                }
                else
                {
                    // Email không tồn tại
                    lblEmailDaDangKy.ForeColor = Color.Red;
                    txtEmail.FillColor = Color.Tomato;
                    txtEmail.BorderColor = Color.Red;
                    txtEmail.BorderThickness = 3;
                    txtEmail.PlaceholderForeColor = Color.DimGray;
                }
            }
        }


        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}