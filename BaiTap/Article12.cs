using System;
using System.Windows.Forms;

namespace BaiTap
{
    public partial class Article12 : Form
    {
        public Article12()
        {
            InitializeComponent();
        }

        // 1. Thêm Node G?c (Root) - Ví d?: Thêm Khoa CNTT
        private void bt_AddRoot_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtInput.Text))
            {
                // Thêm tr?c ti?p vào t?p h?p Nodes c?a TreeView
                tv_Data.Nodes.Add(txtInput.Text);

                txtInput.Clear();
                txtInput.Focus();
            }
            else
            {
                MessageBox.Show("Vui lòng nh?p tên Node!");
            }
        }

        // 2. Thêm Node Con (Child) - Ví d?: Thêm L?p vào Khoa ?ang ch?n
        private void bt_AddChild_Click(object sender, EventArgs e)
        {
            // Ki?m tra xem ng??i dùng có ?ang ch?n node nào không?
            if (tv_Data.SelectedNode != null)
            {
                if (!string.IsNullOrWhiteSpace(txtInput.Text))
                {
                    // Thêm node m?i vào t?p h?p Nodes c?a Node ?ang ch?n (SelectedNode)
                    tv_Data.SelectedNode.Nodes.Add(txtInput.Text);

                    // T? ??ng m? r?ng node cha ?? th?y node con v?a thêm
                    tv_Data.SelectedNode.Expand();

                    txtInput.Clear();
                    txtInput.Focus();
                }
                else
                {
                    MessageBox.Show("Vui lòng nh?p tên Node Con!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng ch?n m?t Node cha tr??c khi thêm con!");
            }
        }

        // 3. Xóa Node ?ang ch?n
        private void bt_Remove_Click(object sender, EventArgs e)
        {
            if (tv_Data.SelectedNode != null)
            {
                if (MessageBox.Show("B?n có ch?c mu?n xóa?", "Xác nh?n", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // L?nh xóa node
                    tv_Data.SelectedNode.Remove();
                }
            }
            else
            {
                MessageBox.Show("Ch?a ch?n node nào ?? xóa!");
            }
        }

        // 4. M? r?ng t?t c? (Expand All)
        private void bt_ExpandAll_Click(object sender, EventArgs e)
        {
            tv_Data.ExpandAll();
        }

        // 5. Thu g?n t?t c? (Collapse All)
        private void bt_CollapseAll_Click(object sender, EventArgs e)
        {
            tv_Data.CollapseAll();
        }

        // 6. S? ki?n khi ch?n vào m?t node (AfterSelect)
        private void tv_Data_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Hi?n th? tên node ?ang ch?n lên tiêu ?? Form
            this.Text = "?ang ch?n: " + e.Node.Text;

            // Ví d?: N?u mu?n bi?t node này thu?c cha nào
            if (e.Node.Parent != null)
            {
                this.Text += " (Thu?c: " + e.Node.Parent.Text + ")";
            }
        }
    }
}