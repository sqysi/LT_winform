using System;
using System.Drawing;
using System.Windows.Forms;

namespace BaiTap
{
    public partial class Article26 : Form
    {
        // --- 1. KHAI BÁO BI?N (Theo Slide 167) ---
        // T?o qu? tr?ng
        PictureBox pbEgg = new PictureBox();

        // S?A L?I: Ch? ??nh rõ Timer c?a Windows Forms
        System.Windows.Forms.Timer tmEgg = new System.Windows.Forms.Timer();

        // T?o thêm Gi? và Gà (c?n thi?t cho logic trong Slide 184)
        PictureBox pbBasket = new PictureBox();
        PictureBox pbChicken = new PictureBox();

        // T?a ?? và t?c ?? (Slide 167)
        int xEgg = 300;
        int yEgg = 0;
        int xDelta = 3;
        int yDelta = 3;

        // Hàm kh?i t?o m?c ??nh (B?t bu?c ph?i có)
        public Article26()
        {
            InitializeComponent();
        }

        // --- 2. THI?T L?P BAN ??U (Theo Slide 168) ---
        private void Article26_Load(object sender, EventArgs e)
        {
            // C?u hình Timer
            tmEgg.Interval = 10;
            tmEgg.Tick += tmEgg_Tick;
            tmEgg.Start();

            // C?u hình Qu? tr?ng (pbEgg)
            pbEgg.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEgg.Size = new Size(50, 60); // Kích th??c tr?ng (Width, Height)
            pbEgg.Location = new Point(xEgg, yEgg);
            pbEgg.BackColor = Color.Transparent;

            // Load ?nh tr?ng vàng
            try
            {
                // S?A L?I: Ch? ??nh rõ System.Drawing.Image
                // L?u ý: ??m b?o th? m?c Images n?m ?úng v? trí so v?i file exe
                pbEgg.Image = System.Drawing.Image.FromFile(@"D:\SCHOOL\LT-C#\LT_winform\BaiTap\images\egg.png");
            }
            catch
            {
                pbEgg.BackColor = Color.Yellow; // N?u l?i ?nh thì hi?n màu vàng
            }
            this.Controls.Add(pbEgg);

            // --- B? sung: C?u hình Gi? (pbBasket) ?? code va ch?m ch?y ???c ---
            pbBasket.Size = new Size(100, 50);
            pbBasket.Location = new Point(280, 400); // ??t gi? ? d??i ?áy
            pbBasket.BackColor = Color.Red; // T?m ?? màu ?? ?? d? nhìn
            this.Controls.Add(pbBasket);

            // --- B? sung: C?u hình Gà (pbChicken) ---
            pbChicken.Location = new Point(300, 10); // Gà ? trên cùng
            pbChicken.Size = new Size(50, 50);
            this.Controls.Add(pbChicken);
        }

        // --- 3. X? LÝ CHUY?N ??NG (K?t h?p Slide 169 và 184) ---
        void tmEgg_Tick(object sender, EventArgs e)
        {
            // Tr?ng r?i xu?ng
            yEgg += yDelta;

            // Logic 1: N?u tr?ng ch?m ?áy (Slide 169)
            if (yEgg > this.ClientSize.Height - pbEgg.Height || yEgg <= 0)
            {
                try
                {
                    // ??i sang ?nh tr?ng v?
                    pbEgg.Image = System.Drawing.Image.FromFile(@"D:\SCHOOL\LT-C#\LT_winform\BaiTap\images\egg-broken.jpg");
                }
                catch { }
            }

            // Logic 2: Va ch?m v?i Gi? (Slide 184)
            // Ki?m tra xem hình ch? nh?t c?a Tr?ng có c?t hình ch? nh?t c?a Gi? không
            Rectangle unionRect = Rectangle.Intersect(pbEgg.Bounds, pbBasket.Bounds);

            if (unionRect.IsEmpty == false) // N?u có va ch?m (H?ng ???c tr?ng)
            {
                // Reset tr?ng v? v? trí con gà
                yEgg = 30;
                xEgg = pbChicken.Location.X;

                // ??i l?i ?nh tr?ng nguyên v?n
                try
                {
                    pbEgg.Image = System.Drawing.Image.FromFile(@"D:\SCHOOL\LT-C#\LT_winform\BaiTap\images\egg.png");
                }
                catch { pbEgg.BackColor = Color.Yellow; }
            }

            // C?p nh?t v? trí m?i cho tr?ng
            pbEgg.Location = new Point(xEgg, yEgg);
        }
    }
}