using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderMillTeaProgram.Giao_diện.Giao_Diện_của_Staff.Bảng_điều_hướng_của_Staff
{
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
            SetupDataGridView(); // Thiết lập các cột cho DataGridView
        }

    

        private void btnThemVaoHoaDon_Click(object sender, EventArgs e)
        {
            // Kiểm tra input
            if (string.IsNullOrWhiteSpace(txtMaHang.Text) ||
                string.IsNullOrWhiteSpace(txtTenHang.Text) ||
                string.IsNullOrWhiteSpace(txtSoLuong.Text) ||
                string.IsNullOrWhiteSpace(txtDonGia.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin mặt hàng!", "Thông báo");
                return;
            }

            if (!int.TryParse(txtSoLuong.Text, out int soLuong) ||
                !decimal.TryParse(txtDonGia.Text, out decimal donGia))
            {
                MessageBox.Show("Số lượng và đơn giá phải là số hợp lệ!", "Thông báo");
                return;
            }

            // Tính thành tiền
            decimal thanhTien = soLuong * donGia;

            // Thêm vào DataGridView
            dgvDanhSachHang.Rows.Add(txtMaHang.Text, txtTenHang.Text, soLuong, donGia, thanhTien);

            // Cập nhật tổng tiền
            UpdateTongTien();

            // Xóa dữ liệu trong các textbox
            ClearHangInputs();
        }
        // Hàm tính tổng tiền
        private void UpdateTongTien()
        {
            decimal tongTien = 0;
            foreach (DataGridViewRow row in dgvDanhSachHang.Rows)
            {
                tongTien += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
            }
            lblTongTien.Text = $"Tổng Tiền: {tongTien:C}";
        }

        // Hàm xóa input sau khi thêm hàng
        private void ClearHangInputs()
        {
            txtMaHang.Clear();
            txtTenHang.Clear();
            txtSoLuong.Clear();
            txtDonGia.Clear();
            txtThanhTien.Clear();
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một mặt hàng để chỉnh sửa!", "Thông báo");
                return;
            }

            // Lấy dòng được chọn
            DataGridViewRow selectedRow = dgvDanhSachHang.SelectedRows[0];

            // Cập nhật dữ liệu
            selectedRow.Cells["MaHang"].Value = txtMaHang.Text;
            selectedRow.Cells["TenHang"].Value = txtTenHang.Text;
            selectedRow.Cells["SoLuong"].Value = txtSoLuong.Text;
            selectedRow.Cells["DonGia"].Value = txtDonGia.Text;

            // Tính lại thành tiền
            if (int.TryParse(txtSoLuong.Text, out int soLuong) &&
                decimal.TryParse(txtDonGia.Text, out decimal donGia))
            {
                selectedRow.Cells["ThanhTien"].Value = soLuong * donGia;
            }

            // Cập nhật tổng tiền
            UpdateTongTien();
        }

        private void btnHuyHoaDon_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy hóa đơn không?",
                                        "Xác nhận",
                                        MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                dgvDanhSachHang.Rows.Clear();
                lblTongTien.Text = "Tổng Tiền: 0";
            }
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachHang.Rows.Count == 0)
            {
                MessageBox.Show("Danh sách giỏ hàng trống, không thể xuất hóa đơn!", "Thông báo");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xuất hóa đơn?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int idHoaDon = LuuHoaDon(); // Gọi hàm lưu hóa đơn
                decimal tongTien = CalculateTongTien();
                string ghiChu = txtGhiChu.Text;

                XuatHoaDonPDF(idHoaDon, dgvDanhSachHang, tongTien, ghiChu); // Gọi hàm xuất PDF
                dgvDanhSachHang.Rows.Clear(); // Xóa giỏ hàng sau khi lưu
                lblTongTien.Text = "Tổng Tiền: 0";
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maHoaDon = cmbMaHoaDon.Text;

            if (string.IsNullOrWhiteSpace(maHoaDon))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn để tìm kiếm!", "Thông báo");
                return;
            }

            // Thực hiện tìm kiếm trong cơ sở dữ liệu (thêm logic truy vấn ở đây)
            MessageBox.Show($"Đang tìm kiếm hóa đơn có mã: {maHoaDon}", "Thông báo");
        }
        private int LuuHoaDon()
        {
            int idHoaDon = 0; // Khởi tạo biến để lưu ID hóa đơn

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=QUOCTUAN\\QUOCTUAN;Initial Catalog=UserInfo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    conn.Open();

                    // 1. Tạo hóa đơn mới
                    string insertHoaDonQuery = "INSERT INTO HoaDon (idHoaDon, NgayInHoaDon, TrangThai, TongTien, GhiChu) " +
                            "OUTPUT INSERTED.IdHoaDon VALUES (NEWID(), @NgayInHoaDon, @TrangThai, @TongTien, @GhiChu)";
                    SqlCommand cmd = new SqlCommand(insertHoaDonQuery, conn);
                    // Không cần dòng này nữa: cmd.Parameters.AddWithValue("@idHoaDon", newIdHoaDon); 
                    cmd.Parameters.AddWithValue("@NgayInHoaDon", DateTime.Now);
                    cmd.Parameters.AddWithValue("@TrangThai", "Đã thanh toán"); // Hoặc "Chưa thanh toán"
                    cmd.Parameters.AddWithValue("@TongTien", CalculateTongTien());
                    cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);

                    idHoaDon = (int)cmd.ExecuteScalar(); // Lấy ID hóa đơn vừa tạo

                    // 2. Lưu chi tiết hóa đơn
                    foreach (DataGridViewRow row in dgvDanhSachHang.Rows)
                    {
                        if (row.IsNewRow) continue; // Bỏ qua dòng trống

                        string insertCTHDQuery = "INSERT INTO CTHD (IdHoaDon, IdDrink, SoLuong) VALUES (@IdHoaDon, @IdDrink, @SoLuong)";
                        SqlCommand cmdCTHD = new SqlCommand(insertCTHDQuery, conn);
                        cmdCTHD.Parameters.AddWithValue("@IdHoaDon", idHoaDon); // idHoaDon là kiểu int
                    }

                    MessageBox.Show("Hóa đơn đã được lưu thành công!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi lưu hóa đơn: {ex.Message}", "Lỗi");
            }

            return idHoaDon; // Trả về ID hóa đơn
        }


        // Hàm tính tổng tiền từ DataGridView
        private decimal CalculateTongTien()
        {
            decimal tongTien = 0;
            foreach (DataGridViewRow row in dgvDanhSachHang.Rows)
            {
                if (row.IsNewRow) continue;
                tongTien += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
            }
            return tongTien;
        }
        private void ClearCart()
        {
            dgvDanhSachHang.Rows.Clear(); // Xóa tất cả các dòng trong DataGridView
            lblTongTien.Text = "Tổng Tiền: 0";
            NewMethod();
        }

        private void NewMethod()
        {
            txtGhiChu.Clear(); // Xóa ghi chú
        }
        private void XuatHoaDonPDF(int idHoaDon, DataGridView dgvDanhSachHang, decimal tongTien, string ghiChu)
        {
            try
            {
                // Đường dẫn lưu file PDF
                string filePath = $@"string filePath = $@""C:\Users\Public\Documents\HoaDon_{{idHoaDon}}.pdf"";";

                // Tạo file PDF
                Document pdfDoc = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(filePath, FileMode.Create));
                pdfDoc.Open();
                // Thêm tiêu đề hóa đơn
                var titleFont = FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD);
                var normalFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL);

                pdfDoc.Add(new Paragraph("HÓA ĐƠN BÁN HÀNG", titleFont));
                pdfDoc.Add(new Paragraph($"Ngày: {DateTime.Now.ToString("dd/MM/yyyy")}\n\n", normalFont));

                // Thông tin hóa đơn
                pdfDoc.Add(new Paragraph($"Mã hóa đơn: {idHoaDon}", normalFont));
                pdfDoc.Add(new Paragraph($"Ghi chú: {ghiChu}\n\n", normalFont));

                // Thêm bảng chi tiết hóa đơn
                PdfPTable table = new PdfPTable(4); // 4 cột
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 30, 100, 50, 50 }); // Độ rộng các cột

                // Thêm tiêu đề cột
                table.AddCell("STT");
                table.AddCell("Tên sản phẩm");
                table.AddCell("Số lượng");
                table.AddCell("Thành tiền");

                // Thêm dữ liệu từ DataGridView vào bảng
                int stt = 1;
                foreach (DataGridViewRow row in dgvDanhSachHang.Rows)
                {
                    if (row.IsNewRow) continue;

                    table.AddCell(stt.ToString());
                    table.AddCell(row.Cells["TenHang"].Value.ToString());
                    table.AddCell(row.Cells["SoLuong"].Value.ToString());
                    table.AddCell(row.Cells["ThanhTien"].Value.ToString());
                    stt++;
                }

                pdfDoc.Add(table);

                // Thêm tổng tiền
                pdfDoc.Add(new Paragraph($"\nTổng tiền: {tongTien} VND", titleFont));

                pdfDoc.Close();
                writer.Close();

                MessageBox.Show($"Hóa đơn đã được xuất thành công!\nĐường dẫn: {filePath}", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi xuất hóa đơn: {ex.Message}", "Lỗi");
            }
        }
        private void SetupDataGridView()
        {
            dgvDanhSachHang.Columns.Add("MaHang", "Mã Hàng");
            dgvDanhSachHang.Columns.Add("TenHang", "Tên Hàng");
            dgvDanhSachHang.Columns.Add("SoLuong", "Số Lượng");
            dgvDanhSachHang.Columns.Add("DonGia", "Đơn Giá");
            dgvDanhSachHang.Columns.Add("ThanhTien", "Thành Tiền");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
