namespace ADO
{
    partial class Form1
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
            this.dgvCustomer = new System.Windows.Forms.DataGridView();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.btNew = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btRead = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvCustomer (Lưới)
            // 
            this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomer.Location = new System.Drawing.Point(30, 150);
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.RowHeadersWidth = 62;
            this.dgvCustomer.Size = new System.Drawing.Size(700, 200);
            this.dgvCustomer.TabIndex = 8;
            this.dgvCustomer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomer_CellClick);

            // 
            // ID
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(30, 30);
            this.lblId.Name = "lblId";
            this.lblId.Text = "Mã KH:";

            this.txtId.Location = new System.Drawing.Point(90, 27);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(150, 26);
            this.txtId.TabIndex = 0;

            // 
            // Name
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(280, 30);
            this.lblName.Name = "lblName";
            this.lblName.Text = "Tên KH:";

            this.txtName.Location = new System.Drawing.Point(350, 27);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(250, 26);
            this.txtName.TabIndex = 1;

            // 
            // Phone (Mới)
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(30, 80);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Text = "SĐT:";

            this.txtPhone.Location = new System.Drawing.Point(90, 77);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(150, 26);
            this.txtPhone.TabIndex = 2;

            // 
            // Gender (Radio Buttons - Mới)
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(280, 80);
            this.lblGender.Name = "lblGender";
            this.lblGender.Text = "Giới tính:";

            this.rbMale.AutoSize = true;
            this.rbMale.Location = new System.Drawing.Point(360, 78);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(67, 24);
            this.rbMale.TabIndex = 3;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Nam";
            this.rbMale.UseVisualStyleBackColor = true;
            this.rbMale.Checked = true; // Mặc định chọn Nam

            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(440, 78);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(54, 24);
            this.rbFemale.TabIndex = 4;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Nữ";
            this.rbFemale.UseVisualStyleBackColor = true;

            // 
            // Buttons
            // 
            this.btNew.Location = new System.Drawing.Point(30, 380);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(100, 40);
            this.btNew.Text = "Thêm";
            this.btNew.UseVisualStyleBackColor = true;
            this.btNew.Click += new System.EventHandler(this.btNew_Click);

            this.btDelete.Location = new System.Drawing.Point(150, 380);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(100, 40);
            this.btDelete.Text = "Xóa";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);

            this.btEdit.Location = new System.Drawing.Point(270, 380);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(100, 40);
            this.btEdit.Text = "Sửa";
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);

            this.btRead.Location = new System.Drawing.Point(580, 380);
            this.btRead.Name = "btRead";
            this.btRead.Size = new System.Drawing.Size(150, 40);
            this.btRead.Text = "Đọc Dữ Liệu";
            this.btRead.UseVisualStyleBackColor = true;
            this.btRead.Click += new System.EventHandler(this.btRead_Click);

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 450);
            this.Controls.Add(this.btRead);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btNew);
            this.Controls.Add(this.rbFemale); // Thêm Radio Nữ
            this.Controls.Add(this.rbMale);   // Thêm Radio Nam
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.dgvCustomer);
            this.Name = "Form1";
            this.Text = "Quản Lý Khách Hàng";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCustomer;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPhone; // Mới
        private System.Windows.Forms.TextBox txtPhone; // Mới
        private System.Windows.Forms.Label lblGender; // Mới
        private System.Windows.Forms.RadioButton rbMale; // Mới (Nam)
        private System.Windows.Forms.RadioButton rbFemale; // Mới (Nữ)
        private System.Windows.Forms.Button btNew;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btRead;
    }
}