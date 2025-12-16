using System.Drawing;
using System.Windows.Forms;

namespace BaiTap
{
    partial class Article14
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.gbGender = new System.Windows.Forms.GroupBox();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.ckDiscount = new System.Windows.Forms.CheckBox();
            this.tbDiscount = new System.Windows.Forms.TextBox();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.btRun = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.gbGender.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(12, 12);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(260, 20);
            this.tbName.TabIndex = 0;
            this.tbName.Text = "Nguyễn Văn A";
            // 
            // gbGender
            // 
            this.gbGender.Controls.Add(this.rbFemale);
            this.gbGender.Controls.Add(this.rbMale);
            this.gbGender.Location = new System.Drawing.Point(12, 48);
            this.gbGender.Name = "gbGender";
            this.gbGender.Size = new System.Drawing.Size(260, 70);
            this.gbGender.TabIndex = 1;
            this.gbGender.TabStop = false;
            this.gbGender.Text = "Giới tính";
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(150, 30);
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
            this.rbMale.Location = new System.Drawing.Point(50, 30);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(47, 17);
            this.rbMale.TabIndex = 0;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Nam";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // ckDiscount
            // 
            this.ckDiscount.AutoSize = true;
            this.ckDiscount.Location = new System.Drawing.Point(18, 135);
            this.ckDiscount.Name = "ckDiscount";
            this.ckDiscount.Size = new System.Drawing.Size(67, 17);
            this.ckDiscount.TabIndex = 2;
            this.ckDiscount.Text = "Giảm giá";
            this.ckDiscount.UseVisualStyleBackColor = true;
            this.ckDiscount.CheckedChanged += new System.EventHandler(this.ckDiscount_CheckedChanged);
            // 
            // tbDiscount
            // 
            this.tbDiscount.Enabled = false;
            this.tbDiscount.Location = new System.Drawing.Point(91, 133);
            this.tbDiscount.Name = "tbDiscount";
            this.tbDiscount.Size = new System.Drawing.Size(181, 20);
            this.tbDiscount.TabIndex = 3;
            // 
            // tbResult
            // 
            this.tbResult.Location = new System.Drawing.Point(12, 170);
            this.tbResult.Multiline = true;
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(260, 80);
            this.tbResult.TabIndex = 4;
            // 
            // btRun
            // 
            this.btRun.Location = new System.Drawing.Point(100, 265);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(75, 23);
            this.btRun.TabIndex = 5;
            this.btRun.Text = "Tính tiền";
            this.btRun.UseVisualStyleBackColor = true;
            this.btRun.Click += new System.EventHandler(this.btRun_Click);
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(197, 265);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(75, 23);
            this.btExit.TabIndex = 6;
            this.btExit.Text = "Thoát";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // Article14
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 301);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btRun);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.tbDiscount);
            this.Controls.Add(this.ckDiscount);
            this.Controls.Add(this.gbGender);
            this.Controls.Add(this.tbName);
            this.Name = "Article14";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Article14_Load);
            this.gbGender.ResumeLayout(false);
            this.gbGender.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.GroupBox gbGender;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.CheckBox ckDiscount;
        private System.Windows.Forms.TextBox tbDiscount;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Button btRun;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Label lblInstruction;
    }
}