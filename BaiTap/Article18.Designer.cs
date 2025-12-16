using System.Drawing;
using System.Windows.Forms;

namespace BaiTap
{
    partial class Article18
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboList = new System.Windows.Forms.ComboBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblResultItem = new System.Windows.Forms.Label();
            this.lblResultIndex = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Blue;
            this.lblTitle.Location = new System.Drawing.Point(50, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(225, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "MINH HỌA COMBOBOX";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboList);
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtInput);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 150);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thao tác";
            // 
            // cboList
            // 
            this.cboList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboList.FormattingEnabled = true;
            this.cboList.Location = new System.Drawing.Point(80, 70);
            this.cboList.Name = "cboList";
            this.cboList.Size = new System.Drawing.Size(200, 21);
            this.cboList.TabIndex = 4;
            this.cboList.SelectedIndexChanged += new System.EventHandler(this.cboList_SelectedIndexChanged);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(190, 110);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(90, 30);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Xóa mục chọn";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(80, 110);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 30);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Thêm vào DS";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(80, 30);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(200, 20);
            this.txtInput.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập từ:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblResultItem);
            this.groupBox2.Controls.Add(this.lblResultIndex);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 220);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(310, 80);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin chi tiết";
            // 
            // lblResultItem
            // 
            this.lblResultItem.AutoSize = true;
            this.lblResultItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultItem.ForeColor = System.Drawing.Color.Red;
            this.lblResultItem.Location = new System.Drawing.Point(180, 50);
            this.lblResultItem.Name = "lblResultItem";
            this.lblResultItem.Size = new System.Drawing.Size(19, 13);
            this.lblResultItem.TabIndex = 3;
            this.lblResultItem.Text = "...";
            // 
            // lblResultIndex
            // 
            this.lblResultIndex.AutoSize = true;
            this.lblResultIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultIndex.ForeColor = System.Drawing.Color.Red;
            this.lblResultIndex.Location = new System.Drawing.Point(180, 25);
            this.lblResultIndex.Name = "lblResultIndex";
            this.lblResultIndex.Size = new System.Drawing.Size(19, 13);
            this.lblResultIndex.TabIndex = 2;
            this.lblResultIndex.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nội dung (SelectedItem)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Chỉ số (SelectedIndex)";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(247, 310);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Article18
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 345);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitle);
            this.Name = "Article18";
            this.Text = "Combobox Demo";
            this.Load += new System.EventHandler(this.Article18_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblResultItem;
        private System.Windows.Forms.Label lblResultIndex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExit;
    }
}