namespace BaiTap
{
    partial class Article11
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
            // Khởi tạo các biến
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btnDiv = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btnMul = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btnSub = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btnDot = new System.Windows.Forms.Button();
            this.btnEqual = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // 1. Cấu hình Màn hình hiển thị (txtDisplay)
            // 
            this.txtDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.txtDisplay.Location = new System.Drawing.Point(12, 12);
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.Size = new System.Drawing.Size(260, 38);
            this.txtDisplay.TabIndex = 0;
            this.txtDisplay.Text = "0";
            this.txtDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right; // Căn lề phải giống máy tính thật

            // 
            // Cấu hình chung cho các nút (Vị trí x, y và Kích thước)
            // 
            // Hàng 1: 7, 8, 9, /
            this.btn7.Location = new System.Drawing.Point(12, 70);
            this.btn7.Size = new System.Drawing.Size(60, 50);
            this.btn7.Text = "7";
            this.btn7.Click += new System.EventHandler(this.button_Click); // Gán sự kiện nhập số

            this.btn8.Location = new System.Drawing.Point(78, 70);
            this.btn8.Size = new System.Drawing.Size(60, 50);
            this.btn8.Text = "8";
            this.btn8.Click += new System.EventHandler(this.button_Click);

            this.btn9.Location = new System.Drawing.Point(144, 70);
            this.btn9.Size = new System.Drawing.Size(60, 50);
            this.btn9.Text = "9";
            this.btn9.Click += new System.EventHandler(this.button_Click);

            this.btnDiv.Location = new System.Drawing.Point(210, 70);
            this.btnDiv.Size = new System.Drawing.Size(60, 50);
            this.btnDiv.Text = "/";
            this.btnDiv.BackColor = System.Drawing.Color.LightGray;
            this.btnDiv.Click += new System.EventHandler(this.operator_Click); // Gán sự kiện phép tính

            // Hàng 2: 4, 5, 6, *
            this.btn4.Location = new System.Drawing.Point(12, 126);
            this.btn4.Size = new System.Drawing.Size(60, 50);
            this.btn4.Text = "4";
            this.btn4.Click += new System.EventHandler(this.button_Click);

            this.btn5.Location = new System.Drawing.Point(78, 126);
            this.btn5.Size = new System.Drawing.Size(60, 50);
            this.btn5.Text = "5";
            this.btn5.Click += new System.EventHandler(this.button_Click);

            this.btn6.Location = new System.Drawing.Point(144, 126);
            this.btn6.Size = new System.Drawing.Size(60, 50);
            this.btn6.Text = "6";
            this.btn6.Click += new System.EventHandler(this.button_Click);

            this.btnMul.Location = new System.Drawing.Point(210, 126);
            this.btnMul.Size = new System.Drawing.Size(60, 50);
            this.btnMul.Text = "*";
            this.btnMul.BackColor = System.Drawing.Color.LightGray;
            this.btnMul.Click += new System.EventHandler(this.operator_Click);

            // Hàng 3: 1, 2, 3, -
            this.btn1.Location = new System.Drawing.Point(12, 182);
            this.btn1.Size = new System.Drawing.Size(60, 50);
            this.btn1.Text = "1";
            this.btn1.Click += new System.EventHandler(this.button_Click);

            this.btn2.Location = new System.Drawing.Point(78, 182);
            this.btn2.Size = new System.Drawing.Size(60, 50);
            this.btn2.Text = "2";
            this.btn2.Click += new System.EventHandler(this.button_Click);

            this.btn3.Location = new System.Drawing.Point(144, 182);
            this.btn3.Size = new System.Drawing.Size(60, 50);
            this.btn3.Text = "3";
            this.btn3.Click += new System.EventHandler(this.button_Click);

            this.btnSub.Location = new System.Drawing.Point(210, 182);
            this.btnSub.Size = new System.Drawing.Size(60, 50);
            this.btnSub.Text = "-";
            this.btnSub.BackColor = System.Drawing.Color.LightGray;
            this.btnSub.Click += new System.EventHandler(this.operator_Click);

            // Hàng 4: 0, ., =, +
            this.btn0.Location = new System.Drawing.Point(12, 238);
            this.btn0.Size = new System.Drawing.Size(126, 50); // Nút 0 dài gấp đôi
            this.btn0.Text = "0";
            this.btn0.Click += new System.EventHandler(this.button_Click);

            this.btnDot.Location = new System.Drawing.Point(144, 238);
            this.btnDot.Size = new System.Drawing.Size(60, 50);
            this.btnDot.Text = ".";
            this.btnDot.Click += new System.EventHandler(this.button_Click);

            this.btnAdd.Location = new System.Drawing.Point(210, 238);
            this.btnAdd.Size = new System.Drawing.Size(60, 50);
            this.btnAdd.Text = "+";
            this.btnAdd.BackColor = System.Drawing.Color.LightGray;
            this.btnAdd.Click += new System.EventHandler(this.operator_Click);

            // Nút Bằng (=) và Xóa (C)
            this.btnEqual.Location = new System.Drawing.Point(210, 294);
            this.btnEqual.Size = new System.Drawing.Size(60, 50);
            this.btnEqual.Text = "=";
            this.btnEqual.BackColor = System.Drawing.Color.Orange;
            this.btnEqual.Click += new System.EventHandler(this.btnEqual_Click);

            this.btnClear.Location = new System.Drawing.Point(12, 294);
            this.btnClear.Size = new System.Drawing.Size(192, 50);
            this.btnClear.Text = "Clear";
            this.btnClear.BackColor = System.Drawing.Color.Red;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(284, 360);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEqual);
            this.Controls.Add(this.btnDot);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btnSub);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btnMul);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btnDiv);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.txtDisplay);
            this.Name = "Article11";
            this.Text = "Máy tính bỏ túi";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // Khai báo biến
        private System.Windows.Forms.TextBox txtDisplay;
        private System.Windows.Forms.Button btn7, btn8, btn9, btnDiv;
        private System.Windows.Forms.Button btn4, btn5, btn6, btnMul;
        private System.Windows.Forms.Button btn1, btn2, btn3, btnSub;
        private System.Windows.Forms.Button btn0, btnDot, btnEqual, btnAdd, btnClear;
    }
}