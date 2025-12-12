using System;
using System.Windows.Forms;
using System.IO; // Để dùng StreamWriter
using System.Xml.Serialization; // Để dùng XmlSerializer

namespace BaiTap
{
    public partial class Article1 : Form
    {
        string path = @"D:\form.xml";
        public Article1()
        {
            InitializeComponent();
            // Nếu bạn đã gán sự kiện qua bảng Properties (hình tia sét) thì không cần 2 dòng dưới.
            this.Load += new EventHandler(Article1_Load);
            this.ResizeEnd += new EventHandler(Article1_ResizeEnd);
        }

        public void Write(InfoWindows iw)
        {
            try
            {
                // Khởi tạo đối tượng XmlSerializer cho kiểu dữ liệu InfoWindows
                XmlSerializer writer = new XmlSerializer(typeof(InfoWindows));

                // Khởi tạo StreamWriter để ghi vào đường dẫn path
                using (StreamWriter file = new StreamWriter(path))
                {
                    // Thực hiện tuần tự hóa (Serialize) đối tượng iw thành XML và lưu vào file
                    writer.Serialize(file, iw);
                }
                // Dùng 'using' sẽ tự động Close file, nhưng nếu viết theo Slide 28 thì dùng file.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi file: " + ex.Message);
            }
        }

        // Sự kiện xảy ra khi Form bắt đầu chạy (Dựa theo Slide 29)
        private void Article1_Load(object sender, EventArgs e)
        {
            InfoWindows iw = new InfoWindows();
            iw.Width = this.Size.Width;   // Lấy chiều rộng hiện tại của Form
            iw.Height = this.Size.Height; // Lấy chiều cao hiện tại của Form
            Write(iw); // Ghi xuống file
        }

        // Sự kiện xảy ra khi người dùng kết thúc việc thay đổi kích thước Form (thả chuột ra)
        private void Article1_ResizeEnd(object sender, EventArgs e)
        {
            InfoWindows iw = new InfoWindows();
            iw.Width = this.Size.Width;
            iw.Height = this.Size.Height;
            Write(iw); // Ghi xuống file cập nhật kích thước mới
        }
    }
}
