using System.Drawing;
using System.Windows.Forms;

namespace BaiTap
{
    partial class Article19
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMaNhanVien = new System.Windows.Forms.Label();
            this.txtMaNhanVien = new System.Windows.Forms.TextBox();
            this.lblTenNhanVien = new System.Windows.Forms.Label();
            this.txtTenNhanVien = new System.Windows.Forms.TextBox();
            this.lblAnh = new System.Windows.Forms.Label();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btFile = new System.Windows.Forms.Button();
            this.dgvEmployee = new System.Windows.Forms.DataGridView();
            this.colMa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaNhanVien
            // 
            this.lblMaNhanVien.AutoSize = true;
            this.lblMaNhanVien.Location = new System.Drawing.Point(20, 20);
            this.lblMaNhanVien.Name = "lblMaNhanVien";
            this.lblMaNhanVien.Size = new System.Drawing.Size(72, 13);
            this.lblMaNhanVien.TabIndex = 0;
            this.lblMaNhanVien.Text = "Mã nhân viên";
            // 
            // txtMaNhanVien
            // 
            this.txtMaNhanVien.Location = new System.Drawing.Point(110, 17);
            this.txtMaNhanVien.Name = "txtMaNhanVien";
            this.txtMaNhanVien.Size = new System.Drawing.Size(150, 20);
            this.txtMaNhanVien.TabIndex = 1;
            // 
            // lblTenNhanVien
            // 
            this.lblTenNhanVien.AutoSize = true;
            this.lblTenNhanVien.Location = new System.Drawing.Point(20, 50);
            this.lblTenNhanVien.Name = "lblTenNhanVien";
            this.lblTenNhanVien.Size = new System.Drawing.Size(76, 13);
            this.lblTenNhanVien.TabIndex = 2;
            this.lblTenNhanVien.Text = "Tên nhân viên";
            // 
            // txtTenNhanVien
            // 
            this.txtTenNhanVien.Location = new System.Drawing.Point(110, 47);
            this.txtTenNhanVien.Name = "txtTenNhanVien";
            this.txtTenNhanVien.Size = new System.Drawing.Size(250, 20);
            this.txtTenNhanVien.TabIndex = 3;
            // 
            // lblAnh
            // 
            this.lblAnh.AutoSize = true;
            this.lblAnh.Location = new System.Drawing.Point(20, 90);
            this.lblAnh.Name = "lblAnh";
            this.lblAnh.Size = new System.Drawing.Size(46, 13);
            this.lblAnh.TabIndex = 4;
            this.lblAnh.Text = "Ảnh 3x4";
            // 
            // pbImage
            // 
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Location = new System.Drawing.Point(110, 90);
            this.pbImage.Name = "pbImage"; // Tên theo Slide 128
            this.pbImage.Size = new System.Drawing.Size(120, 150);
            this.pbImage.TabIndex = 5;
            this.pbImage.TabStop = false;
            // 
            // btFile
            // 
            this.btFile.Location = new System.Drawing.Point(250, 90);
            this.btFile.Name = "btFile"; // Tên theo Slide 128
            this.btFile.Size = new System.Drawing.Size(100, 30);
            this.btFile.TabIndex = 6;
            this.btFile.Text = "Chọn ảnh ...";
            this.btFile.UseVisualStyleBackColor = true;
            this.btFile.Click += new System.EventHandler(this.btFile_Click);
            // 
            // dgvEmployee
            // 
            this.dgvEmployee.AllowUserToAddRows = false;
            this.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMa,
            this.colTen});
            this.dgvEmployee.Location = new System.Drawing.Point(23, 260);
            this.dgvEmployee.Name = "dgvEmployee"; // Tên theo Slide 133
            this.dgvEmployee.Size = new System.Drawing.Size(350, 150);
            this.dgvEmployee.TabIndex = 7;
            // 
            // colMa
            // 
            this.colMa.HeaderText = "Mã nhân viên"; // Tiêu đề cột 1 (Slide 132)
            this.colMa.Name = "colMa";
            this.colMa.Width = 120;
            // 
            // colTen
            // 
            this.colTen.HeaderText = "Tên nhân viên"; // Tiêu đề cột 2 (Slide 132)
            this.colTen.Name = "colTen";
            this.colTen.Width = 180;
            // 
            // Article19
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 430);
            this.Controls.Add(this.dgvEmployee);
            this.Controls.Add(this.btFile);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.lblAnh);
            this.Controls.Add(this.txtTenNhanVien);
            this.Controls.Add(this.lblTenNhanVien);
            this.Controls.Add(this.txtMaNhanVien);
            this.Controls.Add(this.lblMaNhanVien);
            this.Name = "Article19";
            this.Text = "Quản lý nhân sự";
            this.Load += new System.EventHandler(this.Article19_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaNhanVien;
        private System.Windows.Forms.TextBox txtMaNhanVien;
        private System.Windows.Forms.Label lblTenNhanVien;
        private System.Windows.Forms.TextBox txtTenNhanVien;
        private System.Windows.Forms.Label lblAnh;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btFile;
        private System.Windows.Forms.DataGridView dgvEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTen;
    }
}