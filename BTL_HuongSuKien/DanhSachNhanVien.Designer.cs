namespace BTL_HSK_ver_1
{
    partial class frmDanhSachNhanVien
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
            this.button_huy = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button_XoaNV = new System.Windows.Forms.Button();
            this.button_SuaNV = new System.Windows.Forms.Button();
            this.button_ThemNV = new System.Windows.Forms.Button();
            this.comboBox_Timkiem = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1_ngay_vao_lam = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_NgaySinh = new System.Windows.Forms.DateTimePicker();
            this.radioButton_GT_Nu = new System.Windows.Forms.RadioButton();
            this.radioButton_GT_Nam = new System.Windows.Forms.RadioButton();
            this.textBox_TimKiem = new System.Windows.Forms.TextBox();
            this.textBox_phu_cap = new System.Windows.Forms.TextBox();
            this.textBox_luong = new System.Windows.Forms.TextBox();
            this.textBox_SDT = new System.Windows.Forms.TextBox();
            this.textBox_DiaChi = new System.Windows.Forms.TextBox();
            this.textBox_Ten = new System.Windows.Forms.TextBox();
            this.textBox_maNV = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label_NgaySinh = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Boloc = new System.Windows.Forms.Button();
            this.button_inDS = new System.Windows.Forms.Button();
            this.dataGridView_NhanVien = new System.Windows.Forms.DataGridView();
            this.sMaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sSDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dNgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dNgayVaoLam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fPhuCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_NhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // button_huy
            // 
            this.button_huy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_huy.Location = new System.Drawing.Point(573, 210);
            this.button_huy.Name = "button_huy";
            this.button_huy.Size = new System.Drawing.Size(67, 29);
            this.button_huy.TabIndex = 39;
            this.button_huy.Text = "Hủy";
            this.button_huy.UseVisualStyleBackColor = true;
            this.button_huy.Click += new System.EventHandler(this.button_huy_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(541, 140);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 18);
            this.label9.TabIndex = 37;
            this.label9.Text = "Phụ Cấp";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(541, 105);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 18);
            this.label8.TabIndex = 36;
            this.label8.Text = "Lương";
            // 
            // button_XoaNV
            // 
            this.button_XoaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_XoaNV.Location = new System.Drawing.Point(410, 210);
            this.button_XoaNV.Margin = new System.Windows.Forms.Padding(2);
            this.button_XoaNV.Name = "button_XoaNV";
            this.button_XoaNV.Size = new System.Drawing.Size(89, 29);
            this.button_XoaNV.TabIndex = 35;
            this.button_XoaNV.Text = "Xóa";
            this.button_XoaNV.UseVisualStyleBackColor = true;
            this.button_XoaNV.Click += new System.EventHandler(this.button_XoaNV_Click);
            // 
            // button_SuaNV
            // 
            this.button_SuaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SuaNV.Location = new System.Drawing.Point(247, 210);
            this.button_SuaNV.Margin = new System.Windows.Forms.Padding(2);
            this.button_SuaNV.Name = "button_SuaNV";
            this.button_SuaNV.Size = new System.Drawing.Size(89, 29);
            this.button_SuaNV.TabIndex = 34;
            this.button_SuaNV.Text = "Sửa";
            this.button_SuaNV.UseVisualStyleBackColor = true;
            this.button_SuaNV.Click += new System.EventHandler(this.button_SuaNV_Click);
            // 
            // button_ThemNV
            // 
            this.button_ThemNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ThemNV.Location = new System.Drawing.Point(85, 210);
            this.button_ThemNV.Margin = new System.Windows.Forms.Padding(2);
            this.button_ThemNV.Name = "button_ThemNV";
            this.button_ThemNV.Size = new System.Drawing.Size(89, 29);
            this.button_ThemNV.TabIndex = 33;
            this.button_ThemNV.Text = "Thêm";
            this.button_ThemNV.UseVisualStyleBackColor = true;
            this.button_ThemNV.Click += new System.EventHandler(this.button_ThemNV_Click);
            // 
            // comboBox_Timkiem
            // 
            this.comboBox_Timkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Timkiem.FormattingEnabled = true;
            this.comboBox_Timkiem.Items.AddRange(new object[] {
            "Mã Nhân Viên",
            "Tên Nhân Viên",
            "Địa Chỉ",
            "Giới Tính (Nam/Nữ)",
            "ngày sinh",
            "ngày vào làm"});
            this.comboBox_Timkiem.Location = new System.Drawing.Point(512, 262);
            this.comboBox_Timkiem.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Timkiem.Name = "comboBox_Timkiem";
            this.comboBox_Timkiem.Size = new System.Drawing.Size(119, 26);
            this.comboBox_Timkiem.TabIndex = 32;
            this.comboBox_Timkiem.Text = "Mã Nhân Viên";
            // 
            // dateTimePicker1_ngay_vao_lam
            // 
            this.dateTimePicker1_ngay_vao_lam.Cursor = System.Windows.Forms.Cursors.Default;
            this.dateTimePicker1_ngay_vao_lam.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1_ngay_vao_lam.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1_ngay_vao_lam.Location = new System.Drawing.Point(166, 175);
            this.dateTimePicker1_ngay_vao_lam.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1_ngay_vao_lam.Name = "dateTimePicker1_ngay_vao_lam";
            this.dateTimePicker1_ngay_vao_lam.Size = new System.Drawing.Size(139, 22);
            this.dateTimePicker1_ngay_vao_lam.TabIndex = 31;
            // 
            // dateTimePicker_NgaySinh
            // 
            this.dateTimePicker_NgaySinh.Cursor = System.Windows.Forms.Cursors.Default;
            this.dateTimePicker_NgaySinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_NgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_NgaySinh.Location = new System.Drawing.Point(166, 139);
            this.dateTimePicker_NgaySinh.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_NgaySinh.Name = "dateTimePicker_NgaySinh";
            this.dateTimePicker_NgaySinh.Size = new System.Drawing.Size(139, 22);
            this.dateTimePicker_NgaySinh.TabIndex = 30;
            this.dateTimePicker_NgaySinh.Validating += new System.ComponentModel.CancelEventHandler(this.dateTimePicker_NgaySinh_Validating);
            // 
            // radioButton_GT_Nu
            // 
            this.radioButton_GT_Nu.AutoSize = true;
            this.radioButton_GT_Nu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_GT_Nu.Location = new System.Drawing.Point(692, 28);
            this.radioButton_GT_Nu.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_GT_Nu.Name = "radioButton_GT_Nu";
            this.radioButton_GT_Nu.Size = new System.Drawing.Size(51, 24);
            this.radioButton_GT_Nu.TabIndex = 29;
            this.radioButton_GT_Nu.TabStop = true;
            this.radioButton_GT_Nu.Text = "Nữ";
            this.radioButton_GT_Nu.UseVisualStyleBackColor = true;
            // 
            // radioButton_GT_Nam
            // 
            this.radioButton_GT_Nam.AutoSize = true;
            this.radioButton_GT_Nam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_GT_Nam.Location = new System.Drawing.Point(618, 28);
            this.radioButton_GT_Nam.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_GT_Nam.Name = "radioButton_GT_Nam";
            this.radioButton_GT_Nam.Size = new System.Drawing.Size(65, 24);
            this.radioButton_GT_Nam.TabIndex = 28;
            this.radioButton_GT_Nam.TabStop = true;
            this.radioButton_GT_Nam.Text = "Nam";
            this.radioButton_GT_Nam.UseVisualStyleBackColor = true;
            // 
            // textBox_TimKiem
            // 
            this.textBox_TimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_TimKiem.Location = new System.Drawing.Point(129, 262);
            this.textBox_TimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_TimKiem.Name = "textBox_TimKiem";
            this.textBox_TimKiem.Size = new System.Drawing.Size(362, 24);
            this.textBox_TimKiem.TabIndex = 27;
            this.textBox_TimKiem.TextChanged += new System.EventHandler(this.textBox_TimKiem_TextChanged);
            // 
            // textBox_phu_cap
            // 
            this.textBox_phu_cap.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_phu_cap.Location = new System.Drawing.Point(618, 138);
            this.textBox_phu_cap.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_phu_cap.Name = "textBox_phu_cap";
            this.textBox_phu_cap.Size = new System.Drawing.Size(209, 22);
            this.textBox_phu_cap.TabIndex = 26;
            this.textBox_phu_cap.TextChanged += new System.EventHandler(this.textBox_phu_cap_TextChanged);
            this.textBox_phu_cap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_phu_cap_KeyPress);
            this.textBox_phu_cap.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_phu_cap_Validating);
            // 
            // textBox_luong
            // 
            this.textBox_luong.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_luong.Location = new System.Drawing.Point(618, 102);
            this.textBox_luong.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_luong.Name = "textBox_luong";
            this.textBox_luong.Size = new System.Drawing.Size(209, 22);
            this.textBox_luong.TabIndex = 25;
            this.textBox_luong.TextChanged += new System.EventHandler(this.textBox_luong_TextChanged);
            this.textBox_luong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_luong_KeyPress);
            this.textBox_luong.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_luong_Validating);
            // 
            // textBox_SDT
            // 
            this.textBox_SDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SDT.Location = new System.Drawing.Point(618, 63);
            this.textBox_SDT.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_SDT.Name = "textBox_SDT";
            this.textBox_SDT.Size = new System.Drawing.Size(209, 22);
            this.textBox_SDT.TabIndex = 24;
            this.textBox_SDT.TextChanged += new System.EventHandler(this.textBox_SDT_TextChanged);
            this.textBox_SDT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_SDT_KeyPress);
            this.textBox_SDT.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_SDT_Validating);
            // 
            // textBox_DiaChi
            // 
            this.textBox_DiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DiaChi.Location = new System.Drawing.Point(127, 103);
            this.textBox_DiaChi.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_DiaChi.Name = "textBox_DiaChi";
            this.textBox_DiaChi.Size = new System.Drawing.Size(209, 22);
            this.textBox_DiaChi.TabIndex = 23;
            this.textBox_DiaChi.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_DiaChi_Validating);
            // 
            // textBox_Ten
            // 
            this.textBox_Ten.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Ten.Location = new System.Drawing.Point(127, 65);
            this.textBox_Ten.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Ten.Name = "textBox_Ten";
            this.textBox_Ten.Size = new System.Drawing.Size(209, 22);
            this.textBox_Ten.TabIndex = 22;
            this.textBox_Ten.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Ten_Validating);
            // 
            // textBox_maNV
            // 
            this.textBox_maNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_maNV.Location = new System.Drawing.Point(127, 27);
            this.textBox_maNV.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_maNV.Name = "textBox_maNV";
            this.textBox_maNV.Size = new System.Drawing.Size(209, 22);
            this.textBox_maNV.TabIndex = 21;
            this.textBox_maNV.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_MaNV_Validating);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(63, 177);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 18);
            this.label10.TabIndex = 19;
            this.label10.Text = "Ngày vào làm:";
            // 
            // label_NgaySinh
            // 
            this.label_NgaySinh.AutoSize = true;
            this.label_NgaySinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NgaySinh.Location = new System.Drawing.Point(63, 139);
            this.label_NgaySinh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_NgaySinh.Name = "label_NgaySinh";
            this.label_NgaySinh.Size = new System.Drawing.Size(79, 18);
            this.label_NgaySinh.TabIndex = 18;
            this.label_NgaySinh.Text = "Ngày Sinh:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(541, 29);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 18);
            this.label7.TabIndex = 17;
            this.label7.Text = "Giới Tính:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(541, 67);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 18);
            this.label5.TabIndex = 16;
            this.label5.Text = "SDT:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(63, 170);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 18);
            this.label4.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(49, 265);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 18);
            this.label6.TabIndex = 14;
            this.label6.Text = "Tìm Kiếm:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(63, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "Địa chỉ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 18);
            this.label2.TabIndex = 20;
            this.label2.Text = "Tên:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "Mã NV:";
            // 
            // button_Boloc
            // 
            this.button_Boloc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Boloc.Location = new System.Drawing.Point(636, 256);
            this.button_Boloc.Name = "button_Boloc";
            this.button_Boloc.Size = new System.Drawing.Size(85, 37);
            this.button_Boloc.TabIndex = 41;
            this.button_Boloc.Text = "Bỏ lọc";
            this.button_Boloc.UseVisualStyleBackColor = true;
            this.button_Boloc.Click += new System.EventHandler(this.button_Boloc_Click);
            // 
            // button_inDS
            // 
            this.button_inDS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_inDS.Location = new System.Drawing.Point(715, 210);
            this.button_inDS.Margin = new System.Windows.Forms.Padding(2);
            this.button_inDS.Name = "button_inDS";
            this.button_inDS.Size = new System.Drawing.Size(112, 29);
            this.button_inDS.TabIndex = 42;
            this.button_inDS.Text = "In Danh Sách ";
            this.button_inDS.UseVisualStyleBackColor = true;
            this.button_inDS.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView_NhanVien
            // 
            this.dataGridView_NhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_NhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_NhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sMaNV,
            this.sHoTen,
            this.sGioiTinh,
            this.sDiaChi,
            this.sSDT,
            this.dNgaySinh,
            this.dNgayVaoLam,
            this.fLuong,
            this.fPhuCap,
            this.Column10});
            this.dataGridView_NhanVien.Location = new System.Drawing.Point(12, 317);
            this.dataGridView_NhanVien.Name = "dataGridView_NhanVien";
            this.dataGridView_NhanVien.RowHeadersWidth = 51;
            this.dataGridView_NhanVien.RowTemplate.Height = 24;
            this.dataGridView_NhanVien.Size = new System.Drawing.Size(859, 197);
            this.dataGridView_NhanVien.TabIndex = 43;
            this.dataGridView_NhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_NhanVien_CellClick_1);
            // 
            // sMaNV
            // 
            this.sMaNV.HeaderText = "Mã NV";
            this.sMaNV.MinimumWidth = 6;
            this.sMaNV.Name = "sMaNV";
            this.sMaNV.Width = 82;
            // 
            // sHoTen
            // 
            this.sHoTen.HeaderText = "Tên NV";
            this.sHoTen.MinimumWidth = 6;
            this.sHoTen.Name = "sHoTen";
            this.sHoTen.Width = 86;
            // 
            // sGioiTinh
            // 
            this.sGioiTinh.HeaderText = "Giới Tính";
            this.sGioiTinh.MinimumWidth = 6;
            this.sGioiTinh.Name = "sGioiTinh";
            this.sGioiTinh.Width = 96;
            // 
            // sDiaChi
            // 
            this.sDiaChi.HeaderText = "Địa Chỉ";
            this.sDiaChi.MinimumWidth = 6;
            this.sDiaChi.Name = "sDiaChi";
            this.sDiaChi.Width = 85;
            // 
            // sSDT
            // 
            this.sSDT.HeaderText = "SĐT";
            this.sSDT.MinimumWidth = 6;
            this.sSDT.Name = "sSDT";
            this.sSDT.Width = 67;
            // 
            // dNgaySinh
            // 
            this.dNgaySinh.HeaderText = "Ngày Sinh";
            this.dNgaySinh.MinimumWidth = 6;
            this.dNgaySinh.Name = "dNgaySinh";
            this.dNgaySinh.Width = 104;
            // 
            // dNgayVaoLam
            // 
            this.dNgayVaoLam.HeaderText = "Ngày Vào Làm";
            this.dNgayVaoLam.MinimumWidth = 6;
            this.dNgayVaoLam.Name = "dNgayVaoLam";
            this.dNgayVaoLam.Width = 134;
            // 
            // fLuong
            // 
            this.fLuong.HeaderText = "Lương";
            this.fLuong.MinimumWidth = 6;
            this.fLuong.Name = "fLuong";
            this.fLuong.Width = 78;
            // 
            // fPhuCap
            // 
            this.fPhuCap.HeaderText = "Phụ Cấp";
            this.fPhuCap.MinimumWidth = 6;
            this.fPhuCap.Name = "fPhuCap";
            this.fPhuCap.Width = 94;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "So nam";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.Width = 89;
            // 
            // frmDanhSachNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 526);
            this.Controls.Add(this.dataGridView_NhanVien);
            this.Controls.Add(this.button_inDS);
            this.Controls.Add(this.button_Boloc);
            this.Controls.Add(this.button_huy);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button_XoaNV);
            this.Controls.Add(this.button_SuaNV);
            this.Controls.Add(this.button_ThemNV);
            this.Controls.Add(this.comboBox_Timkiem);
            this.Controls.Add(this.dateTimePicker1_ngay_vao_lam);
            this.Controls.Add(this.dateTimePicker_NgaySinh);
            this.Controls.Add(this.radioButton_GT_Nu);
            this.Controls.Add(this.radioButton_GT_Nam);
            this.Controls.Add(this.textBox_TimKiem);
            this.Controls.Add(this.textBox_phu_cap);
            this.Controls.Add(this.textBox_luong);
            this.Controls.Add(this.textBox_SDT);
            this.Controls.Add(this.textBox_DiaChi);
            this.Controls.Add(this.textBox_Ten);
            this.Controls.Add(this.textBox_maNV);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label_NgaySinh);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDanhSachNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin nhân viên";
            this.Load += new System.EventHandler(this.frmDanhSachNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_NhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_huy;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_XoaNV;
        private System.Windows.Forms.Button button_SuaNV;
        private System.Windows.Forms.Button button_ThemNV;
        private System.Windows.Forms.ComboBox comboBox_Timkiem;
        private System.Windows.Forms.DateTimePicker dateTimePicker1_ngay_vao_lam;
        private System.Windows.Forms.DateTimePicker dateTimePicker_NgaySinh;
        private System.Windows.Forms.RadioButton radioButton_GT_Nu;
        private System.Windows.Forms.RadioButton radioButton_GT_Nam;
        private System.Windows.Forms.TextBox textBox_TimKiem;
        private System.Windows.Forms.TextBox textBox_phu_cap;
        private System.Windows.Forms.TextBox textBox_luong;
        private System.Windows.Forms.TextBox textBox_SDT;
        private System.Windows.Forms.TextBox textBox_DiaChi;
        private System.Windows.Forms.TextBox textBox_Ten;
        private System.Windows.Forms.TextBox textBox_maNV;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label_NgaySinh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Boloc;
        private System.Windows.Forms.Button button_inDS;
        private System.Windows.Forms.DataGridView dataGridView_NhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn sHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn sGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn sSDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNgayVaoLam;
        private System.Windows.Forms.DataGridViewTextBoxColumn fLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn fPhuCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
    }
}