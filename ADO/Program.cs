using System;
using System.Windows.Forms;

namespace ADO
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Sửa dòng này để chạy form dgvCustomer
            Application.Run(new Form1());
        }
    }
}