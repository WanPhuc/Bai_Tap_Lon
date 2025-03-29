namespace BTL_HSK_ver_1
{
    partial class frmDanhSachSanPham
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_inds = new System.Windows.Forms.Button();
            this.comboBox_tendvt = new System.Windows.Forms.ComboBox();
            this.comboBox_tenlh = new System.Windows.Forms.ComboBox();
            this.button_Boloc = new System.Windows.Forms.Button();
            this.comboBox_Timkiem = new System.Windows.Forms.ComboBox();
            this.textBox_TimKiem = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox_ma_NCC = new System.Windows.Forms.ComboBox();
            this.button_Huy = new System.Windows.Forms.Button();
            this.button_Xoa = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.button_Luu = new System.Windows.Forms.Button();
            this.textBox_ten_NCC = new System.Windows.Forms.TextBox();
            this.button_Them = new System.Windows.Forms.Button();
            this.textBox_GiaTien = new System.Windows.Forms.TextBox();
            this.textBox_SoLuong = new System.Windows.Forms.TextBox();
            this.textBox_MaSanPham = new System.Windows.Forms.TextBox();
            this.textBox_TenSanPham = new System.Windows.Forms.TextBox();
            this.dataGridView_sanpham = new System.Windows.Forms.DataGridView();
            this.Column_MaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Soluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_giaban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_dvt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_tenlh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_tenNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_mancc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_sanpham)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Tomato;
            this.label1.Location = new System.Drawing.Point(470, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Sách Sản Phẩm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Sản Phẩm:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên Sản Phẩm:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(573, 39);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tên Loại Hàng:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 114);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Số Lượng:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 152);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Giá Tiền:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(573, 115);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Nhà Cung Cấp:";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.button_inds);
            this.groupBox1.Controls.Add(this.comboBox_tendvt);
            this.groupBox1.Controls.Add(this.comboBox_tenlh);
            this.groupBox1.Controls.Add(this.button_Boloc);
            this.groupBox1.Controls.Add(this.comboBox_Timkiem);
            this.groupBox1.Controls.Add(this.textBox_TimKiem);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.comboBox_ma_NCC);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.button_Huy);
            this.groupBox1.Controls.Add(this.button_Xoa);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.button_Luu);
            this.groupBox1.Controls.Add(this.textBox_ten_NCC);
            this.groupBox1.Controls.Add(this.button_Them);
            this.groupBox1.Controls.Add(this.textBox_GiaTien);
            this.groupBox1.Controls.Add(this.textBox_SoLuong);
            this.groupBox1.Controls.Add(this.textBox_MaSanPham);
            this.groupBox1.Controls.Add(this.textBox_TenSanPham);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(11, 42);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1039, 343);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // button_inds
            // 
            this.button_inds.Location = new System.Drawing.Point(865, 234);
            this.button_inds.Margin = new System.Windows.Forms.Padding(2);
            this.button_inds.Name = "button_inds";
            this.button_inds.Size = new System.Drawing.Size(79, 31);
            this.button_inds.TabIndex = 48;
            this.button_inds.Text = "In DS";
            this.button_inds.UseVisualStyleBackColor = true;
            this.button_inds.Click += new System.EventHandler(this.button_inds_Click);
            // 
            // comboBox_tendvt
            // 
            this.comboBox_tendvt.FormattingEnabled = true;
            this.comboBox_tendvt.Items.AddRange(new object[] {
            "Kg",
            "Cái",
            "Túi",
            "Hộp",
            "Gói",
            "Bộ",
            "Thùng",
            "Cuộn",
            "Đôi",
            "Chai"});
            this.comboBox_tendvt.Location = new System.Drawing.Point(713, 71);
            this.comboBox_tendvt.Name = "comboBox_tendvt";
            this.comboBox_tendvt.Size = new System.Drawing.Size(272, 24);
            this.comboBox_tendvt.TabIndex = 47;
            // 
            // comboBox_tenlh
            // 
            this.comboBox_tenlh.FormattingEnabled = true;
            this.comboBox_tenlh.Items.AddRange(new object[] {
            "Thực phẩm khô",
            "Đồ uống",
            "Sữa và chế phẩm",
            "Bánh kẹo",
            "Đồ đông lạnh",
            "Gia vị",
            "Văn phòng phẩm"});
            this.comboBox_tenlh.Location = new System.Drawing.Point(713, 31);
            this.comboBox_tenlh.Name = "comboBox_tenlh";
            this.comboBox_tenlh.Size = new System.Drawing.Size(272, 24);
            this.comboBox_tenlh.TabIndex = 46;
            // 
            // button_Boloc
            // 
            this.button_Boloc.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Boloc.Location = new System.Drawing.Point(814, 286);
            this.button_Boloc.Name = "button_Boloc";
            this.button_Boloc.Size = new System.Drawing.Size(94, 37);
            this.button_Boloc.TabIndex = 45;
            this.button_Boloc.Text = "Bỏ lọc";
            this.button_Boloc.UseVisualStyleBackColor = true;
            this.button_Boloc.Click += new System.EventHandler(this.button_Boloc_Click);
            // 
            // comboBox_Timkiem
            // 
            this.comboBox_Timkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Timkiem.FormattingEnabled = true;
            this.comboBox_Timkiem.Items.AddRange(new object[] {
            "Mã Sản Phẩm",
            "Tên Sản Phẩm",
            "Đơn Vị SP",
            "Tên Loại SP"});
            this.comboBox_Timkiem.Location = new System.Drawing.Point(620, 293);
            this.comboBox_Timkiem.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Timkiem.Name = "comboBox_Timkiem";
            this.comboBox_Timkiem.Size = new System.Drawing.Size(124, 24);
            this.comboBox_Timkiem.TabIndex = 44;
            this.comboBox_Timkiem.Text = "Mã Sản Phẩm";
            // 
            // textBox_TimKiem
            // 
            this.textBox_TimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_TimKiem.Location = new System.Drawing.Point(180, 293);
            this.textBox_TimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_TimKiem.Name = "textBox_TimKiem";
            this.textBox_TimKiem.Size = new System.Drawing.Size(402, 22);
            this.textBox_TimKiem.TabIndex = 43;
            this.textBox_TimKiem.TextChanged += new System.EventHandler(this.textBox_TimKiem_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(106, 296);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 17);
            this.label12.TabIndex = 42;
            this.label12.Text = "Tìm Kiếm:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(573, 77);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 17);
            this.label11.TabIndex = 10;
            this.label11.Text = "Đơn Vị Tính:";
            // 
            // comboBox_ma_NCC
            // 
            this.comboBox_ma_NCC.FormattingEnabled = true;
            this.comboBox_ma_NCC.Location = new System.Drawing.Point(713, 109);
            this.comboBox_ma_NCC.Name = "comboBox_ma_NCC";
            this.comboBox_ma_NCC.Size = new System.Drawing.Size(272, 24);
            this.comboBox_ma_NCC.TabIndex = 4;
            this.comboBox_ma_NCC.SelectedIndexChanged += new System.EventHandler(this.comboBox_ma_NCC_SelectedIndexChanged);
            this.comboBox_ma_NCC.Validating += new System.ComponentModel.CancelEventHandler(this.comboBox_ma_NCC_Validating);
            // 
            // button_Huy
            // 
            this.button_Huy.Location = new System.Drawing.Point(655, 234);
            this.button_Huy.Margin = new System.Windows.Forms.Padding(2);
            this.button_Huy.Name = "button_Huy";
            this.button_Huy.Size = new System.Drawing.Size(79, 31);
            this.button_Huy.TabIndex = 3;
            this.button_Huy.Text = "Hủy";
            this.button_Huy.UseVisualStyleBackColor = true;
            this.button_Huy.Click += new System.EventHandler(this.button_Huy_Click);
            // 
            // button_Xoa
            // 
            this.button_Xoa.Location = new System.Drawing.Point(462, 234);
            this.button_Xoa.Margin = new System.Windows.Forms.Padding(2);
            this.button_Xoa.Name = "button_Xoa";
            this.button_Xoa.Size = new System.Drawing.Size(79, 31);
            this.button_Xoa.TabIndex = 3;
            this.button_Xoa.Text = "Xóa";
            this.button_Xoa.UseVisualStyleBackColor = true;
            this.button_Xoa.Click += new System.EventHandler(this.button_Xoa_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(573, 153);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "Tên nhà cung cấp:";
            // 
            // button_Luu
            // 
            this.button_Luu.Location = new System.Drawing.Point(240, 234);
            this.button_Luu.Margin = new System.Windows.Forms.Padding(2);
            this.button_Luu.Name = "button_Luu";
            this.button_Luu.Size = new System.Drawing.Size(79, 31);
            this.button_Luu.TabIndex = 3;
            this.button_Luu.Text = "Lưu";
            this.button_Luu.UseVisualStyleBackColor = true;
            this.button_Luu.Click += new System.EventHandler(this.button_Luu_Click);
            // 
            // textBox_ten_NCC
            // 
            this.textBox_ten_NCC.Location = new System.Drawing.Point(713, 148);
            this.textBox_ten_NCC.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_ten_NCC.Name = "textBox_ten_NCC";
            this.textBox_ten_NCC.ReadOnly = true;
            this.textBox_ten_NCC.Size = new System.Drawing.Size(272, 22);
            this.textBox_ten_NCC.TabIndex = 2;
            // 
            // button_Them
            // 
            this.button_Them.Location = new System.Drawing.Point(79, 234);
            this.button_Them.Margin = new System.Windows.Forms.Padding(2);
            this.button_Them.Name = "button_Them";
            this.button_Them.Size = new System.Drawing.Size(79, 31);
            this.button_Them.TabIndex = 3;
            this.button_Them.Text = "Thêm";
            this.button_Them.UseVisualStyleBackColor = true;
            this.button_Them.Click += new System.EventHandler(this.button_Them_Click);
            // 
            // textBox_GiaTien
            // 
            this.textBox_GiaTien.Location = new System.Drawing.Point(180, 148);
            this.textBox_GiaTien.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_GiaTien.Name = "textBox_GiaTien";
            this.textBox_GiaTien.Size = new System.Drawing.Size(272, 22);
            this.textBox_GiaTien.TabIndex = 2;
            this.textBox_GiaTien.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_GiaBan_Validating);
            // 
            // textBox_SoLuong
            // 
            this.textBox_SoLuong.Location = new System.Drawing.Point(180, 110);
            this.textBox_SoLuong.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_SoLuong.Name = "textBox_SoLuong";
            this.textBox_SoLuong.Size = new System.Drawing.Size(272, 22);
            this.textBox_SoLuong.TabIndex = 2;
            this.textBox_SoLuong.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_SoLuong_Validating);
            // 
            // textBox_MaSanPham
            // 
            this.textBox_MaSanPham.Location = new System.Drawing.Point(180, 34);
            this.textBox_MaSanPham.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_MaSanPham.Name = "textBox_MaSanPham";
            this.textBox_MaSanPham.Size = new System.Drawing.Size(272, 22);
            this.textBox_MaSanPham.TabIndex = 2;
            this.textBox_MaSanPham.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_MaSanPham_Validating);
            // 
            // textBox_TenSanPham
            // 
            this.textBox_TenSanPham.Location = new System.Drawing.Point(180, 71);
            this.textBox_TenSanPham.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_TenSanPham.Name = "textBox_TenSanPham";
            this.textBox_TenSanPham.Size = new System.Drawing.Size(272, 22);
            this.textBox_TenSanPham.TabIndex = 2;
            this.textBox_TenSanPham.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_TenSanPham_Validating);
            // 
            // dataGridView_sanpham
            // 
            this.dataGridView_sanpham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_sanpham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_MaSanPham,
            this.Column_TenSP,
            this.Column_Soluong,
            this.Column_giaban,
            this.Column_dvt,
            this.Column_tenlh,
            this.Column_tenNCC,
            this.Column_mancc});
            this.dataGridView_sanpham.Location = new System.Drawing.Point(12, 377);
            this.dataGridView_sanpham.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_sanpham.Name = "dataGridView_sanpham";
            this.dataGridView_sanpham.ReadOnly = true;
            this.dataGridView_sanpham.RowHeadersWidth = 50;
            this.dataGridView_sanpham.RowTemplate.Height = 33;
            this.dataGridView_sanpham.Size = new System.Drawing.Size(1038, 212);
            this.dataGridView_sanpham.TabIndex = 3;
            this.dataGridView_sanpham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_sanpham_CellClick);
            // 
            // Column_MaSanPham
            // 
            this.Column_MaSanPham.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_MaSanPham.Frozen = true;
            this.Column_MaSanPham.HeaderText = "Mã SP";
            this.Column_MaSanPham.MinimumWidth = 90;
            this.Column_MaSanPham.Name = "Column_MaSanPham";
            this.Column_MaSanPham.ReadOnly = true;
            this.Column_MaSanPham.Width = 90;
            // 
            // Column_TenSP
            // 
            this.Column_TenSP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_TenSP.Frozen = true;
            this.Column_TenSP.HeaderText = "Tên Sản Phẩm";
            this.Column_TenSP.MinimumWidth = 130;
            this.Column_TenSP.Name = "Column_TenSP";
            this.Column_TenSP.ReadOnly = true;
            this.Column_TenSP.Width = 130;
            // 
            // Column_Soluong
            // 
            this.Column_Soluong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Soluong.Frozen = true;
            this.Column_Soluong.HeaderText = "Số lượng";
            this.Column_Soluong.MinimumWidth = 90;
            this.Column_Soluong.Name = "Column_Soluong";
            this.Column_Soluong.ReadOnly = true;
            this.Column_Soluong.Width = 90;
            // 
            // Column_giaban
            // 
            this.Column_giaban.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_giaban.Frozen = true;
            this.Column_giaban.HeaderText = "Giá Bán";
            this.Column_giaban.MinimumWidth = 6;
            this.Column_giaban.Name = "Column_giaban";
            this.Column_giaban.ReadOnly = true;
            this.Column_giaban.Width = 82;
            // 
            // Column_dvt
            // 
            this.Column_dvt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_dvt.Frozen = true;
            this.Column_dvt.HeaderText = "DV tính";
            this.Column_dvt.MinimumWidth = 6;
            this.Column_dvt.Name = "Column_dvt";
            this.Column_dvt.ReadOnly = true;
            this.Column_dvt.Width = 77;
            // 
            // Column_tenlh
            // 
            this.Column_tenlh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_tenlh.Frozen = true;
            this.Column_tenlh.HeaderText = "Tên LH";
            this.Column_tenlh.MinimumWidth = 100;
            this.Column_tenlh.Name = "Column_tenlh";
            this.Column_tenlh.ReadOnly = true;
            // 
            // Column_tenNCC
            // 
            this.Column_tenNCC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_tenNCC.Frozen = true;
            this.Column_tenNCC.HeaderText = "Tên NCC";
            this.Column_tenNCC.MinimumWidth = 6;
            this.Column_tenNCC.Name = "Column_tenNCC";
            this.Column_tenNCC.ReadOnly = true;
            this.Column_tenNCC.Width = 87;
            // 
            // Column_mancc
            // 
            this.Column_mancc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_mancc.Frozen = true;
            this.Column_mancc.HeaderText = "Mã NCC";
            this.Column_mancc.MinimumWidth = 6;
            this.Column_mancc.Name = "Column_mancc";
            this.Column_mancc.ReadOnly = true;
            this.Column_mancc.Width = 82;
            // 
            // frmDanhSachSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 600);
            this.Controls.Add(this.dataGridView_sanpham);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmDanhSachSanPham";
            this.Text = "SanPham";
            this.Load += new System.EventHandler(this.frmDanhSachSanPham_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_sanpham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_ma_NCC;
        private System.Windows.Forms.Button button_Huy;
        private System.Windows.Forms.Button button_Xoa;
        private System.Windows.Forms.Button button_Luu;
        private System.Windows.Forms.Button button_Them;
        private System.Windows.Forms.TextBox textBox_GiaTien;
        private System.Windows.Forms.TextBox textBox_ten_NCC;
        private System.Windows.Forms.TextBox textBox_SoLuong;
        private System.Windows.Forms.TextBox textBox_MaSanPham;
        private System.Windows.Forms.TextBox textBox_TenSanPham;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_sanpham;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button_Boloc;
        private System.Windows.Forms.ComboBox comboBox_Timkiem;
        private System.Windows.Forms.TextBox textBox_TimKiem;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_MaSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Soluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_giaban;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_dvt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_tenlh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_tenNCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_mancc;
        private System.Windows.Forms.ComboBox comboBox_tenlh;
        private System.Windows.Forms.ComboBox comboBox_tendvt;
        private System.Windows.Forms.Button button_inds;
    }
}