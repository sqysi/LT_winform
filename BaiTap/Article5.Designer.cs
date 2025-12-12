namespace BaiTap
{
    partial class Article5
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
            // Khởi tạo nút bấm bt_OK (Dựa trên Slide 51)
            this.bt_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_OK
            // 
            // Cấu hình thuộc tính Anchor: Bám dính vào cạnh Dưới (Bottom) và Phải (Right)
            this.bt_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            // Cấu hình vị trí xuất hiện trên Form
            this.bt_OK.Location = new System.Drawing.Point(208, 302);
            // Đặt tên biến cho control (quan trọng để gọi trong code)
            this.bt_OK.Name = "bt_OK";
            // Kích thước nút bấm
            this.bt_OK.Size = new System.Drawing.Size(80, 25);
            // Thứ tự tab (khi nhấn phím Tab để chuyển đổi)
            this.bt_OK.TabIndex = 0;
            // Chữ hiển thị trên nút
            this.bt_OK.Text = "OK";
            this.bt_OK.UseVisualStyleBackColor = true;
            // Gán sự kiện Click: Khi nhấn nút sẽ chạy hàm bt_OK_Click
            this.bt_OK.Click += new System.EventHandler(this.bt_OK_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 350); // Kích thước ví dụ cho Form chứa vừa nút
            this.Controls.Add(this.bt_OK); // Thêm nút bt_OK vào danh sách điều khiển của Form
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        // Khai báo biến button (Dựa trên dòng 3 của Slide 51)
        private System.Windows.Forms.Button bt_OK;
    }
}