using System;
using System.Drawing;
using System.Windows.Forms;

namespace BaiTap
{
    public partial class Article19 : Form
    {
        public Article19()
        {
            InitializeComponent();
        }

        // S? ki?n khi b?m nút "Ch?n ?nh ..." (btFile)
        // Code d?a trên Slide 129
        private void btFile_Click(object sender, EventArgs e)
        {
            // 1. Cài ??t ch? ?? hi?n th? ?nh co dãn (Stretch)
            pbImage.SizeMode = PictureBoxSizeMode.StretchImage;

            // 2. Kh?i t?o h?p tho?i m? file
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Image"; // Tiêu ?? h?p tho?i

            // B? l?c ch? l?y file .jpg (nh? slide yêu c?u)
            // B?n có th? m? r?ng thêm: "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            dlg.Filter = "JPEG files (*.jpg)|*.jpg";

            // 3. Hi?n th? h?p tho?i và ki?m tra n?u ng??i dùng b?m OK
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Gán ???ng d?n file ?nh vào PictureBox
                pbImage.ImageLocation = dlg.FileName;
            }
        }

        // S? ki?n Form Load (Tùy ch?n: ?? cài ??t d? li?u m?u ban ??u n?u c?n)
        private void Article19_Load(object sender, EventArgs e)
        {
            // Code này ?? setup d? li?u m?u cho TextBox gi?ng trong hình (Slide 128)
            txtMaNhanVien.Text = "03152482001";
            txtTenNhanVien.Text = "Nguy?n V?n Hùng";
        }
    }
}