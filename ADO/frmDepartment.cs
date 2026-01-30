using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ADO
{
    public class frmDepartment : Form
    {
        string strConnect = @"Data Source=QYS\SYQUYS;Database=sale;Integrated Security=True";

        // Controls
        DataGridView dgvDept;
        TextBox txtName;
        Button btAdd, btDelete, btClose, btCancel;
        Label lbInfo;

        int _currentId = 0; // 0: Thêm mới, >0: Đang sửa ID này

        public frmDepartment()
        {
            // --- GIAO DIỆN (Code tạo giao diện giữ nguyên) ---
            this.Text = "Quản Lý Phòng Ban";
            this.Size = new Size(500, 480);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            Label lbTitle = new Label() { Text = "Tên Phòng Ban:", Location = new Point(20, 25), AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold) };
            txtName = new TextBox() { Location = new Point(150, 22), Size = new Size(200, 25) };

            btAdd = new Button() { Text = "Thêm / Lưu", Location = new Point(360, 20), Size = new Size(100, 30), BackColor = Color.LightGreen };
            btCancel = new Button() { Text = "Hủy Sửa", Location = new Point(360, 55), Size = new Size(100, 30), Visible = false };

            lbInfo = new Label() { Text = "Danh sách:", Location = new Point(20, 80), AutoSize = true, ForeColor = Color.Blue };

            dgvDept = new DataGridView()
            {
                Location = new Point(20, 100),
                Size = new Size(440, 280),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                RowHeadersVisible = false
            };

            btDelete = new Button() { Text = "Xóa Chọn", Location = new Point(20, 390), Size = new Size(100, 35), BackColor = Color.IndianRed, ForeColor = Color.White };
            btClose = new Button() { Text = "Đóng", Location = new Point(360, 390), Size = new Size(100, 35) };

            this.Controls.AddRange(new Control[] { lbTitle, txtName, btAdd, btCancel, lbInfo, dgvDept, btDelete, btClose });

            // --- SỰ KIỆN ---
            this.Load += (s, e) => LoadData();
            btAdd.Click += BtAdd_Click;
            btDelete.Click += BtDelete_Click;
            btCancel.Click += (s, e) => ResetInput();
            btClose.Click += (s, e) => this.Close();
            dgvDept.CellClick += DgvDept_CellClick;
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM department", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvDept.DataSource = dt;
                    if (dgvDept.Columns["name"] != null) dgvDept.Columns["name"].HeaderText = "Tên Phòng Ban";
                    if (dgvDept.Columns["id"] != null) dgvDept.Columns["id"].Visible = false; // Ẩn cột ID cho đẹp
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {
            // 1. VALIDATE RỖNG
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phòng ban!"); return;
            }

            string name = txtName.Text.Trim();

            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                conn.Open();

                // 2. VALIDATE TRÙNG TÊN
                string sqlCheck = "SELECT COUNT(*) FROM department WHERE name = @name AND id != @id";
                SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn);
                cmdCheck.Parameters.AddWithValue("@name", name);
                cmdCheck.Parameters.AddWithValue("@id", _currentId);

                if ((int)cmdCheck.ExecuteScalar() > 0)
                {
                    MessageBox.Show("Tên phòng ban này đã tồn tại!", "Trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. XỬ LÝ LƯU (CÓ UPDATE ĐỒNG BỘ)
                SqlCommand cmd = new SqlCommand("", conn);
                if (_currentId == 0)
                {
                    // --- TRƯỜNG HỢP THÊM MỚI ---
                    cmd.CommandText = "INSERT INTO department (name) VALUES (@name)";
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    // --- TRƯỜNG HỢP CẬP NHẬT (QUAN TRỌNG) ---

                    // B1: Lấy tên cũ trước khi sửa
                    string oldName = "";
                    SqlCommand cmdGetOld = new SqlCommand("SELECT name FROM department WHERE id = @id", conn);
                    cmdGetOld.Parameters.AddWithValue("@id", _currentId);
                    object result = cmdGetOld.ExecuteScalar();
                    if (result != null) oldName = result.ToString();

                    // B2: Cập nhật tên mới trong bảng department
                    cmd.CommandText = "UPDATE department SET name = @name WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", _currentId);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();

                    // B3: Cập nhật đồng bộ sang bảng customer (Nếu tên thay đổi)
                    if (!string.IsNullOrEmpty(oldName) && oldName != name)
                    {
                        // Sửa tất cả nhân viên có phòng ban là tên cũ -> thành tên mới
                        string sqlCascade = "UPDATE customer SET department = @newName WHERE department = @oldName";
                        SqlCommand cmdCascade = new SqlCommand(sqlCascade, conn);
                        cmdCascade.Parameters.AddWithValue("@newName", name);
                        cmdCascade.Parameters.AddWithValue("@oldName", oldName);
                        cmdCascade.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Thành công!");
                LoadData();
                ResetInput();
            }
        }

        private void BtDelete_Click(object sender, EventArgs e)
        {
            if (_currentId == 0) { MessageBox.Show("Chọn phòng ban cần xóa!"); return; }

            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                conn.Open();

                // 3. VALIDATE RÀNG BUỘC DỮ LIỆU
                // Kiểm tra cả theo ID và theo Tên (vì dữ liệu cũ có thể lưu tên)
                string sqlCheck = "SELECT COUNT(*) FROM customer WHERE department = @idStr OR department = @name";

                SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn);
                cmdCheck.Parameters.AddWithValue("@idStr", _currentId.ToString());
                cmdCheck.Parameters.AddWithValue("@name", txtName.Text);

                int count = (int)cmdCheck.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show($"Không thể xóa! Đang có {count} nhân viên thuộc phòng ban này.\nHãy chuyển nhân viên sang phòng khác trước.", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                // Xóa
                if (MessageBox.Show("Xóa phòng ban này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SqlCommand cmdDel = new SqlCommand("DELETE FROM department WHERE id = @id", conn);
                    cmdDel.Parameters.AddWithValue("@id", _currentId);
                    cmdDel.ExecuteNonQuery();
                    LoadData();
                    ResetInput();
                }
            }
        }

        private void DgvDept_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDept.CurrentRow != null)
            {
                _currentId = Convert.ToInt32(dgvDept.CurrentRow.Cells["id"].Value);
                txtName.Text = dgvDept.CurrentRow.Cells["name"].Value.ToString();
                btAdd.Text = "Cập nhật";
                btCancel.Visible = true;
            }
        }

        private void ResetInput()
        {
            txtName.Text = "";
            _currentId = 0;
            btAdd.Text = "Thêm / Lưu";
            btCancel.Visible = false;
            dgvDept.ClearSelection();
        }
    }
}