using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL_HSK_ver_1.Resources;
using BTL_HSK_ver_1.crystal;

namespace BTL_HSK_ver_1
{
    public partial class KhachHang : Form
    {
        khachhang khachHang = new khachhang();
        ErrorProvider error = new ErrorProvider();
        private string tth = "0";
        CancelEventArgs cancel = new CancelEventArgs();
        DuLieuChung dlc = new DuLieuChung();
        public string tenDangNhap;
        public KhachHang()
        {
            InitializeComponent();

        }


        private void textBox_Ma_KhachHang_Validating(object sender, CancelEventArgs e)
        {
            string maKH = textBox_SDT_KhachHang.Text.Trim();

            if (string.IsNullOrEmpty(maKH))
            {
                error.SetError(textBox_SDT_KhachHang, "Mã khách hàng không được để trống!");
            }
            else if (maKH.Length < 3 || maKH.Length > 20)
            {
                error.SetError(textBox_SDT_KhachHang, "Độ dài mã khách hàng phải từ 3 đến 20 ký tự!");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(maKH, @"^[a-zA-Z0-9]+$"))
            {
                error.SetError(textBox_SDT_KhachHang, "Mã khách hàng chỉ được chứa chữ và số!");
            }
            else
            {
                error.SetError(textBox_SDT_KhachHang, null);
            }
        }

        private void textBox_Ten_KhachHang_Validating(object sender, CancelEventArgs e)
        {
            string tenKH = textBox_Ten_KhachHang.Text.Trim();

            if (string.IsNullOrEmpty(tenKH))
            {
                error.SetError(textBox_Ten_KhachHang, "Tên khách hàng không được để trống!");
            }
            else if (tenKH.Length < 3 || tenKH.Length > 50)
            {
                error.SetError(textBox_Ten_KhachHang, "Độ dài tên khách hàng phải từ 3 đến 50 ký tự!");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(tenKH, @"^[a-zA-Z\s]+$"))
            {
                error.SetError(textBox_Ten_KhachHang, "Tên khách hàng chỉ được chứa chữ và khoảng trắng!");
            }
            else
            {
                error.SetError(textBox_Ten_KhachHang, null);
            }
        }

       

        private void textBox_DiaChi_Validating(object sender, CancelEventArgs e)
        {
            string diaChi = textBox_DiaChi.Text.Trim();

            if (string.IsNullOrEmpty(diaChi))
            {
                error.SetError(textBox_DiaChi, "Địa chỉ khách hàng không được để trống!");
            }
            else if (diaChi.Length < 5 || diaChi.Length > 100)
            {
                error.SetError(textBox_DiaChi, "Địa chỉ phải từ 5 đến 100 ký tự!");
            }
            else
            {
                error.SetError(textBox_DiaChi, null);
            }
        }

        private void textBox_GioiTinh_KH_Validating(object sender, CancelEventArgs e)
        {
            string gioiTinh = textBox_GioiTinh_KH.Text.Trim();

            if (string.IsNullOrEmpty(gioiTinh))
            {
                error.SetError(textBox_GioiTinh_KH, "Giới tính không được để trống!");
            }
            else if (gioiTinh != "Nam" && gioiTinh != "Nữ" && gioiTinh != "Khác")
            {
                error.SetError(textBox_GioiTinh_KH, "Giới tính chỉ có thể là 'Nam', 'Nữ' hoặc 'Khác'!");
            }
            else
            {
                error.SetError(textBox_GioiTinh_KH, null);
            }
        }


        private void button_Them_Click(object sender, EventArgs e)
        {
            textBox_GioiTinh_KH_Validating(sender, cancel);
            textBox_DiaChi_Validating(sender, cancel);
            textBox_Ma_KhachHang_Validating(sender, cancel);
            textBox_Ten_KhachHang_Validating(sender, cancel);
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(textBox_SDT_KhachHang.Text.Trim()) ||
                    string.IsNullOrEmpty(textBox_Ten_KhachHang.Text.Trim()) ||
                    string.IsNullOrEmpty(textBox_GioiTinh_KH.Text.Trim()) ||
                    string.IsNullOrEmpty(textBox_DiaChi.Text.Trim()) ||
                    string.IsNullOrEmpty(textBox_TongTienhang.Text.Trim()))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                // Kiểm tra giới tính hợp lệ
                if (textBox_GioiTinh_KH.Text.Trim() != "Nam" && textBox_GioiTinh_KH.Text.Trim() != "Nữ")
                {
                    MessageBox.Show("Giới tính không hợp lệ. Vui lòng nhập 'Nam' hoặc 'Nữ'.");
                    return;
                }

                // Lấy ngày từ DateTimePicker
                DateTime dateTime = dateTimePicker1_ngaybatdau.Value;
                string ngayban = dateTime.ToString("yyyy/MM/dd");

                // Kiểm tra mã khách hàng đã tồn tại chưa
                if (!khachHang.kiemtra_maKH(textBox_SDT_KhachHang.Text.Trim(), error, textBox_SDT_KhachHang))
                {
                    // Thêm khách hàng vào cơ sở dữ liệu
                    if (khachHang.ThemKhachHang(
                            textBox_SDT_KhachHang.Text.Trim(),
                            textBox_Ten_KhachHang.Text.Trim(),
                            textBox_GioiTinh_KH.Text.Trim(),
                            textBox_DiaChi.Text.Trim(),
                            float.Parse(textBox_TongTienhang.Text.Trim()),
                            ngayban))
                    {
                        // Thông báo thành công
                        MessageBox.Show("Thêm thành công.");

                        // Xóa dữ liệu chỉ khi thêm thành công
                        textBox_SDT_KhachHang.Text = string.Empty;
                        textBox_Ten_KhachHang.Text = string.Empty;
                        textBox_GioiTinh_KH.Text = string.Empty;
                        textBox_DiaChi.Text = string.Empty;
                        textBox_TongTienhang.Text = string.Empty;

                        // Hiển thị danh sách khách hàng mới
                        dataGridView_Khach_Hang.Rows.Clear();
                        khachHang.hien_KhachHang(dataGridView_Khach_Hang);
                        khachHang.CapNhatSoNam();

                    }
                }
                else
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại.");
                }
            }
            catch (SqlException ex)
            {
                // Xử lý lỗi từ SQL Server
                if (ex.Message.Contains("CHECK constraint") && ex.Message.Contains("GioiTinh"))
                {
                    MessageBox.Show("Giới tính không hợp lệ. Vui lòng nhập 'Nam' hoặc 'Nữ'.");
                }
                else
                {
                    MessageBox.Show($"Lỗi SQL: {ex.Message}");
                }
            }
            catch (FormatException ex)
            {
                // Xử lý lỗi định dạng (ví dụ: nhập sai định dạng số)
                MessageBox.Show($"Lỗi định dạng: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi khác
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void QLKhachHang_Load(object sender, EventArgs e)
        {
            textBox_TongTienhang.Text = tth;
            khachHang.hien_KhachHang(dataGridView_Khach_Hang);
            khachHang.CapNhatTongTien();
            khachHang.CapNhatSoNam();

        }

        private void dataGridView_Khach_Hang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) // Nếu click vào header row
            {
                // Không cho phép chọn nếu click vào header row
                dataGridView_Khach_Hang.ClearSelection();
            }

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell dataGridViewCell = dataGridView_Khach_Hang[e.ColumnIndex, e.RowIndex];
                if (dataGridViewCell.Value != null)
                {
                    //  error.SetError(textBox_maNV, null);
                    DataGridViewRow row = dataGridView_Khach_Hang.Rows[e.RowIndex];
                    textBox_SDT_KhachHang.Text = row.Cells[0].Value.ToString();
                    textBox_Ten_KhachHang.Text = row.Cells[1].Value.ToString();
                    textBox_GioiTinh_KH.Text = row.Cells[2].Value.ToString();
                    textBox_DiaChi.Text = row.Cells[3].Value.ToString();
                    textBox_TongTienhang.Text = row.Cells[4].Value.ToString();
                    dateTimePicker1_ngaybatdau.Text= row.Cells[5].Value.ToString();
                    textBox_sonam.Text= row.Cells[6].Value.ToString();

                }
                else
                {
                    // Xử lý khi giá trị của ô là null
                }

            }
        }

        private void textBox_Ma_KhachHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button_Luu_Click(object sender, EventArgs e)
        {
            DateTime dateTime = dateTimePicker1_ngaybatdau.Value;
            string ngayban = dateTime.ToString("yyyy/MM/dd");
            // kiểm tra nếu rỗng thì không xóa được
            if (!string.IsNullOrEmpty(textBox_SDT_KhachHang.Text.Trim()) && !string.IsNullOrEmpty(textBox_Ten_KhachHang.Text.Trim())
               && !string.IsNullOrEmpty(textBox_GioiTinh_KH.Text.Trim()) && !string.IsNullOrEmpty(textBox_DiaChi.Text.Trim())
               && !string.IsNullOrEmpty(textBox_TongTienhang.Text.Trim()))
            {

                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn sửa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    // Sử lí khi update

                    khachHang.UpdateKhachHang(textBox_SDT_KhachHang.Text.Trim(), textBox_Ten_KhachHang.Text.Trim()
                      , textBox_GioiTinh_KH.Text.Trim() , textBox_DiaChi.Text.Trim(),ngayban);
                    // đưa các ô nhập liệu về rỗng
                    textBox_SDT_KhachHang.Text = string.Empty;
                    textBox_Ten_KhachHang.Text = string.Empty;
                    textBox_GioiTinh_KH.Text = string.Empty;
                    textBox_DiaChi.Text = string.Empty;
                    textBox_TongTienhang.Text = tth;

                    dataGridView_Khach_Hang.Rows.Clear();
                    khachHang.hien_KhachHang(dataGridView_Khach_Hang);
                    khachHang.CapNhatSoNam();


                }
            }
        }

        private void button_Xóa_Click(object sender, EventArgs e)
        {
            // kiểm tra nếu rỗng thì không xóa được
            if (!string.IsNullOrEmpty(textBox_SDT_KhachHang.Text.Trim()) && !string.IsNullOrEmpty(textBox_Ten_KhachHang.Text.Trim())
               && !string.IsNullOrEmpty(textBox_TongTienhang.Text.Trim()) && !string.IsNullOrEmpty(textBox_DiaChi.Text.Trim()))
            {

                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    khachHang.xoa_KhachHang(textBox_SDT_KhachHang.Text.Trim());
                    // đưa các ô nhập liệu về rỗng
                    textBox_SDT_KhachHang.Text = string.Empty;
                    textBox_Ten_KhachHang.Text = string.Empty;
                    textBox_GioiTinh_KH.Text = string.Empty;
                    textBox_DiaChi.Text = string.Empty;
                    textBox_TongTienhang.Text = tth;
                    dataGridView_Khach_Hang.Rows.Clear();
                    khachHang.hien_KhachHang(dataGridView_Khach_Hang);
                }
                else
                {
                    // đóng
                }
            }
        }

        private void textBox_TimKiem_TextChanged(object sender, EventArgs e)
        {

            string columnName = "";
            string searchValue = textBox_TimKiem.Text.Trim();

            // Lấy tên cột tìm kiếm từ ComboBox
            string selectedSearch = comboBox_Timkiem.SelectedItem?.ToString() ?? "";
            if (string.IsNullOrEmpty(searchValue))
            {
                // Nếu cần, bạn có thể thêm lệnh xóa dữ liệu cũ ở đây
                return;
            }
            // Xác định cột tìm kiếm dựa vào lựa chọn
            switch (selectedSearch)
            {
                case "Số Điện Thoại":
                    columnName = "sSoDTKH";
                    break;
                case "Tên Khách Hàng":
                    columnName = "sHoTen";
                    break;
                case "ngaybatdau":
                    columnName = "ngaybatdau";
                    break;
                
                default:
                    MessageBox.Show("Vui lòng chọn tiêu chí tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            string query = $"SELECT kh.sSoDTKH, kh.sHoTen, kh.sGioiTinh, kh.sDiaChi, kh.fTongTienKH, kh.ngaybatdau, kh.SoNam " +
               "FROM tblKhachHang kh ";


            // Điều kiện tìm kiếm
            if (!string.IsNullOrEmpty(columnName))
            {
                if (columnName == "ngaybatdau")
                {
                    // Kiểm tra độ dài chuỗi trước khi chuyển đổi
                    if (searchValue.Length == 10 && DateTime.TryParse(searchValue, out DateTime parsedDate))
                    {
                        // Định dạng lại ngày tháng thành yyyy-MM-dd
                        searchValue = parsedDate.ToString("yyyy-MM-dd");
                        query += $"WHERE CONVERT(VARCHAR(10), {columnName}, 120) = @searchValue";
                    }
                    else if (searchValue.Length > 0 && searchValue.Length < 10)
                    {
                        // Nếu chưa đủ độ dài, không làm gì cả (tránh lỗi)
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập ngày đúng định dạng yyyy-MM-dd!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    query += $"WHERE {columnName} LIKE @searchValue COLLATE SQL_Latin1_General_CP1_CI_AS";
                    searchValue = "%" + searchValue + "%";
                }
            }

            // Tạo danh sách tham số
            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@searchValue", searchValue }
    };

            // Gọi hàm tìm kiếm chung từ lớp DuLieuChung
            dlc.TimKiemDuLieu(query, parameters, dataGridView_Khach_Hang);

        }

        /*private void button_inds_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra giá trị biến tenDangNhap trước khi gọi form báo cáo
                DataTable dt = new DataTable();

                // Khai báo các biến lọc
                string maNV = textBox_Ten_KhachHang.Text.Trim();
                string ngayDK = dateTimePicker1_ngaybatdau.Checked ? dateTimePicker1_ngaybatdau.Value.ToString("yyyy-MM-dd") : "";
                string soDTKH = textBox_SDT_KhachHang.Text.Trim();
                string Magt = textBox_GioiTinh_KH.Text.Trim();
                string dc = textBox_DiaChi.Text.Trim();

                // Tạo câu truy vấn động
                string query = @"SELECT kh.*, ctkh.*
                        FROM tblKhachHang kh
                        ";

                List<SqlParameter> parameters = new List<SqlParameter>();

                // Điều kiện theo Mã Khách Hàng
              
                

                // Điều kiện theo Số ĐT Khách Hàng
             
                

                // Điều kiện theo Ngày Đăng Ký (chỉ thêm nếu có chọn ngày)
                if (!string.IsNullOrWhiteSpace(ngayDK))
                {
                    query += " AND CONVERT(VARCHAR(10), kh.ngaybatdau, 120) = @NgayDK";
                    parameters.Add(new SqlParameter("@NgayDK", ngayDK));
                }

                // Lấy dữ liệu từ database
                dt = dlc.GetData(query, parameters.ToArray());

                // Khởi tạo báo cáo cụ thể
                CachedCrystalReport1 report = new CachedCrystalReport1();

                // In hóa đơn bằng hàm dùng chung
                dlc.InHoaDon(dt, report, tenDangNhap);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở báo cáo: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

    }
}

