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
using BTL_HSK_ver_1.crystal;
using BTL_HSK_ver_1.Resources;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BTL_HSK_ver_1
{
    public partial class frmTrangChu : Form
    {
        public string tenDangNhap;
        private bool isAdmin;
        DuLieuChung dlc = new DuLieuChung();

        public frmTrangChu(string tenDangNhap, bool isAdmin)
        {
            InitializeComponent();
            this.tenDangNhap = tenDangNhap;
            this.isAdmin = isAdmin;
            PhanQuyen();
            textBox_tendn.Text = "Xin chào : " + this.tenDangNhap;

        }

        private void PhanQuyen()
        {
            if (isAdmin)
            {
                // Admin có quyền truy cập tất cả
                quảnLýSảnPhẩmToolStripMenuItem.Enabled = true;
                quảnLýNhânViênToolStripMenuItem.Enabled = true;
                quảnLýNhàCungCấpToolStripMenuItem.Enabled = true;
                quảnLýKháchHàngToolStripMenuItem.Enabled = true;
                nhậpHàngToolStripMenuItem.Enabled = true;
                mnuHoaDon.Enabled = true;
            }
            else
            {
                // Nhân viên chỉ có quyền truy cập một số chức năng
                quảnLýSảnPhẩmToolStripMenuItem.Enabled = true;
                mnuHoaDon.Enabled = true;
                quảnLýKháchHàngToolStripMenuItem.Enabled = true;
                nhậpHàngToolStripMenuItem.Enabled = true;

                // Vô hiệu hóa các chức năng quản lý nhân viên và nhập hàng
                quảnLýNhânViênToolStripMenuItem.Enabled = false;
                quảnLýNhàCungCấpToolStripMenuItem.Enabled = false;
            }
        }
        private void QuanLy_Click(object sender, EventArgs e)
        {

        }

        private void nhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhapHang form = new NhapHang(this.tenDangNhap);
            this.Hide();
            form.ShowDialog();
            form = null;
            this.Show();
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            textBox_tendn.SelectionStart = textBox_tendn.Text.Length; // Đặt con trỏ chuột ở cuối
            textBox_tendn.SelectionLength = 0; // Không bôi đen
            textBox_tendn.Enabled = false; // Vô hiệu hóa để không chỉnh sửa
            textBox_tendn.TabStop = false;
        }



        private void quảnLýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDanhSachSanPham form = new frmDanhSachSanPham(tenDangNhap);
            this.Hide();
            form.ShowDialog();
            form = null;
            this.Show();
        }

        

        

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDanhSachNhanVien form = new frmDanhSachNhanVien(this.tenDangNhap);
            this.Hide();
            form.ShowDialog();
            form = null;
            this.Show();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KhachHang form = new KhachHang();
            this.Hide();
            form.ShowDialog();
            form = null;
            this.Show();
        }

        private void mnuHoaDon_Click(object sender, EventArgs e)
        {
            HoaDon form = new HoaDon(tenDangNhap);
            this.Hide();
            form.ShowDialog();
            form = null;
            this.Show();
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            // Đóng form hiện tại
            this.Hide();
            // Hiển thị lại form đăng nhập
            DangNhap frmDangNhap = new DangNhap();
            frmDangNhap.Show();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            // Hỏi xác nhận trước khi thoát
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Thoát hoàn toàn chương trình
                Application.Exit();
            }
        }

        private void thốngKêNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReportDocument report = new ReportDocument();
            report.Load(@"crystal\DSNhanVien.rpt");
            BaoCao crDS = new BaoCao(report, this.tenDangNhap);
            crDS.ShowDialog();
            crDS = null;
            this.Show();
        }

        private void quảnLýNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nhacungcap form = new Nhacungcap();
            this.Hide();
            form.ShowDialog();
            form = null;
            this.Show();
        }

        private void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
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

                string ngayDat = DateTime.Now.ToString("yyyy-MM-dd");
                

                // Tạo câu truy vấn động
                string query = @"SELECT ddh.*, ctdh.*
                        FROM tblDonDatHang ddh
                        JOIN tblChiTietDDH ctdh ON ddh.sMaDDH = ctdh.sMaDDH
                        WHERE 1=1 
                        AND CONVERT(VARCHAR(10), ddh.dNgayDatHang, 120) = @NgayDat";

                List<SqlParameter> parameters = new List<SqlParameter>();

               
                
                    parameters.Add(new SqlParameter("@NgayDat", ngayDat));
                

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

        private void hóaĐơnNhậpToolStripMenuItem1_Click(object sender, EventArgs e)
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

                string ngayDat = DateTime.Now.ToString("yyyy-MM-dd");


                // Tạo câu truy vấn động
                string query = @"SELECT dnh.*, ctdnh.*
                        FROM tblDonNhapHang dnh
                        JOIN tblChiTietDNH ctdnh ON dnh.sMaDNH = ctdnh.sMaDNH
                        WHERE 1=1 
                        AND CONVERT(VARCHAR(10), dnh.dNgayNhapHang, 120) = @NgayDat";

                List<SqlParameter> parameters = new List<SqlParameter>();



                parameters.Add(new SqlParameter("@NgayDat", ngayDat));


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

        private void thốngKêCácLoạiHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReportDocument report = new ReportDocument();
            report.Load(@"crystal\DSSanPham.rpt");
            BaoCao crDS = new BaoCao(report, this.tenDangNhap);
            crDS.ShowDialog();
            crDS = null;
            this.Show();
        }

        
    }

}
