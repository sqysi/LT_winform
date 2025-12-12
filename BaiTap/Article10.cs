using System;
using System.Windows.Forms;

namespace BaiTap
{
    public partial class Article10 : Form
    {
        public Article10()
        {
            InitializeComponent();
        }

        // 1. X? lý m? file ?nh
        private void mn_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            // Ch? l?c l?y file ?nh
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // T?o m?t Form con m?i
                FormChild child = new FormChild();

                // ??t Form cha c?a nó là Form hi?n t?i (Article10) -> ?ây là b??c quan tr?ng nh?t c?a MDI
                child.MdiParent = this;

                // G?i hàm hi?n th? ?nh bên Form con
                child.SetImage(dlg.FileName);

                // Hi?n th? Form con lên
                child.Show();
            }
        }

        // 2. Thoát ch??ng trình
        private void mn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // 3. Các ch?c n?ng s?p x?p c?a s? con
        private void mn_Cascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade); // X?p ch?ng so le
        }

        private void mn_TileH_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal); // X?p ngang
        }

        private void mn_TileV_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical); // X?p d?c
        }
    }
}
