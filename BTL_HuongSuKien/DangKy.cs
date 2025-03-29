using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using BTL_HSK_ver_1.Resources;
namespace BTL_HSK_ver_1
{
    public partial class DangKy : Form
    {
        DuLieuChung dlc = new DuLieuChung();
        public string tenDangKy;
        public DangKy()
        {
            InitializeComponent();
        }

        // Sự kiện nút Đăng Ký
        private void chkAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAdmin.Checked)
            {
                chkNhanVien.Checked = false; // Bỏ chọn Nhân Viên nếu Admin được chọn
            }
        }

        // Sự kiện khi thay đổi trạng thái của CheckBox Nhân Viên
        private void chkNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNhanVien.Checked)
            {
                chkAdmin.Checked = false; // Bỏ chọn Admin nếu Nhân Viên được chọn
            }
        }

        // Sự kiện nút Đăng Ký
        private void btnDKDangKy_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangKy.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string xacNhanMK = txtXacNhanMK.Text.Trim();
            string role = chkAdmin.Checked ? "Admin" : "NhanVien"; // Đảm bảo đúng role

            // Kiểm tra thông tin rỗng
            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau) || string.IsNullOrEmpty(xacNhanMK))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mật khẩu và xác nhận mật khẩu
            if (matKhau != xacNhanMK)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Chuỗi kết nối đến cơ sở dữ liệu
                using (SqlConnection conn = new SqlConnection(dlc.connectionstring))
                {
                    conn.Open();

                    // Kiểm tra tài khoản đã tồn tại
                    string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                    using (SqlCommand checkCmd = new SqlCommand(checkUserQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", tenDangNhap);
                        int userExists = (int)checkCmd.ExecuteScalar();

                        if (userExists > 0)
                        {
                            MessageBox.Show("Tên đăng nhập đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Thực hiện thêm tài khoản mới với quyền
                    string insertQuery = "INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", tenDangNhap);
                        cmd.Parameters.AddWithValue("@Password", matKhau);
                        cmd.Parameters.AddWithValue("@Role", role);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            frmTrangChu fm = new frmTrangChu(tenDangNhap, role == "Admin");
                            fm.FormClosed += (s, args) => Application.Exit();
                            fm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Đăng ký thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Sự kiện nút Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Sự kiện nút Đăng Nhập
        private void btnDN_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Hide();
        }

        private void checkBoxHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHienMK.Checked)
            {
                txtMatKhau.PasswordChar = '\0';
                txtXacNhanMK.PasswordChar = '\0';
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
                txtXacNhanMK.PasswordChar = '*';
            }
        }

        


        private void DangKy_Load(object sender, EventArgs e)
        {
            chkNhanVien.Checked = true;
        }

        private void DangKy_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
