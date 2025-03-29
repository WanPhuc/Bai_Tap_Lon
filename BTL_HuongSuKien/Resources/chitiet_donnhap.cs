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
    internal class chitiet_donnhap
    {
        string connectionString = ConfigurationManager.ConnectionStrings["BTL"].ConnectionString;
        public chitiet_donnhap() { }
        public bool kiemtratontai(string sohd, string masp, ErrorProvider error, TextBox tb_tensp)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(1) FROM tblChiTietDNH WHERE sMaDNH = @sMaDNH AND sMaSP = @sMaSP";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm tham số vào câu truy vấn
                        cmd.Parameters.AddWithValue("@sMaDNH", sohd);  // Mã đơn đặt hàng
                        cmd.Parameters.AddWithValue("@sMaSP", masp);   // Mã sản phẩm

                        // Mở kết nối và thực thi câu lệnh
                        conn.Open();

                        // Kiểm tra số lượng bản ghi có thỏa mãn điều kiện
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        // Kiểm tra kết quả
                        if (count > 0)
                        {
                            // Nếu sản phẩm đã tồn tại trong chi tiết hóa đơn
                            error.SetError(tb_tensp, "Mã sản phẩm đã tồn tại trong chi tiết đơn hàng này!");
                            return true;
                        }
                        else
                        {
                            // Nếu không tồn tại
                            error.SetError(tb_tensp, null);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Nếu có lỗi xảy ra, hiển thị thông báo lỗi
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        public bool them_ChiTiet_hoadon(string sMaDNH, string MaSP, string TenDVT, int soLuong, int giaTien)
        {
            string insert_command = "INSERT INTO tblChiTietDNH (sMaDNH, sMaSP, sTenDVT, iSoLuong, fGiaTien) " +
                                    "VALUES (@sMaDNH, @MaSP, @sTenDVT, @SoLuong, @GiaTien)";
            string update_command = "UPDATE tblSanPham SET iSoLuong = iSoLuong + @SoLuong WHERE sMaSP = @MaSP";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = insert_command;

                    // Thêm tham số vào câu lệnh SQL
                    cmd.Parameters.AddWithValue("@sMaDNH", sMaDNH);
                    cmd.Parameters.AddWithValue("@MaSP", MaSP);
                    cmd.Parameters.AddWithValue("@sTenDVT", TenDVT);
                    cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmd.Parameters.AddWithValue("@GiaTien", giaTien);

                    int i = cmd.ExecuteNonQuery();

                    if (i > 0)
                    {
                        // Cập nhật số lượng sản phẩm
                        cmd.CommandText = update_command;
                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                    return i > 0;
                }
            }
        }

        public bool update_ChiTiet_hoadon(string sMaDNH, string MaSP, string MaDVT, int soLuong, int giaTien)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand command = conn.CreateCommand())
                {
                    conn.Open();

                    // Lấy số lượng cũ từ tblChiTietDNH
                    int oldSoLuong = 0;
                    command.CommandText = "SELECT iSoLuong FROM tblChiTietDNH WHERE sMaDNH = @sMaDNH AND sMaSP = @MaSP";
                    command.Parameters.AddWithValue("@sMaDNH", sMaDNH);
                    command.Parameters.AddWithValue("@MaSP", MaSP);
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        oldSoLuong = Convert.ToInt32(result);
                    }

                    // Tính toán chênh lệch số lượng
                    int deltaSoLuong = soLuong - oldSoLuong;

                    // Cập nhật chi tiết hóa đơn
                    command.CommandText = "UPDATE tblChiTietDNH " +
                                          "SET iSoLuong = @SoLuong, fGiaTien = @GiaTien, sTenDVT = @sTenDVT " +
                                          "WHERE sMaDNH = @sMaDNH AND sMaSP = @MaSP";
                    command.Parameters.AddWithValue("@sTenDVT", MaDVT);
                    command.Parameters.AddWithValue("@SoLuong", soLuong);
                    command.Parameters.AddWithValue("@GiaTien", giaTien);

                    int i = command.ExecuteNonQuery();

                    // Nếu cập nhật thành công, điều chỉnh số lượng sản phẩm trong tblSanPham
                    if (i > 0)
                    {
                        command.CommandText = "UPDATE tblSanPham SET iSoLuong = iSoLuong + @DeltaSoLuong WHERE sMaSP = @MaSP";
                        command.Parameters.AddWithValue("@DeltaSoLuong", deltaSoLuong);
                        command.ExecuteNonQuery();
                    }

                    conn.Close();
                    return i > 0;
                }
            }
        }

        public bool xoa_ChiTiet_PhieuNHap(string sMaDNH, string MaSP)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    connection.Open();

                    // Lấy số lượng cũ từ tblChiTietDNH
                    int soLuong = 0;
                    cmd.CommandText = "SELECT iSoLuong FROM tblChiTietDNH WHERE sMaDNH = @sMaDNH AND sMaSP = @MaSP";
                    cmd.Parameters.AddWithValue("@sMaDNH", sMaDNH);
                    cmd.Parameters.AddWithValue("@MaSP", MaSP);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        soLuong = Convert.ToInt32(result);
                    }

                    // Xóa chi tiết hóa đơn
                    cmd.CommandText = "DELETE FROM tblChiTietDNH WHERE sMaDNH = @sMaDNH AND sMaSP = @MaSP";
                    int i = cmd.ExecuteNonQuery();

                    // Nếu xóa thành công, cập nhật số lượng sản phẩm trong tblSanPham
                    if (i > 0)
                    {
                        cmd.CommandText = "UPDATE tblSanPham SET iSoLuong = iSoLuong - @SoLuong WHERE sMaSP = @MaSP";
                        cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                    return i > 0;
                }
            }
        }


        public void uploadComboBox(ComboBox comboBox_ma_sp)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT sMaSP FROM tblSanPham", conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            comboBox_ma_sp.Items.Clear();  // Xóa các mục cũ trong comboBox
                            while (reader.Read())
                            {
                                comboBox_ma_sp.Items.Add(reader["sMaSP"].ToString());
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString().Trim();
            }
        }
        public void layten_sp(string masp, TextBox textBox)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT sTenSP FROM tblSanPham WHERE sMaSP = @masp and sMaSP like '%SP%'";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@masp", masp);

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox.Text = reader["sTenSP"].ToString();
                        }
                    }
                }
            }
        }
        public void hien_ChiTiethd(DataGridView dataGridView, string sMaDNH)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"
                    SELECT 
                        cthddh.sMaDNH AS MaDNH, 
                        cthddh.sMaSP AS MaSP, 
                        sp.sTenSP AS TenSP, 
                        cthddh.sTenDVT AS TenDVT, 
                        cthddh.iSoLuong AS SoLuong, 
                        cthddh.fGiaTien AS GiaTien,
                        cthddh.fThanhTien as ThanhTien
                    FROM tblChiTietDNH cthddh
                    JOIN tblSanPham sp ON cthddh.sMaSP = sp.sMaSP
                    JOIN tblDonNhapHang ddh ON cthddh.sMaDNH = ddh.sMaDNH
                    WHERE cthddh.sMaDNH = @sMaDNH";

                        cmd.Parameters.AddWithValue("@sMaDNH", sMaDNH);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dataGridView.Rows.Clear(); // Xóa dữ liệu cũ trước khi thêm mới

                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                DataGridViewRow row = new DataGridViewRow();
                                row.CreateCells(dataGridView);
                                row.Cells[1].Value = dataRow["MaSP"].ToString();
                                row.Cells[2].Value = dataRow["TenSP"].ToString();
                                row.Cells[3].Value = dataRow["TenDVT"].ToString();
                                row.Cells[4].Value = dataRow["SoLuong"].ToString();
                                row.Cells[5].Value = dataRow["GiaTien"].ToString();
                                row.Cells[6].Value = dataRow["ThanhTien"].ToString();
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

        public void CapNhatTongTien(string sMaDNH)
        {
            string query = @"
        UPDATE tblDonNhapHang
        SET fTongTienHang = (
            SELECT COALESCE(SUM(iSoLuong * fGiaTien), 0) 
            FROM tblChiTietDNH 
            WHERE sMaDNH = @sMaDNH
        )
        WHERE sMaDNH = @sMaDNH";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@sMaDNH", sMaDNH);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
