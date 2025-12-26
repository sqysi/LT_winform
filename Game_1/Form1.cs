using System;
using System.Drawing;
using System.IO;
using System.Media; // --- MỚI: Thư viện âm thanh
using System.Windows.Forms;

namespace Game_1
{
    public partial class Form1 : Form
    {
        // --- CẤU HÌNH ---
        string folderPath = @"D:\SCHOOL\LT-C#\LT_winform\Game_1\images\";

        // --- BIẾN LOGIC ---
        bool goLeft, goRight, jumping, isGameOver;
        bool isCrouching;
        bool isGameStarted = false;
        bool isPaused = false;
        bool isLevelComplete = false;
        bool isOnGround = false;

        int currentLevel = 1;
        const int MAX_LEVEL = 4;

        int jumpSpeed;
        int force;
        int score = 0;

        // --- THÔNG SỐ VẬT LÝ ---
        int playerSpeed = 8;
        int jumpForceInitial = 15;
        int gravitySpeed = 12;

        int playerWidth = 30;
        int playerHeight = 45;
        int playerCrouchHeight = 25;

        int screenW, screenH;

        PictureBox player;
        Timer gameTimer;
        Label txtScore;
        Label lblMessage;
        Panel pnlMessageBoard;

        // --- CACHE HÌNH ẢNH ---
        Image imgPlayerIdleRight, imgPlayerJumpRight, imgPlayerCrouchRight;
        Image imgPlayerIdleLeft, imgPlayerJumpLeft, imgPlayerCrouchLeft;
        Image imgPlatform, imgCoin, imgDoor;

        // --- MỚI: CACHE ÂM THANH ---
        SoundPlayer soundJump;
        SoundPlayer soundCoin;
        SoundPlayer soundWin;
        SoundPlayer soundLose;

        bool facingRight = true;

        public Form1()
        {
            InitializeComponent();

            this.Text = "JUMP HERO - AUDIO EDITION";
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            screenW = Screen.PrimaryScreen.Bounds.Width;
            screenH = Screen.PrimaryScreen.Bounds.Height;

            this.DoubleBuffered = true;
            this.KeyPreview = true;

            this.KeyDown += KeyIsDown;
            this.KeyUp += KeyIsUp;

            // Load hình ảnh và âm thanh
            LoadGameResources();
            LoadSounds(); // --- MỚI: Hàm load âm thanh

            ShowStartScreen();
        }

        // --- MỚI: HÀM LOAD ÂM THANH ---
        private void LoadSounds()
        {
            // Lưu ý: File phải là đuôi .wav
            soundJump = LoadSound("jump.wav");
            soundCoin = LoadSound("coin.wav");
            soundWin = LoadSound("win.wav");
            soundLose = LoadSound("lose.wav");
        }

        private SoundPlayer LoadSound(string fileName)
        {
            string path = folderPath + fileName;
            if (File.Exists(path))
            {
                SoundPlayer sp = new SoundPlayer(path);
                // LoadAsync giúp game không bị khựng lại khi load file to
                sp.LoadAsync();
                return sp;
            }
            return null;
        }

        // --- MỚI: HÀM PHÁT ÂM THANH ---
        private void PlaySound(SoundPlayer sound)
        {
            if (sound != null)
            {
                try
                {
                    // Play() chạy luồng riêng, không làm đứng game
                    // Nếu dùng PlaySync() game sẽ bị đơ đến khi hết nhạc
                    sound.Play();
                }
                catch { } // Bỏ qua lỗi nếu file lỗi
            }
        }

        // ... (Giữ nguyên ShowCustomMessage và LoadGameResources cũ) ...
        private void ShowCustomMessage(string title, string content, Color titleColor)
        {
            if (pnlMessageBoard != null && this.Controls.Contains(pnlMessageBoard))
            {
                this.Controls.Remove(pnlMessageBoard);
            }

            pnlMessageBoard = new Panel();
            pnlMessageBoard.Size = new Size(500, 300);
            pnlMessageBoard.Location = new Point((screenW - 500) / 2, (screenH - 300) / 2);
            pnlMessageBoard.BackColor = Color.FromArgb(240, 240, 240);
            pnlMessageBoard.BringToFront();

            pnlMessageBoard.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Rectangle rect = pnlMessageBoard.ClientRectangle;
                rect.Width--; rect.Height--;
                int r = 20;

                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddArc(rect.X, rect.Y, r, r, 180, 90);
                path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
                path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
                path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
                path.CloseFigure();

                e.Graphics.FillPath(new SolidBrush(Color.White), path);
                e.Graphics.DrawPath(new Pen(titleColor, 4), path);
            };

            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Arial", 28, FontStyle.Bold);
            lblTitle.ForeColor = titleColor;
            lblTitle.AutoSize = false;
            lblTitle.Size = new Size(500, 60);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Location = new Point(0, 30);
            lblTitle.BackColor = Color.Transparent;

            Label lblContent = new Label();
            lblContent.Text = content;
            lblContent.Font = new Font("Arial", 14, FontStyle.Regular);
            lblContent.ForeColor = Color.Black;
            lblContent.AutoSize = false;
            lblContent.Size = new Size(500, 150);
            lblContent.TextAlign = ContentAlignment.MiddleCenter;
            lblContent.Location = new Point(0, 100);
            lblContent.BackColor = Color.Transparent;

            pnlMessageBoard.Controls.Add(lblTitle);
            pnlMessageBoard.Controls.Add(lblContent);

            this.Controls.Add(pnlMessageBoard);
            pnlMessageBoard.BringToFront();
        }

        private void LoadGameResources()
        {
            imgPlayerIdleRight = LoadImage("player.png");
            imgPlayerJumpRight = LoadImage("player_jump.png");
            imgPlayerCrouchRight = LoadImage("player_crouch.png");

            if (imgPlayerIdleRight != null)
            {
                imgPlayerIdleLeft = (Image)imgPlayerIdleRight.Clone();
                imgPlayerIdleLeft.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            if (imgPlayerJumpRight != null)
            {
                imgPlayerJumpLeft = (Image)imgPlayerJumpRight.Clone();
                imgPlayerJumpLeft.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            if (imgPlayerCrouchRight != null)
            {
                imgPlayerCrouchLeft = (Image)imgPlayerCrouchRight.Clone();
                imgPlayerCrouchLeft.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }

            imgPlatform = LoadImage("platform.jpg");
            imgCoin = LoadImage("coin.png");
            imgDoor = LoadImage("door.png");
        }

        private Image LoadImage(string fileName)
        {
            string path = folderPath + fileName;
            if (File.Exists(path)) return Image.FromFile(path);
            return null;
        }

        private void ShowStartScreen()
        {
            this.Controls.Clear();
            this.BackgroundImage = null;
            this.BackColor = Color.FromArgb(30, 30, 40);
            ShowCustomMessage("JUMP HERO", "PARKOUR EDITION\n\nCONTROLS:\nA/D: Move | W: Jump | S: Crouch\n\nPRESS [ENTER] TO START", Color.DarkBlue);
        }

        private void UpdateMessagePosition()
        {
            if (lblMessage != null)
                lblMessage.Location = new Point((screenW - lblMessage.Width) / 2, (screenH - lblMessage.Height) / 2);
        }

        private void SetBackground(string imageName)
        {
            string path = folderPath + imageName;
            if (File.Exists(path))
            {
                try
                {
                    this.BackgroundImage = Image.FromFile(path);
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                }
                catch { this.BackColor = Color.LightSlateGray; }
            }
            else
            {
                this.BackgroundImage = null;
                if (currentLevel == 1) this.BackColor = Color.LightSkyBlue;
                else if (currentLevel == 2) this.BackColor = Color.FromArgb(40, 40, 60);
                else if (currentLevel == 3) this.BackColor = Color.MistyRose;
                else this.BackColor = Color.SlateGray;
            }
        }

        private void SetupGameLevel()
        {
            this.Controls.Clear();
            SetBackground("level" + currentLevel + ".png");

            jumping = false;
            goLeft = false;
            goRight = false;
            isCrouching = false;
            isGameOver = false;
            isLevelComplete = false;
            isOnGround = false;
            force = jumpForceInitial;
            jumpSpeed = 0;

            txtScore = new Label();
            txtScore.Text = "Level: " + currentLevel + "/" + MAX_LEVEL + " | Score: " + score;
            txtScore.Font = new Font("Arial", 16, FontStyle.Bold);
            txtScore.ForeColor = Color.White;
            txtScore.BackColor = Color.Transparent;
            txtScore.Location = new Point(20, 20);
            txtScore.AutoSize = true;
            this.Controls.Add(txtScore);

            lblMessage = new Label();
            lblMessage.AutoSize = true;
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblMessage.Font = new Font("Arial", 24, FontStyle.Bold);
            lblMessage.Visible = false;
            this.Controls.Add(lblMessage);

            switch (currentLevel)
            {
                case 1: BuildLevel1(); break;
                case 2: BuildLevel2(); break;
                case 3: BuildLevel3(); break;
                case 4: BuildLevel4(); break;
            }

            if (gameTimer != null) gameTimer.Stop();
            gameTimer = new Timer();
            gameTimer.Interval = 15;
            gameTimer.Tick += MainGameTimerEvent;
            gameTimer.Start();
        }

        // --- CÁC LEVEL (GIỮ NGUYÊN) ---
        private void BuildLevel1()
        {
            CreatePlatform(0, screenH - 50, screenW, 50);
            CreatePlatform(200, screenH - 150, 150, 20);
            CreatePlatform(400, screenH - 250, 150, 20);
            CreatePlatform(600, screenH - 350, 150, 20);
            CreatePlatform(850, screenH - 250, 150, 20);
            CreatePlatform(screenW - 250, screenH - 150, 200, 20);
            CreateCoin(420, screenH - 300);
            CreateCoin(620, screenH - 400);
            CreatePlayer(50, screenH - 150);
            CreateDoor(screenW - 150, screenH - 220);
        }
        private void BuildLevel2()
        {
            CreatePlatform(0, screenH - 50, 300, 50);
            CreatePlatform(350, screenH - 150, 100, 20);
            CreatePlatform(500, screenH - 250, 100, 20);
            CreatePlatform(350, screenH - 350, 100, 20);
            CreatePlatform(150, screenH - 400, 100, 20);
            CreatePlatform(350, screenH - 500, 100, 20);
            CreatePlatform(600, screenH - 500, 100, 20);
            CreatePlatform(800, screenH - 400, 100, 20);
            CreatePlatform(screenW - 300, screenH - 300, 100, 20);
            CreatePlatform(screenW - 150, screenH - 450, 150, 20);
            CreateCoin(160, screenH - 450);
            CreateCoin(810, screenH - 450);
            CreateCoin(360, screenH - 550);
            CreatePlayer(50, screenH - 150);
            CreateDoor(screenW - 100, screenH - 520);
        }
        private void BuildLevel3()
        {
            CreatePlatform(0, screenH - 100, 200, 30);
            CreatePlatform(250, screenH - 200, 90, 20);
            CreatePlatform(400, screenH - 300, 90, 20);
            CreatePlatform(550, screenH - 250, 150, 20);
            CreatePlatform(750, screenH - 350, 90, 20);
            CreatePlatform(900, screenH - 450, 90, 20);
            CreatePlatform(1050, screenH - 350, 80, 20);
            CreatePlatform(1200, screenH - 250, 80, 20);
            CreatePlatform(screenW - 350, screenH - 400, 90, 20);
            CreatePlatform(screenW - 200, screenH - 550, 200, 20);
            CreateCoin(410, screenH - 350);
            CreateCoin(760, screenH - 400);
            CreateCoin(screenW - 340, screenH - 450);
            CreatePlayer(50, screenH - 200);
            CreateDoor(screenW - 100, screenH - 620);
        }
        private void BuildLevel4()
        {
            // --- 1. SÀN NHÀ AN TOÀN ---
            // Giữ nguyên sàn để nếu ngã thì không game over ngay, chỉ phải leo lại thôi
            CreatePlatform(0, screenH - 50, screenW, 50);

            // --- 2. CÁC BẬC THANG (Rộng hơn và gần hơn) ---

            // Bậc 1: Khởi động bên trái (Thấp)
            CreatePlatform(50, screenH - 150, 200, 20);

            // Bậc 2: Nhảy sang giữa (Cao hơn chút)
            CreatePlatform(300, screenH - 250, 200, 20);

            // Bậc 3: Một cây cầu dài bên phải (Nơi nghỉ chân an toàn)
            CreatePlatform(600, screenH - 350, 300, 20);

            // Bậc 4: Nhảy ngược lại về phía bên trái (Cao)
            CreatePlatform(350, screenH - 450, 150, 20);

            // Bậc 5: Bệ đỡ cuối cùng bên trái (Rất cao)
            CreatePlatform(100, screenH - 550, 200, 20);

            // --- 3. TIỀN THƯỞNG (Đặt ngay trên đường đi để khuyến khích) ---
            CreateCoin(150, screenH - 200);       // Trên bậc 1
            CreateCoin(400, screenH - 300);       // Trên bậc 2
            CreateCoin(750, screenH - 400);       // Trên bậc 3
            CreateCoin(screenW - 100, screenH - 120); // Một đồng khuyến mãi ở góc phải dưới đất

            // --- 4. NGƯỜI CHƠI VÀ CỬA ---
            // Xuất phát ở góc trái dưới
            CreatePlayer(20, screenH - 100);

            // Cửa nằm trên bệ cao nhất bên trái (Dễ nhìn thấy đích đến)
            CreateDoor(150, screenH - 620);
        }
        private void CreatePlatform(int x, int y, int w, int h)
        {
            PictureBox p = new PictureBox { Location = new Point(x, y), Size = new Size(w, h), Tag = "platform" };
            if (imgPlatform != null) p.Image = imgPlatform;
            else p.BackColor = Color.Brown;
            p.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(p);
        }
        private void CreateCoin(int x, int y)
        {
            PictureBox p = new PictureBox { Location = new Point(x, y), Size = new Size(30, 30), Tag = "coin", BackColor = Color.Transparent };
            if (imgCoin != null) p.Image = imgCoin;
            else p.BackColor = Color.Yellow;
            p.SizeMode = PictureBoxSizeMode.Zoom;
            this.Controls.Add(p); p.BringToFront();
        }
        private void CreateDoor(int x, int y)
        {
            PictureBox p = new PictureBox { Location = new Point(x, y), Size = new Size(50, 70), Tag = "door", BackColor = Color.Transparent };
            if (imgDoor != null) p.Image = imgDoor;
            else p.BackColor = Color.DarkRed;
            p.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(p);
        }
        private void CreatePlayer(int x, int y)
        {
            player = new PictureBox { Location = new Point(x, y), Size = new Size(playerWidth, playerHeight), Tag = "player", BackColor = Color.Transparent };
            if (imgPlayerIdleRight != null) player.Image = imgPlayerIdleRight;
            else player.BackColor = Color.Blue;
            player.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(player); player.BringToFront();
        }

        // --- MAIN LOGIC ---
        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            if (isPaused) return;

            txtScore.Text = "Level: " + currentLevel + "/" + MAX_LEVEL + " | Score: " + score;

            UpdatePlayerAnimation();

            if (jumping == true)
            {
                jumpSpeed = -10;
                force -= 1;
            }
            else
            {
                jumpSpeed = gravitySpeed;
            }

            if (jumping == true && force < 0)
            {
                jumping = false;
            }

            player.Top += jumpSpeed;

            if (goLeft == true && player.Left > 0) player.Left -= playerSpeed;
            if (goRight == true && player.Left + player.Width < screenW) player.Left += playerSpeed;

            isOnGround = false;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "platform")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            if (jumpSpeed >= 0 && player.Bottom <= x.Bottom)
                            {
                                player.Top = x.Top - player.Height;
                                isOnGround = true;
                                jumping = false;
                                force = jumpForceInitial;
                            }
                            else if (jumpSpeed < 0 && player.Top > x.Top)
                            {
                                jumping = false;
                                force = -1;
                                player.Top = x.Bottom;
                            }
                        }
                    }

                    if ((string)x.Tag == "coin" && x.Visible)
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            x.Visible = false;
                            score += 10;
                            PlaySound(soundCoin); // --- MỚI: Âm thanh ăn tiền
                        }
                    }

                    if ((string)x.Tag == "door")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            WinLevel();
                        }
                    }
                }
            }

            if (player.Top > screenH) GameOver("GAME OVER!");
        }

        private void UpdatePlayerAnimation()
        {
            Image currentIdle = facingRight ? imgPlayerIdleRight : imgPlayerIdleLeft;
            Image currentJump = facingRight ? imgPlayerJumpRight : imgPlayerJumpLeft;
            Image currentCrouch = facingRight ? imgPlayerCrouchRight : imgPlayerCrouchLeft;

            if (jumping && !isOnGround)
            {
                if (currentJump != null) player.Image = currentJump;
                player.Size = new Size(playerWidth, playerHeight);
            }
            else if (isCrouching && isOnGround)
            {
                if (currentCrouch != null) player.Image = currentCrouch;
                if (player.Height != playerCrouchHeight)
                {
                    player.Top += (playerHeight - playerCrouchHeight);
                    player.Height = playerCrouchHeight;
                }
            }
            else
            {
                if (currentIdle != null) player.Image = currentIdle;
                if (player.Height != playerHeight)
                {
                    player.Top -= (playerHeight - playerCrouchHeight);
                    player.Height = playerHeight;
                }
            }
        }

        private void WinLevel()
        {
            gameTimer.Stop();
            isLevelComplete = true;

            // --- MỚI: Âm thanh chiến thắng
            PlaySound(soundWin);

            string title = "COMPLETED!";
            string msg = "Level " + currentLevel + " Finished!\nScore: " + score + "\n\nPRESS [ENTER] FOR NEXT LEVEL";
            Color c = Color.Green;

            if (currentLevel == MAX_LEVEL)
            {
                title = "VICTORY!";
                msg = "YOU BEAT THE GAME!\nFINAL SCORE: " + score + "\n\nPRESS [ENTER] TO RESTART";
                c = Color.Gold;
            }

            ShowCustomMessage(title, msg, c);
        }

        private void GameOver(string msg)
        {
            gameTimer.Stop();
            isGameOver = true;

            // --- MỚI: Âm thanh thua cuộc
            PlaySound(soundLose);

            ShowCustomMessage("GAME OVER", "Don't give up!\nScore: " + score + "\n\nPRESS [ENTER] TO RETRY", Color.Red);
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A) { goLeft = true; facingRight = false; }
            if (e.KeyCode == Keys.D) { goRight = true; facingRight = true; }
            if (e.KeyCode == Keys.S) isCrouching = true;

            if (e.KeyCode == Keys.W && isOnGround == true && !isCrouching)
            {
                jumping = true;
                isOnGround = false;
                PlaySound(soundJump); // --- MỚI: Âm thanh nhảy
            }

            if (e.KeyCode == Keys.Escape) Application.Exit();
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A) goLeft = false;
            if (e.KeyCode == Keys.D) goRight = false;
            if (e.KeyCode == Keys.S) isCrouching = false;

            if (e.KeyCode == Keys.Enter)
            {
                if (pnlMessageBoard != null) pnlMessageBoard.Visible = false;

                if (!isGameStarted)
                {
                    isGameStarted = true;
                    SetupGameLevel();
                }
                else if (isLevelComplete)
                {
                    if (currentLevel < MAX_LEVEL) { currentLevel++; SetupGameLevel(); }
                    else { currentLevel = 1; score = 0; SetupGameLevel(); }
                }
                else if (isGameOver)
                {
                    SetupGameLevel();
                }
            }

            if (e.KeyCode == Keys.P && isGameStarted && !isGameOver && !isLevelComplete)
            {
                isPaused = !isPaused;
                if (isPaused) { lblMessage.Text = "PAUSED"; lblMessage.ForeColor = Color.Yellow; lblMessage.Visible = true; UpdateMessagePosition(); }
                else { lblMessage.Visible = false; }
            }
        }
    }
}