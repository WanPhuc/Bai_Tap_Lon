using BTL_HSK_ver_1.Resources;
using BTL_HSK_ver_1.crystal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_HSK_ver_1
{
    public partial class NhapHang : Form
    {
        nhaphang hdnhap = new nhaphang();
        ErrorProvider error = new ErrorProvider();
        DuLieuChung dlc = new DuLieuChung();
        public string tenDangNhap;


        public string MaHD;
        public NhapHang(string tenDangNhap)
        {
            InitializeComponent();
            this.tenDangNhap = tenDangNhap;
        }
        
        

        private void NhapHang_Load(object sender, EventArgs e)
        {
            hdnhap.hien_HoaDonban(dataGridView_donnhaphang);
            hdnhap.uploadComboBox(comboBox_manv, comboBox_mancc);
            comboBox_Timkiem.SelectedIndex = 0;

        }


        private void textBox_mahoadon_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string maHoaDon = textBox_madonnhap.Text.Trim();

            if (string.IsNullOrEmpty(maHoaDon))
            {
                error.SetError(textBox_madonnhap, "Mã hóa đơn bán không được để trống!");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(maHoaDon, @"^[a-zA-Z0-9]+$"))
            {
                error.SetError(textBox_madonnhap, "Mã hóa đơn chỉ được chứa chữ và số!");
            }
            else
            {
                error.SetError(textBox_madonnhap, null);
            }
        }

        private void comboBox_manv_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox_manv.Text.Trim()))
            {
                error.SetError(comboBox_manv, "Mã nhân viên không được để trống!");
            }
            else
            {
                error.SetError(comboBox_manv, null);
            }
        }

        private void comboBox_makh_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox_mancc.Text.Trim()))
            {
                error.SetError(comboBox_mancc, "Mã khách hàng không được để trống!");
            }
            else
            {
                error.SetError(comboBox_mancc, null);
            }
        }
        private void dateTimePicker_ngaynhap_Validating(object sender, CancelEventArgs e)
        {
            DateTime ngayBan = dateTimePicker_ngaynhap.Value;

            if (ngayBan > DateTime.Now)
            {
                error.SetError(dateTimePicker_ngaynhap, "Ngày bán không được vượt quá ngày hiện tại!");
            }
            else
            {
                error.SetError(dateTimePicker_ngaynhap, null);
            }
        }

        private void button_ThemHD_Click(object sender, EventArgs e)
        {
            CancelEventArgs cancelEvent = new CancelEventArgs();
            textBox_mahoadon_Validating(sender, cancelEvent);
            comboBox_manv_Validating(sender, cancelEvent);
            comboBox_makh_Validating(sender, cancelEvent);
            dateTimePicker_ngaynhap_Validating(sender, cancelEvent);

            DateTime dateTime = Convert.ToDateTime(dateTimePicker_ngaynhap.Text);
            string ngayban = dateTime.ToString("yyyy/MM/dd");

            if (!string.IsNullOrEmpty(textBox_madonnhap.Text.Trim())
                && !string.IsNullOrEmpty(comboBox_manv.Text.Trim()) && !string.IsNullOrEmpty(comboBox_mancc.Text.Trim()))
            {
                if (hdnhap.kiemtratontai(textBox_madonnhap.Text.ToString(), error, textBox_madonnhap) == false)
                {
                    if (hdnhap.them_HoaDon_ban(textBox_madonnhap.Text.Trim(), comboBox_manv.Text.Trim(), comboBox_mancc.Text.Trim(), ngayban) == true)
                    {
                        MessageBox.Show("Thêm thành công");
                        error.SetError(textBox_madonnhap, null);

                        MaHD = textBox_madonnhap.Text.Trim();
                        // Mở form Chi tiết hóa đơn ngay sau khi thêm thành công
                        ChiTietDN frmChiTietDN = new ChiTietDN(MaHD);
                        frmChiTietDN.Show();

                        // Làm mới
                        textBox_madonnhap.Text = string.Empty;
                        comboBox_mancc.Text = string.Empty;
                        comboBox_manv.Text = string.Empty;
                        textBox_tth.Text = string.Empty;
                        dateTimePicker_ngaynhap.Value = DateTime.Now;
                    }
                }
                else
                {
                    MessageBox.Show("Không thành công");
                    error.SetError(textBox_madonnhap, "Mã hóa đơn này đã tồn tại");
                }
            }
            dataGridView_donnhaphang.Rows.Clear();
            hdnhap.hien_HoaDonban(dataGridView_donnhaphang);
        }


        private void dataGridView_donnhaphang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) // Nếu click vào header row
            {
                // Không cho phép chọn nếu click vào header row
                dataGridView_donnhaphang.ClearSelection();
                return;
            }

            // Kiểm tra nếu click vào một trong các cột (0 - 3) để hiển thị thông tin hóa đơn
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.ColumnIndex <= 4)
            {
                // Lấy thông tin dòng đã chọn
                DataGridViewRow row = dataGridView_donnhaphang.Rows[e.RowIndex];

                // Chuyển tất cả giá trị thành chuỗi và gán cho các ô tương ứng
                textBox_madonnhap.Text = row.Cells[0].Value.ToString();
                comboBox_manv.Text = row.Cells[1].Value.ToString();
                comboBox_mancc.Text = row.Cells[2].Value.ToString();

                // Chuyển đổi ngày bán thành chuỗi (giả sử định dạng ngày là yyyy/MM/dd)
                string ngayBan = row.Cells[3].Value.ToString();
                dateTimePicker_ngaynhap.Text = ngayBan;
                textBox_tth.Text = row.Cells[4].Value.ToString();

                // Đặt lại lỗi nếu có
                error.SetError(textBox_madonnhap, null);
            }

            // Kiểm tra nếu click vào cột số 4 (cột "Chi Tiết")
            if (e.ColumnIndex == 5 && e.RowIndex >= 0) // Đảm bảo không click vào tiêu đề
            {
                // Lấy mã hóa đơn từ DataGridView, giả sử cột 0 chứa mã hóa đơn
                object value = dataGridView_donnhaphang.Rows[e.RowIndex].Cells[0].Value;

                if (value != null)
                {
                    string maHoaDon = value.ToString().Trim();

                    // Mở form ChiTietHD với mã hóa đơn lấy từ DataGridView
                    ChiTietDN chiTiet = new ChiTietDN(maHoaDon);
                    chiTiet.Show();
                }
                else
                {
                    MessageBox.Show("Không có mã hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }



        private void button_sua_Click(object sender, EventArgs e)
        {
            try
            {

                // Chuyển đổi ngày bán thành định dạng phù hợp
                DateTime dateTime = dateTimePicker_ngaynhap.Value;
                string ngayBan = dateTime.ToString("yyyy-MM-dd");

                // Kiểm tra các trường nhập không được để trống
                if (string.IsNullOrWhiteSpace(textBox_madonnhap.Text) ||
                    string.IsNullOrWhiteSpace(comboBox_manv.Text) ||
                    string.IsNullOrWhiteSpace(comboBox_mancc.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hỏi xác nhận trước khi sửa
                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn sửa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Gọi hàm cập nhật hóa đơn
                    bool isUpdated = hdnhap.update_HoaDon_ban(
                        textBox_madonnhap.Text.Trim(),
                        comboBox_manv.Text.Trim(),
                        comboBox_mancc.Text.Trim(),
                        ngayBan
                    );

                    if (isUpdated)
                    {
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Làm mới các ô nhập
                        textBox_madonnhap.Text = string.Empty;
                        comboBox_mancc.Text = string.Empty;
                        comboBox_manv.Text = string.Empty;
                        dateTimePicker_ngaynhap.Value = DateTime.Now;
                        textBox_tth.Text = string.Empty;


                        // Cập nhật lại danh sách hóa đơn
                        dataGridView_donnhaphang.Rows.Clear();
                        hdnhap.hien_HoaDonban(dataGridView_donnhaphang);
                    }
                    else
                    {
                        MessageBox.Show("Không thể sửa hóa đơn, vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Mã hóa đơn, mã nhân viên và mã khách hàng phải là số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button_xoa_Click(object sender, EventArgs e)
        {
            DateTime dateTime = Convert.ToDateTime(dateTimePicker_ngaynhap.Text);
            string ngayban = dateTime.ToString("yyyy/MM/dd");

            if (!string.IsNullOrEmpty(textBox_madonnhap.Text.Trim())
                && !string.IsNullOrEmpty(comboBox_manv.Text.Trim()) && !string.IsNullOrEmpty(comboBox_mancc.Text.Trim()))
            {
                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (hdnhap.Xoa_HD_ban(textBox_madonnhap.Text.Trim()) == true)
                    {
                        MessageBox.Show("Xóa thành công");
                        // làm mới
                        textBox_madonnhap.Text = string.Empty;
                        comboBox_mancc.Text = string.Empty;
                        comboBox_manv.Text = string.Empty;
                        dateTimePicker_ngaynhap.Value = DateTime.Now;
                        textBox_tth.Text = string.Empty;

                    }
                    else
                    {
                        MessageBox.Show("Không thành công");
                    }
                }
            }
            dataGridView_donnhaphang.Rows.Clear();
            hdnhap.hien_HoaDonban(dataGridView_donnhaphang);
        }

        private void button_lammoi_Click(object sender, EventArgs e)
        {
            textBox_madonnhap.Text = string.Empty;
            comboBox_mancc.Text = string.Empty;
            comboBox_manv.Text = string.Empty;
            comboBox_mancc.Items.Clear();
            comboBox_manv.Items.Clear();
            dateTimePicker_ngaynhap.Value = DateTime.Now;
            textBox_tth.Text = "0";
            textBox_TimKiem.Text = string.Empty;
            NhapHang_Load(sender, e);
        }

        private void textBox_TimKiem_TextChanged(object sender, EventArgs e)
        {
            string columnName = "";
            string searchValue = textBox_TimKiem.Text.Trim();

            if (string.IsNullOrEmpty(searchValue))
            {
                // Nếu cần, bạn có thể thêm lệnh xóa dữ liệu cũ ở đây
                return;
            }
            // Lấy tên cột tìm kiếm từ ComboBox
            string selectedSearch = comboBox_Timkiem.SelectedItem?.ToString() ?? "";

            // Xác định cột tìm kiếm dựa vào lựa chọn
            switch (selectedSearch)
            {
                
                case "Mã Đơn Nhập":
                    columnName = "sMaDNH";
                    break;
                case "Mã Nhân Viên":
                    columnName = "sMaNV";
                    break;
                case "Mã Nhà Cung Cấp":
                    columnName = "sMaNCC";
                    break;
                case "Ngày Nhập":
                    columnName = "dNgayNhapHang";
                    break;
                default:
                    MessageBox.Show("Vui lòng chọn tiêu chí tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            string query = $"SELECT dnh.sMaDNH, dnh.sMaNV, dnh.sMaNCC, dnh.dNgayNhapHang, dnh.fTongTienHang " +
                           "FROM tblDonNhapHang dnh " +
                           "LEFT JOIN tblNhaCungCap ncc ON dnh.sMaNCC = ncc.sMaNCC ";

            // Điều kiện tìm kiếm
            if (!string.IsNullOrEmpty(columnName))
            {
                if (columnName == "dNgayNhapHang")
                {
                    // Kiểm tra định dạng ngày tháng
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
            dlc.TimKiem_DNH_DDH(query, parameters, dataGridView_donnhaphang);
        }



        private void button_inhd_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra giá trị biến tenDangNhap trước khi gọi form báo cáo
                if (string.IsNullOrEmpty(tenDangNhap))
                {
                    MessageBox.Show("Không lấy được tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dt = new DataTable();

                // Khai báo các biến lọc
                string maNV = comboBox_manv.Text.Trim();
                string ngayNhap = dateTimePicker_ngaynhap.Checked ? dateTimePicker_ngaynhap.Value.ToString("yyyy-MM-dd") : "";
                string maNCC = comboBox_mancc.Text.Trim();
                string MaDNH = textBox_madonnhap.Text.Trim();

                // Tạo câu truy vấn động
                string query = @"SELECT dnh.*, ctdnh.*
                        FROM tblDonNhapHang dnh
                        JOIN tblChiTietDNH ctdnh ON dnh.sMaDNH = ctdnh.sMaDNH
                        WHERE 1=1";

                List<SqlParameter> parameters = new List<SqlParameter>();

                // Điều kiện theo Mã Đơn Nhập
                if (!string.IsNullOrWhiteSpace(MaDNH))
                {
                    query += " AND dnh.sMaDNH = @MaDNH";
                    parameters.Add(new SqlParameter("@MaDNH", MaDNH));
                }

                // Điều kiện theo Mã Nhân Viên
                if (!string.IsNullOrWhiteSpace(maNV))
                {
                    query += " AND dnh.sMaNV = @MaNV";
                    parameters.Add(new SqlParameter("@MaNV", maNV));
                }

                // Điều kiện theo Mã Nhà Cung Cấp
                if (!string.IsNullOrWhiteSpace(maNCC))
                {
                    query += " AND dnh.sMaNCC = @MaNCC";
                    parameters.Add(new SqlParameter("@MaNCC", maNCC));
                }

                // Điều kiện theo Ngày Nhập (chỉ thêm nếu có chọn ngày)
                if (!string.IsNullOrWhiteSpace(ngayNhap))
                {
                    query += " AND CONVERT(VARCHAR(10), dnh.dNgayNhapHang, 120) = @NgayNhap";
                    parameters.Add(new SqlParameter("@NgayNhap", ngayNhap));
                }

                // Lấy dữ liệu từ database
                dt = dlc.GetData(query, parameters.ToArray());

                // Khởi tạo báo cáo cụ thể
                DSNhapHang report = new DSNhapHang();

                // In hóa đơn bằng hàm dùng chung
                dlc.InHoaDon(dt, report, tenDangNhap);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở báo cáo: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }




}


