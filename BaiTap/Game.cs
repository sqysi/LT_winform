using System;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace BaiTap
{
    public partial class Game : Form
    {
        // --- 1. KHAI BÁO CÁC ??I T??NG ---
        PictureBox pbEgg = new PictureBox();
        PictureBox pbBasket = new PictureBox();
        PictureBox pbChicken = new PictureBox();
        System.Windows.Forms.Label lblScore = new System.Windows.Forms.Label();             // B?ng ?i?m & Level        Button btnPause = new Button();

        // Nút B?t ??u m?i
        Button btnStart = new Button();
        Button btnPause = new Button();

        System.Windows.Forms.Timer tmGame = new System.Windows.Forms.Timer();

        // --- CÁC BI?N LOGIC GAME ---
        int score = 0;
        int level = 1;
        int eggSpeed = 5;
        int basketSpeed = 15;
        bool isGameOver = false;
        bool isPaused = false;
        bool isGameRunning = false; // Bi?n ki?m tra game ?ã b?t ??u ch?a

        // Bi?n ?i?u khi?n di chuy?n m??t
        bool goLeft = false;
        bool goRight = false;

        // ???ng d?n ?nh
        string pathChicken = @"D:\SCHOOL\LT-C#\LT_winform\BaiTap\images\chicken.jpg";
        string pathEgg = @"D:\SCHOOL\LT-C#\LT_winform\BaiTap\images\egg.png";
        string pathBasket = @"D:\SCHOOL\LT-C#\LT_winform\BaiTap\images\basket.jpg";
        string pathBroken = @"D:\SCHOOL\LT-C#\LT_winform\BaiTap\images\egg-broken.png";

        public Game()
        {
            InitializeComponent();

            // K? THU?T: Double Buffered giúp m??t hình
            this.DoubleBuffered = true;

            // QUAN TR?NG: Dòng này giúp Form luôn nh?n ???c phím b?m dù ?ang ch?n nút nào
            this.KeyPreview = true;

            // ??ng ký s? ki?n bàn phím
            this.KeyDown += Game_KeyDown;
            this.KeyUp += Game_KeyUp;
        }

        // --- 2. THI?T L?P GAME KHI M? LÊN ---
        private void Game_Load(object sender, EventArgs e)
        {
            // Cài ??t Form
            this.Text = "Game Hung Trung";
            this.Size = new Size(600, 700);
            this.BackColor = Color.LightSkyBlue;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Cài ??t Con Gà
            pbChicken.Size = new Size(100, 100);
            pbChicken.Location = new Point(250, 10);
            pbChicken.SizeMode = PictureBoxSizeMode.StretchImage;
            pbChicken.BackColor = Color.Transparent;
            SetImage(pbChicken, pathChicken, Color.White);
            this.Controls.Add(pbChicken);

            // Cài ??t Qu? Tr?ng
            pbEgg.Size = new Size(50, 60);
            pbEgg.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEgg.BackColor = Color.Transparent;
            SetImage(pbEgg, pathEgg, Color.White);
            pbEgg.Visible = false; // ?n tr?ng ?i khi ch?a b?t ??u
            this.Controls.Add(pbEgg);

            // Cài ??t Cái Gi?
            pbBasket.Size = new Size(120, 70);
            pbBasket.Location = new Point(240, 550);
            pbBasket.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBasket.BackColor = Color.Transparent;
            SetImage(pbBasket, pathBasket, Color.White);
            this.Controls.Add(pbBasket);

            // Cài ??t B?ng ?i?m
            lblScore.Text = "Diem: 0 | Level: 1";
            lblScore.Font = new Font("Arial", 16, FontStyle.Bold);
            lblScore.ForeColor = Color.DarkBlue;
            lblScore.Location = new Point(10, 10);
            lblScore.AutoSize = true;
            this.Controls.Add(lblScore);

            // Cài ??t Nút T?m D?ng (Ban ??u ?n ?i)
            btnPause.Text = "Tam Dung (P)";
            btnPause.Font = new Font("Arial", 10, FontStyle.Bold);
            btnPause.Size = new Size(120, 40);
            btnPause.Location = new Point(450, 10);
            btnPause.BackColor = Color.LightYellow;
            btnPause.Click += BtnPause_Click;
            btnPause.TabStop = false; // Không cho phím Tab nh?y vào ?ây
            btnPause.Visible = false; // ?n khi ch?a ch?i
            this.Controls.Add(btnPause);

            // --- CÀI ??T NÚT START GAME ---
            btnStart.Text = "BAT DAU GAME";
            btnStart.Font = new Font("Arial", 20, FontStyle.Bold);
            btnStart.Size = new Size(300, 80);
            // C?n gi?a màn hình
            btnStart.Location = new Point((this.ClientSize.Width - btnStart.Width) / 2, 250);
            btnStart.BackColor = Color.OrangeRed;
            btnStart.ForeColor = Color.White;
            btnStart.Click += BtnStart_Click;
            this.Controls.Add(btnStart);

            // Cài ??t Timer (Ch?a Start v?i)
            tmGame.Interval = 20;
            tmGame.Tick += tmGame_Tick;
        }

        // --- S? KI?N NÚT B?T ??U ---
        private void BtnStart_Click(object sender, EventArgs e)
        {
            isGameRunning = true;
            isGameOver = false;

            // ?n nút Start, hi?n nút Pause và Tr?ng
            btnStart.Visible = false;
            btnPause.Visible = true;
            pbEgg.Visible = true;

            ResetEggPosition();
            tmGame.Start(); // B?t ??u ch?y game

            // Tr? l?i focus cho Form ?? ?i?u khi?n
            this.Focus();
        }

        // --- 3. LOGIC GAME (VÒNG L?P CHÍNH) ---
        private void tmGame_Tick(object sender, EventArgs e)
        {
            // N?u ch?a b?t ??u ho?c Game Over ho?c Pause thì d?ng
            if (!isGameRunning || isGameOver || isPaused) return;

            // --- A. X? LÝ DI CHUY?N GI? ---
            if (goLeft == true && pbBasket.Left > 0)
            {
                pbBasket.Left -= basketSpeed;
            }
            if (goRight == true && pbBasket.Right < this.ClientSize.Width)
            {
                pbBasket.Left += basketSpeed;
            }

            // --- B. X? LÝ TR?NG R?I ---
            pbEgg.Top += eggSpeed;

            // Ki?m tra va ch?m
            if (pbEgg.Bounds.IntersectsWith(pbBasket.Bounds))
            {
                score++;
                CheckLevelUp();
                lblScore.Text = "Diem: " + score + " | Level: " + level;
                ResetEggPosition();
            }

            // Ki?m tra ch?m ??t
            if (pbEgg.Top > this.ClientSize.Height - pbEgg.Height)
            {
                GameOver();
            }
        }

        // --- 4. H? TH?NG LEVEL ---
        private void CheckLevelUp()
        {
            if (score % 10 == 0 && score > 0)
            {
                level++;
                eggSpeed += 2;
                basketSpeed += 1;

                if (level % 2 == 0) this.BackColor = Color.LightPink;
                else this.BackColor = Color.LightSkyBlue;

                this.Text = "Game Hung Trung - Level " + level;
            }
        }

        // --- 5. ?I?U KHI?N & S? KI?N ---
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            // N?u ch?a ch?i mà b?m Enter thì B?t ??u luôn (ti?n l?i)
            if (!isGameRunning && btnStart.Visible == true && e.KeyCode == Keys.Enter)
            {
                BtnStart_Click(null, null);
                return;
            }

            // N?u Game Over b?m Enter thì ch?i l?i
            if (isGameOver && e.KeyCode == Keys.Enter)
            {
                RestartGame();
                return;
            }

            if (e.KeyCode == Keys.Left) goLeft = true;
            if (e.KeyCode == Keys.Right) goRight = true;
            if (e.KeyCode == Keys.P) TogglePause();
        }

        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) goLeft = false;
            if (e.KeyCode == Keys.Right) goRight = false;
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            TogglePause();
            this.Focus(); // Quan tr?ng: Tr? l?i quy?n bàn phím cho Form
        }

        private void TogglePause()
        {
            if (isGameOver || !isGameRunning) return;

            isPaused = !isPaused;

            if (isPaused)
            {
                btnPause.Text = "Tiep Tuc (P)";
                tmGame.Stop();
                this.Text = "Game Dang Tam Dung...";
            }
            else
            {
                btnPause.Text = "Tam Dung (P)";
                tmGame.Start();
                this.Text = "Game Hung Trung - Level " + level;
            }
        }

        // --- CÁC HÀM PH? TR? ---
        private void ResetEggPosition()
        {
            Random rand = new Random();
            int randomX = rand.Next(20, this.ClientSize.Width - pbEgg.Width - 20);
            pbEgg.Location = new Point(randomX, 80);
            SetImage(pbEgg, pathEgg, Color.Yellow);
        }

        private void GameOver()
        {
            isGameOver = true;
            tmGame.Stop();
            SetImage(pbEgg, pathBroken, Color.Black);

            // Hi?n h?p tho?i thông báo
            DialogResult result = MessageBox.Show(
                "Game Over!\nDiem: " + score + "\nLevel: " + level + "\n\nBan co muon choi lai khong?",
                "Ket Thuc",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                RestartGame();
            }
            else
            {
                this.Close(); // Thoát game
            }
        }

        private void RestartGame()
        {
            // Reset toàn b? thông s?
            score = 0;
            level = 1;
            eggSpeed = 5;
            basketSpeed = 15;
            isGameOver = false;
            isPaused = false;
            isGameRunning = true; // Ch?i luôn không c?n b?m Start l?i

            lblScore.Text = "Diem: 0 | Level: 1";
            this.BackColor = Color.LightSkyBlue;
            this.Text = "Game Hung Trung - Level 1";
            btnPause.Text = "Tam Dung (P)";
            btnPause.Visible = true;
            btnStart.Visible = false;

            ResetEggPosition();
            tmGame.Start();
        }

        private void SetImage(PictureBox pb, string path, Color fallbackColor)
        {
            try
            {
                Bitmap bmp = new Bitmap(path);
                bmp.MakeTransparent(Color.White);
                pb.Image = bmp;
            }
            catch
            {
                pb.Image = null;
                pb.BackColor = fallbackColor;
            }
        }
    }
}