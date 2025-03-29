
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_HSK_ver_1.Resources
{
    internal class NhanVien
    {
        string connectionString = "Data Source=VANPHUC;Initial Catalog=BTL_HSK;Integrated Security=True";
        public NhanVien() { }
        public bool kiemtra_maNV(string manv, ErrorProvider error, TextBox textBox_maNV)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Câu truy vấn SQL trực tiếp thay vì sử dụng stored procedure
                    string query = "SELECT COUNT(1) FROM tblNhanVien WHERE sMaNV = @maNV";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maNV", manv); // Thêm tham số vào câu truy vấn

                        // Mở kết nối và thực thi câu lệnh
                        conn.Open();

                        // Kiểm tra xem có bản ghi nào với mã nhân viên đó hay không
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        // Kiểm tra kết quả
                        if (count > 0)
                        {
                            // Nếu mã nhân viên tồn tại
                            error.SetError(textBox_maNV, "Mã nhân viên đã tồn tại!");
                            return true;
                        }
                        else
                        {
                            // Nếu mã nhân viên không tồn tại
                            error.SetError(textBox_maNV, null);
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

        public void tim_kiem_NhanVien_duavaoMa(string maNV, DataGridView dataGridView)
        {
            try
            {
                dataGridView.Rows.Clear();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from tblNhanVien where sMaNV=@maNV",conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@maNV", maNV);

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
                                row.Cells[7].Value = dataRow[7].ToString();
                                row.Cells[8].Value = dataRow[8].ToString();


                                dataGridView.Rows.Add(row);
                                // Cách khác 
                                //  DataGridViewRow row = new DataGridViewRow();
                                //  // Đổ dữ liệu từ bảng ảo vào datagridView
                                //  row.CreateCells(dataGridView);
                                //  row.SetValues(dataRow.ItemArray);
                                //  dataGridView.Rows.Add(row);

                            }



                        }
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void tim_kiem_NhanVien_duavaoTen(string tenNV, DataGridView dataGridView)
        {
            try
            {
                dataGridView.Rows.Clear();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from tblNhanVien WHERE sHoTen LIKE '%' + @tenNV + '%';", conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@tenNV", tenNV);

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
                                row.Cells[7].Value = dataRow[7].ToString();
                                row.Cells[8].Value = dataRow[8].ToString();


                                dataGridView.Rows.Add(row);
                            }
                        }
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void tim_kiem_NhanVien_duavaoDiaChi(string diachi, DataGridView dataGridView)
        {
            try
            {
                dataGridView.Rows.Clear();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from tblNhanVien WHERE sDiaChi LIKE '%' + @diaChi + '%';", conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@diachi", diachi);

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
                                row.Cells[7].Value = dataRow[7].ToString();
                                row.Cells[8].Value = dataRow[8].ToString();


                                dataGridView.Rows.Add(row);
                            }
                        }
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void tim_kiem_NhanVien_duavaoGT(string gioitinh, DataGridView dataGridView)
        {
            try
            {
                dataGridView.Rows.Clear();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from tblNhanVien WHERE sGioitinh LIKE '%' + @gioiTinh + '%';", conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@gioitinh", gioitinh);

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
                                row.Cells[7].Value = dataRow[7].ToString();
                                row.Cells[8].Value = dataRow[8].ToString();


                                dataGridView.Rows.Add(row);

                            }
                        }
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void update_NhanVien(string sMaNhanVien,
    string sTenNhanVien, string gioitinh, string sDiaChi, string sdt, string dNgaysinh
    , string dNgayVaoLam, double fLuongCoBan, double fPhuCap)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand command =new SqlCommand(@"
                        UPDATE tblNhanVien
                        SET 
                            sHoTen = @tenNV,
                            sGioitinh = @gioitinh,
                            sDiachi = @diachi,
                            sSDT = @sdt,
                            dNgaysinh = @ngaysinh,
                            dNgayvaolam = @ngayvaolam,
                            fLuongcoban = @luong,
                            fPhucap = @phucap
                        WHERE sMaNV = @maNV;", conn))
                {
                    conn.Open();

                    command.Parameters.AddWithValue("@maNV", sMaNhanVien);
                    command.Parameters.AddWithValue("@tenNV", sTenNhanVien);
                    command.Parameters.AddWithValue("@gioitinh", gioitinh);
                    command.Parameters.AddWithValue("@diachi", sDiaChi);
                    command.Parameters.AddWithValue("@sdt", sdt);
                    command.Parameters.AddWithValue("@ngaysinh", dNgaysinh);
                    command.Parameters.AddWithValue("@ngayvaolam", dNgayVaoLam);
                    command.Parameters.AddWithValue("@luong", fLuongCoBan);
                    command.Parameters.AddWithValue("@phucap", fPhuCap);

                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void xoa_Nhanvien(string sMaNhanVien,
            string sTenNhanVien, string gioitinh, string sDiaChi, string sdt, string dNgaysinh
            , string dNgayVaoLam, double fLuongCoBan, double fPhuCap)
        {
            try
            {
                string delete_nv = "DELETE FROM tblNhanVien WHERE sMaNV = @maNV";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(delete_nv, connection))
                    {
                        cmd.Parameters.AddWithValue("@maNV", sMaNhanVien);

                        connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Nhân viên đã được xóa.");
                        }
                        else
                        {
                            Console.WriteLine("Không tìm thấy nhân viên với mã nhân viên này.");
                        }

                        // Đóng kết nối
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // Nếu có lỗi xảy ra, hiển thị thông báo lỗi
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }

        public bool ThemNhanVien(string sMaNhanVien,
            string sTenNhanVien, string gioitinh, string sDiaChi, string sdt, string dNgaysinh
            , string dNgayVaoLam, double fLuongCoBan, double fPhuCap)
        {
            try
            {
                string insert_command = "INSERT INTO tblNhanVien " +
                                  "VALUES ('" + sMaNhanVien + "', N'" + sTenNhanVien + "', N'" + gioitinh + "', N'" + sDiaChi + "', '" + sdt +
                                  "', '" + dNgaysinh + "','" + dNgayVaoLam + "','" + fLuongCoBan + "','" + fPhuCap + "')";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = insert_command;

                        connection.Open();
                        int i = cmd.ExecuteNonQuery();
                        connection.Close();

                        return i > 0;
                    }
                }
            }
            catch
            {
                return false;

            }



        }
        public void hien_NhanVien(DataGridView dataGridView)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = conn.CreateCommand())
                    {

                        cmd.CommandText = "select * from tblNhanVien";
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
                                row.Cells[5].Value = ((DateTime)dataRow[5]).ToString("dd/MM/yyyy");
                                row.Cells[6].Value = ((DateTime)dataRow[6]).ToString("dd/MM/yyyy");
                                row.Cells[7].Value = dataRow[7].ToString();
                                row.Cells[8].Value = dataRow[8].ToString();


                                dataGridView.Rows.Add(row);
                                // Cách khác 
                                //  DataGridViewRow row = new DataGridViewRow();
                                //  // Đổ dữ liệu từ bảng ảo vào datagridView
                                //  row.CreateCells(dataGridView);
                                //  row.SetValues(dataRow.ItemArray);
                                //  dataGridView.Rows.Add(row);

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
    }
}
