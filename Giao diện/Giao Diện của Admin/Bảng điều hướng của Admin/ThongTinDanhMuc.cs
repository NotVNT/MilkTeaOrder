using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using OrderMillTeaProgram.Database;

namespace OrderMillTeaProgram.Giao_diện.Giao_Diện_của_Admin
{
    public partial class ThongTinDanhMuc : Form
    {
        public ThongTinDanhMuc()
        {
            InitializeComponent();
        }


        private void ThongTinDanhMuc_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            LoadLoaiData();
            btnUpdate.Enabled = false;
            btnExitEdit.Visible = false;
            btnEdit.Enabled = true;
        }

        private void LoadLoaiData()
        {
            // 1. Tạo câu truy vấn SQL
            string query = "SELECT idLoai, TenLoai FROM Loai"; // Adjust column names if needed

            // 2. Tạo kết nối đến database
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();

                // 3. Tạo SqlDataAdapter để lấy dữ liệu
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    // 4. Tạo DataTable để chứa dữ liệu
                    DataTable dt = new DataTable();

                    // 5. Đổ dữ liệu từ database vào DataTable
                    adapter.Fill(dt);

                    // 6. Gán DataTable cho DataSource của DataGridView
                    dgvLoai.DataSource = dt;
                }
            }
        }

        private void ThongTinDanhMuc_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string idLoai = txtMaLoai.Text;
                string tenLoai = txtTenLoai.Text;

                if (string.IsNullOrWhiteSpace(idLoai))
                {
                    MessageBox.Show("Vui lòng nhập mã loại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrWhiteSpace(tenLoai))
                {
                    MessageBox.Show("Vui lòng nhập tên loại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Kiểm tra idLoai đã tồn tại chưa
                string queryCheck = "SELECT COUNT(*) FROM Loai WHERE idLoai = @idLoai";
                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(queryCheck, connection))
                    {
                        command.Parameters.AddWithValue("@idLoai", idLoai);
                        int count = (int)command.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Mã loại đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                string query = "INSERT INTO Loai (idLoai, TenLoai) VALUES (@idLoai, @TenLoai)";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@idLoai", idLoai },
                    { "@TenLoai", tenLoai }
                };

                Modify modify = new Modify();
                modify.Command(query, parameters);

                LoadLoaiData();

                txtMaLoai.Clear();
                txtTenLoai.Clear();

                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm loại: " + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnExitEdit.Visible = true;
            if (dgvLoai.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvLoai.SelectedRows[0];
                string idLoai = selectedRow.Cells["MaLoai"].Value?.ToString();

                if (string.IsNullOrEmpty(idLoai))
                {
                    btnEdit.Enabled = false;
                }
                else
                {
                    try
                    {
                        txtMaLoai.Text = selectedRow.Cells["MaLoai"].Value.ToString();
                        txtTenLoai.Text = selectedRow.Cells["NameLoai"].Value.ToString();

                        txtMaLoai.Enabled = false;

                        btnEdit.Enabled = true;
                        btnAdd.Enabled = false;
                        btnDelete.Enabled = true;
                        btnUpdate.Enabled = true;
                        btnExitEdit.Visible = true;
                    }
                    catch (NullReferenceException ex)
                    {
                        MessageBox.Show("Lỗi: Một số cột không có giá trị. " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string idLoai = txtMaLoai.Text;
                string tenLoai = txtTenLoai.Text;

                if (string.IsNullOrWhiteSpace(tenLoai))
                {
                    MessageBox.Show("Vui lòng nhập tên loại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string query = "UPDATE Loai SET TenLoai = @TenLoai WHERE idLoai = @idLoai";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@idLoai", idLoai },
                    { "@TenLoai", tenLoai }
                };

                Modify modify = new Modify();
                modify.Command(query, parameters);

                LoadLoaiData();

                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtMaLoai.Clear();
                txtTenLoai.Clear();

                btnAdd.Enabled = true;
                btnUpdate.Enabled = false;
                btnExitEdit.Visible = false;

                txtMaLoai.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin loại: " + ex.Message);
            }
        }

        private void btnExitEdit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chỉnh sửa không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                btnAdd.Enabled = true;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
                btnExitEdit.Visible = false;

                txtMaLoai.Enabled = true;

                txtMaLoai.Clear();
                txtTenLoai.Clear();

                btnEdit.Enabled = true;

            }
            if (dgvLoai.SelectedRows.Count > 0 &&
                !string.IsNullOrEmpty(dgvLoai.SelectedRows[0].Cells["MaLoai"].Value?.ToString()))
              
            {
                btnEdit.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLoai.SelectedRows.Count > 0)
                {
                    string idLoai = dgvLoai.SelectedRows[0].Cells["MaLoai"].Value.ToString();

                    if (string.IsNullOrEmpty(idLoai))
                    {
                        MessageBox.Show("Không thể xóa dữ liệu trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa loại có mã '{idLoai}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        string query = "DELETE FROM Loai WHERE idLoai = @idLoai";

                        Dictionary<string, object> parameters = new Dictionary<string, object>
                        {
                            { "@idLoai", idLoai }
                        };

                        Modify modify = new Modify();
                        modify.Command(query, parameters);

                        LoadLoaiData();

                        MessageBox.Show("Xóa loại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn loại cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa loại: " + ex.Message);
            }
        }

        private void dgvLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if a valid row is clicked
            {
                DataGridViewRow selectedRow = dgvLoai.Rows[e.RowIndex];
                string idDrink = selectedRow.Cells["MaLoai"].Value?.ToString();

                // Disable btnEdit if STT is null
                btnEdit.Enabled = !string.IsNullOrEmpty(idDrink);
                btnDelete.Enabled = !string.IsNullOrEmpty(idDrink);
                btnUpdate.Enabled = false;

            }
            else
            {
                btnEdit.Enabled = false; 
                btnDelete.Enabled = false;
            }

        }

        private void txtTimTen_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtTimTen.Text.Trim();

            // 1. Tạo câu truy vấn SQL với điều kiện WHERE
            string query = @"SELECT idLoai, TenLoai 
                            FROM Loai
                            WHERE LOWER(idLoai) LIKE @searchName 
                                OR LOWER(TenLoai) LIKE @searchName";

            // 2. Tạo kết nối đến database
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();

                // 3. Tạo SqlDataAdapter với câu truy vấn và tham số
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    // Chuyển đổi searchText sang chữ thường và thêm ký tự đại diện
                    string searchValue = "%" + searchText.ToLower() + "%";
                    adapter.SelectCommand.Parameters.AddWithValue("@searchName", searchValue);

                    // 4. Tạo DataTable để chứa dữ liệu
                    DataTable dt = new DataTable();

                    // 5. Đổ dữ liệu từ database vào DataTable
                    adapter.Fill(dt);

                    // 6. Gán DataTable cho DataSource của DataGridView
                    dgvLoai.DataSource = dt;
                }
            }
        }
    }
}
