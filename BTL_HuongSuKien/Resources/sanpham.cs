using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Configuration;


namespace BTL_HSK_ver_1.Resources
{
    internal class sanpham
    {
        DuLieuChung dlc = new DuLieuChung();
        public sanpham() { }

        

        public bool update_sanpham(string sMasp,
    string sTensp, string TenLoaiHang, string sMaNCC,string tendvt, int iSoLuong, float fGiatien)
        {
            using (SqlConnection conn = new SqlConnection(dlc.connectionstring))
            {
                using (SqlCommand command = conn.CreateCommand())
                {
                    conn.Open();
                    command.Connection = conn;
                    command.CommandText = @"
                UPDATE tblSanPham
                SET 
                    sTenSP = @Tensp,
                    sMaNCC = @sMaNCC,
                    sTenDVT = @tendvt,
                    sTenLoaiHang = @TenLoaiHang,
                    iSoLuong = @iSoLuong,
                    fGiaTien = @fGiatien
                WHERE 
                    sMaSP = @Masp";

                    command.Parameters.AddWithValue("@Tensp", sTensp);
                    command.Parameters.AddWithValue("@Masp", sMasp);
                    command.Parameters.AddWithValue("@TenLoaiHang", TenLoaiHang);
                    command.Parameters.AddWithValue("@sMaNCC", sMaNCC);
                    command.Parameters.AddWithValue("@tendvt", tendvt);
                    command.Parameters.AddWithValue("@iSoLuong", iSoLuong);
                    command.Parameters.AddWithValue("@fGiatien", fGiatien);

                    int i = command.ExecuteNonQuery();
                    conn.Close();
                    return i > 0;
                }
            }
        }


        public bool xoa_SP(string sMasp)
        {
            using (SqlConnection connection = new SqlConnection(dlc.connectionstring))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM tblSanPham WHERE sMaSP = @sMaSP", connection)) 
                {
                    
                    cmd.Parameters.AddWithValue("@sMaSP", sMasp);
                    int i = cmd.ExecuteNonQuery();
                    
                    return i > 0;
                }
                connection.Close();
            }

        }

        public void ThemSP(string sMasp, string sTensp, string sTenlh, string sMaNCC, int iSoLuong, float fGiatien,string stendvt)
        {
            using (SqlConnection conn = new SqlConnection(dlc.connectionstring))
            {
                using (SqlCommand command = conn.CreateCommand())
                {
                    conn.Open();
                    command.Connection = conn;

                    // Sử dụng câu lệnh SQL trực tiếp
                    command.CommandText = "INSERT INTO tblSanPham (sMaSP, sTenSP, sMaNCC, sTenLoaiHang, sTenDVT, iSoLuong, fGiaTien) " +
                                          "VALUES (@sMaSP, @sTenSP, @sMaNCC, @sTenlh,@stendvt, @iSoLuong, @fGiaTien)";
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@sMaSP", sMasp);       
                    command.Parameters.AddWithValue("@sTenSP", sTensp);     
                    command.Parameters.AddWithValue("@sMaNCC", sMaNCC);     
                    command.Parameters.AddWithValue("@sTenlh", sTenlh);
                    command.Parameters.AddWithValue("@stendvt", stendvt);
                    command.Parameters.AddWithValue("@iSoLuong", iSoLuong); 
                    command.Parameters.AddWithValue("@fGiaTien", fGiatien);   
                    command.ExecuteNonQuery();

                    conn.Close();
                }
            }

        }


        public void hien_SP(DataGridView dataGridView)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dlc.connectionstring))
                {

                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT sMaSP, sTenSP, iSoLuong, fGiaTien, sTenDVT, sTenLoaiHang, sTenNCC, NCC.sMaNCC " +
                                          "FROM tblSanPham AS SP " +
                                          "JOIN tblNhaCungCap AS NCC ON NCC.sMaNCC = SP.sMaNCC " +
                                          "WHERE NCC.sMaNCC LIKE '%NCC%'";

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
                                row.Cells[7].Value = dataRow[7].ToString();
                                dataGridView.Rows.Add(row);
                            }
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message);
            }

        }
        public void uploadComboBox( ComboBox comboBox_ma_NCC)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dlc.connectionstring))
                {
                    conn.Open();  // Mở kết nối một lần duy nhất

                    // Lấy danh sách Mã Nhà Cung Cấp (sMaNCC)
                    using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT sMaNCC FROM tblNhaCungCap", conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            comboBox_ma_NCC.Items.Clear();  // Xóa các mục cũ trong comboBox
                            while (reader.Read())
                            {
                                comboBox_ma_NCC.Items.Add(reader["sMaNCC"].ToString());
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

        
        public void layten_ncc(string mancc, TextBox textBox)
        {
            using (SqlConnection connection = new SqlConnection(dlc.connectionstring))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT sTenNCC FROM tblNhaCungCap WHERE sMaNCC = @mancc and sMaNCC like '%NCC%'";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@mancc", mancc); // Sử dụng parameters để tránh SQL injection

                    connection.Open(); // Mở kết nối trước khi thực hiện command

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox.Text = reader["sTenNCC"].ToString(); // Đọc dữ liệu từ cột "sTenLoai"
                        }
                    }
                }
            }
        }
        
        

    }
}
