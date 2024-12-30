﻿using OrderMillTeaProgram.Đăng_Nhập_Đăng_ký_của_User;
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
            if (email.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập email đăng ký!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string query = "Select * from UserInfo where Email = '" + email + "' ";
                if(modify.Accounts(query).Count != 0)
                {
                   // làm mã capcha xác thực là con người 
                   // gắn api của email
                }
                else
                {
                    lblEmailDaDangKy.ForeColor = Color.Red;
                    txtEmail.FillColor = Color.Tomato;
                    txtEmail.BorderColor = Color.Red;
                    txtEmail.BorderThickness = 3;
                    txtEmail.PlaceholderForeColor = Color.DimGray;
                    
                }
            }
            FogotPassword_child childForm = new FogotPassword_child(email);
            childForm.Show();
            this.Hide(); // Ẩn form hiện tại

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
