using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BaiTap
{
    public partial class Article27 : Form
    {
        // --- 1. KHAI BÁO BI?N ---
        // T?o m?t danh sách ?? ch?a t?a ?? các qu? bóng (Rectangle ??i di?n cho hình ch? nh?t bao quanh bóng)
        List<Rectangle> bubbles = new List<Rectangle>();

        // Bi?n Random ?? t?o v? trí ng?u nhiên
        Random rnd = new Random();

        // S? l??ng bóng mu?n t?o
        int numberOfBubbles = 10;

        public Article27()
        {
            InitializeComponent();

            // Cài ??t s? ki?n chu?t và v? (Quan tr?ng)
            this.MouseClick += Article27_MouseClick;
            this.Paint += Article27_Paint;
        }

        // --- 2. THI?T L?P BAN ??U (Form_Load) ---
        private void Article27_Load(object sender, EventArgs e)
        {
            // Khi Form hi?n lên, ta t?o ng?u nhiên 10 qu? bóng
            for (int i = 0; i < numberOfBubbles; i++)
            {
                int x = rnd.Next(0, this.ClientSize.Width - 50);
                int y = rnd.Next(0, this.ClientSize.Height - 50);

                // T?o bóng kích th??c 50x50 t?i v? trí ng?u nhiên
                Rectangle bubble = new Rectangle(x, y, 50, 50);
                bubbles.Add(bubble);
            }
        }

        // --- 3. V? HÌNH (S? ki?n Paint) ---
        // Hàm này t? ??ng ch?y m?i khi c?n v? l?i giao di?n
        private void Article27_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Duy?t qua danh sách và v? t?ng qu? bóng
            foreach (Rectangle item in bubbles)
            {
                // V? hình tròn màu ??
                g.FillEllipse(Brushes.Red, item);
                // V? vi?n ?en cho ??p
                g.DrawEllipse(Pens.Black, item);
            }
        }

        // --- 4. X? LÝ CLICK CHU?T (Slide 164, 165) ---
        private void Article27_MouseClick(object sender, MouseEventArgs e)
        {
            // e.X và e.Y là t?a ?? n?i chu?t v?a click

            // Duy?t ng??c t? cu?i danh sách v? ??u (?? xóa không b? l?i)
            for (int i = bubbles.Count - 1; i >= 0; i--)
            {
                // Ki?m tra: N?u v? trí click n?m trong vùng c?a qu? bóng th? i
                if (bubbles[i].Contains(e.X, e.Y))
                {
                    // Xóa bóng ?ó kh?i danh sách
                    bubbles.RemoveAt(i);

                    // Yêu c?u v? l?i Form (c?p nh?t giao di?n ngay l?p t?c)
                    this.Invalidate();

                    // Thoát vòng l?p (m?i l?n click ch? v? 1 qu? trên cùng)
                    break;
                }
            }

            // N?u xóa h?t bóng thì thông báo th?ng
            if (bubbles.Count == 0)
            {
                MessageBox.Show("B?n ?ã th?ng! ?ã ??p h?t bóng.");
                // N?p l?i game m?i
                Article27_Load(sender, e);
                this.Invalidate();
            }
        }
    }
}
