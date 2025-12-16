using System.Drawing;
using System.Windows.Forms;

namespace BaiTap
{
    partial class Article13
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
            this.lbSource = new System.Windows.Forms.ListBox();
            this.lbDest = new System.Windows.Forms.ListBox();
            this.btnToRight = new System.Windows.Forms.Button();
            this.btnAllToRight = new System.Windows.Forms.Button();
            this.btnToLeft = new System.Windows.Forms.Button();
            this.btnAllToLeft = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // 1. Cấu hình ListBox Trái (Nguồn)
            // 
            this.lbSource.FormattingEnabled = true;
            this.lbSource.Location = new System.Drawing.Point(30, 50);
            this.lbSource.Name = "lbSource";
            // SelectionMode.MultiExtended: Cho phép giữ Ctrl/Shift để chọn nhiều dòng
            this.lbSource.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbSource.Size = new System.Drawing.Size(150, 250);
            this.lbSource.TabIndex = 0;

            // 
            // 2. Cấu hình ListBox Phải (Đích)
            // 
            this.lbDest.FormattingEnabled = true;
            this.lbDest.Location = new System.Drawing.Point(300, 50);
            this.lbDest.Name = "lbDest";
            this.lbDest.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbDest.Size = new System.Drawing.Size(150, 250);
            this.lbDest.TabIndex = 1;

            // 
            // 3. Các nút điều hướng
            // 
            // Nút >
            this.btnToRight.Location = new System.Drawing.Point(200, 80);
            this.btnToRight.Name = "btnToRight";
            this.btnToRight.Size = new System.Drawing.Size(80, 30);
            this.btnToRight.Text = " > ";
            this.btnToRight.Click += new System.EventHandler(this.btnToRight_Click);

            // Nút >>
            this.btnAllToRight.Location = new System.Drawing.Point(200, 120);
            this.btnAllToRight.Name = "btnAllToRight";
            this.btnAllToRight.Size = new System.Drawing.Size(80, 30);
            this.btnAllToRight.Text = " >> ";
            this.btnAllToRight.Click += new System.EventHandler(this.btnAllToRight_Click);

            // Nút <
            this.btnToLeft.Location = new System.Drawing.Point(200, 160);
            this.btnToLeft.Name = "btnToLeft";
            this.btnToLeft.Size = new System.Drawing.Size(80, 30);
            this.btnToLeft.Text = " < ";
            this.btnToLeft.Click += new System.EventHandler(this.btnToLeft_Click);

            // Nút <<
            this.btnAllToLeft.Location = new System.Drawing.Point(200, 200);
            this.btnAllToLeft.Name = "btnAllToLeft";
            this.btnAllToLeft.Size = new System.Drawing.Size(80, 30);
            this.btnAllToLeft.Text = " << ";
            this.btnAllToLeft.Click += new System.EventHandler(this.btnAllToLeft_Click);

            // 
            // Label tiêu đề
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Text = "Danh sách có sẵn:";

            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 30);
            this.label2.Text = "Danh sách đã chọn:";

            // 
            // Form Article13
            // 
            this.ClientSize = new System.Drawing.Size(480, 350);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAllToLeft);
            this.Controls.Add(this.btnToLeft);
            this.Controls.Add(this.btnAllToRight);
            this.Controls.Add(this.btnToRight);
            this.Controls.Add(this.lbDest);
            this.Controls.Add(this.lbSource);
            this.Name = "Article13";
            this.Text = "Article 13 - ListBox Transfer";
            this.Load += new System.EventHandler(this.Article13_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox lbSource;
        private System.Windows.Forms.ListBox lbDest;
        private System.Windows.Forms.Button btnToRight, btnAllToRight, btnToLeft, btnAllToLeft;
        private System.Windows.Forms.Label label1, label2;
    }
}