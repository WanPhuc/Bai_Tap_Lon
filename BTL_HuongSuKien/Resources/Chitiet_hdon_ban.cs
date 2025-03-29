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
    internal class Chitiet_hdon_ban
    {
        string connectionString = ConfigurationManager.ConnectionStrings["BTL"].ConnectionString;
        public Chitiet_hdon_ban() { }
        public bool kiemtratontai(string sohd, string masp, ErrorProvider error,TextBox tb_tensp)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Câu truy vấn SQL kiểm tra xem mã đơn đặt hàng (sMaDDH) và mã sản phẩm (sMaSP) đã tồn tại trong bảng tblChiTietDDH
                    string query = "SELECT COUNT(1) FROM tblChiTietDDH WHERE sMaDDH = @sMaDDH AND sMaSP = @sMaSP";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm tham số vào câu truy vấn
                        cmd.Parameters.AddWithValue("@sMaDDH", sohd);  // Mã đơn đặt hàng
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


        public bool them_ChiTiet_hoadon(string MaDDH, string MaSP, string TenDVT, int soLuong, float giaTien)
        {
            // Kiểm tra giá tiền trước khi thêm
            if (giaTien < 0)
            {
                MessageBox.Show("Giá tiền không được nhỏ hơn 0");
                return false;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction()) // Bắt đầu transaction
                {
                    try
                    {
                        // Thêm chi tiết hóa đơn
                        string insert_command = "INSERT INTO tblChiTietDDH (sMaDDH, sMaSP, sTenDVT, iSoLuong, fGiaTien) " +
                                                "VALUES (@MaDDH, @MaSP, @sTenDVT, @SoLuong, @GiaTien)";

                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.Transaction = transaction;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = insert_command;

                            // Thêm tham số vào câu lệnh SQL
                            cmd.Parameters.AddWithValue("@MaDDH", MaDDH);
                            cmd.Parameters.AddWithValue("@MaSP", MaSP);
                            cmd.Parameters.AddWithValue("@sTenDVT", TenDVT);
                            cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                            cmd.Parameters.AddWithValue("@GiaTien", giaTien);

                            int i = cmd.ExecuteNonQuery();

                            if (i <= 0)
                            {
                                transaction.Rollback();
                                MessageBox.Show("Thêm chi tiết hóa đơn thất bại!");
                                return false;
                            }
                        }

                        // Giảm số lượng tồn kho trong bảng tblSanPham
                        string update_command = "UPDATE tblSanPham SET iSoLuong = iSoLuong - @SoLuong WHERE sMaSP = @MaSP";

                        using (SqlCommand updateCmd = connection.CreateCommand())
                        {
                            updateCmd.Transaction = transaction;
                            updateCmd.CommandType = CommandType.Text;
                            updateCmd.CommandText = update_command;

                            updateCmd.Parameters.AddWithValue("@SoLuong", soLuong);
                            updateCmd.Parameters.AddWithValue("@MaSP", MaSP);

                            int j = updateCmd.ExecuteNonQuery();

                            if (j <= 0)
                            {
                                transaction.Rollback();
                                MessageBox.Show("Giảm số lượng tồn kho thất bại!");
                                return false;
                            }
                        }

                        transaction.Commit();
                        MessageBox.Show("Thêm chi tiết hóa đơn và cập nhật tồn kho thành công!");
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool update_ChiTiet_hoadon(string MaDDH, string MaSP, string MaDVT, int soLuong, int giaTien)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction()) // Bắt đầu transaction
                {
                    try
                    {
                        // Lấy số lượng cũ từ hóa đơn
                        int oldSoLuong = 0;
                        string select_command = "SELECT iSoLuong FROM tblChiTietDDH WHERE sMaDDH = @MaDDH AND sMaSP = @MaSP";
                        using (SqlCommand selectCmd = new SqlCommand(select_command, conn, transaction))
                        {
                            selectCmd.Parameters.AddWithValue("@MaDDH", MaDDH);
                            selectCmd.Parameters.AddWithValue("@MaSP", MaSP);
                            object result = selectCmd.ExecuteScalar();
                            if (result != null)
                            {
                                oldSoLuong = Convert.ToInt32(result);
                            }
                        }

                        // Cập nhật chi tiết hóa đơn
                        string update_command = "UPDATE tblChiTietDDH " +
                                                "SET iSoLuong = @SoLuong, fGiaTien = @GiaTien, sTenDVT = @sTenDVT " +
                                                "WHERE sMaDDH = @MaDDH AND sMaSP = @MaSP";

                        using (SqlCommand command = new SqlCommand(update_command, conn, transaction))
                        {
                            command.Parameters.AddWithValue("@MaDDH", MaDDH);
                            command.Parameters.AddWithValue("@MaSP", MaSP);
                            command.Parameters.AddWithValue("@sTenDVT", MaDVT);
                            command.Parameters.AddWithValue("@SoLuong", soLuong);
                            command.Parameters.AddWithValue("@GiaTien", giaTien);

                            int i = command.ExecuteNonQuery();
                            if (i <= 0)
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }

                        // Cập nhật lại số lượng tồn kho
                        int chenhLech = soLuong - oldSoLuong;
                        string update_sanpham = "UPDATE tblSanPham SET iSoLuong = iSoLuong - @ChenhLech WHERE sMaSP = @MaSP";

                        using (SqlCommand updateCmd = new SqlCommand(update_sanpham, conn, transaction))
                        {
                            updateCmd.Parameters.AddWithValue("@ChenhLech", chenhLech);
                            updateCmd.Parameters.AddWithValue("@MaSP", MaSP);
                            updateCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool xoa_ChiTiet_PhieuNHap(string MaDDH, string MaSP)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction()) // Bắt đầu transaction
                {
                    try
                    {
                        // Lấy số lượng cũ từ hóa đơn
                        int oldSoLuong = 0;
                        string select_command = "SELECT iSoLuong FROM tblChiTietDDH WHERE sMaDDH = @MaDDH AND sMaSP = @MaSP";
                        using (SqlCommand selectCmd = new SqlCommand(select_command, connection, transaction))
                        {
                            selectCmd.Parameters.AddWithValue("@MaDDH", MaDDH);
                            selectCmd.Parameters.AddWithValue("@MaSP", MaSP);
                            object result = selectCmd.ExecuteScalar();
                            if (result != null)
                            {
                                oldSoLuong = Convert.ToInt32(result);
                            }
                        }

                        // Xóa chi tiết hóa đơn
                        string delete_command = "DELETE FROM tblChiTietDDH WHERE sMaDDH = @MaDDH AND sMaSP = @MaSP";
                        using (SqlCommand cmd = new SqlCommand(delete_command, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@MaDDH", MaDDH);
                            cmd.Parameters.AddWithValue("@MaSP", MaSP);

                            int i = cmd.ExecuteNonQuery();
                            if (i <= 0)
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }

                        // Cập nhật lại số lượng tồn kho (tăng lại số lượng)
                        string update_sanpham = "UPDATE tblSanPham SET iSoLuong = iSoLuong + @SoLuong WHERE sMaSP = @MaSP";
                        using (SqlCommand updateCmd = new SqlCommand(update_sanpham, connection, transaction))
                        {
                            updateCmd.Parameters.AddWithValue("@SoLuong", oldSoLuong);
                            updateCmd.Parameters.AddWithValue("@MaSP", MaSP);
                            updateCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return false;
                    }
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
        public void hien_ChiTiethd(DataGridView dataGridView, string MaDDH)
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
                        cthddh.sMaDDH AS MaDDH, 
                        cthddh.sMaSP AS MaSP, 
                        sp.sTenSP AS TenSP, 
                        cthddh.sTenDVT AS TenDVT, 
                        cthddh.iSoLuong AS SoLuong, 
                        cthddh.fGiaTien AS GiaTien,
                        cthddh.fThanhTien as ThanhTien
                    FROM tblChiTietDDH cthddh
                    JOIN tblSanPham sp ON cthddh.sMaSP = sp.sMaSP
                    JOIN tblDonDatHang ddh ON cthddh.sMaDDH = ddh.sMaDDH
                    WHERE cthddh.sMaDDH = @MaDDH";

                        cmd.Parameters.AddWithValue("@MaDDH", MaDDH);

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

        public void CapNhatTongTien(string maDDH)
        {
            string query = @"
        UPDATE tblDonDatHang
        SET fTongTienHang = (
            SELECT COALESCE(SUM(iSoLuong * fGiaTien), 0) 
            FROM tblChiTietDDH 
            WHERE sMaDDH = @MaDDH
        )
        WHERE sMaDDH = @MaDDH";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDDH", maDDH);
                    cmd.ExecuteNonQuery();
                }
            }
        }



    }
}
