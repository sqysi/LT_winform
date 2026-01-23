using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ADO
{
    public partial class Form1 : Form
    {
        // --- CẤU HÌNH KẾT NỐI ---
        // Thay tên Server của bạn vào đây
        string strConnect = @"Data Source=QYS\SYQUYS;Database=sale;Integrated Security=True";
        SqlConnection conn = null;

        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection(strConnect);
        }

        // 1. ĐỌC DỮ LIỆU
        private void btRead_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM customer", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCustomer.DataSource = dt;

                if (conn.State == ConnectionState.Open) conn.Close();

                // Đổi tên cột hiển thị cho đẹp
                if (dgvCustomer.Columns.Count >= 4)
                {
                    dgvCustomer.Columns[0].HeaderText = "Mã KH";
                    dgvCustomer.Columns[1].HeaderText = "Họ Tên";
                    dgvCustomer.Columns[2].HeaderText = "SĐT";
                    dgvCustomer.Columns[3].HeaderText = "Giới tính";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // 2. THÊM (Có kiểm tra trùng ID)
        private void btNew_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                // Bước 1: Kiểm tra trùng ID
                if (CheckDuplicateID(txtId.Text))
                {
                    MessageBox.Show("Mã ID này đã tồn tại! Vui lòng nhập mã khác.");
                    return;
                }

                // Bước 2: Thêm mới
                string sql = "INSERT INTO customer (id, name, phone, gender) VALUES (@id, @name, @phone, @gender)";
                RunSQL(sql);
            }
        }

        // 3. XÓA
        private void btDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập Mã ID cần xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sql = "DELETE FROM customer WHERE id = @id";
                RunSQL(sql);
            }
        }

        // 4. SỬA
        private void btEdit_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                // Khi sửa thì ID dùng làm điều kiện tìm kiếm để update các trường khác
                string sql = "UPDATE customer SET name = @name, phone = @phone, gender = @gender WHERE id = @id";
                RunSQL(sql);
            }
        }

        // --- HÀM KIỂM TRA TRÙNG ID ---
        private bool CheckDuplicateID(string id)
        {
            bool isExist = false;
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM customer WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(id));

                int count = (int)cmd.ExecuteScalar(); // Trả về số lượng bản ghi tìm thấy

                if (count > 0) isExist = true;

                if (conn.State == ConnectionState.Open) conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra trùng: " + ex.Message);
            }
            return isExist;
        }

        // --- HÀM CHẠY SQL CHUNG (QUAN TRỌNG: XỬ LÝ GIỚI TÍNH CHUỖI) ---
        private void RunSQL(string sql)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);

                // Thêm tham số ID
                if (!string.IsNullOrEmpty(txtId.Text))
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtId.Text));

                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);

                // --- XỬ LÝ GIỚI TÍNH (CHUỖI) ---
                // Nếu Radio Nam chọn -> Lưu chữ "Nam", ngược lại lưu "Nữ"
                string genderValue = rbMale.Checked ? "Nam" : "Nữ";
                cmd.Parameters.AddWithValue("@gender", genderValue);

                int result = cmd.ExecuteNonQuery();

                if (conn.State == ConnectionState.Open) conn.Close();

                if (result > 0)
                {
                    MessageBox.Show("Thành công!");
                    LoadData(); // Load lại lưới

                    // Xóa trắng form, đặt lại mặc định là Nam
                    txtId.Text = ""; txtName.Text = ""; txtPhone.Text = "";
                    rbMale.Checked = true;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu để thao tác (Kiểm tra Mã ID).");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thao tác SQL: " + ex.Message);
            }
        }

        // --- SỰ KIỆN CLICK VÀO LƯỚI (HIỆN LÊN RADIO) ---
        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomer.Rows[e.RowIndex];

                txtId.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtPhone.Text = row.Cells[2].Value != DBNull.Value ? row.Cells[2].Value.ToString() : "";

                // Xử lý hiển thị RadioButton từ chuỗi
                if (row.Cells[3].Value != DBNull.Value)
                {
                    string gender = row.Cells[3].Value.ToString().Trim(); // Lấy chữ "Nam" hoặc "Nữ"

                    if (gender == "Nam")
                    {
                        rbMale.Checked = true;
                    }
                    else
                    {
                        rbFemale.Checked = true;
                    }
                }
            }
        }

        // Kiểm tra đầu vào cơ bản
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtId.Text) || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã và Tên!");
                return false;
            }
            if (!int.TryParse(txtId.Text, out _))
            {
                MessageBox.Show("Mã ID phải là số nguyên!");
                return false;
            }
            return true;
        }
    }
}