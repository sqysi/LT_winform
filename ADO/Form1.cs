using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;   // Để ghi file
using System.Text; // Để xử lý tiếng Việt

namespace ADO
{
    public partial class Form1 : Form
    {
        // --- CẤU HÌNH ---
        string strConnect = @"Data Source=QYS\SYQUYS;Database=sale;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            ConfigGridView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        #region Helpers
        private void ConfigGridView()
        {
            dgvCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomer.MultiSelect = false;
            dgvCustomer.ReadOnly = true;
            dgvCustomer.AllowUserToAddRows = false;
            dgvCustomer.AllowUserToDeleteRows = false;
            dgvCustomer.RowHeadersVisible = false;
            dgvCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, name, phone, gender, department FROM customer";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCustomer.DataSource = dt;

                    // Đặt tên cột hiển thị tiếng Việt
                    if (dgvCustomer.Columns.Count > 0)
                    {
                        dgvCustomer.Columns["id"].HeaderText = "Mã NV";
                        dgvCustomer.Columns["name"].HeaderText = "Họ và Tên";
                        dgvCustomer.Columns["phone"].HeaderText = "SĐT";
                        dgvCustomer.Columns["gender"].HeaderText = "Giới Tính";
                        dgvCustomer.Columns["department"].HeaderText = "Phòng Ban";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
                }
            }
        }
        #endregion

        #region Buttons Events
        private void btRead_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            frmCustomer f = new frmCustomer();
            if (f.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.CurrentRow == null) return;

            string id = dgvCustomer.CurrentRow.Cells["id"].Value.ToString();
            string name = dgvCustomer.CurrentRow.Cells["name"].Value.ToString();

            if (MessageBox.Show($"Xóa nhân viên [{name}]?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(strConnect))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM customer WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    LoadData();
                }
            }
        }

        // --- NÚT QUẢN LÝ PHÒNG BAN ---
        private void btDepartment_Click(object sender, EventArgs e)
        {
            frmDepartment f = new frmDepartment();
            f.ShowDialog();
            // Sau khi đóng form phòng ban, load lại danh sách nhân viên
            // để cập nhật tên phòng ban mới (nếu có sửa đổi)
            LoadData();
        }

        // --- NÚT XUẤT EXCEL ---
        private void btExcel_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "DanhSachNhanVien.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ToExcel(dgvCustomer, sfd.FileName);
            }
        }
        #endregion

        #region Excel Logic
        private void ToExcel(DataGridView dgv, string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.Unicode))
                {
                    // Ghi tiêu đề
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        sw.Write(dgv.Columns[i].HeaderText);
                        if (i < dgv.Columns.Count - 1) sw.Write("\t");
                    }
                    sw.WriteLine();

                    // Ghi dữ liệu
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            for (int i = 0; i < dgv.Columns.Count; i++)
                            {
                                string value = row.Cells[i].Value != null ? row.Cells[i].Value.ToString() : "";
                                value = value.Replace("\n", " ").Replace("\r", " ");
                                sw.Write(value);
                                if (i < dgv.Columns.Count - 1) sw.Write("\t");
                            }
                            sw.WriteLine();
                        }
                    }
                }
                MessageBox.Show("Xuất Excel thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất file: " + ex.Message);
            }
        }
        #endregion

        #region Grid Events
        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCustomer.CurrentRow != null)
            {
                var id = dgvCustomer.CurrentRow.Cells["id"].Value;
                if (id != null)
                {
                    frmCustomer f = new frmCustomer(id.ToString());
                    if (f.ShowDialog() == DialogResult.OK) LoadData();
                }
            }
        }
        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        #endregion
    }
}