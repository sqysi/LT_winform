using System.Drawing;
using System.Windows.Forms;

namespace BaiTap
{
    partial class Article10
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mn_File = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_Window = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_Cascade = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_TileH = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_TileV = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();

            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_File,
            this.mn_Window});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.Text = "menuStrip1";

            // --- Menu File ---
            this.mn_File.Text = "File";
            this.mn_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_Open,
            this.mn_Exit});

            // Open
            this.mn_Open.Text = "Open Image...";
            this.mn_Open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mn_Open.Click += new System.EventHandler(this.mn_Open_Click);

            // Exit
            this.mn_Exit.Text = "Exit";
            this.mn_Exit.Click += new System.EventHandler(this.mn_Exit_Click);

            // --- Menu Window (Sắp xếp cửa sổ) ---
            this.mn_Window.Text = "Window";
            this.mn_Window.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_Cascade,
            this.mn_TileH,
            this.mn_TileV});

            // Cascade
            this.mn_Cascade.Text = "Cascade";
            this.mn_Cascade.Click += new System.EventHandler(this.mn_Cascade_Click);

            // Tile Horizontal
            this.mn_TileH.Text = "Tile Horizontal";
            this.mn_TileH.Click += new System.EventHandler(this.mn_TileH_Click);

            // Tile Vertical
            this.mn_TileV.Text = "Tile Vertical";
            this.mn_TileV.Click += new System.EventHandler(this.mn_TileV_Click);

            // 
            // Form Article10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.menuStrip1);

            // QUAN TRỌNG: Biến form này thành form chứa (MDI Container)
            this.IsMdiContainer = true;

            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Article10";
            this.Text = "Article 10 - MDI Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized; // Mở lên là phóng to hết cỡ
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mn_File, mn_Open, mn_Exit;
        private System.Windows.Forms.ToolStripMenuItem mn_Window, mn_Cascade, mn_TileH, mn_TileV;
    }
}
