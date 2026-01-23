using System;
using System.Collections.Generic;
using System.Drawing; // Th? vi?n ?? v? giao di?n (Point, Size)
using System.Reflection.Emit;
using System.Windows.Forms; // Th? vi?n ch?a các control (Button, TextBox...)

namespace ADO
{
    // K? th?a t? Form ?? t?o c?a s?
    public class dgvCustomer : Form
    {
        // --- 1. KHAI BÁO CÁC CONTROL ---
        // Khai báo logic x? lý (theo mô hình 3 l?p trong ?nh c?a b?n)
        CustomerBAL cusBAL = new CustomerBAL();

        // Khai báo các bi?n giao di?n
        private Label lblId, lblName;
        private TextBox txtId, txtName; // Ô nh?p li?u
        private Button btnAdd, btnDelete, btnEdit, btnExit;
        private DataGridView dgvList; // B?ng hi?n th? danh sách

        // --- 2. CONSTRUCTOR (Hàm kh?i t?o) ---
        public dgvCustomer()
        {
            // Thay vì g?i InitializeComponent() c?a Designer, ta g?i hàm t? vi?t
            InitializeMyComponent();

            // Load d? li?u lên b?ng ngay khi m? form
            LoadDataFromBAL();
        }

        // --- 3. HÀM V? GIAO DI?N (CODE C?NG) ---
        private void InitializeMyComponent()
        {
            // Cài ??t chung cho Form
            this.Text = "Qu?n Lý Khách Hàng (Code C?ng)";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            // --- Hàng 1: ID ---
            lblId = new Label();
            lblId.Text = "Mã KH:";
            lblId.Location = new Point(30, 30); // V? trí (X, Y)
            lblId.AutoSize = true;
            this.Controls.Add(lblId);

            txtId = new TextBox();
            txtId.Location = new Point(100, 27);
            txtId.Size = new Size(150, 20);
            this.Controls.Add(txtId);

            // --- Hàng 2: Tên ---
            lblName = new Label();
            lblName.Text = "Tên KH:";
            lblName.Location = new Point(30, 70);
            lblName.AutoSize = true;
            this.Controls.Add(lblName);

            txtName = new TextBox();
            txtName.Location = new Point(100, 67);
            txtName.Size = new Size(300, 20);
            this.Controls.Add(txtName);

            // --- Hàng 3: Các nút b?m ---
            btnAdd = new Button();
            btnAdd.Text = "Thêm";
            btnAdd.Location = new Point(30, 120);
            btnAdd.Size = new Size(80, 30);
            btnAdd.Click += new EventHandler(btnAdd_Click); // Gán s? ki?n Click
            this.Controls.Add(btnAdd);

            btnDelete = new Button();
            btnDelete.Text = "Xóa";
            btnDelete.Location = new Point(120, 120);
            btnDelete.Size = new Size(80, 30);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            this.Controls.Add(btnDelete);

            btnEdit = new Button();
            btnEdit.Text = "S?a";
            btnEdit.Location = new Point(210, 120);
            btnEdit.Size = new Size(80, 30);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            this.Controls.Add(btnEdit);

            btnExit = new Button();
            btnExit.Text = "Thoát";
            btnExit.Location = new Point(300, 120);
            btnExit.Size = new Size(80, 30);
            btnExit.Click += (s, e) => { this.Close(); };
            this.Controls.Add(btnExit);

            // --- Hàng 4: B?ng d? li?u (DataGridView) ---
            dgvList = new DataGridView();
            dgvList.Location = new Point(30, 170);
            dgvList.Size = new Size(520, 250);
            dgvList.ColumnCount = 2; // T?o 2 c?t
            dgvList.Columns[0].Name = "ID";
            dgvList.Columns[0].Width = 100;
            dgvList.Columns[1].Name = "H? và Tên";
            dgvList.Columns[1].Width = 350;

            // Cài ??t hành vi cho b?ng
            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Ch?n c? dòng
            dgvList.AllowUserToAddRows = false; // Không cho user nh?p tr?c ti?p trên l??i
            dgvList.CellClick += new DataGridViewCellEventHandler(dgvList_CellClick); // S? ki?n click
            this.Controls.Add(dgvList);
        }

        // --- 4. CÁC HÀM X? LÝ S? KI?N (LOGIC) ---

        // Hàm t?i d? li?u dùng chung (g?i t? BAL)
        private void LoadDataFromBAL()
        {
            List<CustomerBEL> lst = cusBAL.ReadCustomer();
            dgvList.Rows.Clear(); // Xóa d? li?u c? trên l??i
            foreach (CustomerBEL cus in lst)
            {
                dgvList.Rows.Add(cus.Id, cus.Name);
            }
        }

        // X? lý nút THÊM
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerBEL cus = new CustomerBEL();
                // L?y d? li?u t? ô nh?p li?u (TextBox) thay vì fix c?ng
                cus.Id = int.Parse(txtId.Text);
                cus.Name = txtName.Text;

                cusBAL.AddCustomer(cus);

                LoadDataFromBAL(); // T?i l?i b?ng
                MessageBox.Show("Thêm thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i: " + ex.Message);
            }
        }

        // X? lý nút XÓA
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerBEL cus = new CustomerBEL();
                cus.Id = int.Parse(txtId.Text); // Ch? c?n ID ?? xóa

                cusBAL.DeleteCustomer(cus);

                LoadDataFromBAL();
                MessageBox.Show("Xóa thành công!");
                // Xóa tr?ng ô nh?p sau khi xóa
                txtId.Text = "";
                txtName.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i: " + ex.Message);
            }
        }

        // X? lý nút S?A
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerBEL cus = new CustomerBEL();
                cus.Id = int.Parse(txtId.Text);
                cus.Name = txtName.Text; // L?y tên m?i t? ô nh?p

                cusBAL.EditCustomer(cus);

                LoadDataFromBAL();
                MessageBox.Show("S?a thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i: " + ex.Message);
            }
        }

        // X? lý s? ki?n: Click vào dòng trong b?ng -> ??y d? li?u lên ô nh?p
        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ki?m tra n?u click vào dòng h?p l?
            if (e.RowIndex >= 0 && e.RowIndex < dgvList.Rows.Count)
            {
                DataGridViewRow row = dgvList.Rows[e.RowIndex];
                txtId.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
            }
        }
    }
}