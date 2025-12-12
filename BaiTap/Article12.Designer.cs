namespace BaiTap
{
    partial class Article12
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
            this.tv_Data = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.bt_AddRoot = new System.Windows.Forms.Button();
            this.bt_AddChild = new System.Windows.Forms.Button();
            this.bt_Remove = new System.Windows.Forms.Button();
            this.bt_ExpandAll = new System.Windows.Forms.Button();
            this.bt_CollapseAll = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();

            // 
            // 1. Cấu hình TreeView (tv_Data)
            // 
            this.tv_Data.Location = new System.Drawing.Point(12, 12);
            this.tv_Data.Name = "tv_Data";
            this.tv_Data.Size = new System.Drawing.Size(250, 300);
            this.tv_Data.TabIndex = 0;
            // Gán sự kiện AfterSelect (Chạy sau khi click chọn 1 nút)
            this.tv_Data.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_Data_AfterSelect);

            // 
            // 2. Khu vực nhập liệu bên phải
            // 
            this.groupBox1.Controls.Add(this.bt_CollapseAll);
            this.groupBox1.Controls.Add(this.bt_ExpandAll);
            this.groupBox1.Controls.Add(this.bt_Remove);
            this.groupBox1.Controls.Add(this.bt_AddChild);
            this.groupBox1.Controls.Add(this.bt_AddRoot);
            this.groupBox1.Controls.Add(this.txtInput);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(280, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 300);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control Panel";

            // Label
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 30);
            this.label1.Text = "Nhập tên Node:";

            // TextBox Input
            this.txtInput.Location = new System.Drawing.Point(10, 50);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(180, 20);

            // Button Add Root (Thêm Khoa)
            this.bt_AddRoot.Location = new System.Drawing.Point(10, 90);
            this.bt_AddRoot.Name = "bt_AddRoot";
            this.bt_AddRoot.Size = new System.Drawing.Size(180, 30);
            this.bt_AddRoot.Text = "Thêm Gốc (Root)";
            this.bt_AddRoot.Click += new System.EventHandler(this.bt_AddRoot_Click);

            // Button Add Child (Thêm Lớp)
            this.bt_AddChild.Location = new System.Drawing.Point(10, 130);
            this.bt_AddChild.Name = "bt_AddChild";
            this.bt_AddChild.Size = new System.Drawing.Size(180, 30);
            this.bt_AddChild.Text = "Thêm Con (Child)";
            this.bt_AddChild.Click += new System.EventHandler(this.bt_AddChild_Click);

            // Button Remove
            this.bt_Remove.Location = new System.Drawing.Point(10, 170);
            this.bt_Remove.Name = "bt_Remove";
            this.bt_Remove.Size = new System.Drawing.Size(180, 30);
            this.bt_Remove.Text = "Xóa Node Chọn";
            this.bt_Remove.BackColor = System.Drawing.Color.MistyRose;
            this.bt_Remove.Click += new System.EventHandler(this.bt_Remove_Click);

            // Button Expand All
            this.bt_ExpandAll.Location = new System.Drawing.Point(10, 220);
            this.bt_ExpandAll.Size = new System.Drawing.Size(85, 30);
            this.bt_ExpandAll.Text = "Mở rộng";
            this.bt_ExpandAll.Click += new System.EventHandler(this.bt_ExpandAll_Click);

            // Button Collapse All
            this.bt_CollapseAll.Location = new System.Drawing.Point(105, 220);
            this.bt_CollapseAll.Size = new System.Drawing.Size(85, 30);
            this.bt_CollapseAll.Text = "Thu gọn";
            this.bt_CollapseAll.Click += new System.EventHandler(this.bt_CollapseAll_Click);

            // Form Article12
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 330);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tv_Data);
            this.Name = "Article12";
            this.Text = "Article 12 - TreeView";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TreeView tv_Data;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_CollapseAll, bt_ExpandAll, bt_Remove, bt_AddChild, bt_AddRoot;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label1;
    }
}