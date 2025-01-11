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

namespace OrderMillTeaProgram.Giao_diện.Giao_Diện_của_Staff
{
    public partial class DonHang : Form
    {
        // Add missing TextBox controls
        private TextBox txtMaHoaDon;
        private TextBox txtIdDrink;
        private TextBox txtSoLuong;
        private TextBox txtPrice;
        private TextBox txtUserName;
        private TextBox txtKhuyenMai;

        public DonHang()
        {
            InitializeComponent();
            // Initialize the TextBox controls
            txtMaHoaDon = new TextBox();
            txtIdDrink = new TextBox();
            txtSoLuong = new TextBox();
            txtPrice = new TextBox();
            txtUserName = new TextBox();
            txtKhuyenMai = new TextBox();
        }

        private void DonHang_Load(object sender, EventArgs e)
        {
            LoadHoaDonData();
        }
        private void LoadHoaDonData()
        {
            // Chuỗi kết nối đến cơ sở dữ liệu
            string connectionString = "Server=.;Database=YourDatabaseName;Trusted_Connection=True;";
            string query = "SELECT IdHoaDon, IdDrink, SoLuong, Price, UserName, KhuyenMai FROM HoaDon";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Gán DataTable vào DataGridView
                    dgvHoaDon.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}");
                }
            }
        }
        private void CreateHoaDon()
        {
            // Chuỗi kết nối đến cơ sở dữ liệu
            string connectionString = "Server=.;Database=YourDatabaseName;Trusted_Connection=True;";
            string query = "INSERT INTO HoaDon (IdHoaDon, IdDrink, SoLuong, Price, UserName, KhuyenMai) " +
                           "VALUES (@IdHoaDon, @IdDrink, @SoLuong, @Price, @UserName, @KhuyenMai)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số
                        command.Parameters.AddWithValue("@IdHoaDon", txtMaHoaDon.Text);
                        command.Parameters.AddWithValue("@IdDrink", txtIdDrink.Text);
                        command.Parameters.AddWithValue("@SoLuong", int.Parse(txtSoLuong.Text));
                        command.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text));
                        command.Parameters.AddWithValue("@UserName", txtUserName.Text);
                        command.Parameters.AddWithValue("@KhuyenMai", decimal.Parse(txtKhuyenMai.Text));

                        // Thực thi câu lệnh
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Tạo hóa đơn thành công!");

                    // Gọi lại hàm load dữ liệu để làm mới DataGridView
                    LoadHoaDonData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}");
                }
            }
        }

    }
}
