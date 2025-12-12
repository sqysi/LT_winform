using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BaiTap
{
    public partial class Article11 : Form
    {
        // Khai báo các bi?n toàn c?c ?? l?u tr?ng thái
        Double result = 0;      // L?u giá tr? s? h?ng ??u tiên
        String operation = "";  // L?u phép tính (+, -, *, /)
        bool isOperationPerformed = false; // Ki?m tra xem ng??i dùng v?a nh?n phím phép tính xong ?úng không
        public Article11()
        {
            InitializeComponent();
        }

        // 1. Hàm x? lý s? ki?n khi nh?n các nút S? (0-9) và d?u CH?M (.)
        // T?t c? các nút s? ??u ???c tr? v? hàm này (b?n xem trong file Designer)
        private void button_Click(object sender, EventArgs e)
        {
            // Ki?m tra: N?u màn hình ?ang là "0" ho?c ng??i dùng v?a nh?n phép tính xong
            // thì xóa màn hình ?i ?? nh?p s? m?i
            if ((txtDisplay.Text == "0") || (isOperationPerformed))
            {
                txtDisplay.Clear();
            }

            isOperationPerformed = false; // ?ánh d?u là ?ang nh?p s?

            // L?y ra nút v?a ???c nh?n (sender)
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;

            // Logic cho d?u ch?m (.)
            if (btn.Text == ".")
            {
                // N?u màn hình ch?a có d?u ch?m nào thì m?i cho thêm
                if (!txtDisplay.Text.Contains("."))
                {
                    txtDisplay.Text = txtDisplay.Text + btn.Text;
                }
            }
            else
            {
                // C?ng d?n con s? vào màn hình
                txtDisplay.Text = txtDisplay.Text + btn.Text;
            }
        }

        // 2. Hàm x? lý s? ki?n khi nh?n các nút PHÉP TÍNH (+, -, *, /)
        private void operator_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;

            // L?u phép tính ng??i dùng v?a ch?n vào bi?n operation
            operation = btn.Text;

            // L?u con s? ?ang hi?n trên màn hình vào bi?n result
            // Double.Parse dùng ?? chuy?n chu?i thành s?
            try
            {
                result = Double.Parse(txtDisplay.Text);
            }
            catch
            {
                result = 0;
            }

            // B?t c? này lên ?? bi?t là chu?n b? nh?p s? th? 2
            isOperationPerformed = true;
        }

        // 3. Hàm x? lý nút C (Clear)
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            result = 0;
            operation = "";
        }

        // 4. Hàm x? lý nút B?NG (=) - Th?c hi?n phép tính
        private void btnEqual_Click(object sender, EventArgs e)
        {
            // Switch case ?? ki?m tra xem phép tính ?ang ch? là gì
            switch (operation)
            {
                case "+":
                    txtDisplay.Text = (result + Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (result - Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "*":
                    txtDisplay.Text = (result * Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "/":
                    // X? lý chia cho 0 n?u c?n (máy tính ??n gi?n thì k? c?ng ???c)
                    txtDisplay.Text = (result / Double.Parse(txtDisplay.Text)).ToString();
                    break;
                default:
                    break;
            }

            // Sau khi tính xong, l?u k?t qu? m?i vào result ?? tính ti?p n?u mu?n
            // result = Double.Parse(txtDisplay.Text); // Dòng này tùy ch?n
            // operation = ""; // Reset phép tính
        }
    }
}
