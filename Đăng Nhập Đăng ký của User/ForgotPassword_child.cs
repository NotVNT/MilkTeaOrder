using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Web;
using System.Configuration;
using System.Data.OleDb;


namespace OrderMillTeaProgram.Đăng_Nhập_Đăng_ký_của_User
{
    public partial class FogotPassword_child : Form
    {
        private string email; // Biến lưu email nhận từ form cha
        public FogotPassword_child(string emailFromParent)
        {
            InitializeComponent();
            email = emailFromParent; // Lưu email từ form cha
            txtForgetPasswordEmail.Text = email; // Hiển thị email trên form con
            txtForgetPasswordEmail.ReadOnly = true; // Ngăn chỉnh sửa email

            txtForgetPasswordConformPassword.PasswordChar = '*';
            txtForgetPasswordNewPassword.PasswordChar = '*'; // Nếu bạn có ô nhập mật khẩu mới
        }
        Random rnd = new Random();
        public int code;

        // Kết nối SQL Server
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tuquo\source\repos\MilkTeaOrder\Database\UserInfoDB.mdf;Integrated Security=True");
        public FogotPassword_child()
        {
            InitializeComponent();
        }

        private void mail()
        {
            code = rnd.Next(123123, 999999);
            const string appPassword = "rfmx kvrx rbrm zihp"; // Mật khẩu ứng dụng của bạn
            const string email = "tuquoctuan201@gmail.com"; // Thay bằng email của bạn

            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            message.From = new MailAddress(email);
            message.To.Add(new MailAddress("tuquoctuan201@gmail.com")); // Thay bằng email người nhận
            message.Subject = "Change Password";
            message.Body = "Write this given code on text box\n" + code + "\nThank you!";

            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(email, appPassword);
            smtp.Send(message);

            MessageBox.Show("Email has been sent");
        }

        private void btnForgetPasswordChange_Click(object sender, EventArgs e)
        {
            if (txtForgetPasswordNewPassword.Text == txtForgetPasswordConformPassword.Text)
            {
                string query = "UPDATE ownerInfo SET Password = @Password WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Password", txtForgetPasswordConformPassword.Text);
                cmd.Parameters.AddWithValue("@Email", txtForgetPasswordEmail.Text); // Email đã được nhập ở bước trước

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Password changed successfully");
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Failed to change password");
                }
            }
            else
            {
                MessageBox.Show("Passwords do not match");
            }
        }

        private void btnForgetPasswordSendMail_Click_1(object sender, EventArgs e)
        {
            string query = "SELECT Email FROM UserInfo WHERE Email = @Email";
            SqlCommand cmd = new SqlCommand(query, con);

            // Lấy email từ text box
            string txtboxEmail = txtForgetPasswordEmail.Text;
            cmd.Parameters.AddWithValue("@Email", txtboxEmail);

            con.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            SqlDataReader reader = sqlDataReader;

            if (reader.HasRows)
            {
                lblNextStep1.Visible = true;
                imgNextStep1.Visible = true;

                txtForgrtPassswordCode.Enabled = true;
                btnForgetPassordNextStep.Enabled = true;
                btnForgetPassordSendAgain.Enabled = true;
                btnForgetPasswordSendMail.Enabled = false;

                mail();
            }
            else
            {
                MessageBox.Show("This email does not exist in the database");
            }

            con.Close();
        }

        private void btnForgetPassordNextStep_Click(object sender, EventArgs e)
        {
            if (code.ToString() == txtForgrtPassswordCode.Text)
            {
                lblNextStep2.Visible = true;
                imgNextStep2.Visible = true;

                txtForgetPasswordConformPassword.Enabled = true;
                txtForgetPasswordNewPassword.Enabled = true;
                btnForgetPasswordChange.Enabled = true;
                btnForgetPassordNextStep.Enabled = false;
                btnForgetPassordSendAgain.Enabled = false;
            }

            else
            {
                MessageBox.Show("Code doesent Match");
            }
        }

        private void btnForgetPassordSendAgain_Click(object sender, EventArgs e)
        {
            mail();
        }

        private void btnForgetPasswordChange_Click_1(object sender, EventArgs e)
        {
            if (txtForgetPasswordNewPassword.Text == txtForgetPasswordConformPassword.Text)
            {
                string query = "UPDATE UserInfo SET [Password] = @Password WHERE [Email] = @Email"; // Sử dụng cột Email
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Password", txtForgetPasswordConformPassword.Text);
                    cmd.Parameters.AddWithValue("@Email", txtForgetPasswordEmail.Text);

                    try
                    {
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password changed successfully");

                            // Hiển thị form LoginForm
                            this.Hide(); // Ẩn form hiện tại
                            LoginForm loginForm = new LoginForm(); // Khởi tạo form LoginForm
                            loginForm.Show(); // Hiển thị form LoginForm
                            this.Close(); // Đóng form hiện tại
                        }
                        else
                        {
                            MessageBox.Show("No matching email found in the database.");
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"SQL Error: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Unexpected Error: {ex.Message}");
                    }
                    finally
                    {
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Passwords do not match");
            }
        }
    }
}
