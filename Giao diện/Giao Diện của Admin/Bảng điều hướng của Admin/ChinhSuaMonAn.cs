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
    public partial class ChinhSuaMonAn : Form
    {
        public ChinhSuaMonAn()
        {
            InitializeComponent();
        }
        private void ChinhSuaMonAn_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            LoadLoaiDataIntoComboBox();
            LoadDrinkData();
            btnUpdate.Enabled = false;
            btnExitEdit.Visible = false;
            btnEdit.Enabled = true;
        }

        private void ChinhSuaMonAn_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

      

        private void LoadLoaiDataIntoComboBox()
        {
            try
            {
                cmbDanhMuc.Items.Clear(); // Clear existing items before reloading

                string query = "SELECT idLoai FROM Loai";

                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbDanhMuc.Items.Add(reader["idLoai"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu loại: " + ex.Message);
            }
        }


       

        private void LoadDrinkData()
        {
            try
            {
                // 1. Tạo câu truy vấn SQL (lấy dữ liệu từ bảng Drink)
                string query = "SELECT IdDrink, Name, price, idLoai FROM Drink";

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

                        // 6. Gán DataTable cho DataSource của DataGridView (dgvCSMA)
                        dgvCSMA.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu Drink: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string idDrink = txtSTT.Text;
                string name = txtTenMon.Text;
                decimal price;
                if (!decimal.TryParse(txtGia.Text, out price))
                {
                    MessageBox.Show("Giá tiền không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string idLoai = cmbDanhMuc.SelectedItem?.ToString();

                // Validation (similar to your QLTK form)
                if (string.IsNullOrWhiteSpace(idDrink))
                {
                    MessageBox.Show("Vui lòng nhập số thứ tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // ... (other validations for name, price, idLoai)

                // Check if idDrink already exists
                string queryCheck = "SELECT COUNT(*) FROM Drink WHERE IdDrink = @IdDrink";
                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(queryCheck, connection))
                    {
                        command.Parameters.AddWithValue("@IdDrink", idDrink);
                        int count = (int)command.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Số thứ tự đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                // Insert into Drink table
                string query = "INSERT INTO Drink (IdDrink, Name, price, idLoai) VALUES (@IdDrink, @Name, @price, @idLoai)";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@IdDrink", idDrink },
                    { "@Name", name },
                    { "@price", price },
                    { "@idLoai", idLoai }
                };

                Modify modify = new Modify();
                modify.Command(query, parameters);

                LoadDrinkData(); // Refresh DataGridView

                // Clear input fields
                txtSTT.Clear();
                txtTenMon.Clear();
                txtGia.Clear();
                cmbDanhMuc.SelectedIndex = -1;

                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm món ăn: " + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           
            btnExitEdit.Visible = true;
            if (dgvCSMA.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCSMA.SelectedRows[0];
                string idDrink = selectedRow.Cells["STT"].Value?.ToString();

                if (string.IsNullOrEmpty(idDrink))
                {
                    btnEdit.Enabled = false;
                }
                else
                {
                    try
                    {
                        txtSTT.Text = selectedRow.Cells["STT"].Value.ToString();
                        txtTenMon.Text = selectedRow.Cells["TenMon"].Value.ToString();
                        txtGia.Text = selectedRow.Cells["GiaTien"].Value.ToString();

                        // Set SelectedIndex of cmbDanhMuc
                        string idLoai = selectedRow.Cells["DanhMuc"].Value.ToString();
                        cmbDanhMuc.SelectedIndex = cmbDanhMuc.FindStringExact(idLoai);

                        txtSTT.Enabled = false;

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
                MessageBox.Show("Vui lòng chọn món ăn cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string idDrink = txtSTT.Text;
                string name = txtTenMon.Text;
                decimal price;
                if (!decimal.TryParse(txtGia.Text, out price))
                {
                    MessageBox.Show("Giá tiền không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string idLoai = cmbDanhMuc.SelectedItem?.ToString();

                // Validation (similar to your QLTK form)
                // ... (validations for name, price, idLoai)

                string query = "UPDATE Drink SET Name = @Name, price = @price, idLoai = @idLoai " +
                               "WHERE IdDrink = @IdDrink";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@IdDrink", idDrink },
                    { "@Name", name },
                    { "@price", price },
                    { "@idLoai", idLoai }
                };

                Modify modify = new Modify();
                modify.Command(query, parameters);

                LoadDrinkData(); // Refresh DataGridView

                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnUpdate.Enabled = false;

                // Clear input fields and reset buttons
                txtSTT.Clear();
                txtTenMon.Clear();
                txtGia.Clear();
                cmbDanhMuc.SelectedIndex = -1;
                txtSTT.Enabled = true;


                btnAdd.Enabled = true;
                btnUpdate.Enabled = true;
                btnExitEdit.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin món ăn: " + ex.Message);
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

                txtSTT.Enabled = true;

                // Clear input fields
                txtSTT.Clear();
                txtTenMon.Clear();
                txtGia.Clear();
                cmbDanhMuc.SelectedIndex = -1;
            }

            // Enable Delete button if a row is selected
            if (dgvCSMA.SelectedRows.Count > 0)
            {
                string idDrink = dgvCSMA.SelectedRows[0].Cells["STT"].Value?.ToString();
                btnEdit.Enabled = !string.IsNullOrEmpty(idDrink);
            }
            else
            {
                btnEdit.Enabled = true; // No row selected
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCSMA.SelectedRows.Count > 0)
                {
                    string idDrink = dgvCSMA.SelectedRows[0].Cells["STT"].Value.ToString();

                    if (string.IsNullOrEmpty(idDrink))
                    {
                        MessageBox.Show("Không thể xóa dữ liệu trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa món ăn có số thứ tự '{idDrink}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        string query = "DELETE FROM Drink WHERE IdDrink = @IdDrink";

                        Dictionary<string, object> parameters = new Dictionary<string, object>
                        {
                            { "@IdDrink", idDrink }
                        };

                        Modify modify = new Modify();
                        modify.Command(query, parameters);

                        LoadDrinkData(); // Refresh DataGridView

                        MessageBox.Show("Xóa món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn món ăn cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa món ăn: " + ex.Message);
            }
        
         }

        private void dgvCSMA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if a valid row is clicked
            {
                DataGridViewRow selectedRow = dgvCSMA.Rows[e.RowIndex];
                string idDrink = selectedRow.Cells["STT"].Value?.ToString();

                // Disable btnEdit if STT is null
                btnEdit.Enabled = !string.IsNullOrEmpty(idDrink);
                btnDelete.Enabled = !string.IsNullOrEmpty(idDrink);
                btnUpdate.Enabled = false;

            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadLoaiDataIntoComboBox();
        }
    }
}
