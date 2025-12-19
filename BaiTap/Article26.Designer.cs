using System.Drawing;
using System.Windows.Forms;

namespace BaiTap
{
    partial class Article26
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
            // Article26
            // 
            Controls.Add(lbl);
            Load += Article26_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
