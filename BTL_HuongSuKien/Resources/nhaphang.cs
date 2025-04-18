﻿using System;
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
    class nhaphang
    {
        string connectionString = ConfigurationManager.ConnectionStrings["BTL"].ConnectionString;
        public nhaphang() { }
        public bool kiemtratontai(string sohd, ErrorProvider error, TextBox textBox_mahd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Câu truy vấn SQL trực tiếp thay vì sử dụng stored procedure
                    string query = "SELECT COUNT(1) FROM tblDonNhapHang WHERE sMaDNH = @sMaDNH";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@sMaDNH", sohd); // Thêm tham số vào câu truy vấn

                        // Mở kết nối và thực thi câu lệnh
                        conn.Open();

                        // Kiểm tra xem có bản ghi nào với mã nhân viên đó hay không
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        // Kiểm tra kết quả
                        if (count > 0)
                        {
                            // Nếu mã nhân viên tồn tại
                            error.SetError(textBox_mahd, "Mã HĐ đã tồn tại!");
                            return true;
                        }
                        else
                        {
                            // Nếu mã nhân viên không tồn tại
                            error.SetError(textBox_mahd, null);
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
        public void hien_HoaDonban(DataGridView dataGridView)
        {
            try
            {
                // Xóa dữ liệu cũ trong DataGridView trước khi nạp dữ liệu mới
                dataGridView.Rows.Clear();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT sMaDNH, sMaNV, sMaNCC, dNgayNhapHang, fTongTienHang FROM tblDonNhapHang";
                        cmd.CommandType = CommandType.Text;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            // Tạo một bảng dữ liệu ảo
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable); // Đổ dữ liệu từ CSDL vào bảng

                            // Duyệt qua từng dòng dữ liệu
                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                // Tạo một hàng mới trong DataGridView
                                DataGridViewRow row = new DataGridViewRow();
                                row.CreateCells(dataGridView);

                                // Gán giá trị từ bảng dữ liệu vào các ô trong hàng
                                row.Cells[0].Value = dataRow["sMaDNH"].ToString();
                                row.Cells[1].Value = dataRow["sMaNV"].ToString();
                                row.Cells[2].Value = dataRow["sMaNCC"].ToString();
                                row.Cells[3].Value = Convert.ToDateTime(dataRow["dNgayNhapHang"]).ToString("yyyy/MM/dd");
                                row.Cells[4].Value = Convert.ToDouble(dataRow["fTongTienHang"]).ToString("N0") + " VND";

                                // Tạo nút "Chi Tiết" ở cột cuối cùng
                                DataGridViewButtonCell buttonCell = new DataGridViewButtonCell();
                                buttonCell.Value = "Chi Tiết";
                                row.Cells[5] = buttonCell;

                                // Thêm hàng vào DataGridView
                                dataGridView.Rows.Add(row);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public bool them_HoaDon_ban(string MaDDH, string MaNV, string sMaNCC, string NgayDatHang)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO tblDonNhapHang (sMaDNH, sMaNV, sMaNCC, dNgayNhapHang) VALUES (@sMaDNH, @MaNV, @sMaNCC, @dNgayNhapHang)", connection))
                {
                    cmd.CommandType = CommandType.Text;

                    // Thêm tham số để tránh SQL Injection
                    cmd.Parameters.AddWithValue("@sMaDNH", MaDDH);
                    cmd.Parameters.AddWithValue("@MaNV", MaNV);
                    cmd.Parameters.AddWithValue("@sMaNCC", sMaNCC);
                    cmd.Parameters.AddWithValue("@dNgayNhapHang", DateTime.Parse(NgayDatHang));

                    int i = cmd.ExecuteNonQuery();
                    connection.Close();

                    return i > 0;
                }
            }
        }

        public void uploadComboBox(ComboBox comboBox_manv, ComboBox comboBox_makh)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select sMaNV  from tblNhanVien";
                        cmd.CommandType = System.Data.CommandType.Text;
                        conn.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            // Tạo một kho dữ liệu ảo
                            DataTable dataTable = new DataTable();
                            // Đổ dữ liệu từ csdl vào kho
                            adapter.Fill(dataTable);
                            // Ngắt kết nối
                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                comboBox_manv.Items.Add(dataRow[0]);

                            }
                        }
                        cmd.CommandText = "select sMaNCC from tblNhaCungCap ";
                        cmd.CommandType = System.Data.CommandType.Text;
                        using (SqlDataAdapter adapters = new SqlDataAdapter(cmd))
                        {
                            // Tạo một kho dữ liệu ảo
                            DataTable dataTable = new DataTable();
                            // Đổ dữ liệu từ csdl vào kho
                            adapters.Fill(dataTable);
                            // Ngắt kết nối
                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                comboBox_makh.Items.Add(dataRow[0]);
                            }
                            conn.Close();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString().Trim();
            }
        }
        public bool update_HoaDon_ban(string MaDDH, string MaNV, string sMaNCC, string NgayDatHang)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE tblDonNhapHang " +
                               "SET sMaNV = @sMaNV, sMaNCC = @sMaNCC, dNgayNhapHang = @dNgayNhapHang " +
                               "WHERE sMaDNH = @sMaDNH";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@sMaDNH", MaDDH);
                    command.Parameters.AddWithValue("@sMaNV", MaNV);
                    command.Parameters.AddWithValue("@sMaNCC", sMaNCC);
                    command.Parameters.AddWithValue("@dNgayNhapHang", DateTime.Parse(NgayDatHang));

                    conn.Open();
                    int i = command.ExecuteNonQuery();
                    conn.Close();

                    return i > 0;
                }
            }
        }
        public bool Xoa_HD_ban(string MaDDH)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM tblDonNhapHang WHERE sMaDNH = @sMaDNH";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@sMaDNH", MaDDH);

                    conn.Open();
                    int i = command.ExecuteNonQuery();
                    conn.Close();

                    return i > 0;
                }
            }
        }
    }
}
