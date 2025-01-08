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
using OrderMillTeaProgram.Giao_diện.Giao_Diện_của_Admin.Bảng_điều_hướng_của_Admin;

namespace OrderMillTeaProgram.Giao_diện.Giao_Diện_của_Admin
{
    public partial class QLDT : Form
    {
        public QLDT()
        {
            InitializeComponent();
        }

        private void QLDT_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void QLDT_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            LoadHoaDonData();
        }

        private void btnTimKiemNhanVien_Click(object sender, EventArgs e)
        {
            TimKiem timKiemForm = new TimKiem();
            timKiemForm.FormClosed += TimKiem_FormClosed; // Subscribe to the event
            timKiemForm.ShowDialog();
        }

        private void TimKiem_FormClosed(object sender, FormClosedEventArgs e)
        {

        }


        private void LoadHoaDonData()
        {
            // 1. Calculate TongTien in HoaDon
            CalculateTongTien();

            // 2. Load HoaDon data into DataGridView
            string query = "SELECT idHoaDon, DateCheckIn, DateCheckOut, TrangThai, UserName, TongTien FROM HoaDon";

            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvQLDT.DataSource = dt;

                    decimal tongTienDoanhThu = CalculateTongTienDoanhThu(dt);
                    txtTongTienDoanhThu.Text = string.Format("{0:n0} VND", tongTienDoanhThu);
                }
            }
        }

        private void CalculateTongTien()
        {
            string query = @"UPDATE HoaDon
                            SET TongTien = sub.TotalPrice
                            FROM (
                                SELECT idHoaDon, SUM(CAST(price AS DECIMAL(18,2))) AS TotalPrice 
                                FROM CTHD
                                GROUP BY idHoaDon
                            ) AS sub
                            WHERE HoaDon.idHoaDon = sub.idHoaDon;";

            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private decimal CalculateTongTienDoanhThu(DataTable dt)
        {
            decimal tongTien = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row["TongTien"] != DBNull.Value)
                {
                    tongTien += Convert.ToDecimal(row["TongTien"]);
                }
            }
            return tongTien;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadHoaDonData();
        }

        private void txtTimTen_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtTimTen.Text.Trim().ToLower();

    
            if (string.IsNullOrEmpty(searchText))
            {
                LoadHoaDonData();
                return;
            }

            DataTable dt = (DataTable)dgvQLDT.DataSource;
            if (dt != null)
            {
                DataView dv = dt.DefaultView;
                string filter = string.Format("UserName LIKE '%{0}%' OR " +
                                             "idHoaDon LIKE '%{0}%' OR " +
                                             "TrangThai LIKE '%{0}%' OR " +
                                             "Convert(TongTien, 'System.String') LIKE '%{0}%'", searchText);
                dv.RowFilter = filter;

                // Update TongTienDoanhThu based on the filtered data
                decimal tongTienDoanhThu = CalculateTongTienDoanhThu(dv.ToTable());
                txtTongTienDoanhThu.Text = string.Format("{0:n0} VND", tongTienDoanhThu);
            }
        }
    }
}
