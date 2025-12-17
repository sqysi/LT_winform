using System;
using System.Windows.Forms;

namespace BaiTap

{
    public partial class Article20 : Form
    {
        public Article20()
        {
            InitializeComponent();
        }

        private void Article20_Load(object sender, EventArgs e)
        {
            // Code ch?y khi form m? lên (n?u c?n)
        }

        // 1. Nút Thêm
        private void btAddNew_Click(object sender, EventArgs e)
        {
            dgvEmployee.Rows.Add(tbId.Text, tbName.Text, tbAge.Text, ckGender.Checked);

            // Xóa tr?ng ô nh?p sau khi thêm
            tbId.Text = ""; tbName.Text = ""; tbAge.Text = ""; ckGender.Checked = false;
        }

        // 2. Nút Xóa
        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.CurrentRow != null && !dgvEmployee.CurrentRow.IsNewRow)
            {
                int idx = dgvEmployee.CurrentCell.RowIndex;
                dgvEmployee.Rows.RemoveAt(idx);
            }
        }

        // 3. S? ki?n Click vào dòng (S?a l?i CS8600 - Ki?m tra null an toàn)
        private void dgvEmployee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;

            // Ki?m tra dòng h?p l?
            if (idx >= 0 && idx < dgvEmployee.Rows.Count - 1)
            {
                // L?y dòng hi?n t?i
                DataGridViewRow row = dgvEmployee.Rows[idx];

                // L?y Mã (Ki?m tra null tr??c khi .ToString())
                if (row.Cells[0].Value != null)
                    tbId.Text = row.Cells[0].Value.ToString();
                else
                    tbId.Text = "";

                // L?y Tên
                if (row.Cells[1].Value != null)
                    tbName.Text = row.Cells[1].Value.ToString();
                else
                    tbName.Text = "";

                // L?y Tu?i
                if (row.Cells[2].Value != null)
                    tbAge.Text = row.Cells[2].Value.ToString();
                else
                    tbAge.Text = "";

                // L?y Gi?i tính (Checkbox)
                // Fix l?i c?nh báo vàng ? ?ây b?ng cách ki?m tra k?
                object genderValue = row.Cells[3].Value;
                if (genderValue != null)
                {
                    bool isMale;
                    // Th? ép ki?u sang bool, n?u thành công thì gán, th?t b?i thì thôi
                    if (bool.TryParse(genderValue.ToString(), out isMale))
                    {
                        ckGender.Checked = isMale;
                    }
                }
                else
                {
                    ckGender.Checked = false;
                }
            }
        }

        // 4. Nút Thoát (S?a l?i CS0104 - Ambiguous reference)
        private void btExit_Click(object sender, EventArgs e)
        {
            // S?A L?I: G?i ??y ?? tên th? vi?n ?? máy không b? nh?m
            System.Windows.Forms.Application.Exit();
        }
    }
}