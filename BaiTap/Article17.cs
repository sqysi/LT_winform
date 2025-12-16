using System;
using System.Windows.Forms;

namespace BaiTap
{
    public partial class Article17 : Form
    {
        public Article17()
        {
            InitializeComponent();
        }

        private void Article17_Load(object sender, EventArgs e)
        {
            // Thêm bài hát m?u khi m? Form (nh? trong Slide 116)
            lbSong.Items.Add("Gi?c m? Chapi");
            lbSong.Items.Add("?ôi M?t Pleiku");
            lbSong.Items.Add("Em Mu?n S?ng Bên Anh Tr?n ??i");
            lbSong.Items.Add("H'Zen Lên R?y");
            lbSong.Items.Add("Còn Th??ng Nhau Thì V? Buôn Mê Thu?t");
            lbSong.Items.Add("Ly Cà Phê Ban Mê");
            lbSong.Items.Add("?i tìm l?i ru m?t tr?i");
        }

        // 1. X? lý nút [>] : Chuy?n 1 bài t? Trái -> Ph?i
        private void btSelect_Click(object sender, EventArgs e)
        {
            // Ki?m tra xem có bài nào ?ang ???c ch?n không (SelectedIndex khác -1)
            if (lbSong.SelectedIndex != -1)
            {
                // L?y tên bài hát ?ang ch?n
                string song = lbSong.SelectedItem.ToString();

                // Thêm vào danh sách Ph?i
                lbFavorite.Items.Add(song);

                // Xóa kh?i danh sách Trái
                lbSong.Items.RemoveAt(lbSong.SelectedIndex);
            }
        }

        // 2. X? lý nút [<] : Chuy?n 1 bài t? Ph?i -> Trái
        private void btDeselect_Click(object sender, EventArgs e)
        {
            if (lbFavorite.SelectedIndex != -1)
            {
                string song = lbFavorite.SelectedItem.ToString();
                lbSong.Items.Add(song);
                lbFavorite.Items.RemoveAt(lbFavorite.SelectedIndex);
            }
        }

        // 3. X? lý nút [>>] : Chuy?n T?T C? t? Trái -> Ph?i
        private void btSelectAll_Click(object sender, EventArgs e)
        {
            // Cách làm ?úng: Duy?t ng??c t? cu?i danh sách v? ??u (i--)
            // Vì n?u duy?t xuôi (i++), khi xóa ph?n t? 0, ph?n t? 1 s? t?t xu?ng thành 0 
            // và vòng l?p s? b? qua nó.

            int count = lbSong.Items.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                string song = lbSong.Items[i].ToString();
                lbFavorite.Items.Add(song);
                lbSong.Items.RemoveAt(i);
            }
        }

        // 4. X? lý nút [<<] : Chuy?n T?T C? t? Ph?i -> Trái
        private void btDeselectAll_Click(object sender, EventArgs e)
        {
            int count = lbFavorite.Items.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                string song = lbFavorite.Items[i].ToString();
                lbSong.Items.Add(song);
                lbFavorite.Items.RemoveAt(i);
            }
        }

        // 5. X? lý Double Click (Nh?p ?úp) bên Trái
        private void lbSong_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // G?i l?i hàm x? lý c?a nút [>] cho ti?n, ?? vi?t l?i code
            btSelect_Click(sender, e);
        }

        // 6. X? lý Double Click (Nh?p ?úp) bên Ph?i
        private void lbFavorite_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // G?i l?i hàm x? lý c?a nút [<]
            btDeselect_Click(sender, e);
        }
    }
}