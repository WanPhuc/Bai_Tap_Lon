
namespace BTL_HSK_ver_1
{
    partial class KhachHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView_Khach_Hang = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label_DanhMuc_KhachHang = new System.Windows.Forms.Label();
            this.textBox_SDT_KhachHang = new System.Windows.Forms.TextBox();
            this.label_Ten_KhachHang = new System.Windows.Forms.Label();
            this.textBox_Ten_KhachHang = new System.Windows.Forms.TextBox();
            this.textBox_DiaChi = new System.Windows.Forms.TextBox();
            this.label_DiaChi = new System.Windows.Forms.Label();
            this.label_DienThoai = new System.Windows.Forms.Label();
            this.textBox_TongTienhang = new System.Windows.Forms.TextBox();
            this.button_Them = new System.Windows.Forms.Button();
            this.button_Luu = new System.Windows.Forms.Button();
            this.button_Xóa = new System.Windows.Forms.Button();
            this.button_Huy = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_TimKiem = new System.Windows.Forms.TextBox();
            this.comboBox_Timkiem = new System.Windows.Forms.ComboBox();
            this.textBox_GioiTinh_KH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1_ngaybatdau = new System.Windows.Forms.DateTimePicker();
            this.Column_SDT_KhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Ten_KhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_GioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_tth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox_sonam = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_inds = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Khach_Hang)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Khach_Hang
            // 
            this.dataGridView_Khach_Hang.AllowUserToAddRows = false;
            this.dataGridView_Khach_Hang.AllowUserToDeleteRows = false;
            this.dataGridView_Khach_Hang.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView_Khach_Hang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Khach_Hang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_SDT_KhachHang,
            this.Column_Ten_KhachHang,
            this.Column_GioiTinh,
            this.Column_DiaChi,
            this.Column_tth,
            this.Column1,
            this.Column2});
            this.dataGridView_Khach_Hang.Location = new System.Drawing.Point(11, 296);
            this.dataGridView_Khach_Hang.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_Khach_Hang.Name = "dataGridView_Khach_Hang";
            this.dataGridView_Khach_Hang.ReadOnly = true;
            this.dataGridView_Khach_Hang.RowHeadersWidth = 50;
            this.dataGridView_Khach_Hang.RowTemplate.Height = 33;
            this.dataGridView_Khach_Hang.Size = new System.Drawing.Size(984, 197);
            this.dataGridView_Khach_Hang.TabIndex = 0;
            this.dataGridView_Khach_Hang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Khach_Hang_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(20, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Số Điện Thoại:";
            // 
            // label_DanhMuc_KhachHang
            // 
            this.label_DanhMuc_KhachHang.AutoSize = true;
            this.label_DanhMuc_KhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label_DanhMuc_KhachHang.Location = new System.Drawing.Point(285, 9);
            this.label_DanhMuc_KhachHang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_DanhMuc_KhachHang.Name = "label_DanhMuc_KhachHang";
            this.label_DanhMuc_KhachHang.Size = new System.Drawing.Size(183, 20);
            this.label_DanhMuc_KhachHang.TabIndex = 4;
            this.label_DanhMuc_KhachHang.Text = "Danh Mục Khách Hàng";
            // 
            // textBox_SDT_KhachHang
            // 
            this.textBox_SDT_KhachHang.Location = new System.Drawing.Point(139, 61);
            this.textBox_SDT_KhachHang.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_SDT_KhachHang.Name = "textBox_SDT_KhachHang";
            this.textBox_SDT_KhachHang.Size = new System.Drawing.Size(250, 22);
            this.textBox_SDT_KhachHang.TabIndex = 5;
            this.textBox_SDT_KhachHang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Ma_KhachHang_KeyPress);
            this.textBox_SDT_KhachHang.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Ma_KhachHang_Validating);
            // 
            // label_Ten_KhachHang
            // 
            this.label_Ten_KhachHang.AutoSize = true;
            this.label_Ten_KhachHang.Location = new System.Drawing.Point(20, 99);
            this.label_Ten_KhachHang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Ten_KhachHang.Name = "label_Ten_KhachHang";
            this.label_Ten_KhachHang.Size = new System.Drawing.Size(119, 17);
            this.label_Ten_KhachHang.TabIndex = 6;
            this.label_Ten_KhachHang.Text = "Tên Khách Hàng:";
            // 
            // textBox_Ten_KhachHang
            // 
            this.textBox_Ten_KhachHang.Location = new System.Drawing.Point(139, 96);
            this.textBox_Ten_KhachHang.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Ten_KhachHang.Name = "textBox_Ten_KhachHang";
            this.textBox_Ten_KhachHang.Size = new System.Drawing.Size(250, 22);
            this.textBox_Ten_KhachHang.TabIndex = 7;
            this.textBox_Ten_KhachHang.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Ten_KhachHang_Validating);
            // 
            // textBox_DiaChi
            // 
            this.textBox_DiaChi.Location = new System.Drawing.Point(139, 166);
            this.textBox_DiaChi.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_DiaChi.Name = "textBox_DiaChi";
            this.textBox_DiaChi.Size = new System.Drawing.Size(250, 22);
            this.textBox_DiaChi.TabIndex = 7;
            this.textBox_DiaChi.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_DiaChi_Validating);
            // 
            // label_DiaChi
            // 
            this.label_DiaChi.AutoSize = true;
            this.label_DiaChi.Location = new System.Drawing.Point(20, 167);
            this.label_DiaChi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_DiaChi.Name = "label_DiaChi";
            this.label_DiaChi.Size = new System.Drawing.Size(57, 17);
            this.label_DiaChi.TabIndex = 6;
            this.label_DiaChi.Text = "Địa Chỉ:";
            // 
            // label_DienThoai
            // 
            this.label_DienThoai.AutoSize = true;
            this.label_DienThoai.Location = new System.Drawing.Point(20, 201);
            this.label_DienThoai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_DienThoai.Name = "label_DienThoai";
            this.label_DienThoai.Size = new System.Drawing.Size(115, 17);
            this.label_DienThoai.TabIndex = 6;
            this.label_DienThoai.Text = "Tổng Tiền Hàng:";
            // 
            // textBox_TongTienhang
            // 
            this.textBox_TongTienhang.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox_TongTienhang.Location = new System.Drawing.Point(139, 201);
            this.textBox_TongTienhang.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_TongTienhang.Name = "textBox_TongTienhang";
            this.textBox_TongTienhang.ReadOnly = true;
            this.textBox_TongTienhang.Size = new System.Drawing.Size(250, 22);
            this.textBox_TongTienhang.TabIndex = 7;
            // 
            // button_Them
            // 
            this.button_Them.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button_Them.Location = new System.Drawing.Point(458, 82);
            this.button_Them.Margin = new System.Windows.Forms.Padding(2);
            this.button_Them.Name = "button_Them";
            this.button_Them.Size = new System.Drawing.Size(73, 27);
            this.button_Them.TabIndex = 9;
            this.button_Them.Text = "Thêm";
            this.button_Them.UseVisualStyleBackColor = true;
            this.button_Them.Click += new System.EventHandler(this.button_Them_Click);
            // 
            // button_Luu
            // 
            this.button_Luu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button_Luu.Location = new System.Drawing.Point(458, 126);
            this.button_Luu.Margin = new System.Windows.Forms.Padding(2);
            this.button_Luu.Name = "button_Luu";
            this.button_Luu.Size = new System.Drawing.Size(73, 27);
            this.button_Luu.TabIndex = 10;
            this.button_Luu.Text = "Lưu";
            this.button_Luu.UseVisualStyleBackColor = true;
            this.button_Luu.Click += new System.EventHandler(this.button_Luu_Click);
            // 
            // button_Xóa
            // 
            this.button_Xóa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button_Xóa.Location = new System.Drawing.Point(458, 176);
            this.button_Xóa.Margin = new System.Windows.Forms.Padding(2);
            this.button_Xóa.Name = "button_Xóa";
            this.button_Xóa.Size = new System.Drawing.Size(73, 27);
            this.button_Xóa.TabIndex = 11;
            this.button_Xóa.Text = "Xóa";
            this.button_Xóa.UseVisualStyleBackColor = true;
            this.button_Xóa.Click += new System.EventHandler(this.button_Xóa_Click);
            // 
            // button_Huy
            // 
            this.button_Huy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button_Huy.Location = new System.Drawing.Point(633, 176);
            this.button_Huy.Margin = new System.Windows.Forms.Padding(2);
            this.button_Huy.Name = "button_Huy";
            this.button_Huy.Size = new System.Drawing.Size(73, 28);
            this.button_Huy.TabIndex = 12;
            this.button_Huy.Text = "Hủy";
            this.button_Huy.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 269);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Tìm Kiếm:";
            // 
            // textBox_TimKiem
            // 
            this.textBox_TimKiem.Location = new System.Drawing.Point(175, 265);
            this.textBox_TimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_TimKiem.Name = "textBox_TimKiem";
            this.textBox_TimKiem.Size = new System.Drawing.Size(293, 22);
            this.textBox_TimKiem.TabIndex = 14;
            this.textBox_TimKiem.TextChanged += new System.EventHandler(this.textBox_TimKiem_TextChanged);
            // 
            // comboBox_Timkiem
            // 
            this.comboBox_Timkiem.FormattingEnabled = true;
            this.comboBox_Timkiem.Items.AddRange(new object[] {
            "Số Điện Thoại",
            "Tên Khách Hàng",
            "ngaybatdau"});
            this.comboBox_Timkiem.Location = new System.Drawing.Point(498, 265);
            this.comboBox_Timkiem.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Timkiem.Name = "comboBox_Timkiem";
            this.comboBox_Timkiem.Size = new System.Drawing.Size(208, 24);
            this.comboBox_Timkiem.TabIndex = 15;
            this.comboBox_Timkiem.Text = "Tên Khách Hàng";
            // 
            // textBox_GioiTinh_KH
            // 
            this.textBox_GioiTinh_KH.Location = new System.Drawing.Point(139, 131);
            this.textBox_GioiTinh_KH.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_GioiTinh_KH.Name = "textBox_GioiTinh_KH";
            this.textBox_GioiTinh_KH.Size = new System.Drawing.Size(250, 22);
            this.textBox_GioiTinh_KH.TabIndex = 18;
            this.textBox_GioiTinh_KH.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_GioiTinh_KH_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 133);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Giới Tính:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 240);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "ngày bắt đầu";
            // 
            // dateTimePicker1_ngaybatdau
            // 
            this.dateTimePicker1_ngaybatdau.Cursor = System.Windows.Forms.Cursors.Default;
            this.dateTimePicker1_ngaybatdau.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1_ngaybatdau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1_ngaybatdau.Location = new System.Drawing.Point(139, 235);
            this.dateTimePicker1_ngaybatdau.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1_ngaybatdau.Name = "dateTimePicker1_ngaybatdau";
            this.dateTimePicker1_ngaybatdau.Size = new System.Drawing.Size(139, 22);
            this.dateTimePicker1_ngaybatdau.TabIndex = 32;
            // 
            // Column_SDT_KhachHang
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Column_SDT_KhachHang.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column_SDT_KhachHang.Frozen = true;
            this.Column_SDT_KhachHang.HeaderText = "Số Điện Thoại";
            this.Column_SDT_KhachHang.MinimumWidth = 10;
            this.Column_SDT_KhachHang.Name = "Column_SDT_KhachHang";
            this.Column_SDT_KhachHang.ReadOnly = true;
            this.Column_SDT_KhachHang.Width = 127;
            // 
            // Column_Ten_KhachHang
            // 
            this.Column_Ten_KhachHang.Frozen = true;
            this.Column_Ten_KhachHang.HeaderText = "Tên KH";
            this.Column_Ten_KhachHang.MinimumWidth = 10;
            this.Column_Ten_KhachHang.Name = "Column_Ten_KhachHang";
            this.Column_Ten_KhachHang.ReadOnly = true;
            this.Column_Ten_KhachHang.Width = 85;
            // 
            // Column_GioiTinh
            // 
            this.Column_GioiTinh.Frozen = true;
            this.Column_GioiTinh.HeaderText = "Giới Tính";
            this.Column_GioiTinh.MinimumWidth = 10;
            this.Column_GioiTinh.Name = "Column_GioiTinh";
            this.Column_GioiTinh.ReadOnly = true;
            this.Column_GioiTinh.Width = 94;
            // 
            // Column_DiaChi
            // 
            this.Column_DiaChi.Frozen = true;
            this.Column_DiaChi.HeaderText = "Địa Chỉ";
            this.Column_DiaChi.MinimumWidth = 10;
            this.Column_DiaChi.Name = "Column_DiaChi";
            this.Column_DiaChi.ReadOnly = true;
            this.Column_DiaChi.Width = 82;
            // 
            // Column_tth
            // 
            this.Column_tth.Frozen = true;
            this.Column_tth.HeaderText = "Tổng Tiền Hàng";
            this.Column_tth.MinimumWidth = 6;
            this.Column_tth.Name = "Column_tth";
            this.Column_tth.ReadOnly = true;
            this.Column_tth.Width = 128;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ngay bat dau";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "so nam";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 125;
            // 
            // textBox_sonam
            // 
            this.textBox_sonam.Location = new System.Drawing.Point(415, 237);
            this.textBox_sonam.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_sonam.Name = "textBox_sonam";
            this.textBox_sonam.Size = new System.Drawing.Size(250, 22);
            this.textBox_sonam.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(296, 238);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);----------------------------------------------------------------------------------------------------------------------
            this.label5.TabIndex = 33;
            this.label5.Text = "sonam";
            // 
            // button_inds
            // 
            this.button_inds.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button_inds.Location = new System.Drawing.Point(633, 126);
            this.button_inds.Margin = new System.Windows.Forms.Padding(2);
            this.button_inds.Name = "button_inds";
            this.button_inds.Size = new System.Drawing.Size(73, 27);
            this.button_inds.TabIndex = 35;
            this.button_inds.Text = "in ds";
            this.button_inds.UseVisualStyleBackColor = true;
            // 
            // KhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 504);
            this.Controls.Add(this.button_inds);
            this.Controls.Add(this.textBox_sonam);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker1_ngaybatdau);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_GioiTinh_KH);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_Timkiem);
            this.Controls.Add(this.textBox_TimKiem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_Huy);
            this.Controls.Add(this.button_Xóa);
            this.Controls.Add(this.button_Luu);
            this.Controls.Add(this.button_Them);
            this.Controls.Add(this.textBox_TongTienhang);
            this.Controls.Add(this.textBox_DiaChi);
            this.Controls.Add(this.textBox_Ten_KhachHang);
            this.Controls.Add(this.label_DienThoai);
            this.Controls.Add(this.label_DiaChi);
            this.Controls.Add(this.label_Ten_KhachHang);
            this.Controls.Add(this.textBox_SDT_KhachHang);
            this.Controls.Add(this.label_DanhMuc_KhachHang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_Khach_Hang);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "KhachHang";
            this.Text = "QLKhachHang";
            this.Load += new System.EventHandler(this.QLKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Khach_Hang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Khach_Hang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_DanhMuc_KhachHang;
        private System.Windows.Forms.TextBox textBox_SDT_KhachHang;
        private System.Windows.Forms.Label label_Ten_KhachHang;
        private System.Windows.Forms.TextBox textBox_Ten_KhachHang;
        private System.Windows.Forms.TextBox textBox_DiaChi;
        private System.Windows.Forms.Label label_DiaChi;
        private System.Windows.Forms.Label label_DienThoai;
        private System.Windows.Forms.TextBox textBox_TongTienhang;
        private System.Windows.Forms.Button button_Them;
        private System.Windows.Forms.Button button_Luu;
        private System.Windows.Forms.Button button_Xóa;
        private System.Windows.Forms.Button button_Huy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_TimKiem;
        private System.Windows.Forms.ComboBox comboBox_Timkiem;
        private System.Windows.Forms.TextBox textBox_GioiTinh_KH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1_ngaybatdau;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_SDT_KhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Ten_KhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_GioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_tth;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TextBox textBox_sonam;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_inds;
    }
}