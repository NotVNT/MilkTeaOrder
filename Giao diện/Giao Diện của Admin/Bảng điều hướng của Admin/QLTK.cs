using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;



namespace OrderMillTeaProgram.Giao_diện.Giao_Diện_của_Admin
{
    public partial class QLTK : Form
    {

        public QLTK()
        {
            InitializeComponent();
        }

        private void QLTK_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void QLTK_Load(object sender, EventArgs e)
        {

            this.ControlBox = false;
            LoadUserInfo();
            cmbChucVu.SelectedIndex = cmbChucVu.FindStringExact("Người dùng");
            btnUpdate.Enabled = false;
            btnExitEdit.Visible = false;
        }

        private void LoadUserInfo()
        {
            // 1. Tạo câu truy vấn SQL
            string query = "SELECT UserName, HoTen, Email, SDT, Role FROM UserInfo";

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
                    dgvQLTK.DataSource = dt;

                    
                }
            }
        }

        public bool CheckEmail(string checkEm)
        {
            return Regex.IsMatch(checkEm, @"^[a-zA-Z0-9_.]{4,20}@gmail.com(.vn|)$");
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                string userName = txtTenTaiKhoan.Text;
                string password = txtMatKhau.Text; // No hashing here
                string hoTen = txtHoTen.Text;
                string sdt = txtSDT.Text;
                string email = txtEmail.Text;
                string role = cmbChucVu.SelectedItem.ToString();


                if (string.IsNullOrWhiteSpace(userName) || userName.Length < 6 || userName.Length > 26)
                {
                    MessageBox.Show("Vui lòng nhập tên tài khoản có độ dài từ 6-26 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu có độ dài từ 8 ký tự trở lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!CheckEmail(email))
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng Email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!Regex.IsMatch(sdt, @"^0\d{9,10}$"))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại hợp lệ (bắt đầu bằng 0, tối đa 11 chữ số)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Modify modify = new Modify();


                if (modify.CheckExistingUser(userName, email))
                {
                    MessageBox.Show("Tên tài khoản hoặc Email này đã tồn tại. Vui lòng chọn tên tài khoản hoặc Email khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                string query = "INSERT INTO UserInfo (UserName, HoTen, Password, Email, SDT, Role) " +
                               "VALUES (@UserName, @HoTen, @Password, @Email, @SDT, @Role)";


                Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "@UserName", userName },
            { "@HoTen", hoTen },
            { "@Password", password },  
            { "@Email", email },
            { "@SDT", sdt },
            { "@Role", role }
        };


                modify.Command(query, parameters);


                LoadUserInfo();


                txtTenTaiKhoan.Clear();
                txtMatKhau.Clear();
                txtHoTen.Clear();
                txtEmail.Clear();
                txtSDT.Clear();

                cmbChucVu.SelectedIndex = cmbChucVu.FindStringExact("Người dùng");



                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm người dùng: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Kiểm tra xem có dòng nào được chọn trong DataGridView hay không
                if (dgvQLTK.SelectedRows.Count > 0)
                {
                    // 2. Lấy UserName từ dòng được chọn
                    string userName = dgvQLTK.SelectedRows[0].Cells["UserName"].Value.ToString();

                    // 3. Kiểm tra xem UserName có null hay không
                    if (string.IsNullOrEmpty(userName))
                    {
                        MessageBox.Show("Không thể xóa dữ liệu trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Thoát khỏi hàm nếu UserName là null
                    }
                    if (userName.ToLower() == "admin")
                    {
                        MessageBox.Show("Không thể xóa tài khoản admin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Thoát khỏi hàm nếu userName là "admin"
                    }

                    // 4. Xác nhận xóa (nếu UserName không null)
                    DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa tài khoản '{userName}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        // 5. Tạo câu truy vấn SQL để xóa
                        string query = "DELETE FROM UserInfo WHERE UserName = @UserName";

                        // 6. Tạo Dictionary để chứa tham số
                        Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@UserName", userName }
                };

                        // 7. Thực thi câu truy vấn xóa
                        Modify modify = new Modify();
                        modify.Command(query, parameters);

                        // 8. Cập nhật lại DataGridView
                        LoadUserInfo();

                        MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                   
                }

                else
                {
                    MessageBox.Show("Vui lòng chọn tài khoản cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa tài khoản: " + ex.Message);
            }
        }

        private void dgvQLTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex >= 0) // Kiểm tra xem có dòng nào được chọn hay không
            {
                DataGridViewRow selectedRow = dgvQLTK.Rows[e.RowIndex];
                string userName = selectedRow.Cells["UserName"].Value?.ToString(); // Lấy giá trị UserName, xử lý null

                if (string.IsNullOrEmpty(userName)) // Kiểm tra xem UserName có null hay rỗng không
                {
                    btnDelete.Enabled = false; // Vô hiệu hóa nút Xóa
                    btnEdit.Enabled = false;    
                    btnUpdate.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true; // Kích hoạt nút Xóa nếu dòng hợp lệ
                    btnEdit.Enabled = true;
                  
                }
                if (btnUpdate.Enabled)
                {
                    btnUpdate.Enabled = false; // Disable btnUpdate after cell click
                }
            }
        }

        private void txtTimTen_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtTimTen.Text.Trim();

            // 1. Tạo câu truy vấn SQL với điều kiện WHERE
            string query = @"SELECT UserName, HoTen, Email, SDT, Role 
                     FROM UserInfo 
                     WHERE LOWER(UserName) LIKE @searchName 
                        OR LOWER(HoTen) LIKE @searchName";

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
                    dgvQLTK.DataSource = dt;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnExitEdit.Visible = true;
            if (dgvQLTK.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvQLTK.SelectedRows[0];
                string userName = selectedRow.Cells["UserName"].Value?.ToString();

                if (string.IsNullOrEmpty(userName))
                {
                    btnEdit.Enabled = false; // Vô hiệu hóa nút Edit
                                             // Hoặc bạn có thể ẩn nút Edit: btnEdit.Visible = false;
                }
                else
                {
                    try
                    {
                        // Lấy thông tin từ dòng được chọn và hiển thị lên các textbox
                        txtTenTaiKhoan.Text = selectedRow.Cells["UserName"].Value.ToString();
                        txtHoTen.Text = selectedRow.Cells["HoTen"].Value.ToString();
                        txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                        txtSDT.Text = selectedRow.Cells["SDT"].Value.ToString();

                        // Xử lý cmbChucVu
                        string role = selectedRow.Cells["Role"].Value.ToString();
                        cmbChucVu.SelectedIndex = cmbChucVu.FindStringExact(role);

                        // Vô hiệu hóa textbox tên tài khoản vì không được phép sửa
                        txtTenTaiKhoan.Enabled = false;

                        // Ẩn txtMatKhau
                        txtMatKhau.Visible = false;

                        // Kích hoạt nút Edit (nếu trước đó bị vô hiệu hóa)
                        btnEdit.Enabled = true;
                        // Kích hoạt nút Update (nếu trước đó bị vô hiệu hóa)
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
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //Kiểm tra Email khi nhấn nút btnUpdate nếu Email đã tồn tài  trên hệ thống thì sẽ thông báo cho người chỉnh sửa YÊU CẦU NHẬP EMAIL KHÁC
        private string GetOriginalEmail(string userName)
        {
            string originalEmail = "";
            string query = "SELECT Email FROM UserInfo WHERE UserName = @UserName";

            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", userName);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            originalEmail = reader["Email"].ToString();
                        }
                    }
                }
            }
            return originalEmail;
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtTenTaiKhoan.Text;
                string hoTen = txtHoTen.Text;
                string sdt = txtSDT.Text;
                string email = txtEmail.Text;
                string role = cmbChucVu.SelectedItem.ToString();

                // Kiểm tra số điện thoại
                if (!Regex.IsMatch(sdt, @"^0\d{9,10}$"))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại hợp lệ (bắt đầu bằng 0, tối đa 11 chữ số)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Kiểm tra định dạng email
                if (!CheckEmail(email))
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng Email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Kiểm tra email đã tồn tại (trừ email của user hiện tại)
                Modify modify = new Modify();
                string originalEmail = GetOriginalEmail(userName); // You'll need to implement this function

                if (email != originalEmail && modify.CheckExistingEmail(email))
                {
                    MessageBox.Show("Email này đã tồn tại trên hệ thống. Vui lòng chọn Email khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                // Kiểm tra dữ liệu đầu vào khác (tương tự như btnAdd_Click) ...

                string query = "UPDATE UserInfo SET HoTen = @HoTen, Email = @Email, SDT = @SDT, Role = @Role " +
                                "WHERE UserName = @UserName";

                Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "@UserName", userName },
            { "@HoTen", hoTen },
            { "@Email", email },
            { "@SDT", sdt },
            { "@Role", role }
        };


                modify.Command(query, parameters);

                LoadUserInfo(); // Cập nhật lại DataGridView

                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtTenTaiKhoan.Clear();
                txtHoTen.Clear();
                txtEmail.Clear();
                txtSDT.Clear();
                cmbChucVu.SelectedIndex = cmbChucVu.FindStringExact("Người dùng");

                btnAdd.Enabled = true;
                btnUpdate.Enabled = true;
                btnExitEdit.Visible = false;

                txtTenTaiKhoan.Enabled = true;
                txtMatKhau.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin người dùng: " + ex.Message);
            }
        }

        private void btnExitEdit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chỉnh sửa không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = false;
                btnExitEdit.Visible = false;

                txtTenTaiKhoan.Enabled = true;
                txtMatKhau.Visible = true;

                txtTenTaiKhoan.Clear() ;
                txtHoTen.Clear() ;
                txtSDT.Clear() ;
                txtEmail.Clear() ;
                cmbChucVu.SelectedIndex = cmbChucVu.FindStringExact("Người dùng");
            }
        }
    }
}
