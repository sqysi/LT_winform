using System;
using System.Windows.Forms;

namespace BaiTap
{
    public partial class Article14 : Form
    {
        public Article14()
        {
            InitializeComponent();
        }

        // S? ki?n khi Form v?a t?i lên (Optional: ?? thi?t l?p m?c ??nh)
        private void Article14_Load(object sender, EventArgs e)
        {
            // M?c ??nh ch?n Nam
            rbMale.Checked = true;
            // M?c ??nh ô gi?m giá b? khóa vì ch?a tick ch?n
            tbDiscount.Enabled = false;
        }

        // S? ki?n khi b?m nút "Tính ti?n" (btRun)
        private void btRun_Click(object sender, EventArgs e)
        {
            string msg = null;
            int disc = 0;

            // 1. Ki?m tra gi?i tính ?? ch?n x?ng hô
            if (rbMale.Checked == true)
            {
                msg = "Ông ";
            }
            else if (rbFemale.Checked == true)
            {
                msg = "Bà ";
            }

            // 2. Ki?m tra gi?m giá
            if (ckDiscount.Checked == true)
            {
                // L?y giá tr? t? ô tbDiscount. 
                // S? d?ng TryParse ?? tránh l?i n?u ng??i dùng nh?p ch? thay vì s?
                if (int.TryParse(tbDiscount.Text, out int value))
                {
                    disc = value;
                }
                else
                {
                    MessageBox.Show("Vui lòng nh?p s? vào ô gi?m giá!");
                    return; // D?ng l?i n?u nh?p sai
                }
            }
            else
            {
                // N?u không check thì gi?m giá = 0
                disc = 0;
            }

            // 3. Xu?t k?t qu? ra màn hình
            // C?u trúc: Ông/Bà + Tên + ???c gi?m + %
            tbResult.Text = msg + tbName.Text + " ???c gi?m " + disc.ToString() + "%" + "\r\n";
        }

        // S? ki?n khi thay ??i tr?ng thái Checkbox (ckDiscount)
        private void ckDiscount_CheckedChanged(object sender, EventArgs e)
        {
            // N?u ???c check -> Cho phép nh?p (Enable = true)
            if (ckDiscount.Checked == true)
            {
                tbDiscount.Enabled = true;
                tbDiscount.Focus(); // ??a con tr? chu?t vào ô nh?p cho ti?n
            }
            else
            {
                // N?u b? check -> Khóa ô nh?p (Enable = false)
                tbDiscount.Enabled = false;
                tbDiscount.Text = ""; // Xóa tr?ng ô nh?p cho ??p
            }
        }

        // S? ki?n nút Thoát
        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}