namespace Example03
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            tbYear = new TextBox();
            textBox2 = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 65);
            label1.Name = "label1";
            label1.Size = new Size(44, 25);
            label1.TabIndex = 0;
            label1.Text = "Year";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 108);
            label2.Name = "label2";
            label2.Size = new Size(127, 25);
            label2.TabIndex = 1;
            label2.Text = "PhoneNumber";
            // 
            // tbYear
            // 
            tbYear.Location = new Point(172, 65);
            tbYear.Name = "tbYear";
            tbYear.Size = new Size(222, 31);
            tbYear.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(172, 108);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(222, 31);
            textBox2.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(492, 207);
            Controls.Add(textBox2);
            Controls.Add(tbYear);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox tbYear;
        private TextBox textBox2;
    }
}
