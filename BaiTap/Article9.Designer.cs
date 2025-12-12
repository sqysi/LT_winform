using System.Drawing;
using System.Windows.Forms;

namespace BaiTap
{
    partial class Article9
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            // Khởi tạo các biến
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lb_Clock = new System.Windows.Forms.Label();
            this.lb_RunningText = new System.Windows.Forms.Label();
            this.bt_Start = new System.Windows.Forms.Button();
            this.bt_Stop = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // 1. Cấu hình Timer (Quan trọng nhất)
            // 
            // Interval = 100 nghĩa là 0.1 giây chạy 1 lần (để chữ chạy mượt)
            // Nếu chỉ làm đồng hồ thì để 1000 (1 giây) là đủ.
            this.timer1.Interval = 100;
            // Gán sự kiện Tick (Nhịp đập của đồng hồ)
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);

            // 
            // 2. Cấu hình Label Đồng hồ (lb_Clock)
            // 
            this.lb_Clock.AutoSize = true;
            this.lb_Clock.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lb_Clock.ForeColor = System.Drawing.Color.Blue;
            this.lb_Clock.Location = new System.Drawing.Point(100, 50);
            this.lb_Clock.Name = "lb_Clock";
            this.lb_Clock.Size = new System.Drawing.Size(120, 32);
            this.lb_Clock.Text = "00:00:00"; // Giá trị ban đầu

            // 
            // 3. Cấu hình Label Chữ chạy (lb_RunningText)
            // 
            this.lb_RunningText.AutoSize = true;
            this.lb_RunningText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic);
            this.lb_RunningText.ForeColor = System.Drawing.Color.Red;
            this.lb_RunningText.Location = new System.Drawing.Point(12, 120); // Vị trí ban đầu
            this.lb_RunningText.Name = "lb_RunningText";
            this.lb_RunningText.Size = new System.Drawing.Size(250, 20);
            this.lb_RunningText.Text = "Xin chào! Chúc bạn học tốt C#";

            // 
            // 4. Cấu hình Button Start
            // 
            this.bt_Start.Location = new System.Drawing.Point(80, 200);
            this.bt_Start.Name = "bt_Start";
            this.bt_Start.Size = new System.Drawing.Size(75, 30);
            this.bt_Start.Text = "Start";
            this.bt_Start.Click += new System.EventHandler(this.bt_Start_Click);

            // 
            // 5. Cấu hình Button Stop
            // 
            this.bt_Stop.Location = new System.Drawing.Point(200, 200);
            this.bt_Stop.Name = "bt_Stop";
            this.bt_Stop.Size = new System.Drawing.Size(75, 30);
            this.bt_Stop.Text = "Stop";
            this.bt_Stop.Click += new System.EventHandler(this.bt_Stop_Click);

            // 
            // Form Article09
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.bt_Stop);
            this.Controls.Add(this.bt_Start);
            this.Controls.Add(this.lb_RunningText);
            this.Controls.Add(this.lb_Clock);
            this.Name = "Article09";
            this.Text = "Article 09 - Timer Control";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lb_Clock;
        private System.Windows.Forms.Label lb_RunningText;
        private System.Windows.Forms.Button bt_Start;
        private System.Windows.Forms.Button bt_Stop;
    }
}
