using System.Drawing;
using System.Windows.Forms;

namespace BaiTap
{
    partial class Article3
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
            lbl.Text = "Đây là bài số 3";
            // 
            // Article3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            ClientSize = new Size(400, 200);
            Controls.Add(lbl);
            Name = "Article3";
            Text = "Bài 3";
            Load += Article3_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
