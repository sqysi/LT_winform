using System;
using System.Drawing;
using System.Windows.Forms;

namespace BaiTap
{
    public partial class Article25 : Form
    {
        // --- 1. KHAI BÁO BI?N (Theo Slide 162) ---
        PictureBox pb = new PictureBox(); // T?o ??i t??ng khung ?nh
        System.Windows.Forms.Timer tmGame = new System.Windows.Forms.Timer();       // T?o b? ??m th?i gian

        int xBall = 0;      // T?a ?? X ban ??u
        int yBall = 0;      // T?a ?? Y ban ??u
        int xDelta = 5;     // T?c ?? di chuy?n theo chi?u ngang
        int yDelta = 5;     // T?c ?? di chuy?n theo chi?u d?c

        public Article25()
        {
            InitializeComponent();
        }

        // --- 2. THI?T L?P BAN ??U (Theo Slide 163 ph?n trên) ---
        private void Article25_Load(object sender, EventArgs e)
        {
            // C?u hình Timer
            tmGame.Interval = 10;           // C? 10ms thì ch?y 1 l?n
            tmGame.Tick += tmGame_Tick;     // Gán s? ki?n Tick
            tmGame.Start();                 // B?t ??u ch?y Timer

            // C?u hình PictureBox (Qu? bóng)
            pb.SizeMode = PictureBoxSizeMode.StretchImage; // Co giãn ?nh cho v?a khung
            pb.Size = new Size(100, 100);   // Kích th??c bóng
            pb.Location = new Point(xBall, yBall); // ??t v? trí ban ??u

            // L?U Ý: B?n c?n s?a ???ng d?n này tr? ?úng ??n file ?nh trong máy b?n
            // D?u @ giúp chu?i hi?u ???c ký t? '\'
            pb.ImageLocation = @"D:\SCHOOL\LT-C#\LT_winform\BaiTap\images\egg.png";

            // Quan tr?ng: Thêm qu? bóng vào giao di?n Form
            this.Controls.Add(pb);
        }

        // --- 3. X? LÝ CHUY?N ??NG (Theo Slide 163 ph?n d??i) ---
        void tmGame_Tick(object sender, EventArgs e)
        {
            // C?ng thêm t?a ?? ?? bóng di chuy?n
            xBall += xDelta;
            yBall += yDelta;

            // Ki?m tra va ch?m chi?u ngang (Trái - Ph?i)
            // N?u bóng ra quá mép ph?i HO?C bóng ch?m mép trái (<=0)
            if (xBall > this.ClientSize.Width - pb.Width || xBall <= 0)
            {
                xDelta = -xDelta; // ??i chi?u (D??ng thành Âm ho?c ng??c l?i)
            }

            // Ki?m tra va ch?m chi?u d?c (Trên - D??i)
            // N?u bóng ra quá mép d??i HO?C bóng ch?m mép trên (<=0)
            if (yBall > this.ClientSize.Height - pb.Height || yBall <= 0)
            {
                yDelta = -yDelta; // ??i chi?u
            }

            // C?p nh?t v? trí m?i cho PictureBox
            pb.Location = new Point(xBall, yBall);
        }
    }
}