using BTL_HSK_ver_1.crystal;
using BTL_HSK_ver_1.Resources;
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
    public partial class frmDanhSachSanPham : Form
    {

        DuLieuChung dlc = new DuLieuChung();
        public string tenDangNhap;
        ErrorProvider error = new ErrorProvider();
        sanpham sp = new sanpham();
        public frmDanhSachSanPham(string tenDangNhap)
        {
            InitializeComponent();
            this.tenDangNhap = tenDangNhap;
        }

        private void textBox_MaSanPham_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string maSP = textBox_MaSanPham.Text.Trim();

            if (string.IsNullOrEmpty(maSP))
            {
                error.SetError(textBox_MaSanPham, "Mã sản phẩm không được để trống!");
                e.Cancel = true;
            }
            else if (maSP.Length < 3 || maSP.Length > 20)
            {
                error.SetError(textBox_MaSanPham, "Độ dài mã sản phẩm phải từ 3 đến 20 ký tự!");
                e.Cancel = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(maSP, @"^[a-zA-Z0-9]+$"))
            {
                error.SetError(textBox_MaSanPham, "Mã sản phẩm chỉ được chứa chữ và số!");
                e.Cancel = true;
            }
            else
            {
                // Kiểm tra mã sản phẩm đã tồn tại
                bool isExist = dlc.KiemTraMaTonTai(
                    tableName: "tblSanPham",
                    columnName: "sMaSP",
                    valueToCheck: maSP,
                    error: error,
                    textBox: textBox_MaSanPham,
                    errorMessage: "Mã sản phẩm đã tồn tại!"
                );

                if (isExist)
                {
                    e.Cancel = true;
                }
                else
                {
                    error.SetError(textBox_MaSanPham, null);
                    e.Cancel = false;
                }
            }
        }

        private void textBox_TenSanPham_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string tenSP = textBox_TenSanPham.Text.Trim();

            if (string.IsNullOrEmpty(tenSP))
            {
                error.SetError(textBox_TenSanPham, "Tên sản phẩm không được để trống!");
                e.Cancel = true;
            }
            else if (tenSP.Length < 3 || tenSP.Length > 50)
            {
                error.SetError(textBox_TenSanPham, "Độ dài tên sản phẩm phải từ 3 đến 50 ký tự!");
                e.Cancel = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(tenSP, @"^[a-zA-Z\s]+$"))
            {
                error.SetError(textBox_TenSanPham, "Tên sản phẩm chỉ được chứa chữ cái và khoảng trắng!");
                e.Cancel = true;
            }
            else
            {
                error.SetError(textBox_TenSanPham, null);
                e.Cancel = false;
            }
        }

        private void textBox_SoLuong_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string soLuong = textBox_SoLuong.Text.Trim();

            if (string.IsNullOrEmpty(soLuong))
            {
                error.SetError(textBox_SoLuong, "Số lượng sản phẩm không được để trống!");
                e.Cancel = true;
            }
            else if (!int.TryParse(soLuong, out int sl) || sl <= 0)
            {
                error.SetError(textBox_SoLuong, "Số lượng phải là số nguyên dương!");
                e.Cancel = true;
            }
            else
            {
                error.SetError(textBox_SoLuong, null);
                e.Cancel = false;
            }
        }

        private void textBox_GiaBan_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string giaBan = textBox_GiaTien.Text.Trim();

            if (string.IsNullOrEmpty(giaBan))
            {
                error.SetError(textBox_GiaTien, "Giá bán sản phẩm không được để trống!");
                e.Cancel = true;
            }
            else if (!decimal.TryParse(giaBan, out decimal gia) || gia <= 0)
            {
                error.SetError(textBox_GiaTien, "Giá bán phải là số dương!");
                e.Cancel = true;
            }
            else
            {
                error.SetError(textBox_GiaTien, null);
                e.Cancel = false;
            }
        }

        private void frmDanhSachSanPham_Load(object sender, EventArgs e)
        {
            this.Select(); // Đặt con trỏ chuột mặc định cho form
            sp.hien_SP(dataGridView_sanpham);
            
            comboBox_ma_NCC.Items.Clear();
            sp.uploadComboBox( comboBox_ma_NCC);
        }


        private void button_Them_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng CancelEventArgs để dùng cho các hàm Validating
            CancelEventArgs cancelEvent = new CancelEventArgs();

            // Gọi các hàm kiểm tra dữ liệu từ các TextBox và ComboBox
            textBox_GiaBan_Validating(sender, cancelEvent);
            textBox_MaSanPham_Validating(sender, cancelEvent);
            textBox_SoLuong_Validating(sender, cancelEvent);
            textBox_TenSanPham_Validating(sender, cancelEvent);
            comboBox_ten_dvt_Validating(sender, cancelEvent);
            comboBox_ma_sx_Validating(sender, cancelEvent);
            comboBox_ma_NCC_Validating(sender, cancelEvent);

            // Kiểm tra nếu tất cả các trường đều không trống
            if (!string.IsNullOrEmpty(textBox_MaSanPham.Text.Trim()) &&
                !string.IsNullOrEmpty(textBox_TenSanPham.Text.Trim()) &&
                !string.IsNullOrEmpty(comboBox_tenlh.Text.Trim()) &&
                !string.IsNullOrEmpty(comboBox_ma_NCC.Text.Trim()) &&
                !string.IsNullOrEmpty(textBox_SoLuong.Text.Trim()) &&
                !string.IsNullOrEmpty(textBox_GiaTien.Text.Trim()) &&
                !string.IsNullOrEmpty(comboBox_tendvt.Text.Trim()))
            {
                // Sử dụng hàm kiểm tra mã dùng chung trong DuLieuChung
                bool isExist = dlc.KiemTraMaTonTai(
                    tableName: "tblSanPham",
                    columnName: "sMaSP",
                    valueToCheck: textBox_MaSanPham.Text.Trim(),
                    error: error,
                    textBox: textBox_MaSanPham,
                    errorMessage: "Mã sản phẩm đã tồn tại!"
                );

                if (!isExist)
                {
                    // Thêm sản phẩm nếu mã sản phẩm chưa tồn tại
                    sp.ThemSP(
                        textBox_MaSanPham.Text.Trim(),
                        textBox_TenSanPham.Text.Trim(),
                        comboBox_tenlh.Text.Trim(),
                        comboBox_ma_NCC.Text.Trim(),
                        int.Parse(textBox_SoLuong.Text.Trim()),
                        float.Parse(textBox_GiaTien.Text.Trim()),
                        comboBox_tendvt.Text.Trim()
                    );

                    MessageBox.Show("Thêm thành công");

                    // Reset các trường nhập liệu
                    comboBox_ma_NCC.Text = string.Empty;
                    textBox_ten_NCC.Text = string.Empty;
                    comboBox_tenlh.Text = string.Empty;
                    textBox_MaSanPham.Text = string.Empty;
                    textBox_TenSanPham.Text = string.Empty;
                    textBox_SoLuong.Text = string.Empty;
                    textBox_GiaTien.Text = string.Empty;
                    comboBox_tendvt.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại, vui lòng nhập mã khác.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin các trường!");
            }

            // Cập nhật lại DataGridView sau khi thêm sản phẩm mới
            dataGridView_sanpham.Rows.Clear();
            sp.hien_SP(dataGridView_sanpham);
        }



        private void comboBox_ten_dvt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox_tendvt.Text.Trim()))
            {
                error.SetError(comboBox_tendvt, "Mã dvt không được để trống!");
            }
            else
            {
                error.SetError(comboBox_tendvt, null);
            }
        }

        private void comboBox_ma_sx_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox_tenlh.Text.Trim()))
            {
                error.SetError(comboBox_tenlh, "Mã sx không được để trống!");
            }
            else
            {
                error.SetError(comboBox_tenlh, null);
            }
        }

        private void comboBox_ma_NCC_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox_ma_NCC.Text.Trim()))
            {
                error.SetError(comboBox_ma_NCC, "Mã nhà cung cấp không được để trống!");
            }
            else
            {
                error.SetError(comboBox_ma_NCC, null);
            }
        }

        
        private void comboBox_ma_NCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            sp.layten_ncc(comboBox_ma_NCC.Text.Trim(), textBox_ten_NCC);
        }

        
        private void dataGridView_sanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {textBox_MaSanPham.CausesValidation = false;
    textBox_MaSanPham.CausesValidation = true;
            if (e.RowIndex == -1) // Nếu click vào header row
            {
                // Không cho phép chọn nếu click vào header row
                dataGridView_sanpham.ClearSelection();
            }

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell dataGridViewCell = dataGridView_sanpham[e.ColumnIndex, e.RowIndex];
                if (dataGridViewCell.Value != null)
                {
                    error.SetError(textBox_MaSanPham, null);
                    DataGridViewRow row = dataGridView_sanpham.Rows[e.RowIndex];
                    textBox_MaSanPham.Text = row.Cells[0].Value.ToString();
                    textBox_TenSanPham.Text = row.Cells[1].Value.ToString();
                    textBox_SoLuong.Text = row.Cells[2].Value.ToString();
                    textBox_GiaTien.Text = row.Cells[3].Value.ToString();
                    comboBox_tendvt.Text = row.Cells[4].Value.ToString();
                    comboBox_tenlh.Text = row.Cells[5].Value.ToString();
                    textBox_ten_NCC.Text = row.Cells[6].Value.ToString();
                    comboBox_ma_NCC.Text = row.Cells[7].Value.ToString();
                }
                else
                {
                    // Xử lý khi giá trị của ô là null
                }
            }
        }

        private void button_Luu_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_MaSanPham.Text.Trim()) &&
                !string.IsNullOrEmpty(textBox_TenSanPham.Text.Trim()) &&
                !string.IsNullOrEmpty(comboBox_tenlh.Text.Trim()) &&
                !string.IsNullOrEmpty(comboBox_ma_NCC.Text.Trim()) &&
                !string.IsNullOrEmpty(textBox_SoLuong.Text.Trim()) &&
                !string.IsNullOrEmpty(textBox_GiaTien.Text.Trim()) )
            {
                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn sửa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    if (sp.update_sanpham(textBox_MaSanPham.Text.Trim(), textBox_TenSanPham.Text.Trim(), comboBox_tenlh.Text.Trim(), comboBox_ma_NCC.Text.Trim(),comboBox_tendvt.Text.Trim(), int.Parse(textBox_SoLuong.Text.Trim()), float.Parse(textBox_GiaTien.Text.Trim())) == true)
                    {
                        MessageBox.Show("Sửa thành công");
                        // đưa các ô nhập liệu về rỗng
                        textBox_MaSanPham.Text = string.Empty;
                        textBox_TenSanPham.Text = string.Empty;
                        textBox_SoLuong.Text = string.Empty;
                        textBox_GiaTien.Text = string.Empty;
                        comboBox_tendvt.Text = string.Empty;
                        comboBox_tenlh.Text = string.Empty;
                        comboBox_ma_NCC.Text = string.Empty;
                        textBox_ten_NCC.Text = string.Empty;
                    }

                    else
                    {
                        MessageBox.Show("Sửa không thành công");
                    }

                }


            }
            dataGridView_sanpham.Rows.Clear();
            sp.hien_SP(dataGridView_sanpham);
        }

        private void button_Huy_Click(object sender, EventArgs e)
        {
            comboBox_ma_NCC.Text = string.Empty;
            textBox_ten_NCC.Text = string.Empty;
            comboBox_tenlh.Text = string.Empty;
            textBox_MaSanPham.Text = string.Empty;
            textBox_TenSanPham.Text = string.Empty;
            textBox_SoLuong.Text = string.Empty;
            textBox_GiaTien.Text = string.Empty;
            comboBox_tendvt.Text = string.Empty;
        }

        private void button_Xoa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_MaSanPham.Text.Trim()) &&
                !string.IsNullOrEmpty(textBox_TenSanPham.Text.Trim()) &&
                !string.IsNullOrEmpty(comboBox_tenlh.Text.Trim()) &&
                !string.IsNullOrEmpty(comboBox_ma_NCC.Text.Trim()) &&
                !string.IsNullOrEmpty(textBox_SoLuong.Text.Trim()) &&
                !string.IsNullOrEmpty(textBox_GiaTien.Text.Trim()) 
                )
            {
                DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn xóa không(dữ liệu ở bảng nhập và bán có thể bị mất)?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (sp.xoa_SP(textBox_MaSanPham.Text.Trim()) == true)
                    {
                        MessageBox.Show("Xóa thành công");
                        // đưa các ô nhập liệu về rỗng
                        textBox_MaSanPham.Text = string.Empty;
                        textBox_TenSanPham.Text = string.Empty;
                        textBox_SoLuong.Text = string.Empty;
                        textBox_GiaTien.Text = string.Empty;
                        comboBox_tendvt.Text = string.Empty;
                        comboBox_tenlh.Text = string.Empty;
                        comboBox_ma_NCC.Text = string.Empty;
                        textBox_ten_NCC.Text = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công");
                    }
                }


            }
            dataGridView_sanpham.Rows.Clear();
            sp.hien_SP(dataGridView_sanpham);
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
                case "Mã Sản Phẩm":
                    columnName = "sMaSP";
                    break;
                case "Tên Sản Phẩm":
                    columnName = "sTenSP";
                    break;
                case "Đơn Vị SP":
                    columnName = "sTenDVT";
                    break;
                case "Tên Loại SP":
                    columnName = "sTenLoaiHang";
                    break;
                default:
                    MessageBox.Show("Vui lòng chọn tiêu chí tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }


            string query = $"SELECT sp.sMaSP, sp.sTenSP, sp.iSoLuong, sp.fGiaTien, sp.sTenDVT, sp.sTenLoaiHang, ncc.sTenNCC, ncc.sMaNCC " +
            "FROM tblSanPham sp " +
            "LEFT JOIN tblNhaCungCap ncc ON sp.sMaNCC = ncc.sMaNCC " +
             $"WHERE {columnName} LIKE @searchValue COLLATE SQL_Latin1_General_CP1_CI_AS;";



            // Tạo danh sách tham số
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@searchValue", "%" + searchValue + "%" }
            };

            // Gọi hàm tìm kiếm chung từ lớp DuLieuChung
            dlc.TimKiemDuLieu(query, parameters, dataGridView_sanpham);
        }

        private void button_Boloc_Click(object sender, EventArgs e)
        {
            textBox_TimKiem.Text = "";
            sp.hien_SP(dataGridView_sanpham);
        }

        private void button_inds_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tenDangNhap))
                {
                    MessageBox.Show("Không lấy được tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dt = new DataTable();
                string query = "SELECT * FROM tblSanPham";
                SqlParameter[] parameters = null;

                dt = dlc.GetData(query, parameters);


                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DSSanPham report = new DSSanPham();

                dlc.InHoaDon(dt, report, tenDangNhap);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở báo cáo: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
