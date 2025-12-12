using System.Drawing;
using System.Windows.Forms;

namespace BaiTap
{
    partial class Article8
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
            this.components = new System.ComponentModel.Container();
            // Khởi tạo các thành phần
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mn_File = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.rtb_Content = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mn_ChangeColor = new System.Windows.Forms.ToolStripMenuItem();

            // Bắt đầu cấu hình
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();

            // 
            // 1. Cấu hình MenuStrip (Thanh thực đơn trên cùng)
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_File,
            this.mn_Edit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(400, 24);
            this.menuStrip1.Text = "menuStrip1";

            // --- Menu File ---
            this.mn_File.Name = "mn_File";
            this.mn_File.Size = new System.Drawing.Size(37, 20);
            this.mn_File.Text = "&File"; // Dấu & giúp dùng phím tắt Alt+F
            this.mn_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_Exit});

            // Mục Exit (Trong File)
            this.mn_Exit.Name = "mn_Exit";
            this.mn_Exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E))); // Phím tắt Ctrl+E
            this.mn_Exit.Size = new System.Drawing.Size(180, 22);
            this.mn_Exit.Text = "Exit";
            this.mn_Exit.Click += new System.EventHandler(this.mn_Exit_Click);

            // --- Menu Edit ---
            this.mn_Edit.Name = "mn_Edit";
            this.mn_Edit.Size = new System.Drawing.Size(39, 20);
            this.mn_Edit.Text = "&Edit";
            this.mn_Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_Clear});

            // Mục Clear (Trong Edit)
            this.mn_Clear.Name = "mn_Clear";
            this.mn_Clear.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L))); // Phím tắt Ctrl+L
            this.mn_Clear.Size = new System.Drawing.Size(180, 22);
            this.mn_Clear.Text = "Clear Text";
            this.mn_Clear.Click += new System.EventHandler(this.mn_Clear_Click);

            // 
            // 2. Cấu hình ContextMenuStrip (Menu chuột phải)
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_ChangeColor});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(148, 26);

            // Mục Change Color
            this.mn_ChangeColor.Name = "mn_ChangeColor";
            this.mn_ChangeColor.Size = new System.Drawing.Size(147, 22);
            this.mn_ChangeColor.Text = "Change Color";
            this.mn_ChangeColor.Click += new System.EventHandler(this.mn_ChangeColor_Click);

            // 
            // 3. Cấu hình RichTextBox (Vùng nhập liệu)
            // 
            this.rtb_Content.ContextMenuStrip = this.contextMenuStrip1; // GẮN MENU CHUỘT PHẢI VÀO ĐÂY
            this.rtb_Content.Dock = System.Windows.Forms.DockStyle.Fill; // Tràn đầy màn hình
            this.rtb_Content.Location = new System.Drawing.Point(0, 24);
            this.rtb_Content.Name = "rtb_Content";
            this.rtb_Content.Size = new System.Drawing.Size(400, 276);
            this.rtb_Content.TabIndex = 1;
            this.rtb_Content.Text = "Nhập văn bản vào đây và thử chuột phải...";

            // 
            // Cấu hình Form Article08
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.rtb_Content);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Article08";
            this.Text = "Article 08 - Menus";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mn_File;
        private System.Windows.Forms.ToolStripMenuItem mn_Exit;
        private System.Windows.Forms.ToolStripMenuItem mn_Edit;
        private System.Windows.Forms.ToolStripMenuItem mn_Clear;
        private System.Windows.Forms.RichTextBox rtb_Content;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mn_ChangeColor;
    }
}
