﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using OrderMillTeaProgram.Giao_diện_của_User;
using OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User;
using static OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User.DashboardStaff;

namespace OrderMillTeaProgram
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btnshowhidepass_Click(object sender, EventArgs e)
        {

        }

        private void Btnhidepass_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.PasswordChar == '*')
            {
                btnshowpass.BringToFront();
                txtMatKhau.PasswordChar = '\0';
            }
        }

        private void Btnshowpass_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.PasswordChar == '\0')
            {
                btnhidepass.BringToFront();
                txtMatKhau.PasswordChar = '*';
            }
        }

        private void LblQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword Forgot = new ForgotPassword();
            Forgot.Show();
            this.Hide();
        }

        private void TxtDangNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnDangNhap_Click(object sender, EventArgs e, Cart cart)
        {
            string username = txtDangNhap.Text;
            string password = txtMatKhau.Text;
            if (username.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản!");
                return;
            }
            else if (password.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                return;
            }
            else
            {
                string query = "SELECT Role FROM UserInfo WHERE UserName = @username AND Password = @password";

                using (SqlConnection sqlConnection = Connection.GetSqlConnection())
                {

                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))

                    {
                        sqlCommand.Parameters.AddWithValue("@username", username);
                        sqlCommand.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string role = reader["Role"].ToString();

                                switch (role)
                                {
                                    case "Admin":
                                        MessageBox.Show("Bạn đang đăng nhập tài khoản Admin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Hide();
                                        DashboardAdmin dashboardadmin = new DashboardAdmin();
                                        dashboardadmin.ShowDialog();
                                        this.Close();
                                        break;
                                    case "Nhân Viên":
                                        MessageBox.Show("Bạn đang đăng nhập tài khoản Nhân Viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Hide();
                                        DashboardStaff dashboardstaff = new DashboardStaff(cart);
                                        dashboardstaff.ShowDialog();
                                        this.Close();
                                        break;
                                    default: // "Người dùng" or any other role
                                        MessageBox.Show("Bạn đã đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Hide();
                                        Giao_diện_của_User.Hongtratac dashboard = new Giao_diện_của_User.Hongtratac();
                                        dashboard.ShowDialog();
                                        this.Close();
                                        break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Tên tài khoản hoặc mật khẩu của bạn không chính xác, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
        }
        private void LblDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignForm Sign = new SignForm();
            Sign.Show();
            this.Hide();
        }

        private void TxtDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtMatKhau.Focus();
                e.Handled = true;
            }
        }

        private void TxtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtDangNhap.Focus(); // Thay đổi dòng này
                e.Handled = true;
            }
        }
    }
}
