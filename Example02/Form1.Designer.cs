namespace Example02
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.Windows.Forms.Button bt_OK;
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            bt_OK = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // bt_OK
            // 
            bt_OK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bt_OK.Location = new Point(631, 531);
            bt_OK.Name = "bt_OK";
            bt_OK.Size = new Size(80, 15);
            bt_OK.TabIndex = 0;
            bt_OK.Text = "OK";
            bt_OK.Click += bt_OK_Click;
            // 
            // button1
            // 
            button1.Location = new Point(267, 320);
            button1.Name = "button1";
            button1.Size = new Size(112, 54);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(701, 473);
            Controls.Add(button1);
            Controls.Add(bt_OK);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        private Button button1;
        #endregion
        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>


    }
}
