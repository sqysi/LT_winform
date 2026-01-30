using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ADO
{
    public class frmDetail : Form
    {
        #region Fields & Constants
        private readonly string _id;
        // Nên chuyển chuỗi kết nối vào App.config trong dự án thực tế
        private readonly string _connectionString = @"Data Source=QYS\SYQUYS;Database=sale;Integrated Security=True";

        // UI Controls
        private PictureBox _pbAvatar;
        private Label _lblTitle;
        private Label _lblInfo;
        #endregion

        #region Constructor
        public frmDetail(string id)
        {
            _id = id;
            InitializeUI();
            LoadEmployeeData();
        }
        #endregion

        #region UI Initialization
        private void InitializeUI()
        {
            // --- Form Settings ---
            this.Text = "Hồ sơ chi tiết nhân viên";
            this.Size = new Size(900, 750);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Font = new Font("Segoe UI", 10);

            // --- Avatar ---
            _pbAvatar = new PictureBox
            {
                Location = new Point(20, 20),
                Size = new Size(160, 210),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.WhiteSmoke
            };

            // --- Title ---
            _lblTitle = new Label
            {
                Text = "ĐANG TẢI...",
                Location = new Point(200, 20),
                AutoSize = true,
                Font = new Font("Arial", 18, FontStyle.Bold),
                ForeColor = Color.Navy
            };

            // --- Content Panel ---
            _lblInfo = new Label
            {
                AutoSize = true,
                Padding = new Padding(10)
            };

            Panel pnContent = new Panel
            {
                Location = new Point(200, 60),
                Size = new Size(660, 550),
                AutoScroll = true,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };
            pnContent.Controls.Add(_lblInfo);

            // --- Buttons ---
            int btnWidth = 160;
            int btnHeight = 45;
            int startY = 250;
            int gap = 15;

            Button btEdit = CreateButton("Sửa Hồ Sơ", new Point(20, startY), Color.LightBlue, BtEdit_Click);
            Button btDelete = CreateButton("Xóa Hồ Sơ", new Point(20, startY + btnHeight + gap), Color.LightCoral, BtDelete_Click);
            Button btClose = CreateButton("Đóng", new Point(20, 630), Color.Gainsboro, (s, e) => this.Close());

            // --- Add Controls ---
            this.Controls.AddRange(new Control[] { _pbAvatar, _lblTitle, pnContent, btEdit, btDelete, btClose });
        }

        // Helper tạo nút nhanh gọn
        private Button CreateButton(string text, Point loc, Color bg, EventHandler clickEvent)
        {
            Button btn = new Button
            {
                Text = text,
                Location = loc,
                Size = new Size(160, 45),
                BackColor = bg,
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += clickEvent;
            return btn;
        }
        #endregion

        #region Data Loading & Logic
        private void LoadEmployeeData()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM customer WHERE id = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _id);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                RenderEmployeeInfo(dr);
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy dữ liệu nhân viên này.");
                                this.Close();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RenderEmployeeInfo(SqlDataReader dr)
        {
            // 1. Xử lý Ảnh
            if (dr["avatar"] != DBNull.Value)
            {
                byte[] imgData = (byte[])dr["avatar"];
                // Lưu ý: Không dùng 'using' ở đây vì PictureBox cần stream tồn tại
                MemoryStream ms = new MemoryStream(imgData);
                _pbAvatar.Image = Image.FromStream(ms);
            }
            else
            {
                _pbAvatar.Image = null; // Hoặc set ảnh placeholder
            }

            // 2. Tiêu đề
            _lblTitle.Text = dr["name"].ToString().ToUpper();

            // 3. Xây dựng nội dung text
            StringBuilder sb = new StringBuilder();

            // --- THÔNG TIN CÁ NHÂN ---
            sb.AppendLine("--- THÔNG TIN CÁ NHÂN ---");
            sb.AppendLine();
            sb.AppendLine($"Mã NV: {dr["id"]}  |  Bí danh: {SafeString(dr["alias"])}");
            sb.AppendLine($"Giới tính: {SafeString(dr["gender"])}  |  Ngày sinh: {SafeDate(dr["dob"])}");
            sb.AppendLine($"Nơi sinh: {SafeString(dr["pob"])}  |  Nguyên quán: {SafeString(dr["native_place"])}");
            sb.AppendLine($"CMND/CCCD: {SafeString(dr["id_card"])}  |  Ngày cấp: {SafeDate(dr["id_date"])}  |  Nơi cấp: {SafeString(dr["id_place"])}");
            sb.AppendLine($"Hôn nhân: {(CheckBool(dr["is_married"]) ? "Đã kết hôn" : "Độc thân")}");
            sb.AppendLine($"ĐC Thường trú: {SafeString(dr["address"])}  |  TP/Tỉnh: {SafeString(dr["city"])}");
            sb.AppendLine($"ĐC Tạm trú: {SafeString(dr["temp_address"])}");
            sb.AppendLine($"Điện thoại: {SafeString(dr["phone"])}  |  ĐT Nhà: {SafeString(dr["home_phone"])}");
            sb.AppendLine($"Email: {SafeString(dr["email"])}");

            sb.AppendLine("\n----------------------------------------\n");

            // --- THÔNG TIN CÔNG VIỆC ---
            sb.AppendLine("--- THÔNG TIN CÔNG VIỆC ---");
            sb.AppendLine();
            sb.AppendLine($"Phòng ban: {SafeString(dr["department"])}  |  Chức vụ: {SafeString(dr["position"])}");
            sb.AppendLine($"Công việc: {SafeString(dr["job_title"])}  |  Loại NV: {SafeString(dr["emp_type"])}");
            sb.AppendLine($"Ngày vào làm: {SafeDate(dr["start_date"])}");
            sb.AppendLine($"Lương cơ bản: {SafeMoney(dr["basic_salary"])} VND  |  Hệ số: {SafeString(dr["coefficient"])}  |  Phụ cấp: {SafeMoney(dr["allowance"])}");
            sb.AppendLine($"Số sổ LĐ: {SafeString(dr["labor_book"])}  |  Ngày cấp: {SafeDate(dr["labor_date"])}  |  Nơi cấp: {SafeString(dr["labor_place"])}");
            sb.AppendLine($"TK Ngân hàng: {SafeString(dr["bank_acc"])}  |  Ngân hàng: {SafeString(dr["bank_name"])}");

            sb.AppendLine("\n----------------------------------------\n");

            // --- THÔNG TIN KHÁC ---
            sb.AppendLine("--- KHÁC ---");
            sb.AppendLine();
            sb.AppendLine($"Học vấn: {SafeString(dr["education"])}  |  Bằng cấp: {SafeString(dr["degree"])}");
            sb.AppendLine($"Ngoại ngữ: {SafeString(dr["language"])}  |  Tin học: {SafeString(dr["it_skill"])}");
            sb.AppendLine($"Dân tộc: {SafeString(dr["ethnicity"])}  |  Quốc tịch: {SafeString(dr["nationality"])}  |  Tôn giáo: {SafeString(dr["religion"])}");

            _lblInfo.Text = sb.ToString();
        }
        #endregion

        #region Helper Methods
        private string SafeString(object val) => val == DBNull.Value ? "..." : val.ToString();

        private string SafeDate(object val) => val == DBNull.Value ? "..." : ((DateTime)val).ToString("dd/MM/yyyy");

        private string SafeMoney(object val) => val == DBNull.Value ? "0" : string.Format("{0:N0}", val);

        private bool CheckBool(object val) => val != DBNull.Value && Convert.ToBoolean(val);
        #endregion

        #region Event Handlers
        private void BtEdit_Click(object sender, EventArgs e)
        {
            // Đảm bảo frmCustomer có constructor(string id)
            using (frmCustomer f = new frmCustomer(_id))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadEmployeeData(); // Refresh data
                    this.DialogResult = DialogResult.OK; // Báo parent form cập nhật
                }
            }
        }

        private void BtDelete_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "CẢNH BÁO: Bạn có chắc chắn muốn xóa hoàn toàn hồ sơ này không?\nHành động này không thể hoàn tác.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    // Dùng Parameter để tránh SQL Injection
                    string sql = "DELETE FROM customer WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _id);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Xóa hồ sơ thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
    }
}