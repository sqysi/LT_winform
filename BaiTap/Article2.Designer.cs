using System.Drawing;
using System.Windows.Forms;

namespace BaiTap
{
    partial class Article2
    {
        private Label lbl;

        private void InitializeComponent()
        {
            lbl = new Label();
            SuspendLayout();
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lbl.Location = new Point(20, 40);
            lbl.Text = "Đây là bài số 2";
            // 
            // Article2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            ClientSize = new Size(400, 200);
            Controls.Add(lbl);
            Name = "Article2";
            Text = "Bài 2";
            Load += Article2_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
