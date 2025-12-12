using System;
using System.Windows.Forms;

namespace BaiTap
{
    public partial class Article5: Form
    {
        public Article5()
        {
            InitializeComponent();
        }
        // Sự kiện khi Form được tải lên (Slide 52 có khai báo nhưng để trống)
        private void Article5_Load(object sender, EventArgs e)
        {
            // Bạn có thể viết code khởi tạo dữ liệu ở đây
        }

        // Sự kiện khi nhấn nút OK (Slide 52)
        // Hàm này được liên kết nhờ dòng 'this.bt_OK.Click += ...' bên file Designer
        private void bt_OK_Click(object sender, EventArgs e)
        {
            // Trong Slide 52 hàm này đang để trống.
            // Mình thêm dòng này để bạn test thử nút bấm có hoạt động không nhé.
            MessageBox.Show("Bạn vừa nhấn nút OK!");
        }
    }
}