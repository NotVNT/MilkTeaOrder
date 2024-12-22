using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OrderMillTeaProgram
{
    public partial class SignForm : Form
    {
        public SignForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnhidepass_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.PasswordChar == '*')
            {
                btnshowpass.BringToFront();
                txtMatKhau.PasswordChar = '\0';
            }
        }

        private void btnshowpass_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.PasswordChar == '\0')
            {
                btnhidepass.BringToFront();
                txtMatKhau.PasswordChar = '*';
            }
        }

        private void btnhidepass2_Click(object sender, EventArgs e)
        {
            if (txtCheckPass.PasswordChar == '\0')
            {
                btnshowpass2.BringToFront();
                txtCheckPass.PasswordChar = '*';
            }
        }

        private void btnshowpass2_Click(object sender, EventArgs e)
        {
           
            if (txtCheckPass.PasswordChar == '*')
            {
                btnhidepass2.BringToFront();
                txtCheckPass.PasswordChar = '\0';
            }
        }

        private void lblDangNhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm Login = new LoginForm();
            Login.Show();
            this.Hide();
        }

        public bool CheckAccount(string checkAc) // kiểm tra tên tài khoản và mật khẩu phải nhập đúng định dạng
        {
            return Regex.IsMatch(checkAc, "^[a-zA-Z0-9_]{6,26}$");
        }
        public bool CheckEmail(string checkEm) //check email
        {
            return Regex.IsMatch(checkEm, @"^[a-zA-Z0-9_.]{4,20}@gmail.com(.vn|)$");
        }

        Modify modify = new Modify();
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string username = txtDangNhap.Text;
            string password = txtMatKhau.Text;
            string xacnhanpassword = txtCheckPass.Text;
            string email = txtEmail.Text;
            string magioithieu = txtMaGioiThieu.Text;
            if(!CheckAccount(username))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản có độ dài từ 6-26 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!CheckAccount(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu có độ dài từ 8 ký tự trở lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (xacnhanpassword != password)
            {
                MessageBox.Show("Vui lòng xác nhận lại đúng mật khẩu bạn vừa nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!CheckEmail(email))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng Email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            try
            {
                // Use parameterized query to check for existing username or email
                string checkQuery = "SELECT COUNT(*) FROM UserInfo WHERE UserName = @username OR Email = @email";
                using (SqlConnection sqlConnection = Connection.GetSqlConnection())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(checkQuery, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@username", username);
                        sqlCommand.Parameters.AddWithValue("@email", email);
                        int count = (int)sqlCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Tên tài khoản hoặc Email này đã được đăng ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }


                string query = "INSERT INTO UserInfo (UserName, Password, Email) VALUES (@username, @password, @email)";
                var parameters = new Dictionary<string, object>
                {
                    { "@username", username },
                    { "@password", password },
                    { "@email", email }
                };
                modify.Command(query, parameters);

                if (MessageBox.Show("Đăng ký thành công! Bạn có muốn đăng nhập luôn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    LoginForm Login = new LoginForm();
                    Login.Show();
                    this.Hide();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Tên tài khoản hoặc Email này đã được đăng ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình đăng ký. Vui lòng thử lại sau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
