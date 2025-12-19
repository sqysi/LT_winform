using System.Windows.Forms;

namespace BaiTap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("Bài 1");
            listBox1.Items.Add("Bài 2");
            listBox1.Items.Add("Bài 3");
            listBox1.Items.Add("Bài 5");
            listBox1.Items.Add("Bài 6");
            listBox1.Items.Add("Bài 7");
            listBox1.Items.Add("Bài 8");
            listBox1.Items.Add("Bài 9");
            listBox1.Items.Add("Bài 10");
            listBox1.Items.Add("Bài 11");
            listBox1.Items.Add("Bài 12");
            listBox1.Items.Add("Bài 13");
            listBox1.Items.Add("Bài 14");
            listBox1.Items.Add("Bài 16");
            listBox1.Items.Add("Bài 17");
            listBox1.Items.Add("Bài 18");
            listBox1.Items.Add("Bài 19");
            listBox1.Items.Add("Bài 20");
            listBox1.Items.Add("Bài 25");
            listBox1.Items.Add("Bài 26");
            listBox1.Items.Add("Bài 28");


        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;

            string selected = listBox1.SelectedItem.ToString();

            Form frm = selected switch
            {
                "Bài 1" => new Article1(),
                "Bài 2" => new Article2(),
                "Bài 3" => new Article3(),
                "Bài 5" => new Article5(),
                "Bài 6" => new Article6(),
                "Bài 7" => new Article7(),
                "Bài 8" => new Article8(),
                "Bài 9" => new Article9(),
                "Bài 10" => new Article10(),
                "Bài 11" => new Article11(),
                "Bài 12" => new Article12(),
                "Bài 13" => new Article13(),
                "Bài 14" => new Article14(),
                "Bài 16" => new Article16(),
                "Bài 17" => new Article17(),
                "Bài 18" => new Article18(),
                "Bài 19" => new Article19(),
                "Bài 20" => new Article20(),
                "Bài 25" => new Article25(),
                "Bài 26" => new Article26(),
                "Bài 27" => new Article27(),
                "Bài 28" => new Game(),


                _ => null
            };

            frm?.Show();
        }
    }
}
