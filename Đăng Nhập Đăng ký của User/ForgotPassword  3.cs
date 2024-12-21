﻿using Google.Apis.Gmail.v1;
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
                MessageBox.Show("Vui lòng nhập email đăng ký!");
            }
            else
            {
                string query = "Select * from UserInfo where Email = '" + email + "' ";
                if (modify.Accounts(query).Count != 0)
                {
                    // Sinh mã xác thực ngẫu nhiên
                    string verificationCode = new Random().Next(100000, 999999).ToString();

                    // Gửi mã xác thực qua Gmail SMTP
                    EmailService.SendVerificationEmail(email, verificationCode);
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

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
