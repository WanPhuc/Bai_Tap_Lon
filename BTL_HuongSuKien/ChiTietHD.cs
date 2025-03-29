using BTL_HSK_ver_1.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_HSK_ver_1
{
    public partial class ChiTietHD : Form
    {
        ErrorProvider error = new ErrorProvider();
        Chitiet_hdon_ban chitiet = new Chitiet_hdon_ban();
        string mahd;
        public ChiTietHD(string mahd)
        {
            InitializeComponent();
            this.mahd = mahd;
        }

        private void ChiTietHD_Load(object sender, EventArgs e)
        {
            textBox_MaHD.Text = this.mahd + "";
            textBox_MaHD.ReadOnly = true;
            chitiet.uploadComboBox(comboBox_masp);
            dataGridView_chitiethdban.Rows.Clear();
            chitiet.hien_ChiTiethd(dataGridView_chitiethdban, textBox_MaHD.Text.Trim());
            if (dataGridView_chitiethdban.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView_chitiethdban.Rows.Count; i++)
                {
                    dataGridView_chitiethdban.Rows[i].Cells["Column_STT"].Value = (i + 1).ToString();
                }
            }
            chitiet.CapNhatTongTien(mahd);
            
        }

        

        private void comboBox_masp_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string masp = comboBox_masp.Text.Trim();
            if (string.IsNullOrEmpty(masp))
            {
                error.SetError(comboBox_masp, "Mã sản phẩm không được để trống!");
                e.Cancel = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(masp, @"^[A-Za-z0-9]+$"))
            {
                error.SetError(comboBox_masp, "Mã sản phẩm chỉ được chứa chữ và số!");
                e.Cancel = true;
            }
            else
            {
                error.SetError(comboBox_masp, null);
            }
        }

        private void textBox_SoLuong_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string soLuong = textBox_SoLuong.Text.Trim();
            if (string.IsNullOrEmpty(soLuong))
            {
                error.SetError(textBox_SoLuong, "Số lượng không được để trống!");
                e.Cancel = true;
            }
            else if (!int.TryParse(soLuong, out int soLuongInt) || soLuongInt <= 0)
            {
                error.SetError(textBox_SoLuong, "Số lượng phải là số nguyên dương!");
                e.Cancel = true;
            }
            else
            {
                error.SetError(textBox_SoLuong, null);
            }
        }

        private void textBox_GiaBan_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string giaBan = textBox_GiaBan.Text.Trim();
            if (string.IsNullOrEmpty(giaBan))
            {
                error.SetError(textBox_GiaBan, "Giá không được để trống!");
                e.Cancel = true;
            }
            else if (!decimal.TryParse(giaBan, out decimal giaBanDecimal) || giaBanDecimal <= 0)
            {
                error.SetError(textBox_GiaBan, "Giá bán phải là số dương!");
                e.Cancel = true;
            }
            else
            {
                error.SetError(textBox_GiaBan, null);
            }
        }

        private void textBox_dvt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string dvt = comboBox_tendvt.Text.Trim();
            if (string.IsNullOrEmpty(dvt))
            {
                error.SetError(comboBox_tendvt, "Đơn vị tính không được để trống!");
                e.Cancel = true;
            }
            else if (dvt.Any(char.IsDigit))
            {
                error.SetError(comboBox_tendvt, "Đơn vị tính không được chứa số!");
                e.Cancel = true;
            }
            else
            {
                error.SetError(comboBox_tendvt, null);
            }
        }


        private void comboBox_ma_sx_SelectedIndexChanged(object sender, EventArgs e)
        {
            chitiet.layten_sp(comboBox_masp.Text.Trim(), textBox_tensp);
        }
        private void button_Them_Click(object sender, EventArgs e)
        {
            CancelEventArgs cancelEvent = new CancelEventArgs();
            comboBox_masp_Validating(sender, cancelEvent);
            textBox_SoLuong_Validating(sender, cancelEvent);
            textBox_GiaBan_Validating(sender, cancelEvent);
            textBox_dvt_Validating(sender, cancelEvent);
            
            if (!string.IsNullOrEmpty(textBox_MaHD.Text) && !string.IsNullOrEmpty(comboBox_masp.Text.Trim())
                && !string.IsNullOrEmpty(textBox_SoLuong.Text.Trim()) && !string.IsNullOrEmpty(textBox_GiaBan.Text.Trim()))
            {

                if (chitiet.kiemtratontai(textBox_MaHD.Text.Trim(),comboBox_masp.Text.Trim(),error, textBox_tensp) == false)
                {

                    if (chitiet.them_ChiTiet_hoadon(textBox_MaHD.Text.Trim(), comboBox_masp.Text.Trim(),comboBox_tendvt.Text.Trim(), int.Parse( textBox_SoLuong.Text.Trim()),int.Parse( textBox_GiaBan.Text.Trim())) == true)
                    {

                        comboBox_masp.Text = string.Empty;
                        textBox_tensp.Text = string.Empty;
                        comboBox_tendvt.Text = string.Empty;
                        textBox_SoLuong.Text = string.Empty;
                        textBox_GiaBan.Text = string.Empty;
                    }

                }
                else
                {
                    MessageBox.Show("Không thành công(Dữ liệu này đã tồn tại)");
                }
            }
            dataGridView_chitiethdban.Rows.Clear();
            chitiet.CapNhatTongTien(textBox_MaHD.Text.Trim());
            chitiet.hien_ChiTiethd(dataGridView_chitiethdban, textBox_MaHD.Text.Trim());
        }

        private void button_Xua_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox_MaHD.Text) && !string.IsNullOrEmpty(comboBox_masp.Text.Trim())
                && !string.IsNullOrEmpty(textBox_SoLuong.Text.Trim()) && !string.IsNullOrEmpty(textBox_GiaBan.Text.Trim()))
            {

                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn sửa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (chitiet.update_ChiTiet_hoadon(textBox_MaHD.Text.Trim(), comboBox_masp.Text.Trim(), comboBox_tendvt.Text.Trim(), int.Parse(textBox_SoLuong.Text.Trim()), int.Parse(textBox_GiaBan.Text.Trim())) == true)
                    {

                        MessageBox.Show("Sửa thành công");
                        comboBox_masp.Text = string.Empty;
                        textBox_tensp.Text = string.Empty;
                        comboBox_tendvt.Text = string.Empty;
                        textBox_SoLuong.Text = string.Empty;
                        textBox_GiaBan.Text = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("Không thành công");
                    }
                }
                dataGridView_chitiethdban.Rows.Clear();
                chitiet.CapNhatTongTien(textBox_MaHD.Text.Trim());
                chitiet.hien_ChiTiethd(dataGridView_chitiethdban, textBox_MaHD.Text.Trim());
            }
        }

        private void dataGridView_chitiethdban_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) // Nếu click vào header row
            {
                // Không cho phép chọn nếu click vào header row
                dataGridView_chitiethdban.ClearSelection();
            }

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell dataGridViewCell = dataGridView_chitiethdban[e.ColumnIndex, e.RowIndex];
                if (dataGridViewCell.Value != null)
                {
                    error.SetError(textBox_MaHD, null);
                    DataGridViewRow row = dataGridView_chitiethdban.Rows[e.RowIndex];
                    comboBox_masp.Text = row.Cells[1].Value.ToString();
                    textBox_tensp.Text = row.Cells[2].Value.ToString();
                    comboBox_tendvt.Text = row.Cells[3].Value.ToString();
                    textBox_SoLuong.Text = row.Cells[4].Value.ToString();
                    textBox_GiaBan.Text = row.Cells[5].Value.ToString();
                    
                   
                }
                else
                {
                    // Xử lý khi giá trị của ô là null
                }
            }
        }

        private void button_Xoa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_MaHD.Text) && !string.IsNullOrEmpty(comboBox_masp.Text.Trim())
                && !string.IsNullOrEmpty(textBox_SoLuong.Text.Trim()) && !string.IsNullOrEmpty(textBox_GiaBan.Text.Trim()))
            {

                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (chitiet.xoa_ChiTiet_PhieuNHap(textBox_MaHD.Text.Trim(), comboBox_masp.Text.Trim()) == true)
                    {

                        MessageBox.Show("Xóa thành công");
                        comboBox_masp.Text = string.Empty;
                        textBox_tensp.Text = string.Empty;
                        comboBox_tendvt.Text = string.Empty;
                        textBox_SoLuong.Text = string.Empty;
                        
                        textBox_GiaBan.Text = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("Không thành công");
                    }
                }
                dataGridView_chitiethdban.Rows.Clear();
                chitiet.CapNhatTongTien(textBox_MaHD.Text.Trim());
                chitiet.hien_ChiTiethd(dataGridView_chitiethdban, textBox_MaHD.Text.Trim());
            }
        }

        private void button_huy_Click(object sender, EventArgs e)
        {
            comboBox_masp.Text = string.Empty;
            textBox_tensp.Text = string.Empty;
            comboBox_tendvt.Text = string.Empty;
            textBox_SoLuong.Text = string.Empty;
            textBox_GiaBan.Text = string.Empty;
        }

    }
}
