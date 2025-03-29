using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL_HSK_ver_1.Resources;
using BTL_HSK_ver_1.crystal;


namespace BTL_HSK_ver_1
{
    public partial class frmDanhSachNhanVien : Form
    {
        
        double phucap = 0;
        double luong = 0;
        NhanVien nhan_vien = new NhanVien();
        ErrorProvider error = new ErrorProvider();
        public string tenDangNhap;
        DuLieuChung dlc = new DuLieuChung();

        public frmDanhSachNhanVien(string tenDangNhap)
        {
            InitializeComponent();
            this.tenDangNhap = tenDangNhap; // Gán giá trị vào biến thành viên
        }

        private void textBox_Ten_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Ten.Text.Trim()))
            {
                error.SetError(textBox_Ten, "Tên nhân viên không được để trống!");
                e.Cancel = true;
            }
            else if (textBox_Ten.Text.Any(char.IsDigit))
            {
                error.SetError(textBox_Ten, "Tên nhân viên không được chứa số!");
                e.Cancel = true;
            }
            else
            {
                error.SetError(textBox_Ten, null);
            }
        }

        private void textBox_DiaChi_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_DiaChi.Text.Trim()))
            {
                error.SetError(textBox_DiaChi, "Địa chỉ không được để trống!");
                e.Cancel = true;
            }
            else
            {
                error.SetError(textBox_DiaChi, null);
            }
        }

        private void textBox_SDT_Validating(object sender, CancelEventArgs e)
        {
            string sdt = textBox_SDT.Text.Trim();
            if (string.IsNullOrEmpty(sdt))
            {
                error.SetError(textBox_SDT, "Số điện thoại không được để trống!");
                e.Cancel = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^\d{10,11}$"))
            {
                error.SetError(textBox_SDT, "Số điện thoại phải là số từ 10-11 ký tự!");
                e.Cancel = true;
            }
            else
            {
                error.SetError(textBox_SDT, null);
            }
        }

        private void textBox_luong_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_luong.Text.Trim()))
            {
                error.SetError(textBox_luong, "Lương không được để trống!");
                e.Cancel = true;
            }
            else if (!double.TryParse(textBox_luong.Text.Replace(".", ""), out double luong) || luong <= 0)
            {
                error.SetError(textBox_luong, "Lương phải là số dương!");
                e.Cancel = true;
            }
            else
            {
                error.SetError(textBox_luong, null);
            }
        }

        private void textBox_phu_cap_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_phu_cap.Text.Trim()))
            {
                error.SetError(textBox_phu_cap, "Phụ cấp không được để trống!");
                e.Cancel = true;
            }
            else if (!double.TryParse(textBox_phu_cap.Text.Replace(".", ""), out double phuCap) || phuCap < 0)
            {
                error.SetError(textBox_phu_cap, "Phụ cấp phải là số không âm!");
                e.Cancel = true;
            }
            else
            {
                error.SetError(textBox_phu_cap, null);
            }
        }

        private void textBox_MaNV_Validating(object sender, CancelEventArgs e)
        {
            string maNV = textBox_maNV.Text.Trim();
            if (string.IsNullOrEmpty(maNV))
            {
                error.SetError(textBox_maNV, "Mã nhân viên không được để trống!");
               
            }
            else
            {
                error.SetError(textBox_maNV, null);
                bool kiemtra = nhan_vien.kiemtra_maNV(maNV, error, textBox_maNV);
                if (kiemtra)
                {
                    error.SetError(textBox_maNV, "Mã nhân viên đã tồn tại!");
                    e.Cancel = true;
                }
            }
        }

        private void button_ThemNV_Click(object sender, EventArgs e)
        {
            string gioitinh = string.Empty;
            bool isValid = true;

            // Làm mới DataGridView trước khi thêm
            dataGridView_NhanVien.Rows.Clear();

            // Gọi hàm Validating để kiểm tra các trường
            CancelEventArgs g = new CancelEventArgs();
            textBox_phu_cap_Validating(sender, g);
            textBox_luong_Validating(sender, g);
            textBox_DiaChi_Validating(sender, g);
            textBox_SDT_Validating(sender, g);
            textBox_Ten_Validating(sender, g);
            textBox_MaNV_Validating(sender, g);

            // Kiểm tra giới tính
            if (!radioButton_GT_Nam.Checked && !radioButton_GT_Nu.Checked)
            {
                error.SetError(radioButton_GT_Nu, "Vui lòng chọn giới tính!");
                isValid = false;
            }
            else
            {
                gioitinh = radioButton_GT_Nam.Checked ? "Nam" : "Nữ";
                error.SetError(radioButton_GT_Nu, null);
            }

            // Kiểm tra ngày sinh và ngày vào làm
            DateTime ngaySinh = dateTimePicker_NgaySinh.Value.Date;
            DateTime ngayVaoLam = dateTimePicker1_ngay_vao_lam.Value.Date;

            if ((ngayVaoLam - ngaySinh).TotalDays / 365.25 < 18)
            {
                error.SetError(dateTimePicker1_ngay_vao_lam, "Nhân viên phải đủ 18 tuổi!");
                isValid = false;
            }
            else
            {
                error.SetError(dateTimePicker1_ngay_vao_lam, null);
            }

            // Chuyển đổi lương và phụ cấp
            float luong;
            float phucap;

            if (!float.TryParse(textBox_luong.Text, out luong) || luong < 0)
            {
                error.SetError(textBox_luong, "Lương không hợp lệ!");
                isValid = false;
            }
            else
            {
                error.SetError(textBox_luong, null);
            }

            if (!float.TryParse(textBox_phu_cap.Text, out phucap) || phucap < 0)
            {
                error.SetError(textBox_phu_cap, "Phụ cấp không hợp lệ!");
                isValid = false;
            }
            else
            {
                error.SetError(textBox_phu_cap, null);
            }

            // Nếu tất cả hợp lệ, thực hiện thêm
            if (isValid)
            {
                string sNgaySinh = ngaySinh.ToString("yyyy/MM/dd");
                string sNgayVaoLam = ngayVaoLam.ToString("yyyy/MM/dd");

                // Kiểm tra mã nhân viên đã tồn tại chưa
                bool them = nhan_vien.ThemNhanVien(
                    textBox_maNV.Text.Trim(),
                    textBox_Ten.Text.Trim(),
                    gioitinh,
                    textBox_DiaChi.Text.Trim(),
                    textBox_SDT.Text.Trim(),
                    sNgaySinh,
                    sNgayVaoLam,
                    luong,
                    phucap
                );

                if (them)
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Làm sạch các trường nhập liệu
                    textBox_maNV.Text = string.Empty;
                    textBox_Ten.Text = string.Empty;
                    textBox_DiaChi.Text = string.Empty;
                    textBox_SDT.Text = string.Empty;
                    textBox_luong.Text = string.Empty;
                    textBox_phu_cap.Text = string.Empty;
                    radioButton_GT_Nam.Checked = false;
                    radioButton_GT_Nu.Checked = false;
                    dateTimePicker_NgaySinh.Value = DateTime.Now;
                    dateTimePicker1_ngay_vao_lam.Value = DateTime.Now;
                }
                else
                {
                    MessageBox.Show("Không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Hiển thị lại danh sách nhân viên
                nhan_vien.hien_NhanVien(dataGridView_NhanVien);
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void textBox_SDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Không cho phép ký tự không phải số hoặc vượt quá 10 số
            }

            // Kiểm tra độ dài của chuỗi số điện thoại sau khi thêm ký tự mới
            if (char.IsDigit(e.KeyChar) && textBox_SDT.Text.Replace(" ", "").Length >= 10)
            {
                e.Handled = true; // Nếu đã có 10 số, ngăn không cho thêm số nữa
            }
        }

        private void textBox_SDT_TextChanged(object sender, EventArgs e)
        {


        }

        private void textBox_luong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Không cho phép ký tự không phải số hoặc vượt quá 10 số
            }
        }

        private void textBox_luong_TextChanged(object sender, EventArgs e)
        {

            TextBox textBox = (TextBox)sender;
            int caretPosition = textBox.SelectionStart;
            string inputText = textBox.Text;

            string cleanText = Regex.Replace(inputText, @"[^\d]", "");
            string formattedText = string.Empty;
            int separatorCount = 0;

            // Tạo chuỗi với dấu phân cách hàng nghìn
            for (int i = 0; i < cleanText.Length; i++)
            {
                if (i > 0 && i % 3 == 0)
                {
                    formattedText = cleanText[cleanText.Length - i - 1] + "." + formattedText;
                    separatorCount++;
                }
                else
                {
                    formattedText = cleanText[cleanText.Length - i - 1] + formattedText;
                }
            }

            // Xóa kí tự đầu tiên nếu là dấu phân cách hàng nghìn
            if (formattedText.StartsWith("."))
            {
                formattedText = formattedText.Substring(1);
                caretPosition--;
                separatorCount--;
            }

            textBox.TextChanged -= textBox_luong_TextChanged;
            textBox.Text = formattedText;
            textBox.TextChanged += textBox_luong_TextChanged;

            // Đặt vị trí con trỏ
            if (caretPosition <= formattedText.Length + separatorCount)
            {
                textBox.SelectionStart = caretPosition + separatorCount;
            }
            else
            {
                textBox.SelectionStart = formattedText.Length + separatorCount;
            }


        }



        private void textBox_phu_cap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Không cho phép ký tự không phải số hoặc vượt quá 10 số
            }
        }
        private void textBox_phu_cap_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int caretPosition = textBox.SelectionStart;
            string inputText = textBox.Text;

            string cleanText = Regex.Replace(inputText, @"[^\d]", "");
            string formattedText = string.Empty;
            int separatorCount = 0;

            // Tạo chuỗi với dấu phân cách hàng nghìn
            for (int i = 0; i < cleanText.Length; i++)
            {
                if (i > 0 && i % 3 == 0)
                {
                    formattedText = "." + formattedText;
                    separatorCount++;
                }
                formattedText = cleanText[cleanText.Length - i - 1] + formattedText;
            }

            // Xóa kí tự đầu tiên nếu là dấu phân cách hàng nghìn
            if (formattedText.StartsWith("."))
            {
                formattedText = formattedText.Substring(1);
                caretPosition--;
                separatorCount--;
            }

            textBox.TextChanged -= textBox_phu_cap_TextChanged;
            textBox.Text = formattedText;
            textBox.TextChanged += textBox_phu_cap_TextChanged;

            // Đặt vị trí con trỏ
            textBox.SelectionStart = caretPosition + separatorCount;

            // Xử lý chuyển đổi chuỗi đã định dạng thành double
            double parsedValue;
            if (double.TryParse(Regex.Replace(formattedText, @"\.", ""), out parsedValue))
            {
                phucap = parsedValue;
            }
            else
            {
                // Xử lý trường hợp không thể chuyển đổi thành double, ví dụ thông báo hoặc hành động khác tùy thuộc vào yêu cầu của bạn.
            }
        }


       
        private void dataGridView_NhanVien_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView_NhanVien.Rows[e.RowIndex];

                // Đưa dữ liệu từ DataGridView lên các TextBox
                textBox_maNV.Text = selectedRow.Cells["sMaNV"].Value?.ToString() ?? string.Empty;
                textBox_Ten.Text = selectedRow.Cells["sHoTen"].Value?.ToString() ?? string.Empty;
                textBox_DiaChi.Text = selectedRow.Cells["sDiaChi"].Value?.ToString() ?? string.Empty;
                textBox_SDT.Text = selectedRow.Cells["sSDT"].Value?.ToString() ?? string.Empty;
                textBox_luong.Text = selectedRow.Cells["fLuong"].Value?.ToString() ?? string.Empty;
                textBox_phu_cap.Text = selectedRow.Cells["fPhuCap"].Value?.ToString() ?? string.Empty;

                // Đưa giá trị ngày sinh và ngày vào làm lên DateTimePicker
                dateTimePicker_NgaySinh.Value = DateTime.Parse(selectedRow.Cells["dNgaySinh"].Value?.ToString() ?? DateTime.Now.ToString());
                dateTimePicker1_ngay_vao_lam.Value = DateTime.Parse(selectedRow.Cells["dNgayVaoLam"].Value?.ToString() ?? DateTime.Now.ToString());

                // Chọn RadioButton giới tính
                string gioiTinh = selectedRow.Cells["sGioiTinh"].Value?.ToString();
                if (gioiTinh == "Nam")
                {
                    radioButton_GT_Nam.Checked = true;
                }
                else if (gioiTinh == "Nữ")
                {
                    radioButton_GT_Nu.Checked = true;
                }
                else
                {
                    radioButton_GT_Nam.Checked = false;
                    radioButton_GT_Nu.Checked = false;
                }
            }
        }
        private void button_SuaNV_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn trong DataGridView không
            if (dataGridView_NhanVien.SelectedRows.Count > 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = dataGridView_NhanVien.SelectedRows[0];

                // Lấy mã nhân viên từ hàng được chọn
                string maNV = selectedRow.Cells["sMaNV"].Value.ToString();

                // Kiểm tra các trường nhập liệu không rỗng
                if (!string.IsNullOrEmpty(textBox_Ten.Text.Trim()) &&
                    !string.IsNullOrEmpty(textBox_SDT.Text.Trim()) &&
                    !string.IsNullOrEmpty(textBox_DiaChi.Text.Trim()) &&
                    !string.IsNullOrEmpty(textBox_luong.Text.Trim()) &&
                    (radioButton_GT_Nam.Checked || radioButton_GT_Nu.Checked) &&
                    !string.IsNullOrEmpty(dateTimePicker_NgaySinh.Text.Trim()) &&
                    !string.IsNullOrEmpty(dateTimePicker1_ngay_vao_lam.Text.Trim()))
                {
                    int loi = 0;

                    // Hiển thị hộp thoại xác nhận sửa
                    DialogResult result = MessageBox.Show("Bạn chắc chắn muốn sửa thông tin nhân viên này không?",
                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Kiểm tra giới tính
                        if (!radioButton_GT_Nam.Checked && !radioButton_GT_Nu.Checked)
                        {
                            error.SetError(radioButton_GT_Nu, "Vui lòng chọn giới tính!");
                            loi--;
                        }
                        else
                        {
                            error.SetError(radioButton_GT_Nu, null);
                        }

                        // Kiểm tra ngày vào làm lớn hơn 18 tuổi so với ngày sinh
                        DateTime ngaySinh = dateTimePicker_NgaySinh.Value;
                        DateTime ngayVaoLam = dateTimePicker1_ngay_vao_lam.Value;

                        if ((ngayVaoLam - ngaySinh).TotalDays / 365.25 >= 18)
                        {
                            error.SetError(dateTimePicker1_ngay_vao_lam, null);
                        }
                        else
                        {
                            error.SetError(dateTimePicker1_ngay_vao_lam, "Nhân viên phải trên 18 tuổi!");
                            loi--;
                        }

                        if (loi == 0)
                        {
                            // Chuẩn bị dữ liệu để cập nhật
                            string gioitinh = radioButton_GT_Nam.Checked ? "Nam" : "Nữ";
                            double luong = double.Parse(Regex.Replace(textBox_luong.Text, @"\.", ""));
                            double phuCap = string.IsNullOrEmpty(textBox_phu_cap.Text) ? 0 : double.Parse(textBox_phu_cap.Text.Replace(".", ""));
                            string ngaySinhStr = ngaySinh.ToString("yyyy/MM/dd");
                            string ngayVaoLamStr = ngayVaoLam.ToString("yyyy/MM/dd");

                            // Gọi phương thức cập nhật
                            nhan_vien.update_NhanVien(maNV, textBox_Ten.Text.Trim(), gioitinh, textBox_DiaChi.Text.Trim(),
                                textBox_SDT.Text.Trim(), ngaySinhStr, ngayVaoLamStr, luong, phuCap);

                            // Đưa các ô nhập liệu về rỗng
                            textBox_maNV.Text = string.Empty;
                            textBox_Ten.Text = string.Empty;
                            textBox_SDT.Text = string.Empty;
                            textBox_DiaChi.Text = string.Empty;
                            textBox_luong.Text = string.Empty;
                            textBox_phu_cap.Text = string.Empty;
                            radioButton_GT_Nam.Checked = false;
                            radioButton_GT_Nu.Checked = false;
                            dateTimePicker_NgaySinh.Value = DateTime.Now;
                            dateTimePicker1_ngay_vao_lam.Value = DateTime.Now;

                            // Làm mới DataGridView
                            dataGridView_NhanVien.Rows.Clear();
                            nhan_vien.hien_NhanVien(dataGridView_NhanVien);

                            MessageBox.Show("Sửa thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên từ danh sách để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void button_XoaNV_Click(object sender, EventArgs e)
        {
            // kiểm tra nếu rỗng thì không xóa được
            if (!string.IsNullOrEmpty(textBox_maNV.Text.Trim()) && !string.IsNullOrEmpty(textBox_Ten.Text.Trim())
               && !string.IsNullOrEmpty(textBox_SDT.Text.Trim()) && !string.IsNullOrEmpty(textBox_DiaChi.Text.Trim())
               && !string.IsNullOrEmpty(textBox_luong.Text.Trim()) && (radioButton_GT_Nam.Checked == true || radioButton_GT_Nu.Checked == true)
               && !string.IsNullOrEmpty(dateTimePicker_NgaySinh.Text.Trim()) && !string.IsNullOrEmpty(dateTimePicker1_ngay_vao_lam.Text.Trim()))
            {
                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string gioitinh = string.Empty;
                    double luong = 0;
                    double phu = 0;
                    luong = double.Parse(Regex.Replace(textBox_luong.Text, @"\.", ""));
                    if (textBox_phu_cap.Text == "0")
                    {
                        phu = 0;
                    }
                    else
                    {
                        phu = double.Parse(textBox_phu_cap.Text.Replace(".", ""));
                    }
                    if (radioButton_GT_Nam.Checked == true)
                    {
                        gioitinh = "Nam";
                    }
                    else
                    {
                        gioitinh = "Nữ";
                    }
                    DateTime dateTime = Convert.ToDateTime(dateTimePicker_NgaySinh.Text);
                    string sNgaySinh = dateTime.ToString("yyyy/MM/dd");
                    DateTime dateTime_ngayvaolam = Convert.ToDateTime(dateTimePicker1_ngay_vao_lam.Text);
                    string ngayvaolam = dateTime_ngayvaolam.ToString("yyyy/MM/dd");
                    nhan_vien.xoa_Nhanvien(textBox_maNV.Text.Trim(), textBox_Ten.Text.Trim()
                        , gioitinh, textBox_DiaChi.Text.Trim(), textBox_SDT.Text.Trim()
                        , sNgaySinh, ngayvaolam
                        , luong, phu);
                    // đưa các ô nhập liệu về rỗng
                    textBox_maNV.Text = string.Empty;
                    textBox_Ten.Text = string.Empty;
                    textBox_SDT.Text = string.Empty;
                    textBox_DiaChi.Text = string.Empty;
                    textBox_luong.Text = string.Empty;
                    textBox_phu_cap.Text = string.Empty;
                    radioButton_GT_Nam.Checked = false;
                    radioButton_GT_Nu.Checked = false;
                    dateTimePicker_NgaySinh.Value = DateTime.Now;
                    dateTimePicker1_ngay_vao_lam.Value = DateTime.Now;
                    dataGridView_NhanVien.Rows.Clear();
                    nhan_vien.hien_NhanVien(dataGridView_NhanVien);
                }
                else
                {
                    // đóng
                }
            }
        }

        private void button_huy_Click(object sender, EventArgs e)
        {
            // đưa các ô nhập liệu về rỗng
            textBox_maNV.Text = string.Empty;
            textBox_Ten.Text = string.Empty;
            textBox_SDT.Text = string.Empty;
            textBox_DiaChi.Text = string.Empty;
            textBox_luong.Text = string.Empty;
            textBox_phu_cap.Text = string.Empty;
            radioButton_GT_Nam.Checked = false;
            radioButton_GT_Nu.Checked = false;
            dateTimePicker_NgaySinh.Value = DateTime.Now;
            dateTimePicker1_ngay_vao_lam.Value = DateTime.Now;

            error.SetError(textBox_maNV, null);
            error.SetError(textBox_Ten, null);
            error.SetError(textBox_SDT, null);
            error.SetError(textBox_luong, null);
            error.SetError(textBox_phu_cap, null);
            error.SetError(dateTimePicker1_ngay_vao_lam, null);
            error.SetError(radioButton_GT_Nu, null);
        }

        private void dateTimePicker_NgaySinh_Validating(object sender, CancelEventArgs e)
        {
            DateTime selectedDate1 = dateTimePicker_NgaySinh.Value;
            DateTime justDate1 = selectedDate1.Date; // Lấy ngày sinh

            DateTime selectedDate2 = dateTimePicker1_ngay_vao_lam.Value;
            DateTime justDate2 = selectedDate2.Date; // Lấy ngày bắt đầu làm việc

            if ((justDate2 - justDate1).TotalDays / 365.25 >= 18)
            {
                error.SetError(dateTimePicker1_ngay_vao_lam, null);
            }
            else
            {
                error.SetError(dateTimePicker1_ngay_vao_lam, "Ngày sinh phải lơn hơn 18 tuổi!");
            }
        }





        private void textBox_TimKiem_TextChanged(object sender, EventArgs e)
        {
            string columnName = "";
            string searchValue = textBox_TimKiem.Text.Trim();

            // Lấy tên cột tìm kiếm từ ComboBox
            string selectedSearch = comboBox_Timkiem.SelectedItem?.ToString() ?? "";

            // Xác định cột tìm kiếm dựa vào lựa chọn
            switch (selectedSearch)
            {
                case "Mã Nhân Viên":
                    columnName = "sMaNV";
                    break;
                case "Tên Nhân Viên":
                    columnName = "sHoTen";
                    break;
                case "Địa Chỉ":
                    columnName = "sDiachi";
                    break;
                case "Giới Tính (Nam/Nữ)":
                    columnName = "sGioiTinh";
                    break;
                case "ngày sinh":
                    columnName = "dNgaySinh";
                    break;
                case "ngày vào làm":
                    columnName = "dNgayVaoLam";
                    break;
                default:
                    MessageBox.Show("Vui lòng chọn tiêu chí tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            // Tạo câu truy vấn động
            string query = $"SELECT sMaNV, sHoTen,sGioiTinh, sDiachi, sSDT, dNgaysinh, dNgayvaolam, fLuongcoban, fPhucap " +
                "FROM tblNhanvien " +
                $"WHERE {columnName} LIKE @searchValue COLLATE SQL_Latin1_General_CP1_CI_AS;";

            if (!string.IsNullOrEmpty(columnName))
            {
                if (columnName == "dNgayVaoLam")
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
        { "@searchValue", "%" + searchValue + "%" }
    };

            // Gọi hàm tìm kiếm chung từ lớp DuLieuChung
            dlc.TimKiemDuLieu(query, parameters, dataGridView_NhanVien);
        }




        private void frmDanhSachNhanVien_Load(object sender, EventArgs e)
        {
            nhan_vien.hien_NhanVien(dataGridView_NhanVien);
        }

        private void button_Boloc_Click(object sender, EventArgs e)
        {
            textBox_TimKiem.Text = "";
            nhan_vien.hien_NhanVien(dataGridView_NhanVien);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tenDangNhap))
                {
                    MessageBox.Show("Không lấy được tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dt = new DataTable();
                string query = "SELECT * FROM tblNhanVien"; 
                SqlParameter[] parameters = null; 

                    dt = dlc.GetData(query, parameters);
                
                
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DSNhanVien report = new DSNhanVien();

                dlc.InHoaDon(dt, report, tenDangNhap);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở báo cáo: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
