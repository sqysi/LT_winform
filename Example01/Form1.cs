using System.Xml.Serialization;

namespace Example01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        string path = @"D:\form.xml";
        public void Write(InfoWindows iw)
        {
            XmlSerializer write = new XmlSerializer(typeof(InfoWindows));
            StreamWriter file = new StreamWriter(path);
            write.Serialize(file, iw);
            file.Close();
        }

        void Form1_Load(object sender, EventArgs e)
        {
            InfoWindows iw = new InfoWindows();
            iw.Width = this.Size.Width;
            iw.Height = this.Size.Height;
            Write(iw);
            //this.Text = width.ToString() + " - " + height.ToString();
        }

        void Form1_ResizeEnd(object sender, EventArgs e)
        {
            InfoWindows iw = new InfoWindows();
            iw.Width = this.Size.Width;
            iw.Height = this.Size.Height;
            Write(iw);

            //int width = this.Size.Width;
            //int height = this.Size.Height;
            //this.Text = width.ToString() + " - " + height.ToString();
        }
    }
}
