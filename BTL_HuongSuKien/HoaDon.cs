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
    public partial class HoaDon : Form
    {
        hoadon hdban = new hoadon();
        ErrorProvider error = new ErrorProvider();
        DuLieuChung dlc = new DuLieuChung();
        public string tenDangNhap;


        public string MaHD;
        public HoaDon(string tenDangNhap)
        {
            InitializeComponent();
            this.tenDangNhap = tenDangNhap;
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            hdban.hien_HoaDonban(dataGridView_hoadonban);
            hdban.uploadComboBox(comboBox_manv, comboBox_sdtkh);

        }


        private void textBox_mahoadon_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_mahoadon.Text.Trim()))
            {
                error.SetError(textBox_mahoadon, "Mã hóa đơn bán không được để trống!");
            }
            else
            {
                error.SetError(textBox_mahoadon, null);
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
            if (string.IsNullOrEmpty(comboBox_sdtkh.Text.Trim()))
            {
                error.SetError(comboBox_sdtkh, "Mã khách hàng không được để trống!");
            }
            else
            {
                error.SetError(comboBox_sdtkh, null);
            }
        }

        private void button_ThemHD_Click(object sender, EventArgs e)
        {
            CancelEventArgs cancelEvent = new CancelEventArgs();
            textBox_mahoadon_Validating(sender, cancelEvent);
            comboBox_manv_Validating(sender, cancelEvent);
            comboBox_makh_Validating(sender, cancelEvent);

            DateTime dateTime = Convert.ToDateTime(dateTimePicker_ngayban.Text);
            string ngayban = dateTime.ToString("yyyy/MM/dd");

            if (!string.IsNullOrEmpty(textBox_mahoadon.Text.Trim())
                && !string.IsNullOrEmpty(comboBox_manv.Text.Trim()) && !string.IsNullOrEmpty(comboBox_sdtkh.Text.Trim()))
            {
                if (hdban.kiemtratontai(textBox_mahoadon.Text.ToString(), error, textBox_mahoadon) == false)
                {
                    if (hdban.them_HoaDon_ban(textBox_mahoadon.Text.Trim(), comboBox_manv.Text.Trim(), comboBox_sdtkh.Text.Trim(), ngayban) == true)
                    {
                        MessageBox.Show("Thêm thành công");
                        error.SetError(textBox_mahoadon, null);

                        MaHD = textBox_mahoadon.Text.Trim();
                        // Mở form Chi tiết hóa đơn ngay sau khi thêm thành công
                        ChiTietHD frmChiTietHD = new ChiTietHD(MaHD);
                        frmChiTietHD.Show();

                        // Làm mới
                        textBox_mahoadon.Text = string.Empty;
                        comboBox_sdtkh.Text = string.Empty;
                        comboBox_manv.Text = string.Empty;
                        dateTimePicker_ngayban.Value = DateTime.Now;
                    }
                }
                else
                {
                    MessageBox.Show("Không thành công");
                    error.SetError(textBox_mahoadon, "Mã hóa đơn này đã tồn tại");
                }
            }
            dataGridView_hoadonban.Rows.Clear();
            hdban.hien_HoaDonban(dataGridView_hoadonban);
        }


        private void dataGridView_hoadonban_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) // Nếu click vào header row
            {
                // Không cho phép chọn nếu click vào header row
                dataGridView_hoadonban.ClearSelection();
                return;
            }

            // Kiểm tra nếu click vào một trong các cột (0 - 3) để hiển thị thông tin hóa đơn
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.ColumnIndex <= 4)
            {
                // Lấy thông tin dòng đã chọn
                DataGridViewRow row = dataGridView_hoadonban.Rows[e.RowIndex];

                // Chuyển tất cả giá trị thành chuỗi và gán cho các ô tương ứng
                textBox_mahoadon.Text = row.Cells[0].Value.ToString();
                comboBox_manv.Text = row.Cells[1].Value.ToString();
                comboBox_sdtkh.Text = row.Cells[2].Value.ToString();

                // Chuyển đổi ngày bán thành chuỗi (giả sử định dạng ngày là yyyy/MM/dd)
                string ngayBan = row.Cells[3].Value.ToString();
                dateTimePicker_ngayban.Text = ngayBan;
                textBox_tth.Text = row.Cells[4].Value.ToString();

                // Đặt lại lỗi nếu có
                error.SetError(textBox_mahoadon, null);
            }

            // Kiểm tra nếu click vào cột số 4 (cột "Chi Tiết")
            if (e.ColumnIndex == 5 && e.RowIndex >= 0) // Đảm bảo không click vào tiêu đề
            {
                // Lấy mã hóa đơn từ DataGridView, giả sử cột 0 chứa mã hóa đơn
                object value = dataGridView_hoadonban.Rows[e.RowIndex].Cells[0].Value;

                if (value != null)
                {
                    string maHoaDon = value.ToString().Trim();

                    // Mở form ChiTietHD với mã hóa đơn lấy từ DataGridView
                    ChiTietHD chiTiet = new ChiTietHD(maHoaDon);
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
                DateTime dateTime = dateTimePicker_ngayban.Value;
                string ngayBan = dateTime.ToString("yyyy-MM-dd");

                // Kiểm tra các trường nhập không được để trống
                if (string.IsNullOrWhiteSpace(textBox_mahoadon.Text) ||
                    string.IsNullOrWhiteSpace(comboBox_manv.Text) ||
                    string.IsNullOrWhiteSpace(comboBox_sdtkh.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hỏi xác nhận trước khi sửa
                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn sửa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Gọi hàm cập nhật hóa đơn
                    bool isUpdated = hdban.update_HoaDon_ban(
                        textBox_mahoadon.Text.Trim(),
                        comboBox_manv.Text.Trim(),
                        comboBox_sdtkh.Text.Trim(),
                        ngayBan
                    );

                    if (isUpdated)
                    {
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Làm mới các ô nhập
                        textBox_mahoadon.Text = string.Empty;
                        comboBox_sdtkh.Text = string.Empty;
                        comboBox_manv.Text = string.Empty;
                        dateTimePicker_ngayban.Value = DateTime.Now;

                        // Cập nhật lại danh sách hóa đơn
                        dataGridView_hoadonban.Rows.Clear();
                        hdban.hien_HoaDonban(dataGridView_hoadonban);
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
            DateTime dateTime = Convert.ToDateTime(dateTimePicker_ngayban.Text);
            string ngayban = dateTime.ToString("yyyy/MM/dd");

            if (!string.IsNullOrEmpty(textBox_mahoadon.Text.Trim())
                && !string.IsNullOrEmpty(comboBox_manv.Text.Trim()) && !string.IsNullOrEmpty(comboBox_sdtkh.Text.Trim()))
            {
                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (hdban.Xoa_HD_ban(textBox_mahoadon.Text.Trim()) == true)
                    {
                        MessageBox.Show("Xóa thành công");
                        // làm mới
                        textBox_mahoadon.Text = string.Empty;
                        comboBox_sdtkh.Text = string.Empty;
                        comboBox_manv.Text = string.Empty;
                        dateTimePicker_ngayban.Value = DateTime.Now;
                    }
                    else
                    {
                        MessageBox.Show("Không thành công");
                    }
                }
            }
            dataGridView_hoadonban.Rows.Clear();
            hdban.hien_HoaDonban(dataGridView_hoadonban);
        }

        private void button_lammoi_Click(object sender, EventArgs e)
        {
            //textBox_mahoadon.Text = string.Empty;
            comboBox_sdtkh.Text = string.Empty;
            comboBox_manv.Text = string.Empty;
            comboBox_sdtkh.Items.Clear();
            comboBox_manv.Items.Clear();
            dateTimePicker_ngayban.Value = DateTime.Now;
            textBox_tth.Text = "0 VNĐ";
            textBox_TimKiem.Text = string.Empty;
            HoaDon_Load(sender, e);
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
                case "Mã Hóa Đơn":
                    columnName = "sMaDDH";
                    break;
                case "Mã Nhân Viên":
                    columnName = "sMaNV";
                    break;
                case "SĐT KH":
                    columnName = "sSoDTKH";
                    break;
                case "Ngày Bán":
                    columnName = "dNgayDatHang";
                    break;
                default:
                    MessageBox.Show("Vui lòng chọn tiêu chí tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            string query = $"SELECT ddh.sMaDDH, ddh.sMaNV, ddh.sSoDTKH, ddh.dNgayDatHang, ddh.fTongTienHang " +
                           "FROM tblDonDatHang ddh " +
                           "LEFT JOIN tblKhachHang kh ON ddh.sSoDTKH = kh.sSoDTKH ";

            // Điều kiện tìm kiếm
            if (!string.IsNullOrEmpty(columnName))
            {
                if (columnName == "dNgayDatHang")
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
            dlc.TimKiem_DNH_DDH(query, parameters, dataGridView_hoadonban);
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
                string ngayDat = dateTimePicker_ngayban.Checked ? dateTimePicker_ngayban.Value.ToString("yyyy-MM-dd") : "";
                string soDTKH = comboBox_sdtkh.Text.Trim();
                string MaDDH = textBox_mahoadon.Text.Trim();

                // Tạo câu truy vấn động
                string query = @"SELECT ddh.*, ctdh.*
                        FROM tblDonDatHang ddh
                        JOIN tblChiTietDDH ctdh ON ddh.sMaDDH = ctdh.sMaDDH
                        WHERE 1=1";

                List<SqlParameter> parameters = new List<SqlParameter>();

                // Điều kiện theo Mã Đơn Đặt Hàng
                if (!string.IsNullOrWhiteSpace(MaDDH))
                {
                    query += " AND ddh.sMaDDH = @MaDDH";
                    parameters.Add(new SqlParameter("@MaDDH", MaDDH));
                }

                // Điều kiện theo Mã Nhân Viên
                if (!string.IsNullOrWhiteSpace(maNV))
                {
                    query += " AND ddh.sMaNV = @MaNV";
                    parameters.Add(new SqlParameter("@MaNV", maNV));
                }

                // Điều kiện theo Số ĐT Khách Hàng
                if (!string.IsNullOrWhiteSpace(soDTKH))
                {
                    query += " AND ddh.sSoDTKH = @SoDTKH";
                    parameters.Add(new SqlParameter("@SoDTKH", soDTKH));
                }

                // Điều kiện theo Ngày Đặt (chỉ thêm nếu có chọn ngày)
                if (!string.IsNullOrWhiteSpace(ngayDat))
                {
                    query += " AND CONVERT(VARCHAR(10), ddh.dNgayDatHang, 120) = @NgayDat";
                    parameters.Add(new SqlParameter("@NgayDat", ngayDat));
                }

                // Lấy dữ liệu từ database
                dt = dlc.GetData(query, parameters.ToArray());

                // Khởi tạo báo cáo cụ thể
                DSHoaDon report = new DSHoaDon();

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
