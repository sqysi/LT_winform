using System.Drawing;
using System.Windows.Forms;

namespace BaiTap
{
    partial class Article25
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
            // Article25
            // 
            Controls.Add(lbl);
            Name = "Article25";
            Load += Article25_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
