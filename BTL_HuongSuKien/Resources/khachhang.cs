using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_HSK_ver_1.Resources
{
    internal class khachhang
    {
        string connectionString = ConfigurationManager.ConnectionStrings["BTL"].ConnectionString;
        public khachhang() { }
        public bool kiemtra_maKH(string sdtKH, ErrorProvider error, TextBox textBox_sdtKH)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Câu truy vấn SQL trực tiếp thay vì sử dụng stored procedure
                    string query = "SELECT COUNT(1) FROM tblKhachHang WHERE sSoDTKH = @sdtKH";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@sdtKH", sdtKH); // Thêm tham số vào câu truy vấn

                        // Mở kết nối và thực thi câu lệnh
                        conn.Open();

                        // Kiểm tra xem có bản ghi nào với mã nhân viên đó hay không
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        // Kiểm tra kết quả
                        if (count > 0)
                        {
                            // Nếu mã nhân viên tồn tại
                            error.SetError(textBox_sdtKH, "SDT Khách hàng đã tồn tại!");
                            return true;
                        }
                        else
                        {
                            // Nếu mã nhân viên không tồn tại
                            error.SetError(textBox_sdtKH, null);
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
        public bool ThemKhachHang(string sSDTKH, string sTenKH, string gioitinh, string sDiaChi,float tth,string ngaybatdau)
        {
            try
            {
                

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        connection.Open();
                        cmd.Connection = connection;
                        cmd.CommandText = "INSERT INTO tblKhachHang (sSoDTKH, sHoTen, sGioiTinh, sDiaChi, fTongTienKH,ngaybatdau) " +
                                        "VALUES (@sSDTKH, @sTenKH, @gioitinh, @sDiaChi, default,@ngaybatdau,)";
                        cmd.CommandType = CommandType.Text;

                        // Thêm các tham số để tránh lỗi SQL Injection
                        cmd.Parameters.AddWithValue("@sSDTKH", sSDTKH);
                        cmd.Parameters.AddWithValue("@sTenKH", sTenKH);
                        cmd.Parameters.AddWithValue("@gioitinh", gioitinh);
                        cmd.Parameters.AddWithValue("@sDiaChi", sDiaChi);
                        cmd.Parameters.AddWithValue("@ngaybatdau", ngaybatdau);
                        

                        
                        cmd.ExecuteNonQuery();
                        connection.Close();

                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return false;
        }

        public void hien_KhachHang(DataGridView dataGridView)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = conn.CreateCommand())
                    {

                        cmd.CommandText = "select * from tblKhachHang ";
                        cmd.CommandType = System.Data.CommandType.Text;
                        conn.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            // Tạo một kho dữ liệu ảo
                            DataTable dataTable = new DataTable();
                            // Đổ dữ liệu từ csdl vào kho
                            adapter.Fill(dataTable);
                            // Ngắt kết nối
                            conn.Close();


                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                DataGridViewRow row = new DataGridViewRow();
                                row.CreateCells(dataGridView);

                                row.Cells[0].Value = dataRow[0].ToString();
                                row.Cells[1].Value = dataRow[1].ToString();
                                row.Cells[2].Value = dataRow[2].ToString();
                                row.Cells[3].Value = dataRow[3].ToString();
                                row.Cells[4].Value = dataRow[4].ToString();
                                row.Cells[5].Value = dataRow[5].ToString();
                                row.Cells[6].Value = dataRow[6].ToString();

                                dataGridView.Rows.Add(row);
                              
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
        public void xoa_KhachHang(string ssdtKhachHang)
        {
            // Câu lệnh SQL để xóa khách hàng
            string delete_kh = "DELETE FROM tblKhachHang WHERE sSoDTKH = @sdtKH";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(delete_kh, connection))
                {
                    // Mở kết nối
                    connection.Open();

                    // Thêm tham số cho câu lệnh SQL
                    cmd.Parameters.AddWithValue("@sdtKH", ssdtKhachHang);

                    // Thực thi câu lệnh SQL
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Kiểm tra số dòng bị ảnh hưởng
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Khách hàng đã được xóa thành công.");
                    }
                    else
                    {
                        Console.WriteLine("Không tìm thấy khách hàng với mã " + ssdtKhachHang);
                    }

                    // Đóng kết nối
                    connection.Close();
                }
            }
        }

        public void UpdateKhachHang(string ssdtKH, string sTenKH,string gioitinh, string sDiaChi,string ngaybatdau)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand command = conn.CreateCommand())
                {
                    conn.Open();
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;

                    // Sử dụng câu lệnh SQL trực tiếp
                    command.CommandText = "UPDATE tblKhachHang SET sHoTen = @tenKH, sGioiTinh=@gioitinh,sDiaChi = @diachi,ngaybatdau=@ngaybatdau WHERE sSoDTKH = @sdtKH";

                    // Thêm các tham số
                    command.Parameters.AddWithValue("@sdtKH", ssdtKH);
                    command.Parameters.AddWithValue("@tenKH", sTenKH);
                    command.Parameters.AddWithValue("@gioitinh", gioitinh);
                    command.Parameters.AddWithValue("@diachi", sDiaChi);
                    command.Parameters.AddWithValue("@ngaybatdau", ngaybatdau);
                    

                    // Thực thi câu lệnh
                    command.ExecuteNonQuery();
                }
            }
        }

        public void tim_kiem_KhachHang_duavaoSDT(string sdt, DataGridView dataGridView)
        {
            try
            {
                dataGridView.Rows.Clear();
                string query = "SELECT sSoDTKH, sHoTen,sGioiTinh, sDiaChi, fTongTienKH FROM tblKhachHang WHERE sSoDTKH LIKE @sdt";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@sdt", sdt);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                DataGridViewRow row = new DataGridViewRow();
                                row.CreateCells(dataGridView);

                                row.Cells[0].Value = dataRow[0].ToString();
                                row.Cells[1].Value = dataRow[1].ToString();
                                row.Cells[2].Value = dataRow[2].ToString();
                                row.Cells[3].Value = dataRow[3].ToString();
                                row.Cells[4].Value = dataRow[4].ToString();

                                dataGridView.Rows.Add(row);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void tim_kiem_KhachHang_duavaoTen(string ten, DataGridView dataGridView)
        {
            try
            {
                dataGridView.Rows.Clear();
                string query = "SELECT sSoDTKH, sHoTen,sGioiTinh, sDiaChi, fTongTienKH FROM tblKhachHang WHERE sHoTen LIKE @ten";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ten", "%" + ten + "%");

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                DataGridViewRow row = new DataGridViewRow();
                                row.CreateCells(dataGridView);

                                row.Cells[0].Value = dataRow[0].ToString();
                                row.Cells[1].Value = dataRow[1].ToString();
                                row.Cells[2].Value = dataRow[2].ToString();
                                row.Cells[3].Value = dataRow[3].ToString();
                                row.Cells[4].Value = dataRow[4].ToString();

                                dataGridView.Rows.Add(row);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public void CapNhatTongTien()
        {
            string query = @"
        UPDATE kh
        SET kh.fTongTienKH = ISNULL(tong_tien.TongTien, 0)
        FROM tblKhachHang AS kh
        LEFT JOIN (
            SELECT ddh.sSoDTKH, SUM(ddh.fTongTienHang) AS TongTien
            FROM tblDonDatHang AS ddh
            GROUP BY ddh.sSoDTKH
        ) AS tong_tien ON kh.sSoDTKH = tong_tien.sSoDTKH;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void CapNhatSoNam()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = conn.CreateCommand())
                    {
                        // Câu lệnh SQL để cập nhật số năm làm việc
                        command.CommandText = @"
                    UPDATE tblKhachHang
                    SET SoNam = YEAR(GETDATE()) - YEAR(ngaybatdau)";

                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
                
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi không xác định: {ex.Message}");
                }
            }
        }

    }

}

