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

namespace OrderMillTeaProgram.Giao_diện.Giao_Diện_của_Admin
{
    public partial class HoaDonFromAdmin : Form
    {
        public HoaDonFromAdmin()
        {
            InitializeComponent();
        }

      
        private void HoaDonFromAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void HoaDonFromAdmin_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            LoadCTHDData();
        }

        private void LoadCTHDData()
        {
            try
            {
             
                string query = "SELECT IdHoaDon, IdDrink, SoLuong, price, UserName, KhuyenMai FROM CTHD";

           
                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    connection.Open();

                   
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
           
                        DataTable dt = new DataTable();

                        // 5. Đổ dữ liệu từ database vào DataTable
                        adapter.Fill(dt);

               
                        dgvHoaDon.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu CTHD: " + ex.Message);
            }
        }

        private void txtTimTen_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtTimTen.Text;

            try
            {
                string query = "SELECT IdHoaDon, IdDrink, SoLuong, price, UserName, KhuyenMai " +
                               "FROM CTHD " +
                               "WHERE IdHoaDon LIKE @searchTerm OR IdDrink LIKE @searchTerm OR UserName LIKE @searchTerm";

                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvHoaDon.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }
    }
}
