
namespace BTL_HSK_ver_1
{
    partial class NhapHang
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
            this.dataGridView_donnhaphang = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox_tth = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_mancc = new System.Windows.Forms.ComboBox();
            this.comboBox_manv = new System.Windows.Forms.ComboBox();
            this.button_ThemHD = new System.Windows.Forms.Button();
            this.button_inhd = new System.Windows.Forms.Button();
            this.button_lammoi = new System.Windows.Forms.Button();
            this.button_xoa = new System.Windows.Forms.Button();
            this.button_sua = new System.Windows.Forms.Button();
            this.dateTimePicker_ngaynhap = new System.Windows.Forms.DateTimePicker();
            this.textBox_madonnhap = new System.Windows.Forms.TextBox();
            this.groupBox_HoaDon = new System.Windows.Forms.GroupBox();
            this.comboBox_Timkiem = new System.Windows.Forms.ComboBox();
            this.textBox_TimKiem = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_donnhaphang)).BeginInit();
            this.groupBox_HoaDon.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_donnhaphang
            // 
            this.dataGridView_donnhaphang.AllowUserToAddRows = false;
            this.dataGridView_donnhaphang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_donnhaphang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridView_donnhaphang.Location = new System.Drawing.Point(11, 356);
            this.dataGridView_donnhaphang.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_donnhaphang.Name = "dataGridView_donnhaphang";
            this.dataGridView_donnhaphang.ReadOnly = true;
            this.dataGridView_donnhaphang.RowHeadersWidth = 50;
            this.dataGridView_donnhaphang.RowTemplate.Height = 33;
            this.dataGridView_donnhaphang.Size = new System.Drawing.Size(1035, 218);
            this.dataGridView_donnhaphang.TabIndex = 6;
            this.dataGridView_donnhaphang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_donnhaphang_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Mã ĐNH";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Mã NV";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Mã NCC";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Ngày Đặt Hàng";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Tổng Tiền Hàng";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 125;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Chi Tiết Đơn Nhập";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 125;
            // 
            // textBox_tth
            // 
            this.textBox_tth.Location = new System.Drawing.Point(197, 119);
            this.textBox_tth.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_tth.Name = "textBox_tth";
            this.textBox_tth.ReadOnly = true;
            this.textBox_tth.Size = new System.Drawing.Size(265, 24);
            this.textBox_tth.TabIndex = 9;
            this.textBox_tth.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 122);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "Tổng Tiền Hàng:";
            // 
            // comboBox_mancc
            // 
            this.comboBox_mancc.FormattingEnabled = true;
            this.comboBox_mancc.Location = new System.Drawing.Point(691, 77);
            this.comboBox_mancc.Name = "comboBox_mancc";
            this.comboBox_mancc.Size = new System.Drawing.Size(265, 26);
            this.comboBox_mancc.TabIndex = 7;
            // 
            // comboBox_manv
            // 
            this.comboBox_manv.FormattingEnabled = true;
            this.comboBox_manv.Location = new System.Drawing.Point(691, 36);
            this.comboBox_manv.Name = "comboBox_manv";
            this.comboBox_manv.Size = new System.Drawing.Size(265, 26);
            this.comboBox_manv.TabIndex = 6;
            // 
            // button_ThemHD
            // 
            this.button_ThemHD.Location = new System.Drawing.Point(33, 191);
            this.button_ThemHD.Margin = new System.Windows.Forms.Padding(2);
            this.button_ThemHD.Name = "button_ThemHD";
            this.button_ThemHD.Size = new System.Drawing.Size(99, 32);
            this.button_ThemHD.TabIndex = 5;
            this.button_ThemHD.Text = "Thêm";
            this.button_ThemHD.UseVisualStyleBackColor = true;
            this.button_ThemHD.Click += new System.EventHandler(this.button_ThemHD_Click);
            // 
            // button_inhd
            // 
            this.button_inhd.Location = new System.Drawing.Point(850, 191);
            this.button_inhd.Margin = new System.Windows.Forms.Padding(2);
            this.button_inhd.Name = "button_inhd";
            this.button_inhd.Size = new System.Drawing.Size(106, 32);
            this.button_inhd.TabIndex = 5;
            this.button_inhd.Text = "In HD";
            this.button_inhd.UseVisualStyleBackColor = true;
            this.button_inhd.Click += new System.EventHandler(this.button_inhd_Click);
            // 
            // button_lammoi
            // 
            this.button_lammoi.Location = new System.Drawing.Point(709, 191);
            this.button_lammoi.Margin = new System.Windows.Forms.Padding(2);
            this.button_lammoi.Name = "button_lammoi";
            this.button_lammoi.Size = new System.Drawing.Size(106, 32);
            this.button_lammoi.TabIndex = 5;
            this.button_lammoi.Text = "Làm mới";
            this.button_lammoi.UseVisualStyleBackColor = true;
            this.button_lammoi.Click += new System.EventHandler(this.button_lammoi_Click);
            // 
            // button_xoa
            // 
            this.button_xoa.Location = new System.Drawing.Point(356, 191);
            this.button_xoa.Margin = new System.Windows.Forms.Padding(2);
            this.button_xoa.Name = "button_xoa";
            this.button_xoa.Size = new System.Drawing.Size(106, 32);
            this.button_xoa.TabIndex = 5;
            this.button_xoa.Text = "Xóa";
            this.button_xoa.UseVisualStyleBackColor = true;
            this.button_xoa.Click += new System.EventHandler(this.button_xoa_Click);
            // 
            // button_sua
            // 
            this.button_sua.Location = new System.Drawing.Point(197, 191);
            this.button_sua.Margin = new System.Windows.Forms.Padding(2);
            this.button_sua.Name = "button_sua";
            this.button_sua.Size = new System.Drawing.Size(98, 32);
            this.button_sua.TabIndex = 5;
            this.button_sua.Text = "Sửa";
            this.button_sua.UseVisualStyleBackColor = true;
            this.button_sua.Click += new System.EventHandler(this.button_sua_Click);
            // 
            // dateTimePicker_ngaynhap
            // 
            this.dateTimePicker_ngaynhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_ngaynhap.Location = new System.Drawing.Point(197, 78);
            this.dateTimePicker_ngaynhap.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_ngaynhap.Name = "dateTimePicker_ngaynhap";
            this.dateTimePicker_ngaynhap.ShowCheckBox = true;
            this.dateTimePicker_ngaynhap.Size = new System.Drawing.Size(196, 24);
            this.dateTimePicker_ngaynhap.TabIndex = 3;
            this.dateTimePicker_ngaynhap.Validating += new System.ComponentModel.CancelEventHandler(this.dateTimePicker_ngaynhap_Validating);
            // 
            // textBox_madonnhap
            // 
            this.textBox_madonnhap.Location = new System.Drawing.Point(197, 37);
            this.textBox_madonnhap.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_madonnhap.Name = "textBox_madonnhap";
            this.textBox_madonnhap.Size = new System.Drawing.Size(265, 24);
            this.textBox_madonnhap.TabIndex = 2;
            // 
            // groupBox_HoaDon
            // 
            this.groupBox_HoaDon.Controls.Add(this.comboBox_Timkiem);
            this.groupBox_HoaDon.Controls.Add(this.textBox_TimKiem);
            this.groupBox_HoaDon.Controls.Add(this.label12);
            this.groupBox_HoaDon.Controls.Add(this.textBox_tth);
            this.groupBox_HoaDon.Controls.Add(this.label6);
            this.groupBox_HoaDon.Controls.Add(this.comboBox_mancc);
            this.groupBox_HoaDon.Controls.Add(this.comboBox_manv);
            this.groupBox_HoaDon.Controls.Add(this.button_ThemHD);
            this.groupBox_HoaDon.Controls.Add(this.button_inhd);
            this.groupBox_HoaDon.Controls.Add(this.button_lammoi);
            this.groupBox_HoaDon.Controls.Add(this.button_xoa);
            this.groupBox_HoaDon.Controls.Add(this.button_sua);
            this.groupBox_HoaDon.Controls.Add(this.dateTimePicker_ngaynhap);
            this.groupBox_HoaDon.Controls.Add(this.textBox_madonnhap);
            this.groupBox_HoaDon.Controls.Add(this.label2);
            this.groupBox_HoaDon.Controls.Add(this.label3);
            this.groupBox_HoaDon.Controls.Add(this.label5);
            this.groupBox_HoaDon.Controls.Add(this.label4);
            this.groupBox_HoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox_HoaDon.Location = new System.Drawing.Point(11, 75);
            this.groupBox_HoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_HoaDon.Name = "groupBox_HoaDon";
            this.groupBox_HoaDon.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_HoaDon.Size = new System.Drawing.Size(1035, 277);
            this.groupBox_HoaDon.TabIndex = 5;
            this.groupBox_HoaDon.TabStop = false;
            this.groupBox_HoaDon.Text = "Hóa Đơn";
            // 
            // comboBox_Timkiem
            // 
            this.comboBox_Timkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Timkiem.FormattingEnabled = true;
            this.comboBox_Timkiem.Items.AddRange(new object[] {
            "Mã Đơn Nhập",
            "Mã Nhân Viên",
            "Mã Nhà Cung Cấp",
            "Ngày Nhập"});
            this.comboBox_Timkiem.Location = new System.Drawing.Point(628, 237);
            this.comboBox_Timkiem.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Timkiem.Name = "comboBox_Timkiem";
            this.comboBox_Timkiem.Size = new System.Drawing.Size(124, 24);
            this.comboBox_Timkiem.TabIndex = 47;
            this.comboBox_Timkiem.Text = "Mã Đơn Nhập";
            // 
            // textBox_TimKiem
            // 
            this.textBox_TimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_TimKiem.Location = new System.Drawing.Point(117, 237);
            this.textBox_TimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_TimKiem.Name = "textBox_TimKiem";
            this.textBox_TimKiem.Size = new System.Drawing.Size(368, 22);
            this.textBox_TimKiem.TabIndex = 46;
            this.textBox_TimKiem.TextChanged += new System.EventHandler(this.textBox_TimKiem_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(43, 240);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 17);
            this.label12.TabIndex = 45;
            this.label12.Text = "Tìm Kiếm:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Đơn Nhập Hàng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(545, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mã Nhân Viên:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 81);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "Ngày Nhập:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(545, 81);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Mã Nhà Cung Cấp:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(464, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nhập Hàng";
            // 
            // NhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 585);
            this.Controls.Add(this.dataGridView_donnhaphang);
            this.Controls.Add(this.groupBox_HoaDon);
            this.Controls.Add(this.label1);
            this.Name = "NhapHang";
            this.Text = "NhapHang";
            this.Load += new System.EventHandler(this.NhapHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_donnhaphang)).EndInit();
            this.groupBox_HoaDon.ResumeLayout(false);
            this.groupBox_HoaDon.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView_donnhaphang;
        private System.Windows.Forms.TextBox textBox_tth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_mancc;
        private System.Windows.Forms.ComboBox comboBox_manv;
        private System.Windows.Forms.Button button_ThemHD;
        private System.Windows.Forms.Button button_inhd;
        private System.Windows.Forms.Button button_lammoi;
        private System.Windows.Forms.Button button_xoa;
        private System.Windows.Forms.Button button_sua;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ngaynhap;
        private System.Windows.Forms.TextBox textBox_madonnhap;
        private System.Windows.Forms.GroupBox groupBox_HoaDon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.ComboBox comboBox_Timkiem;
        private System.Windows.Forms.TextBox textBox_TimKiem;
        private System.Windows.Forms.Label label12;
    }
}