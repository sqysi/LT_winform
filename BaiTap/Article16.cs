using System;
using System.Windows.Forms;

namespace BaiTap
{
    public partial class Article16 : Form
    {
        // Bi?n ??m s? l??ng sinh viên (?? hi?n th? 1., 2...)
        int count = 0;

        public Article16()
        {
            InitializeComponent();
        }

        // S? ki?n khi Form v?a kh?i ch?y
        private void Article16_Load(object sender, EventArgs e)
        {
            // 1. Thêm d? li?u m?u vào ComboBox (Khoa)
            cbFaculty.Items.Add("Công ngh? thông tin");
            cbFaculty.Items.Add("K? toán");
            cbFaculty.Items.Add("Qu?n tr? kinh doanh");
            cbFaculty.Items.Add("Ngôn ng? Anh");

            // Ch?n m?c ??nh cái ??u tiên
            cbFaculty.SelectedIndex = 0;

            // Thi?t l?p m?c ??nh
            rbMale.Checked = true;
        }

        // S? ki?n nút Thêm
        private void btAdd_Click(object sender, EventArgs e)
        {
            // 1. L?y thông tin t? giao di?n
            string name = tbName.Text;

            // L?y ngày sinh và format thành chu?i dd/MM/yyyy
            string dob = dtpDob.Value.ToString("dd/MM/yyyy");

            string gender = (rbMale.Checked) ? "Nam" : "N?";

            // L?y giá tr? ?ang ch?n trong ComboBox
            string faculty = cbFaculty.SelectedItem.ToString();

            // 2. T?ng bi?n ??m sinh viên
            count++;

            // 3. ??a thông tin vào ListBox gi?ng trong ?nh Slide112
            // Trong ?nh, m?i sinh viên chi?m 4 dòng trong ListBox

            // Dòng 1: S? th? t? + Tên
            lbStatus.Items.Add(count.ToString() + "." + name);

            // Dòng 2: Gi?i tính (th?t vào ??u dòng cho ??p)
            lbStatus.Items.Add("   - Gi?i tính: " + gender);

            // Dòng 3: Ngày sinh
            lbStatus.Items.Add("   - Ngày Sinh: " + dob);

            // Dòng 4: Khoa
            lbStatus.Items.Add("   - Khoa: " + faculty);

            // 4. (Tùy ch?n) Xóa ô nh?p tên ?? nh?p ng??i ti?p theo cho nhanh
            tbName.Text = "";
            tbName.Focus();
        }

        // S? ki?n nút Thoát
        private void btExit_Click(object sender, EventArgs e)
        {
            // ?óng ch??ng trình
            this.Close();
        }
    }
}