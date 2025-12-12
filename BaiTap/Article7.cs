using System;
using System.Windows.Forms;

namespace BaiTap
{
    public partial class Article7 : Form
    {
        public Article7()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Article7_FormClosing);
        }

        // Code nút OK (Giữ nguyên từ bài trước)
        private void bt_OK_Click(object sender, EventArgs e)
        {
            string name = tb_Name.Text;
            string date = dtp_Date.Value.ToString("dd/MM/yyyy");
            string isShown = cb_Show.Checked ? "Checked" : "Unchecked";
            string info = $"User: {name} | Date: {date} | Status: {isShown}";

            if (!string.IsNullOrWhiteSpace(name))
            {
                lb_Selected.Items.Add(info);
                tb_Name.Clear();
                tb_Name.Focus();
            }
            else
            {
                // Sử dụng MessageBox để báo lỗi
                MessageBox.Show("Vui lòng nhập tên trước khi thêm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // --- CODE MỚI CHO ARTICLE 07 ---

        // 1. Xử lý nút Remove (Xóa phần tử)
        private void bt_Remove_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng có chọn dòng nào trong ListBox không?
            // SelectedIndex = -1 nghĩa là chưa chọn gì cả.
            if (lb_Selected.SelectedIndex != -1)
            {
                // Hiện hộp thoại hỏi xác nhận
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa dòng này không?", // Nội dung thông báo
                    "Xác nhận xóa",                              // Tiêu đề hộp thoại
                    MessageBoxButtons.YesNo,                     // Nút hiển thị (Yes/No)
                    MessageBoxIcon.Question                      // Icon hiển thị (Dấu hỏi)
                );

                // Nếu người dùng bấm Yes
                if (result == DialogResult.Yes)
                {
                    // Xóa dòng đang chọn
                    lb_Selected.Items.RemoveAt(lb_Selected.SelectedIndex);
                    MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dòng nào để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2. Xử lý sự kiện khi tắt chương trình
        private void Article7_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có muốn thoát chương trình không?",
                "Thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Nếu người dùng bấm No (Không muốn thoát)
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Hủy lệnh đóng form -> Form sẽ giữ nguyên không tắt
            }
        }
    }
}
