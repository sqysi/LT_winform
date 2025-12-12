using System.Drawing;
using System.Windows.Forms;

namespace BaiTap
{
    public partial class FormChild : Form
    {
        public FormChild()
        {
            InitializeComponent();
        }

        // Hàm nh?n ???ng d?n ?nh và hi?n th? lên
        public void SetImage(string path)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(path);
                this.Text = path; // ??i tên c?a s? thành ???ng d?n file
            }
            catch
            {
                MessageBox.Show("Không th? m? ?nh này!");
            }
        }
    }
}