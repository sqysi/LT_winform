using System.Drawing;
using System.Windows.Forms;

namespace BaiTap
{
    partial class Game
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
            // 
            // Game
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            ClientSize = new Size(400, 200);
            Controls.Add(lbl);
            Load += Game_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
