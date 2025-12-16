using System.Drawing;
using System.Windows.Forms;

namespace BaiTap
{
    partial class Article16
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
            this.lblHoTen = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblDob = new System.Windows.Forms.Label();
            this.dtpDob = new System.Windows.Forms.DateTimePicker();
            this.gbGender = new System.Windows.Forms.GroupBox();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.lblFaculty = new System.Windows.Forms.Label();
            this.cbFaculty = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.ListBox();
            this.btAdd = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.gbGender.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(30, 20);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(54, 13);
            this.lblHoTen.TabIndex = 0;
            this.lblHoTen.Text = "Họ và tên";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(100, 17);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(200, 20);
            this.tbName.TabIndex = 1;
            // 
            // lblDob
            // 
            this.lblDob.AutoSize = true;
            this.lblDob.Location = new System.Drawing.Point(30, 55);
            this.lblDob.Name = "lblDob";
            this.lblDob.Size = new System.Drawing.Size(56, 13);
            this.lblDob.TabIndex = 2;
            this.lblDob.Text = "Ngày Sinh";
            // 
            // dtpDob
            // 
            this.dtpDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDob.Location = new System.Drawing.Point(100, 51);
            this.dtpDob.Name = "dtpDob";
            this.dtpDob.Size = new System.Drawing.Size(200, 20);
            this.dtpDob.TabIndex = 3;
            // 
            // gbGender
            // 
            this.gbGender.Controls.Add(this.rbFemale);
            this.gbGender.Controls.Add(this.rbMale);
            this.gbGender.Location = new System.Drawing.Point(100, 80);
            this.gbGender.Name = "gbGender";
            this.gbGender.Size = new System.Drawing.Size(200, 50);
            this.gbGender.TabIndex = 4;
            this.gbGender.TabStop = false;
            this.gbGender.Text = "Giới tính";
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(120, 20);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(39, 17);
            this.rbFemale.TabIndex = 1;
            this.rbFemale.Text = "Nữ";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Checked = true;
            this.rbMale.Location = new System.Drawing.Point(30, 20);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(47, 17);
            this.rbMale.TabIndex = 0;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Nam";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // lblFaculty
            // 
            this.lblFaculty.AutoSize = true;
            this.lblFaculty.Location = new System.Drawing.Point(30, 145);
            this.lblFaculty.Name = "lblFaculty";
            this.lblFaculty.Size = new System.Drawing.Size(32, 13);
            this.lblFaculty.TabIndex = 5;
            this.lblFaculty.Text = "Khoa";
            // 
            // cbFaculty
            // 
            this.cbFaculty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFaculty.FormattingEnabled = true;
            this.cbFaculty.Location = new System.Drawing.Point(100, 142);
            this.cbFaculty.Name = "cbFaculty";
            this.cbFaculty.Size = new System.Drawing.Size(200, 21);
            this.cbFaculty.TabIndex = 6;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(30, 180);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(55, 13);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Trạng thái";
            // 
            // lbStatus
            // 
            this.lbStatus.FormattingEnabled = true;
            this.lbStatus.Location = new System.Drawing.Point(100, 180);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(200, 134);
            this.lbStatus.TabIndex = 8;
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(120, 330);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(75, 23);
            this.btAdd.TabIndex = 9;
            this.btAdd.Text = "Thêm";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(210, 330);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(75, 23);
            this.btExit.TabIndex = 10;
            this.btExit.Text = "Thoát";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // Article16
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 380);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cbFaculty);
            this.Controls.Add(this.lblFaculty);
            this.Controls.Add(this.gbGender);
            this.Controls.Add(this.dtpDob);
            this.Controls.Add(this.lblDob);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblHoTen);
            this.Name = "Article16";
            this.Text = "Quản lý sinh viên";
            this.Load += new System.EventHandler(this.Article16_Load);
            this.gbGender.ResumeLayout(false);
            this.gbGender.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblDob;
        private System.Windows.Forms.DateTimePicker dtpDob;
        private System.Windows.Forms.GroupBox gbGender;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.Label lblFaculty;
        private System.Windows.Forms.ComboBox cbFaculty;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListBox lbStatus;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btExit;
    }
}