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
using Microsoft.Reporting.WinForms;
using OrderMillTeaProgram.Database;

namespace OrderMillTeaProgram.Giao_diện.Giao_Diện_của_Admin.Report
{
    public partial class ReportDoanhThuT1 : Form
    {
        public ReportDoanhThuT1()
        {
            InitializeComponent();
        }

        private void ReportDoanhThuT1_Load(object sender, EventArgs e)
        {

            try
            {
                List<HoaDon> hoaDons = GetHoaDonDataForThang1();

                ReportDataSource dataSource = new ReportDataSource("DoanhThuT1", hoaDons);

                this.reportThang1.LocalReport.DataSources.Clear();
                this.reportThang1.LocalReport.DataSources.Add(dataSource);

                this.reportThang1.LocalReport.ReportEmbeddedResource = "OrderMillTeaProgram.Giao_diện.Giao_Diện_của_Admin.Report.ReportDoanhThuThang1.rdlc";

                this.reportThang1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<HoaDon> GetHoaDonDataForThang1()
        {
            List<HoaDon> hoaDons = new List<HoaDon>();
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                string query = "SELECT * FROM HoaDon";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HoaDon hoaDon = new HoaDon();
                            hoaDon.idHoaDon = reader["idHoaDon"].ToString();
                            hoaDon.DateCheckIn = reader["DateCheckIn"] as DateTime?;
                            hoaDon.DateCheckOut = reader["DateCheckOut"] as DateTime?;
                            hoaDon.TrangThai = reader["TrangThai"].ToString();
                            hoaDon.UserName = reader["UserName"].ToString();
                            hoaDon.TongTien = reader["TongTien"] as decimal?;
                            hoaDons.Add(hoaDon);
                        }
                    }
                }
            }
            return hoaDons;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
