using System.Drawing;
using System.Windows.Forms;

namespace BaiTap
{
    partial class Article1
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblHello;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblHello = new Label();
            SuspendLayout();
            // 
            // lblHello
            // 
            lblHello.AutoSize = true;
            lblHello.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHello.Location = new Point(30, 40);
            lblHello.Name = "lblHello";
            lblHello.Size = new Size(120, 37);
            lblHello.Text = "Hello!!!";
            // 
            // Article1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            ClientSize = new Size(400, 200);
            Controls.Add(lblHello);
            Name = "Article1";
            Text = "Bài 1";
            Load += Article1_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
