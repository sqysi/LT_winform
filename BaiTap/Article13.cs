using System;
using System.Windows.Forms;

namespace BaiTap
{
    public partial class Article13 : Form
    {
        public Article13()
        {
            InitializeComponent();
        }

        // 1. S? ki?n Load Form: Ch?y ngay khi form v?a m? lên
        private void Article13_Load(object sender, EventArgs e)
        {
            // Thêm d? li?u m?u vào ListBox trái
            string[] students = {
                "Nguy?n V?n An", "Tr?n Th? Bích", "Lê V?n C??ng",
                "Ph?m Th? Dung", "Hoàng V?n Em", "?? Th? G?m",
                "V? V?n Hùng", "Ngô Th? Lan"
            };

            // AddRange dùng ?? thêm 1 m?ng vào ListBox nhanh chóng
            lbSource.Items.AddRange(students);
        }

        // 2. Chuy?n các dòng ?ANG CH?N t? Trái -> Ph?i (>)
        private void btnToRight_Click(object sender, EventArgs e)
        {
            // Duy?t danh sách các item ?ang ???c ch?n (SelectedItems)
            // L?u ý: Ph?i chuy?n sang m?ng ho?c List tr??c khi duy?t vì danh sách SelectedItems s? thay ??i khi ta di chuy?n
            foreach (var item in lbSource.SelectedItems)
            {
                lbDest.Items.Add(item); // Thêm sang ph?i
            }

            // Sau khi thêm xong thì quay l?i xóa bên trái
            // Ph?i xóa ng??c t? d??i lên ho?c dùng vòng l?p while ?? tránh l?i index
            while (lbSource.SelectedItems.Count > 0)
            {
                lbSource.Items.Remove(lbSource.SelectedItems[0]);
            }
        }

        // 3. Chuy?n T?T C? t? Trái -> Ph?i (>>)
        private void btnAllToRight_Click(object sender, EventArgs e)
        {
            // Thêm toàn b? item bên trái sang ph?i
            foreach (var item in lbSource.Items)
            {
                lbDest.Items.Add(item);
            }

            // Xóa s?ch bên trái
            lbSource.Items.Clear();
        }

        // 4. Chuy?n các dòng ?ANG CH?N t? Ph?i -> Trái (<)
        private void btnToLeft_Click(object sender, EventArgs e)
        {
            // Logic t??ng t? nút >
            foreach (var item in lbDest.SelectedItems)
            {
                lbSource.Items.Add(item);
            }

            while (lbDest.SelectedItems.Count > 0)
            {
                lbDest.Items.Remove(lbDest.SelectedItems[0]);
            }
        }

        // 5. Chuy?n T?T C? t? Ph?i -> Trái (<<)
        private void btnAllToLeft_Click(object sender, EventArgs e)
        {
            foreach (var item in lbDest.Items)
            {
                lbSource.Items.Add(item);
            }
            lbDest.Items.Clear();
        }
    }
}