using System;
using System.Windows.Forms;

namespace ADO
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Khởi tạo Form Login
            frmLogin loginForm = new frmLogin();

            // 2. Hiện Form Login dưới dạng hộp thoại (Dialog)
            // Nếu người dùng đăng nhập thành công, DialogResult sẽ là OK
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // 3. Nếu Login OK -> Chạy Form chính (Danh sách nhân viên)
                // Giả sử Form danh sách của bạn tên là Form1
                Application.Run(new Form1());
            }
            else
            {
                // Nếu tắt form login hoặc login thất bại -> Thoát luôn
                Application.Exit();
            }
        }
    }
}