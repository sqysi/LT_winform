using System;
using System.Windows.Forms;

namespace BaiTap
{
    public partial class Article18 : Form
    {
        public Article18()
        {
            InitializeComponent();
        }

        // 1. S? ki?n khi form v?a ch?y (Load)
        private void Article18_Load(object sender, EventArgs e)
        {
            // Thêm s?n m?t vài d? li?u m?u
            cboList.Items.Add("Ti?ng Anh");
            cboList.Items.Add("Ti?ng Pháp");
            cboList.Items.Add("Ti?ng Nh?t");

            // Ch?n m?c ??nh m?c ??u tiên (index = 0)
            cboList.SelectedIndex = 0;
        }

        // 2. Nút Thêm: L?y d? li?u t? TextBox ??a vào ComboBox
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Ki?m tra n?u ô nh?p r?ng thì không thêm
            if (string.IsNullOrWhiteSpace(txtInput.Text))
            {
                MessageBox.Show("Vui lòng nh?p n?i dung c?n thêm!", "Thông báo");
                return;
            }

            // Ki?m tra trùng l?p (n?u mu?n)
            if (cboList.Items.Contains(txtInput.Text))
            {
                MessageBox.Show("M?c này ?ã có trong danh sách!", "Thông báo");
                return;
            }

            // Thêm vào ComboBox
            cboList.Items.Add(txtInput.Text);

            // Xóa ô nh?p và ??a con tr? chu?t v? ?ó
            txtInput.Clear();
            txtInput.Focus();
        }

        // 3. S? ki?n khi ng??i dùng ch?n 1 m?c khác trong ComboBox
        private void cboList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hi?n th? ch? s? (Index) - B?t ??u t? 0
            lblResultIndex.Text = cboList.SelectedIndex.ToString();

            // Hi?n th? n?i dung (Item)
            if (cboList.SelectedItem != null)
            {
                lblResultItem.Text = cboList.SelectedItem.ToString();
            }
            else
            {
                lblResultItem.Text = "(Ch?a ch?n)";
            }
        }

        // 4. Nút Xóa: Xóa m?c ?ang ???c ch?n
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (cboList.SelectedIndex != -1) // N?u có m?c ?ang ???c ch?n
            {
                // Cách 1: Xóa theo ch? s? (Index) - An toàn h?n
                cboList.Items.RemoveAt(cboList.SelectedIndex);

                // Cách 2: Xóa theo n?i dung (Object)
                // cboList.Items.Remove(cboList.SelectedItem);

                // Reset l?i thông tin hi?n th?
                lblResultIndex.Text = "...";
                lblResultItem.Text = "...";

                MessageBox.Show("?ã xóa thành công!", "Thông báo");
            }
            else
            {
                MessageBox.Show("Vui lòng ch?n m?c c?n xóa!", "L?i");
            }
        }

        // 5. Nút Thoát
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}