using System;
using System.Windows.Forms;
using System.Drawing; // C?n th? vi?n này ?? x? lý Color

namespace BaiTap
{
    public partial class Article8 : Form
    {
        public Article8()
        {
            InitializeComponent();
        }

        // 1. X? lý Menu File -> Exit
        private void mn_Exit_Click(object sender, EventArgs e)
        {
            // H?i tr??c khi thoát (Ôn l?i bài tr??c)
            if (MessageBox.Show("B?n mu?n thoát?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // 2. X? lý Menu Edit -> Clear
        private void mn_Clear_Click(object sender, EventArgs e)
        {
            rtb_Content.Clear(); // Xóa s?ch ch? trong khung
            rtb_Content.Focus(); // ??a con tr? chu?t v? l?i khung
        }

        // 3. X? lý Context Menu -> Change Color
        private void mn_ChangeColor_Click(object sender, EventArgs e)
        {
            // S? d?ng ColorDialog có s?n c?a Windows
            ColorDialog colorDialog = new ColorDialog();

            // N?u ng??i dùng ch?n màu và b?m OK
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // ??i màu n?n c?a RichTextBox thành màu v?a ch?n
                rtb_Content.BackColor = colorDialog.Color;
            }
        }
    }
}
