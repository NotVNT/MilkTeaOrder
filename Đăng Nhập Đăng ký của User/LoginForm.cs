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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnshowhidepass_Click(object sender, EventArgs e)
        {

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

        private void lblQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword Forgot = new ForgotPassword();
            Forgot.Show();
            this.Hide();
        }

     

        private void txtDangNhap_TextChanged(object sender, EventArgs e)
        {

        }
        Modify modify = new Modify();
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtDangNhap.Text;
            string password = txtMatKhau.Text;
            if(username.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản!"); 
                return;
            }
            else if(password.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                return;
            }
            else
            {
                string query = "Select * from UserInfo where UserName = '"+username+"' and Password = '"+password+"'";
                if(modify.Accounts(query).Count!=0)
                {
                    MessageBox.Show("Bạn đã đăng nhập thành công!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Dashboard dashboard = new Dashboard();
                    dashboard.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu của bạn không chính xác, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }    
            }
        }

        private void lblDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignForm Sign = new SignForm();
            Sign.Show();
            this.Hide();
        }
    }
}
