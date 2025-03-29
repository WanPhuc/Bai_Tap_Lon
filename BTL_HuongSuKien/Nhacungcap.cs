using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BTL_HSK_ver_1.Resources;

namespace BTL_HSK_ver_1
{
    public partial class Nhacungcap : Form
    {
        DuLieuChung dlc = new DuLieuChung();
        ErrorProvider error = new ErrorProvider();
        CancelEventArgs cancelEvent = new CancelEventArgs();

        public Nhacungcap()
        {
            InitializeComponent();
        }

        private void Nhacungcap_Load(object sender, EventArgs e)
        {

            loadncc();
        }
        private void loadncc()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dlc.connectionstring))
                {
                    conn.Open();
                    string query = "SELECT * FROM tblNhacungcap";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dtgncc.DataSource = dt; // Gán dữ liệu vào DataGridView
                    dtgncc.Columns["sMaNCC"].HeaderText = "Mã NCC";
                    dtgncc.Columns["sSDT"].HeaderText = "SĐT";
                    dtgncc.Columns["sTenNCC"].HeaderText = "Tên NCC";
                    dtgncc.Columns["sDiaChi"].HeaderText = "Địa Chỉ";
                    dtgncc.Columns["sEmail"].HeaderText = "Email";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void textBox_mancc_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string maNCC = txtma.Text.Trim();

            if (string.IsNullOrEmpty(maNCC))
            {
                error.SetError(txtma, "Mã nhà cung cấp không được để trống!");
            }
            else if (maNCC.Length < 3 || maNCC.Length > 20)
            {
                error.SetError(txtma, "Độ dài mã nhà cung cấp phải từ 3 đến 20 ký tự!");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(maNCC, @"^[a-zA-Z0-9]+$"))
            {
                error.SetError(txtma, "Mã nhà cung cấp chỉ được chứa chữ và số!");
            }
            else
            {
                error.SetError(txtma, null);
            }
        }

        private void textBox_tenncc_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string tenNCC = txtten.Text.Trim();

            if (string.IsNullOrEmpty(tenNCC))
            {
                error.SetError(txtten, "Tên nhà cung cấp không được để trống!");
            }
            else if (tenNCC.Length < 3 || tenNCC.Length > 50)
            {
                error.SetError(txtten, "Độ dài tên nhà cung cấp phải từ 3 đến 50 ký tự!");
            }
            else
            {
                error.SetError(txtten, null);
            }
        }

        private void textBox_sdt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string sdt = txtsdt.Text.Trim();

            if (string.IsNullOrEmpty(sdt))
            {
                error.SetError(txtsdt, "Số điện thoại không được để trống!");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^\d{10,15}$"))
            {
                error.SetError(txtsdt, "Số điện thoại chỉ được chứa số, độ dài từ 10 đến 15 ký tự!");
            }
            else
            {
                error.SetError(txtsdt, null);
            }
        }

        private void textBox_email_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string email = txtemail.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                error.SetError(txtemail, "Email không được để trống!");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                error.SetError(txtemail, "Định dạng email không hợp lệ!");
            }
            else
            {
                error.SetError(txtemail, null);
            }
        }

        private void textBox_diachi_Validating(object sender,CancelEventArgs e)
        {
            string diaChi = txtdiachi.Text.Trim();

            if (string.IsNullOrEmpty(diaChi))
            {
                error.SetError(txtdiachi, "Địa chỉ không được để trống!");
            }
            else if (diaChi.Length < 5 || diaChi.Length > 100)
            {
                error.SetError(txtdiachi, "Địa chỉ phải từ 5 đến 100 ký tự!");
            }
            else
            {
                error.SetError(txtdiachi, null);
            }
        }

        private void dtgncc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dòng hiện tại
                DataGridViewRow row = dtgncc.Rows[e.RowIndex];

                // Hiển thị dữ liệu lên các TextBox
                txtma.Text = row.Cells["sMaNCC"].Value.ToString();
                txtsdt.Text = row.Cells["sSDT"].Value.ToString();
                txtten.Text = row.Cells["sTenNCC"].Value.ToString();
                txtdiachi.Text = row.Cells["sDiaChi"].Value.ToString();
                txtemail.Text = row.Cells["sEmail"].Value.ToString();
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            textBox_diachi_Validating(sender, cancelEvent);
            textBox_email_Validating(sender, cancelEvent);
            textBox_mancc_Validating(sender, cancelEvent);
            textBox_sdt_Validating(sender, cancelEvent);
            textBox_tenncc_Validating(sender, cancelEvent);
            // Kiểm tra dữ liệu hợp lệ
            if (string.IsNullOrWhiteSpace(txtma.Text) || string.IsNullOrWhiteSpace(txtten.Text) ||
                string.IsNullOrWhiteSpace(txtsdt.Text) || string.IsNullOrWhiteSpace(txtdiachi.Text) ||
                string.IsNullOrWhiteSpace(txtemail.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(dlc.connectionstring))
                {
                    conn.Open();

                    // Kiểm tra trùng sMaNCC
                    string checkQuery = "SELECT COUNT(*) FROM tblNhaCungCap WHERE sMaNCC = @sMaNCC";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@sMaNCC", txtma.Text);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Mã nhà cung cấp đã tồn tại! Vui lòng nhập mã khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Nếu sMaNCC chưa tồn tại, thêm vào bảng
                    string insertQuery = "INSERT INTO tblNhaCungCap (sMaNCC, sTenNCC, sSDT, sDiaChi, sEmail) " +
                                         "VALUES (@sMaNCC, @sTenNCC, @sSDT, @sDiaChi, @sEmail)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@sMaNCC", txtma.Text);
                        insertCmd.Parameters.AddWithValue("@sTenNCC", txtten.Text);
                        insertCmd.Parameters.AddWithValue("@sSDT", txtsdt.Text);
                        insertCmd.Parameters.AddWithValue("@sDiaChi", txtdiachi.Text);
                        insertCmd.Parameters.AddWithValue("@sEmail", txtemail.Text);

                        int rowsAffected = insertCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadncc(); // Cập nhật lại DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu không nhập mã nhà cung cấp
            if (string.IsNullOrWhiteSpace(txtma.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhà cung cấp cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(dlc.connectionstring))
                {
                    conn.Open();

                    // Kiểm tra xem mã nhà cung cấp có tồn tại không
                    string checkQuery = "SELECT COUNT(*) FROM tblNhaCungCap WHERE sMaNCC = @sMaNCC";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@sMaNCC", txtma.Text);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count == 0)
                        {
                            MessageBox.Show("Mã nhà cung cấp không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Xóa nhà cung cấp
                    string deleteQuery = "DELETE FROM tblNhaCungCap WHERE sMaNCC = @sMaNCC";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@sMaNCC", txtma.Text);

                        int rowsAffected = deleteCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadncc(); // Cập nhật lại DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu không nhập mã nhà cung cấp
            if (string.IsNullOrWhiteSpace(txtma.Text) || string.IsNullOrWhiteSpace(txtten.Text) ||
                string.IsNullOrWhiteSpace(txtsdt.Text) || string.IsNullOrWhiteSpace(txtdiachi.Text) ||
                string.IsNullOrWhiteSpace(txtemail.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(dlc.connectionstring))
                {
                    conn.Open();

                    // Kiểm tra xem mã nhà cung cấp có tồn tại không
                    string checkQuery = "SELECT COUNT(*) FROM tblNhaCungCap WHERE sMaNCC = @sMaNCC";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@sMaNCC", txtma.Text);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count == 0)
                        {
                            MessageBox.Show("Mã nhà cung cấp không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Cập nhật thông tin nhà cung cấp
                    string updateQuery = "UPDATE tblNhaCungCap SET sTenNCC = @sTenNCC, sSDT = @sSDT, " +
                                         "sDiaChi = @sDiaChi, sEmail = @sEmail WHERE sMaNCC = @sMaNCC";

                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@sMaNCC", txtma.Text);
                        updateCmd.Parameters.AddWithValue("@sTenNCC", txtten.Text);
                        updateCmd.Parameters.AddWithValue("@sSDT", txtsdt.Text);
                        updateCmd.Parameters.AddWithValue("@sDiaChi", txtdiachi.Text);
                        updateCmd.Parameters.AddWithValue("@sEmail", txtemail.Text);

                        int rowsAffected = updateCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadncc(); // Cập nhật lại DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dlc.connectionstring))
                {
                    conn.Open();

                    // Tạo truy vấn tìm kiếm với điều kiện động
                    string searchQuery = "SELECT * FROM tblNhaCungCap WHERE 1=1";
                    List<SqlParameter> parameters = new List<SqlParameter>();

                    if (!string.IsNullOrWhiteSpace(txtma.Text))
                    {
                        searchQuery += " AND sMaNCC LIKE @sMaNCC";
                        parameters.Add(new SqlParameter("@sMaNCC", "%" + txtma.Text.Trim() + "%"));
                    }

                    if (!string.IsNullOrWhiteSpace(txtten.Text))
                    {
                        searchQuery += " AND sTenNCC LIKE @sTenNCC";
                        parameters.Add(new SqlParameter("@sTenNCC", "%" + txtten.Text.Trim() + "%"));
                    }

                    if (!string.IsNullOrWhiteSpace(txtsdt.Text))
                    {
                        searchQuery += " AND sSDT LIKE @sSDT";
                        parameters.Add(new SqlParameter("@sSDT", "%" + txtsdt.Text.Trim() + "%"));
                    }

                    if (!string.IsNullOrWhiteSpace(txtdiachi.Text))
                    {
                        searchQuery += " AND sDiaChi LIKE @sDiaChi";
                        parameters.Add(new SqlParameter("@sDiaChi", "%" + txtdiachi.Text.Trim() + "%"));
                    }

                    if (!string.IsNullOrWhiteSpace(txtemail.Text))
                    {
                        searchQuery += " AND sEmail LIKE @sEmail";
                        parameters.Add(new SqlParameter("@sEmail", "%" + txtemail.Text.Trim() + "%"));
                    }

                    using (SqlCommand cmd = new SqlCommand(searchQuery, conn))
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dtgncc.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
