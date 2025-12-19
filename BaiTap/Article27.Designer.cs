using System.Drawing;
using System.Windows.Forms;

namespace BaiTap
{
    partial class Article27
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
            // 
            // Article27
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            ClientSize = new Size(400, 200);
            Name = "Article27";
            Load += Article27_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
