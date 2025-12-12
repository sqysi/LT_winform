namespace BaiTap
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private ListBox listBox1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Segoe UI", 12F);
            listBox1.ItemHeight = 28;
            listBox1.Location = new Point(20, 20);
            listBox1.Size = new Size(300, 300);
            listBox1.DoubleClick += listBox1_DoubleClick;
            // 
            // Form1
            // 
            ClientSize = new Size(350, 360);
            Controls.Add(listBox1);
            Text = "Danh sách bài tập";
            Load += Form1_Load;
            ResumeLayout(false);
        }
    }
}
