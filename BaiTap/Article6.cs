using System;
using System.Windows.Forms;

namespace BaiTap
{
    public partial class Article6 : Form
    {
        public Article6()
        {
            InitializeComponent();
        }

        // S? ki?n khi nh?n nút OK
        private void bt_OK_Click(object sender, EventArgs e)
        {
            // 1. L?y d? li?u t? TextBox
            string name = tb_Name.Text;

            // 2. L?y d? li?u t? DateTimePicker (??nh d?ng ngày/tháng/n?m)
            string date = dtp_Date.Value.ToString("dd/MM/yyyy");

            // 3. Ki?m tra CheckBox có ???c ch?n không
            string isShown = cb_Show.Checked ? "Checked" : "Unchecked";

            // 4. T?o chu?i thông tin t?ng h?p
            // Ví d?: "User: Nguyen Van A | Date: 12/12/2025 | Status: Checked"
            string info = $"User: {name} | Date: {date} | Status: {isShown}";

            // 5. Thêm thông tin vào ListBox
            if (!string.IsNullOrWhiteSpace(name)) // Ch? thêm n?u có nh?p tên
            {
                lb_Selected.Items.Add(info);

                // Tùy ch?n: Xóa tr?ng ô nh?p tên sau khi thêm xong
                tb_Name.Clear();
                tb_Name.Focus();
            }
            else
            {
                MessageBox.Show("Vui lòng nh?p tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
