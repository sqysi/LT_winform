using System;
using System.Drawing;
using System.Windows.Forms;

namespace BaiTap
{
    public partial class Article18 : Form
    {
        public Article18()
        {
            InitializeComponent();
        }

        // S? ki?n khi Form t?i lên (n?u mu?n cài ??t m?c ??nh)
        private void Article18_Load(object sender, EventArgs e)
        {
            // Cài ??t ch? ?? hi?n th? ?nh ?? nó t? co giãn v?a khung
            picAnhNhanVien.SizeMode = PictureBoxSizeMode.StretchImage;

            // D? li?u m?u nh? trong ?nh (Tùy ch?n)
            txtMaNhanVien.Text = "03152482001";
            txtTenNhanVien.Text = "Nguy?n V?n Hùng";
        }

        // S? ki?n khi b?m nút "Ch?n ?nh ..."
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            // T?o m?t h?p tho?i m? file
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Thi?t l?p b? l?c ch? cho phép ch?n file ?nh
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Ch?n ?nh nhân viên";

            // N?u ng??i dùng ch?n file và b?m OK
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Cách 1: Dùng ImageLocation (nh? trong Slide g?i ý) -> ???ng d?n file
                picAnhNhanVien.ImageLocation = openFileDialog.FileName;

                // Cách 2: Gán tr?c ti?p Image (n?u mu?n load vào b? nh? luôn)
                // picAnhNhanVien.Image = Image.FromFile(openFileDialog.FileName);
            }
        }
    }
}