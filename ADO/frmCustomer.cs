using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ADO
{
    public class frmCustomer : Form
    {
        string strConnect = @"Data Source=QYS\SYQUYS;Database=sale;Integrated Security=True";
        private string _currentId = null;

        // --- Controls Group 1 ---
        TextBox txtID, txtName, txtAlias, txtMobile, txtHomePhone, txtEmail, txtPOB, txtCity, txtIDCard, txtIDPlace, txtNative, txtAddr, txtTempAddr;
        DateTimePicker dtpDob, dtpIDDate;
        CheckBox chkMarried;
        RadioButton rbNam, rbNu;
        PictureBox pbAvatar;
        Button btBrowse;

        // --- Controls Group 2 ---
        ComboBox cboEmpType, cboDept, cboPosition, cboJobTitle, cboBankName, cboEdu, cboDegree, cboLang, cboIT, cboEthnicity, cboNation, cboReligion;
        DateTimePicker dtpStartDate, dtpLaborDate;
        TextBox txtBasicSalary, txtCoef, txtAllowance, txtLaborBook, txtLaborPlace, txtBankAcc;

        Button btSave, btCancel;

        public frmCustomer()
        {
            _currentId = null;
            InitializeUI();
            this.Text = "Thêm Hồ Sơ Mới";
        }

        public frmCustomer(string id)
        {
            _currentId = id;
            InitializeUI();
            this.Text = "Cập Nhật Hồ Sơ";
            LoadDataToForm(id);
        }

        private void InitializeUI()
        {
            // 1. Setup Form
            this.Size = new Size(1100, 900);
            this.StartPosition = FormStartPosition.CenterParent;
            this.AutoScroll = true;
            this.Font = new Font("Segoe UI", 9.5f);

            // [FIX] Giảm labelW xuống 100 (cũ 110) để tiết kiệm không gian ngang
            int labelW = 100;
            int y = 30, dy = 45; // Khoảng cách dòng

            // --- GROUP 1: THÔNG TIN CÁ NHÂN ---
            GroupBox grpP = new GroupBox() { Text = "Thông Tin Cá Nhân", Location = new Point(15, 10), Size = new Size(1050, 380) };

            // Avatar
            pbAvatar = new PictureBox() { Location = new Point(15, 30), Size = new Size(140, 180), BorderStyle = BorderStyle.FixedSingle, SizeMode = PictureBoxSizeMode.Zoom };
            btBrowse = new Button() { Text = "Chọn ảnh...", Location = new Point(15, 215), Size = new Size(140, 30) };

            btBrowse.Click += (s, e) => {
                OpenFileDialog op = new OpenFileDialog() { Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp" };
                if (op.ShowDialog() == DialogResult.OK) pbAvatar.Image = Image.FromFile(op.FileName);
            };
            grpP.Controls.Add(pbAvatar); grpP.Controls.Add(btBrowse);

            // [FIX] Dời các cột sang trái một chút để có chỗ cho cột cuối
            // Cũ: 180, 480, 770 -> Mới: 170, 450, 730
            int col1 = 170, col2 = 450, col3 = 730;

            // Dòng 1: Mã NV | Họ Tên | Bí Danh + Giới Tính
            AddLabel(grpP, "Mã NV (*)", col1, y); txtID = AddText(grpP, col1 + labelW, y, 120);
            AddLabel(grpP, "Họ Tên (*)", col2, y); txtName = AddText(grpP, col2 + labelW, y, 180);

            // [FIX] Giảm width txtAlias xuống 100 (cũ 150) và đặt lại vị trí RadioButton sát hơn
            AddLabel(grpP, "Bí danh", col3, y); txtAlias = AddText(grpP, col3 + labelW, y, 100);

            // RadioButton Giới tính: Tính toán lại X để không bị trôi ra ngoài GroupBox
            rbNam = new RadioButton() { Text = "Nam", Location = new Point(col3 + labelW + 110, y), AutoSize = true, Checked = true };
            rbNu = new RadioButton() { Text = "Nữ", Location = new Point(col3 + labelW + 170, y), AutoSize = true };
            grpP.Controls.AddRange(new Control[] { rbNam, rbNu });

            // Dòng 2
            y += dy;
            AddLabel(grpP, "Di Động", col1, y); txtMobile = AddText(grpP, col1 + labelW, y, 150);
            AddLabel(grpP, "ĐT Nhà", col2, y); txtHomePhone = AddText(grpP, col2 + labelW, y, 150);
            AddLabel(grpP, "Email", col3, y); txtEmail = AddText(grpP, col3 + labelW, y, 180);

            // Dòng 3
            y += dy;
            AddLabel(grpP, "Ngày Sinh", col1, y); dtpDob = AddDate(grpP, col1 + labelW, y);
            AddLabel(grpP, "Nơi Sinh", col2, y); txtPOB = AddText(grpP, col2 + labelW, y, 180);
            AddLabel(grpP, "Tỉnh Thành", col3, y); txtCity = AddText(grpP, col3 + labelW, y, 180);

            // Dòng 4
            y += dy;
            AddLabel(grpP, "CCCD/CMND", col1, y); txtIDCard = AddText(grpP, col1 + labelW, y, 150);
            AddLabel(grpP, "Ngày Cấp", col2, y); dtpIDDate = AddDate(grpP, col2 + labelW, y);
            AddLabel(grpP, "Nơi Cấp", col3, y); txtIDPlace = AddText(grpP, col3 + labelW, y, 180);

            // Dòng 5, 6, 7
            y += dy; AddLabel(grpP, "Nguyên Quán", col1, y); txtNative = AddText(grpP, col1 + labelW, y, 750);
            y += dy; AddLabel(grpP, "Đ/C Thường Trú", col1, y); txtAddr = AddText(grpP, col1 + labelW, y, 750);

            y += dy; AddLabel(grpP, "Đ/C Tạm Trú", col1, y); txtTempAddr = AddText(grpP, col1 + labelW, y, 600);
            chkMarried = new CheckBox() { Text = "Đã kết hôn", Location = new Point(col1 + labelW + 620, y + 2), AutoSize = true };
            grpP.Controls.Add(chkMarried);

            // --- GROUP 2: CÔNG VIỆC ---
            GroupBox grpJ = new GroupBox() { Text = "Thông Tin Công Việc & Lương", Location = new Point(15, 400), Size = new Size(1050, 420) };

            y = 35;
            // Canh lại cột cho Group 2 (Sử dụng lại labelW mới là 100)
            int jCol1 = 20, jCol2 = 380, jCol3 = 740;

            // Dòng 1
            AddLabel(grpJ, "Loại NV", jCol1, y); cboEmpType = AddCombo(grpJ, jCol1 + labelW, y, new string[] { "Chính thức", "Thử việc", "CTV", "Thực tập" });
            AddLabel(grpJ, "Ngày Vào", jCol2, y); dtpStartDate = AddDate(grpJ, jCol2 + labelW, y);
            AddLabel(grpJ, "Phòng Ban", jCol3, y); cboDept = AddCombo(grpJ, jCol3 + labelW, y, new string[] { "Ban Giám Đốc", "Kinh Doanh", "Kỹ Thuật", "Nhân Sự", "Kế Toán" }, 180);

            // Dòng 2
            y += dy;
            AddLabel(grpJ, "Công Việc", jCol1, y); cboJobTitle = AddCombo(grpJ, jCol1 + labelW, y, new string[] { "Quản lý", "Nhân viên", "Trưởng nhóm", "Chuyên viên" });
            AddLabel(grpJ, "Chức Vụ", jCol2, y); cboPosition = AddCombo(grpJ, jCol2 + labelW, y, new string[] { "Giám Đốc", "Trưởng Phòng", "Nhân viên" }, 180);

            // Dòng 3
            y += dy;
            AddLabel(grpJ, "Lương CB", jCol1, y); txtBasicSalary = AddText(grpJ, jCol1 + labelW, y);
            AddLabel(grpJ, "Hệ Số", jCol2, y); txtCoef = AddText(grpJ, jCol2 + labelW, y, 80);
            AddLabel(grpJ, "Phụ Cấp", jCol3, y); txtAllowance = AddText(grpJ, jCol3 + labelW, y, 180);

            // Dòng 4
            y += dy;
            AddLabel(grpJ, "Số Sổ LĐ", jCol1, y); txtLaborBook = AddText(grpJ, jCol1 + labelW, y);
            AddLabel(grpJ, "Ngày Cấp Sổ", jCol2, y); dtpLaborDate = AddDate(grpJ, jCol2 + labelW, y);
            AddLabel(grpJ, "Nơi Cấp Sổ", jCol3, y); txtLaborPlace = AddText(grpJ, jCol3 + labelW, y, 180);

            // Dòng 5
            y += dy;
            AddLabel(grpJ, "TK Ngân Hàng", jCol1, y); txtBankAcc = AddText(grpJ, jCol1 + labelW, y, 200);
            AddLabel(grpJ, "Ngân Hàng", jCol2, y); cboBankName = AddCombo(grpJ, jCol2 + labelW, y, new string[] { "Vietcombank", "Techcombank", "ACB", "MB Bank", "Vietinbank" }, 200);

            // Dòng 6
            y += dy;
            AddLabel(grpJ, "Học Vấn", jCol1, y); cboEdu = AddCombo(grpJ, jCol1 + labelW, y, new string[] { "Trên Đại học", "Đại học", "Cao đẳng", "Trung cấp", "THPT" });
            AddLabel(grpJ, "Bằng Cấp", jCol3, y); cboDegree = AddCombo(grpJ, jCol3 + labelW, y, new string[] { "Tiến sĩ", "Thạc sĩ", "Cử nhân", "Kỹ sư", "Khác" }, 180);

            // Dòng 7
            y += dy;
            AddLabel(grpJ, "Ngoại Ngữ", jCol1, y); cboLang = AddCombo(grpJ, jCol1 + labelW, y, new string[] { "Anh - Sơ cấp", "Anh - Trung cấp", "Anh - Cao cấp", "Nhật", "Hàn" });
            AddLabel(grpJ, "Tin Học", jCol2, y); cboIT = AddCombo(grpJ, jCol2 + labelW, y, new string[] { "Văn phòng A", "Văn phòng B", "MOS", "Lập trình viên" }, 180);

            // Dòng 8
            y += dy;
            AddLabel(grpJ, "Dân Tộc", jCol1, y); cboEthnicity = AddCombo(grpJ, jCol1 + labelW, y, new string[] { "Kinh", "Hoa", "Khmer", "Tày", "Thái" });
            AddLabel(grpJ, "Quốc Tịch", jCol2, y); cboNation = AddCombo(grpJ, jCol2 + labelW, y, new string[] { "Việt Nam", "Mỹ", "Anh", "Hàn Quốc" }, 180);
            AddLabel(grpJ, "Tôn Giáo", jCol3, y); cboReligion = AddCombo(grpJ, jCol3 + labelW, y, new string[] { "Không", "Phật Giáo", "Công Giáo", "Tin Lành" }, 180);

            // --- VALIDATION INPUT ---
            txtMobile.KeyPress += InputNumberOnly;
            txtHomePhone.KeyPress += InputNumberOnly;
            txtIDCard.KeyPress += InputNumberOnly;
            txtBasicSalary.KeyPress += InputNumberOnly;
            txtAllowance.KeyPress += InputNumberOnly;
            txtBankAcc.KeyPress += InputNumberOnly;
            txtLaborBook.KeyPress += InputNumberOnly;
            txtCoef.KeyPress += (s, e) => {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) e.Handled = true;
            };

            // --- BUTTONS ---
            btSave = new Button() { Text = "LƯU HỒ SƠ", Location = new Point(400, 830), Size = new Size(140, 45), BackColor = Color.LightSeaGreen, ForeColor = Color.White, Font = new Font("Segoe UI", 10, FontStyle.Bold), FlatStyle = FlatStyle.Flat };
            btCancel = new Button() { Text = "Hủy Bỏ", Location = new Point(560, 830), Size = new Size(140, 45), BackColor = Color.WhiteSmoke, Font = new Font("Segoe UI", 10), FlatStyle = FlatStyle.Flat };

            btSave.Click += BtSave_Click;
            btCancel.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[] { grpP, grpJ, btSave, btCancel });
        }
        // --- Helper Methods ---
        private void AddLabel(GroupBox g, string text, int x, int y)
        {
            Label l = new Label() { Text = text, Location = new Point(x, y + 4), AutoSize = true };
            if (text.Contains("(*)")) l.ForeColor = Color.Red;
            g.Controls.Add(l);
        }

        private TextBox AddText(GroupBox g, int x, int y, int w = 150)
        {
            TextBox t = new TextBox() { Location = new Point(x, y), Size = new Size(w, 25) };
            g.Controls.Add(t);
            return t;
        }

        private DateTimePicker AddDate(GroupBox g, int x, int y)
        {
            DateTimePicker d = new DateTimePicker() { Location = new Point(x, y), Size = new Size(130, 25), Format = DateTimePickerFormat.Short, ShowCheckBox = true, Checked = false };
            g.Controls.Add(d);
            return d;
        }

        private ComboBox AddCombo(GroupBox g, int x, int y, string[] items, int w = 150)
        {
            ComboBox c = new ComboBox() { Location = new Point(x, y), Size = new Size(w, 25), DropDownStyle = ComboBoxStyle.DropDown };
            c.Items.AddRange(items);
            g.Controls.Add(c);
            return c;
        }

        // --- Validation Logic ---
        private void InputNumberOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return true;
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        // --- LOAD DATA ---
        private void LoadDataToForm(string id)
        {
            txtID.Enabled = false;
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM customer WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        Func<object, string> S = (o) => o == DBNull.Value ? "" : o.ToString();

                        txtID.Text = S(dr["id"]);
                        txtName.Text = S(dr["name"]);
                        txtAlias.Text = S(dr["alias"]);
                        txtMobile.Text = S(dr["phone"]);
                        txtHomePhone.Text = S(dr["home_phone"]);
                        txtEmail.Text = S(dr["email"]);

                        rbNam.Checked = S(dr["gender"]) == "Nam";
                        rbNu.Checked = !rbNam.Checked;

                        if (dr["dob"] != DBNull.Value) { dtpDob.Checked = true; dtpDob.Value = (DateTime)dr["dob"]; }
                        txtPOB.Text = S(dr["pob"]);
                        txtCity.Text = S(dr["city"]);
                        txtIDCard.Text = S(dr["id_card"]);
                        if (dr["id_date"] != DBNull.Value) { dtpIDDate.Checked = true; dtpIDDate.Value = (DateTime)dr["id_date"]; }
                        txtIDPlace.Text = S(dr["id_place"]);
                        txtNative.Text = S(dr["native_place"]);
                        txtAddr.Text = S(dr["address"]);
                        txtTempAddr.Text = S(dr["temp_address"]);
                        chkMarried.Checked = dr["is_married"] != DBNull.Value && Convert.ToBoolean(dr["is_married"]);

                        cboDept.Text = S(dr["department"]);
                        cboEmpType.Text = S(dr["emp_type"]);
                        if (dr["start_date"] != DBNull.Value) { dtpStartDate.Checked = true; dtpStartDate.Value = (DateTime)dr["start_date"]; }
                        cboPosition.Text = S(dr["position"]);
                        cboJobTitle.Text = S(dr["job_title"]);

                        txtBasicSalary.Text = dr["basic_salary"] != DBNull.Value ? String.Format("{0:0}", dr["basic_salary"]) : "0";
                        txtCoef.Text = S(dr["coefficient"]);
                        txtAllowance.Text = dr["allowance"] != DBNull.Value ? String.Format("{0:0}", dr["allowance"]) : "0";

                        txtLaborBook.Text = S(dr["labor_book"]);
                        if (dr["labor_date"] != DBNull.Value) { dtpLaborDate.Checked = true; dtpLaborDate.Value = (DateTime)dr["labor_date"]; }
                        txtLaborPlace.Text = S(dr["labor_place"]);
                        txtBankAcc.Text = S(dr["bank_acc"]);
                        cboBankName.Text = S(dr["bank_name"]);

                        cboEdu.Text = S(dr["education"]);
                        cboDegree.Text = S(dr["degree"]);
                        cboLang.Text = S(dr["language"]);
                        cboIT.Text = S(dr["it_skill"]);
                        cboEthnicity.Text = S(dr["ethnicity"]);
                        cboReligion.Text = S(dr["religion"]);
                        cboNation.Text = S(dr["nationality"]);

                        if (dr["avatar"] != DBNull.Value)
                        {
                            byte[] img = (byte[])dr["avatar"];
                            using (MemoryStream ms = new MemoryStream(img)) pbAvatar.Image = Image.FromStream(ms);
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        // --- SAVE DATA ---
        private void BtSave_Click(object sender, EventArgs e)
        {
            // --- 1. VALIDATE CƠ BẢN (Client Side) ---
            if (string.IsNullOrWhiteSpace(txtID.Text)) { MessageBox.Show("Vui lòng nhập Mã Nhân Viên!", "Cảnh báo"); txtID.Focus(); return; }
            if (string.IsNullOrWhiteSpace(txtName.Text)) { MessageBox.Show("Vui lòng nhập Họ Tên!", "Cảnh báo"); txtName.Focus(); return; }

            // Validate CCCD
            if (!string.IsNullOrEmpty(txtIDCard.Text) && txtIDCard.Text.Length != 9 && txtIDCard.Text.Length != 12)
            { MessageBox.Show("Số CMND/CCCD phải là 9 hoặc 12 số.", "Lỗi"); txtIDCard.Focus(); return; }

            // Validate SĐT
            if (!string.IsNullOrEmpty(txtMobile.Text) && txtMobile.Text.Length < 10)
            { MessageBox.Show("Số điện thoại di động không hợp lệ (quá ngắn).", "Lỗi"); txtMobile.Focus(); return; }

            // Validate Email Regex
            if (!IsValidEmail(txtEmail.Text))
            { MessageBox.Show("Email không đúng định dạng.", "Lỗi"); txtEmail.Focus(); return; }

            // Validate Ngày Sinh (Logic)
            if (dtpDob.Checked)
            {
                int age = DateTime.Now.Year - dtpDob.Value.Year;
                if (dtpDob.Value > DateTime.Now)
                { MessageBox.Show("Ngày sinh không được lớn hơn ngày hiện tại!", "Lỗi Logic"); dtpDob.Focus(); return; }

                if (age < 18)
                { MessageBox.Show("Nhân viên chưa đủ 18 tuổi!", "Cảnh báo LĐ"); dtpDob.Focus(); return; }
            }

            // --- 2. VALIDATE TRÙNG LẶP (Database Side) ---
            // Kiểm tra Mã NV trùng (Chỉ check khi thêm mới)
            if (_currentId == null)
            {
                if (CheckDuplicate("id", txtID.Text, "Mã nhân viên")) { txtID.Focus(); return; }
            }

            // Kiểm tra SĐT Di động trùng
            if (CheckDuplicate("phone", txtMobile.Text, "Số điện thoại")) { txtMobile.Focus(); txtMobile.SelectAll(); return; }

            // Kiểm tra Email trùng
            if (CheckDuplicate("email", txtEmail.Text, "Email")) { txtEmail.Focus(); txtEmail.SelectAll(); return; }

            // Kiểm tra CCCD trùng (Rất quan trọng)
            if (CheckDuplicate("id_card", txtIDCard.Text, "Số CCCD/CMND")) { txtIDCard.Focus(); txtIDCard.SelectAll(); return; }


            // --- 3. TIẾN HÀNH LƯU DỮ LIỆU ---
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand() { Connection = conn };

                    if (_currentId == null)
                    {
                        // Câu lệnh Insert
                        cmd.CommandText = @"INSERT INTO customer (id, name, alias, phone, home_phone, email, gender, dob, pob, city, id_card, id_date, id_place, native_place, address, temp_address, is_married, emp_type, start_date, department, position, job_title, basic_salary, coefficient, allowance, labor_book, labor_date, labor_place, bank_acc, bank_name, education, degree, language, it_skill, ethnicity, nationality, religion, avatar) VALUES (@id, @name, @alias, @phone, @home, @email, @gender, @dob, @pob, @city, @idc, @idcd, @idcp, @native, @addr, @temp, @married, @empt, @start, @dept, @pos, @job, @salary, @coef, @allow, @labor, @ldate, @lplace, @bank, @bname, @edu, @deg, @lang, @it, @eth, @nat, @rel, @img)";
                    }
                    else
                    {
                        // Câu lệnh Update
                        cmd.CommandText = @"UPDATE customer SET name=@name, alias=@alias, phone=@phone, home_phone=@home, email=@email, gender=@gender, dob=@dob, pob=@pob, city=@city, id_card=@idc, id_date=@idcd, id_place=@idcp, native_place=@native, address=@addr, temp_address=@temp, is_married=@married, emp_type=@empt, start_date=@start, department=@dept, position=@pos, job_title=@job, basic_salary=@salary, coefficient=@coef, allowance=@allow, labor_book=@labor, labor_date=@ldate, labor_place=@lplace, bank_acc=@bank, bank_name=@bname, education=@edu, degree=@deg, language=@lang, it_skill=@it, ethnicity=@eth, nationality=@nat, religion=@rel, avatar=@img WHERE id=@id";
                    }

                    // Helper để thêm tham số nhanh gọn
                    Action<string, object> AddP = (pName, val) => cmd.Parameters.AddWithValue(pName, (val == null || val.ToString() == "") ? DBNull.Value : val);

                    AddP("@id", txtID.Text);
                    AddP("@name", txtName.Text);
                    AddP("@alias", txtAlias.Text);
                    AddP("@phone", txtMobile.Text);
                    AddP("@home", txtHomePhone.Text);
                    AddP("@email", txtEmail.Text);
                    AddP("@gender", rbNam.Checked ? "Nam" : "Nữ");
                    cmd.Parameters.AddWithValue("@dob", dtpDob.Checked ? (object)dtpDob.Value : DBNull.Value);
                    AddP("@pob", txtPOB.Text);
                    AddP("@city", txtCity.Text);
                    AddP("@idc", txtIDCard.Text);
                    cmd.Parameters.AddWithValue("@idcd", dtpIDDate.Checked ? (object)dtpIDDate.Value : DBNull.Value);
                    AddP("@idcp", txtIDPlace.Text);
                    AddP("@native", txtNative.Text);
                    AddP("@addr", txtAddr.Text);
                    AddP("@temp", txtTempAddr.Text);
                    cmd.Parameters.AddWithValue("@married", chkMarried.Checked);

                    AddP("@empt", cboEmpType.Text);
                    cmd.Parameters.AddWithValue("@start", dtpStartDate.Checked ? (object)dtpStartDate.Value : DBNull.Value);
                    AddP("@dept", cboDept.Text);
                    AddP("@pos", cboPosition.Text);
                    AddP("@job", cboJobTitle.Text);

                    decimal sal = 0; decimal.TryParse(txtBasicSalary.Text, out sal); cmd.Parameters.AddWithValue("@salary", sal);
                    float coef = 1; float.TryParse(txtCoef.Text, out coef); cmd.Parameters.AddWithValue("@coef", coef);
                    decimal allow = 0; decimal.TryParse(txtAllowance.Text, out allow); cmd.Parameters.AddWithValue("@allow", allow);

                    AddP("@labor", txtLaborBook.Text);
                    cmd.Parameters.AddWithValue("@ldate", dtpLaborDate.Checked ? (object)dtpLaborDate.Value : DBNull.Value);
                    AddP("@lplace", txtLaborPlace.Text);
                    AddP("@bank", txtBankAcc.Text);
                    AddP("@bname", cboBankName.Text);
                    AddP("@edu", cboEdu.Text);
                    AddP("@deg", cboDegree.Text);
                    AddP("@lang", cboLang.Text);
                    AddP("@it", cboIT.Text);
                    AddP("@eth", cboEthnicity.Text);
                    AddP("@nat", cboNation.Text);
                    AddP("@rel", cboReligion.Text);

                    // Xử lý ảnh
                    if (pbAvatar.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pbAvatar.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            cmd.Parameters.AddWithValue("@img", ms.ToArray());
                        }
                    }
                    else cmd.Parameters.Add("@img", SqlDbType.VarBinary).Value = DBNull.Value;

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi lưu: " + ex.Message); }
            }
        }        // Hàm kiểm tra trùng lặp trong CSDL
        private bool CheckDuplicate(string fieldName, string value, string displayName)
        {
            // Nếu ô trống thì bỏ qua không kiểm tra (trừ khi bạn bắt buộc nhập)
            if (string.IsNullOrWhiteSpace(value)) return false;

            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                try
                {
                    conn.Open();
                    // Câu lệnh: Đếm xem có ai có giá trị này KHÔNG tính người đang sửa (nếu có)
                    string query = $"SELECT COUNT(*) FROM customer WHERE {fieldName} = @val";

                    // Nếu đang ở chế độ Cập nhật (_currentId != null), ta phải loại trừ chính bản thân người đó ra
                    if (_currentId != null)
                    {
                        query += " AND id != @currId";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@val", value);

                    if (_currentId != null)
                    {
                        cmd.Parameters.AddWithValue("@currId", _currentId);
                    }

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show($"{displayName} '{value}' đã tồn tại trong hệ thống. Vui lòng kiểm tra lại!", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return true; // Có trùng
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kiểm tra trùng lặp: " + ex.Message);
                    return true; // Coi như trùng để chặn lưu cho an toàn
                }
            }
            return false; // Không trùng
        }
    }
}