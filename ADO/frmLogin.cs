using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ADO
{
    public class frmLogin : Form
    {
        // Chuỗi kết nối (Nên để giống bên frmDetail)
        string strConnect = @"Data Source=QYS\SYQUYS;Database=sale;Integrated Security=True";

        private TextBox txtUser, txtPass;
        private Button btnLogin, btnExit;

        public frmLogin()
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "Đăng Nhập Hệ Thống";
            this.Size = new Size(400, 250);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Label & TextBox Username
            Label lblUser = new Label { Text = "Tài khoản:", Location = new Point(30, 30), AutoSize = true };
            txtUser = new TextBox { Location = new Point(120, 27), Width = 200 };
            txtUser.Text = "admin"; // Điền sẵn cho tiện test

            // Label & TextBox Password
            Label lblPass = new Label { Text = "Mật khẩu:", Location = new Point(30, 70), AutoSize = true };
            txtPass = new TextBox { Location = new Point(120, 67), Width = 200, UseSystemPasswordChar = true }; // Ẩn mật khẩu
            txtPass.Text = "123";

            // Buttons
            btnLogin = new Button { Text = "Đăng Nhập", Location = new Point(120, 120), Width = 90, Height = 35, BackColor = Color.LightGreen };
            btnExit = new Button { Text = "Thoát", Location = new Point(230, 120), Width = 90, Height = 35, BackColor = Color.IndianRed };

            // Sự kiện
            btnLogin.Click += BtnLogin_Click;
            btnExit.Click += (s, e) => Application.Exit();

            // Nhấn Enter để đăng nhập luôn
            this.AcceptButton = btnLogin;

            this.Controls.AddRange(new Control[] { lblUser, txtUser, lblPass, txtPass, btnLogin, btnExit });
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (CheckLogin(txtUser.Text, txtPass.Text))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Báo hiệu OK để Program.cs biết
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPass.Focus();
                txtPass.SelectAll();
            }
        }

        private bool CheckLogin(string user, string pass)
        {
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                try
                {
                    conn.Open();
                    // Dùng COUNT để kiểm tra xem có dòng nào khớp username và password không
                    string query = "SELECT COUNT(*) FROM tb_admin WHERE username = @u AND password = @p";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Tham số hóa để chống hack SQL Injection
                    cmd.Parameters.AddWithValue("@u", user);
                    cmd.Parameters.AddWithValue("@p", pass);

                    int result = (int)cmd.ExecuteScalar();
                    return result > 0; // Nếu > 0 là có tài khoản này
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message);
                    return false;
                }
            }
        }
    }
}