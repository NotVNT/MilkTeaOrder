using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            if(modify.Accounts("Select * from UserInfo where Email = '"+ email +"'").Count != 0)
            {
                MessageBox.Show("Email này đã được đăng ký, vui lòng đăng ký Email khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     return;
            }
            try
            {
                string query = "Insert into UserInfo values ('"+ username +"','"+ password +"','"+ email +"')";
                modify.Command(query);
                if(MessageBox.Show("Đăng ký thành công! Bạn có muốn đăng nhập luôn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    LoginForm Login = new LoginForm();
                    Login.Show();
                    this.Hide();
                }
            }
            catch
            {
                MessageBox.Show("Tên tài khoản này đã được đăng ký, vui lòng đăng ký tên tài khoản khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
