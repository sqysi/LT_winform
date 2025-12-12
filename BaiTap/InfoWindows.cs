using System;

// Class này dùng để lưu trữ thông tin kích thước cửa sổ
// Cần phải là 'public' để XmlSerializer có thể truy cập được
public class InfoWindows
{
    public int Width { get; set; }
    public int Height { get; set; }

    // Constructor mặc định (bắt buộc phải có để Serialization hoạt động)
    public InfoWindows() { }
}