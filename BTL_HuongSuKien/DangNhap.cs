using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using BTL_HSK_ver_1.Resources;

namespace BTL_HSK_ver_1
{
    public partial class DangNhap : Form
    {
        DuLieuChung dlc = new DuLieuChung();
        public string tenDangNhap;
        public bool IsAdmin { get; private set; } = false;

        public DangNhap()
        {
            InitializeComponent();
            IsAdmin = false; // Mặc định là nhân viên

        }

        // Xử lý sự kiện nút Đăng Nhập
        private void btnDNDangNhap_Click(object sender, EventArgs e)
        {
            tenDangNhap = txbDNTaiKhoan.Text.Trim();
            string matKhau = txbDNMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(dlc.connectionstring))
                {
                    conn.Open();
                    string query = "SELECT Role FROM Users WHERE Username = @Username AND Password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", tenDangNhap);
                        cmd.Parameters.AddWithValue("@Password", matKhau);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string role = result.ToString();
                            bool isAdmin = role == "Admin";
                            IsAdmin = isAdmin;  
                            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            frmTrangChu fm = new frmTrangChu(tenDangNhap, isAdmin); 
                            fm.FormClosed += (s, args) => this.Close();
                            fm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        // Xử lý sự kiện nút Đăng Ký
        private void btnDNDangKy_Click(object sender, EventArgs e)
        {
            DangKy dk = new DangKy();
            this.Hide();
            dk.Show();

        }

        // Hiển thị hoặc ẩn mật khẩu
        private void checkBoxHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHienMK.Checked)
            {
                txbDNMatKhau.PasswordChar = '\0';
            }
            else
            {
                txbDNMatKhau.PasswordChar = '*';
            }
        }

        // Xử lý sự kiện nút Thoát
        private void btnDNThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Sự kiện khi form tải
        private void DangNhap_Load(object sender, EventArgs e)
        {
            // Có thể thêm các thao tác khởi tạo tại đây
        }
    }
}
