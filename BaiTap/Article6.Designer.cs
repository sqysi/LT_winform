using System.Drawing;
using System.Windows.Forms;

namespace BaiTap
{
    partial class Article6
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
            // Khởi tạo các biến Control
            this.lb_Name = new System.Windows.Forms.Label();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.dtp_Date = new System.Windows.Forms.DateTimePicker();
            this.cb_Show = new System.Windows.Forms.CheckBox();
            this.bt_OK = new System.Windows.Forms.Button();
            this.lb_Selected = new System.Windows.Forms.ListBox();
            this.SuspendLayout();

            // 
            // 1. Cấu hình Label (lb_Name)
            // 
            this.lb_Name.AutoSize = true;
            this.lb_Name.Location = new System.Drawing.Point(20, 30);
            this.lb_Name.Name = "lb_Name";
            this.lb_Name.Size = new System.Drawing.Size(35, 13);
            this.lb_Name.Text = "Name";

            // 
            // 2. Cấu hình TextBox (tb_Name)
            // 
            this.tb_Name.Location = new System.Drawing.Point(80, 27);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(200, 20);

            // 
            // 3. Cấu hình DateTimePicker (dtp_Date)
            // 
            this.dtp_Date.Location = new System.Drawing.Point(80, 70);
            this.dtp_Date.Name = "dtp_Date";
            this.dtp_Date.Size = new System.Drawing.Size(200, 20);
            this.dtp_Date.Format = System.Windows.Forms.DateTimePickerFormat.Short; // Hiển thị ngày ngắn gọn

            // 
            // 4. Cấu hình CheckBox (cb_Show)
            // 
            this.cb_Show.AutoSize = true;
            this.cb_Show.Location = new System.Drawing.Point(80, 110);
            this.cb_Show.Name = "cb_Show";
            this.cb_Show.Size = new System.Drawing.Size(95, 17);
            this.cb_Show.Text = "Show Program";
            this.cb_Show.UseVisualStyleBackColor = true;

            // 
            // 5. Cấu hình ListBox (lb_Selected) - nằm bên phải hoặc dưới
            // 
            this.lb_Selected.FormattingEnabled = true;
            this.lb_Selected.Location = new System.Drawing.Point(23, 150);
            this.lb_Selected.Name = "lb_Selected";
            this.lb_Selected.Size = new System.Drawing.Size(260, 95);

            // 
            // 6. Cấu hình Button (bt_OK)
            // 
            this.bt_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_OK.Location = new System.Drawing.Point(208, 260);
            this.bt_OK.Name = "bt_OK";
            this.bt_OK.Size = new System.Drawing.Size(75, 25);
            this.bt_OK.Text = "OK";
            this.bt_OK.UseVisualStyleBackColor = true;
            this.bt_OK.Click += new System.EventHandler(this.bt_OK_Click); // Gán sự kiện Click

            // 
            // Cấu hình chung cho Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 300);
            this.Controls.Add(this.lb_Selected);
            this.Controls.Add(this.bt_OK);
            this.Controls.Add(this.cb_Show);
            this.Controls.Add(this.dtp_Date);
            this.Controls.Add(this.tb_Name);
            this.Controls.Add(this.lb_Name);
            this.Name = "Form1";
            this.Text = "Article 06"; // Tiêu đề Form
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // Khai báo biến toàn cục cho các Control
        private System.Windows.Forms.Label lb_Name;
        private System.Windows.Forms.TextBox tb_Name;
        private System.Windows.Forms.DateTimePicker dtp_Date;
        private System.Windows.Forms.CheckBox cb_Show;
        private System.Windows.Forms.Button bt_OK;
        private System.Windows.Forms.ListBox lb_Selected;
    }
}
