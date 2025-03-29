using BTL_HSK_ver_1.crystal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_HSK_ver_1.Resources
{
    class DuLieuChung
    {
        public string connectionstring = ConfigurationManager.ConnectionStrings["BTL"].ConnectionString;

        // Kiểm tra mã trùng
        public bool KiemTraMaTonTai(string tableName, string columnName, string valueToCheck, ErrorProvider error, TextBox textBox, string errorMessage)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    string query = $"SELECT COUNT(1) FROM {tableName} WHERE {columnName} = @valueToCheck";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@valueToCheck", valueToCheck);
                        conn.Open();

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            error.SetError(textBox, errorMessage);
                            return true;
                        }
                        else
                        {
                            error.SetError(textBox, null);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                return false;
            }
        }

        // Hàm tìm kiếm chung
        public void TimKiemDuLieu(string query, Dictionary<string, object> parameters, DataGridView dataGridView)
        {
            try
            {
                dataGridView.Rows.Clear();
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }

                        conn.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                DataGridViewRow row = new DataGridViewRow();
                                row.CreateCells(dataGridView);

                                for (int i = 0; i < dataTable.Columns.Count; i++)
                                {
                                    row.Cells[i].Value = dataRow[i].ToString();
                                    
                                }

                                dataGridView.Rows.Add(row);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        public void TimKiem_DNH_DDH(string query, Dictionary<string, object> parameters, DataGridView dataGridView)
        {
            try
            {
                dataGridView.Rows.Clear();
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }

                        conn.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                DataGridViewRow row = new DataGridViewRow();
                                row.CreateCells(dataGridView);

                                for (int i = 0; i < dataTable.Columns.Count; i++)
                                {
                                    row.Cells[i].Value = dataRow[i].ToString();
                                }

                                // Xử lý cột ngày tháng (dNgayNhapHang hoặc dNgayDatHang)
                                if (dataTable.Columns.Contains("dNgayNhapHang"))
                                {
                                    row.Cells[3].Value = Convert.ToDateTime(dataRow["dNgayNhapHang"]).ToString("yyyy/MM/dd");
                                }
                                else if (dataTable.Columns.Contains("dNgayDatHang"))
                                {
                                    row.Cells[3].Value = Convert.ToDateTime(dataRow["dNgayDatHang"]).ToString("yyyy/MM/dd");
                                }

                                // Xử lý cột tổng tiền
                                if (dataTable.Columns.Contains("fTongTienHang"))
                                {
                                    row.Cells[4].Value = Convert.ToDouble(dataRow["fTongTienHang"]).ToString("N0") + " VND";
                                }

                                // Thêm nút Chi Tiết
                                DataGridViewButtonCell buttonCell = new DataGridViewButtonCell();
                                buttonCell.Value = "Chi Tiết";
                                row.Cells[5] = buttonCell;

                                dataGridView.Rows.Add(row);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        public DataTable GetData(string query, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);
            }
            return dt;
        }
        public void InHoaDon(DataTable dt, CrystalDecisions.CrystalReports.Engine.ReportClass report, string tenDangNhap)
        {
            try
            {
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Gán dữ liệu cho báo cáo
                report.SetDataSource(dt);

                // Hiển thị báo cáo trong form báo cáo
                using (var form = new BaoCao(report, tenDangNhap))
                {
                    form.WindowState = FormWindowState.Maximized;
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở báo cáo: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}

