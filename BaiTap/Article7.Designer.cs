using System.Drawing;
using System.Windows.Forms;

namespace BaiTap
{
    partial class Article7
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
            this.lb_Name = new System.Windows.Forms.Label();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.dtp_Date = new System.Windows.Forms.DateTimePicker();
            this.cb_Show = new System.Windows.Forms.CheckBox();
            this.bt_OK = new System.Windows.Forms.Button();
            this.lb_Selected = new System.Windows.Forms.ListBox();
            // Thêm nút Remove mới
            this.bt_Remove = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lb_Name
            this.lb_Name.AutoSize = true;
            this.lb_Name.Location = new System.Drawing.Point(20, 30);
            this.lb_Name.Name = "lb_Name";
            this.lb_Name.Size = new System.Drawing.Size(35, 13);
            this.lb_Name.Text = "Name";

            // tb_Name
            this.tb_Name.Location = new System.Drawing.Point(80, 27);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(200, 20);

            // dtp_Date
            this.dtp_Date.Location = new System.Drawing.Point(80, 70);
            this.dtp_Date.Name = "dtp_Date";
            this.dtp_Date.Size = new System.Drawing.Size(200, 20);
            this.dtp_Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // cb_Show
            this.cb_Show.AutoSize = true;
            this.cb_Show.Location = new System.Drawing.Point(80, 110);
            this.cb_Show.Name = "cb_Show";
            this.cb_Show.Size = new System.Drawing.Size(95, 17);
            this.cb_Show.Text = "Show Program";
            this.cb_Show.UseVisualStyleBackColor = true;

            // lb_Selected
            this.lb_Selected.FormattingEnabled = true;
            this.lb_Selected.Location = new System.Drawing.Point(23, 150);
            this.lb_Selected.Name = "lb_Selected";
            this.lb_Selected.Size = new System.Drawing.Size(260, 95);

            // bt_OK
            this.bt_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_OK.Location = new System.Drawing.Point(208, 260);
            this.bt_OK.Name = "bt_OK";
            this.bt_OK.Size = new System.Drawing.Size(75, 25);
            this.bt_OK.Text = "OK";
            this.bt_OK.UseVisualStyleBackColor = true;
            this.bt_OK.Click += new System.EventHandler(this.bt_OK_Click);

            // 
            // CẤU HÌNH NÚT REMOVE MỚI
            // 
            this.bt_Remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Remove.Location = new System.Drawing.Point(120, 260); // Đặt bên cạnh nút OK
            this.bt_Remove.Name = "bt_Remove";
            this.bt_Remove.Size = new System.Drawing.Size(75, 25);
            this.bt_Remove.Text = "Remove";
            this.bt_Remove.UseVisualStyleBackColor = true;
            this.bt_Remove.Click += new System.EventHandler(this.bt_Remove_Click); // Gán sự kiện Click

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 300);
            this.Controls.Add(this.bt_Remove); // Nhớ add nút Remove vào Form
            this.Controls.Add(this.lb_Selected);
            this.Controls.Add(this.bt_OK);
            this.Controls.Add(this.cb_Show);
            this.Controls.Add(this.dtp_Date);
            this.Controls.Add(this.tb_Name);
            this.Controls.Add(this.lb_Name);
            this.Name = "Form1";
            this.Text = "Article 07 - MessageBox";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lb_Name;
        private System.Windows.Forms.TextBox tb_Name;
        private System.Windows.Forms.DateTimePicker dtp_Date;
        private System.Windows.Forms.CheckBox cb_Show;
        private System.Windows.Forms.Button bt_OK;
        private System.Windows.Forms.ListBox lb_Selected;
        private System.Windows.Forms.Button bt_Remove; // Khai báo nút mới    }
    }
}