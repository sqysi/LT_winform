using System;
using System.Windows.Forms;

namespace BaiTap
{
    public partial class Article9 : Form
    {
        public Article9()
        {
            InitializeComponent();
        }

        // S? ki?n Tick: Ch?y l?p ?i l?p l?i sau m?i kho?ng th?i gian Interval (? ?ây là 100ms)
        private void timer1_Tick(object sender, EventArgs e)
        {
            // 1. C?p nh?t ??ng h?
            // DateTime.Now: L?y gi? h? th?ng hi?n t?i
            // ToString("HH:mm:ss"): ??nh d?ng gi?:phút:giây
            lb_Clock.Text = DateTime.Now.ToString("HH:mm:ss");

            // 2. Làm hi?u ?ng ch? ch?y
            // Gi?m t?a ?? Left (x) ?? ch? ch?y sang trái
            lb_RunningText.Left -= 5;

            // Ki?m tra: N?u ch? ch?y h?t màn hình bên trái (Left < 0 - chi?u dài ch?)
            // Thì reset nó v? l?i mép ph?i màn hình
            if (lb_RunningText.Right < 0)
            {
                lb_RunningText.Left = this.Width;
            }
        }

        // Nút Start: B?t ??u Timer
        private void bt_Start_Click(object sender, EventArgs e)
        {
            timer1.Start(); // Ho?c dùng: timer1.Enabled = true;
        }

        // Nút Stop: D?ng Timer
        private void bt_Stop_Click(object sender, EventArgs e)
        {
            timer1.Stop(); // Ho?c dùng: timer1.Enabled = false;
        }
    }
}
