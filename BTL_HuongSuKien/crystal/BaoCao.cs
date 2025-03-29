using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Windows.Forms;

namespace BTL_HSK_ver_1.crystal
{
    public partial class BaoCao : Form
    {
        private ReportDocument reportDocument;

        public BaoCao(ReportDocument rpt, string tenDangNhap)
        {
            InitializeComponent();
            this.reportDocument = rpt;

            // Thiết lập giá trị tham số
            this.reportDocument.SetParameterValue("nguoilap", tenDangNhap ?? "");

            // Gán báo cáo vào CrystalReportViewer
            crystalReportViewer1.ReportSource = this.reportDocument;
            crystalReportViewer1.Refresh();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            try
            {
                // Đảm bảo báo cáo đã được thiết lập từ form NhapHang
                if (reportDocument != null)
                {
                    crystalReportViewer1.ReportSource = reportDocument;
                    crystalReportViewer1.Refresh();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (ParameterFieldException ex)
            {
                MessageBox.Show("Lỗi tham số: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
