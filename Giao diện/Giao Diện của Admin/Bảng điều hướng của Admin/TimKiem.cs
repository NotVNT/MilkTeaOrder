using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderMillTeaProgram.Giao_diện.Giao_Diện_của_Admin.Bảng_điều_hướng_của_Admin
{
    public partial class TimKiem : Form
    {
        public TimKiem()
        {
            InitializeComponent();
        }

        private void TimKiem_Load(object sender, EventArgs e)
        {
            LoadTaiKhoanData();

        }

        private void LoadTaiKhoanData()
        {
            string query = "SELECT UserName, HoTen, Email, SDT, Role FROM UserInfo WHERE Role != 'Admin'";

            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvTaiKhoan.DataSource = dt;
                }
            }
        }

        private void TimKiem_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string userName = txtTenTaiKhoan.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string email = txtEmail.Text.Trim();

            string query = @"SELECT UserName, HoTen, Email, SDT, Role 
                            FROM UserInfo 
                            WHERE Role != 'Admin' 
                              AND (@UserName = '' OR UserName LIKE '%' + @UserName + '%')
                              AND (@HoTen = '' OR HoTen LIKE '%' + @HoTen + '%')
                              AND (@SDT = '' OR SDT LIKE '%' + @SDT + '%')
                              AND (@Email = '' OR Email LIKE '%' + @Email + '%')";

            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@UserName", userName);
                    adapter.SelectCommand.Parameters.AddWithValue("@HoTen", hoTen);
                    adapter.SelectCommand.Parameters.AddWithValue("@SDT", sdt);
                    adapter.SelectCommand.Parameters.AddWithValue("@Email", email);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvTaiKhoan.DataSource = dt;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTenTaiKhoan.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtEmail.Clear();

            LoadTaiKhoanData();
        }
    }
}
