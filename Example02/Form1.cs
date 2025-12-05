namespace Example02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bt_OK_Click(object sender, EventArgs e)
        {
            this.Text = "Article for Button";
            this.Size = new Size(500, 500);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
