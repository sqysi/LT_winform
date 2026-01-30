using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ADO
{
    public partial class Form1 : Form
    {
        // Chuỗi kết nối (Đã cập nhật theo code bạn gửi)
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

        // --- CẤU HÌNH BẢNG ---
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

        // --- TẢI DỮ LIỆU DANH SÁCH (Chỉ lấy ID và Tên cho nhẹ) ---
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                try
                {
                    conn.Open();
                    // Chỉ lấy các trường cần thiết để hiển thị trên Grid
                    SqlDataAdapter da = new SqlDataAdapter("SELECT id, name, phone, gender FROM customer", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCustomer.DataSource = dt;

                    // Đặt tên cột hiển thị tiếng Việt
                    if (dgvCustomer.Columns.Count > 0)
                    {
                        dgvCustomer.Columns["id"].HeaderText = "Mã NV";
                        dgvCustomer.Columns["id"].FillWeight = 20;
                        dgvCustomer.Columns["name"].HeaderText = "Họ và Tên";
                        dgvCustomer.Columns["name"].FillWeight = 40;
                        dgvCustomer.Columns["phone"].HeaderText = "SĐT";
                        dgvCustomer.Columns["phone"].FillWeight = 25;
                        dgvCustomer.Columns["gender"].HeaderText = "Giới Tính";
                        dgvCustomer.Columns["gender"].FillWeight = 15;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
                }
            }
        }

        private void btRead_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            // Mở form thêm mới (constructor không tham số)
            frmCustomer f = new frmCustomer();
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
                return;
            }

            // Lấy ID dưới dạng chuỗi để khớp với DB
            string id = dgvCustomer.CurrentRow.Cells["id"].Value.ToString();

            if (MessageBox.Show("Bạn chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(strConnect))
                {
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM customer WHERE id = @id", conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Sửa logic: Chỉ cần lấy ID và gọi ShowDetail
            if (e.RowIndex >= 0 && dgvCustomer.CurrentRow != null)
            {
                var cellValue = dgvCustomer.CurrentRow.Cells["id"].Value;
                if (cellValue != null)
                {
                    ShowDetail(cellValue.ToString());
                }
            }
        }

        private void ShowDetail(string id)
        {
            // Truyền ID sang frmDetail, để form đó tự load dữ liệu đầy đủ
            frmDetail f = new frmDetail(id);
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadData(); // Load lại nếu bên detail có sửa/xóa
            }
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}