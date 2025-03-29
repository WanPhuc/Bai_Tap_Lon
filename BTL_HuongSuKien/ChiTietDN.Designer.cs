
namespace BTL_HSK_ver_1
{
    partial class ChiTietDN
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
            this.textBox_tensp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_huy = new System.Windows.Forms.Button();
            this.comboBox_masp = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button_Xoa = new System.Windows.Forms.Button();
            this.button_Xua = new System.Windows.Forms.Button();
            this.button_Them = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView_chitiethdnhap = new System.Windows.Forms.DataGridView();
            this.Column_STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_tensp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_tendvt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_giatien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox_SoLuong = new System.Windows.Forms.TextBox();
            this.textBox_GiaBan = new System.Windows.Forms.TextBox();
            this.textBox_MaDN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_tendvt = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_chitiethdnhap)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_tensp
            // 
            this.textBox_tensp.Location = new System.Drawing.Point(659, 136);
            this.textBox_tensp.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_tensp.Name = "textBox_tensp";
            this.textBox_tensp.ReadOnly = true;
            this.textBox_tensp.Size = new System.Drawing.Size(200, 22);
            this.textBox_tensp.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(549, 188);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 27;
            this.label5.Text = "Tên ĐVT:";
            // 
            // button_huy
            // 
            this.button_huy.Location = new System.Drawing.Point(552, 294);
            this.button_huy.Name = "button_huy";
            this.button_huy.Size = new System.Drawing.Size(75, 25);
            this.button_huy.TabIndex = 26;
            this.button_huy.Text = "Hủy";
            this.button_huy.UseVisualStyleBackColor = true;
            this.button_huy.Click += new System.EventHandler(this.button_huy_Click);
            // 
            // comboBox_masp
            // 
            this.comboBox_masp.FormattingEnabled = true;
            this.comboBox_masp.Location = new System.Drawing.Point(659, 95);
            this.comboBox_masp.Name = "comboBox_masp";
            this.comboBox_masp.Size = new System.Drawing.Size(200, 24);
            this.comboBox_masp.TabIndex = 25;
            this.comboBox_masp.SelectedIndexChanged += new System.EventHandler(this.comboBox_ma_sx_SelectedIndexChanged);
            this.comboBox_masp.Validating += new System.ComponentModel.CancelEventHandler(this.comboBox_masp_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(414, 38);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 20);
            this.label6.TabIndex = 24;
            this.label6.Text = "Chi Tiết Đơn Nhập";
            // 
            // button_Xoa
            // 
            this.button_Xoa.Location = new System.Drawing.Point(410, 294);
            this.button_Xoa.Margin = new System.Windows.Forms.Padding(2);
            this.button_Xoa.Name = "button_Xoa";
            this.button_Xoa.Size = new System.Drawing.Size(79, 25);
            this.button_Xoa.TabIndex = 22;
            this.button_Xoa.Text = "Xóa";
            this.button_Xoa.UseVisualStyleBackColor = true;
            this.button_Xoa.Click += new System.EventHandler(this.button_Xoa_Click);
            // 
            // button_Xua
            // 
            this.button_Xua.Location = new System.Drawing.Point(266, 294);
            this.button_Xua.Margin = new System.Windows.Forms.Padding(2);
            this.button_Xua.Name = "button_Xua";
            this.button_Xua.Size = new System.Drawing.Size(79, 25);
            this.button_Xua.TabIndex = 23;
            this.button_Xua.Text = "Sửa";
            this.button_Xua.UseVisualStyleBackColor = true;
            this.button_Xua.Click += new System.EventHandler(this.button_Xua_Click);
            // 
            // button_Them
            // 
            this.button_Them.Location = new System.Drawing.Point(129, 294);
            this.button_Them.Margin = new System.Windows.Forms.Padding(2);
            this.button_Them.Name = "button_Them";
            this.button_Them.Size = new System.Drawing.Size(79, 25);
            this.button_Them.TabIndex = 21;
            this.button_Them.Text = "Thêm";
            this.button_Them.UseVisualStyleBackColor = true;
            this.button_Them.Click += new System.EventHandler(this.button_Them_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(549, 141);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 17);
            this.label7.TabIndex = 30;
            this.label7.Text = "Tên Sản phẩm:";
            // 
            // dataGridView_chitiethdnhap
            // 
            this.dataGridView_chitiethdnhap.AllowUserToAddRows = false;
            this.dataGridView_chitiethdnhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView_chitiethdnhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_chitiethdnhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_STT,
            this.Column_MaSP,
            this.Column_tensp,
            this.Column_tendvt,
            this.Column_sl,
            this.Column_giatien,
            this.Column1});
            this.dataGridView_chitiethdnhap.Location = new System.Drawing.Point(50, 357);
            this.dataGridView_chitiethdnhap.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_chitiethdnhap.Name = "dataGridView_chitiethdnhap";
            this.dataGridView_chitiethdnhap.ReadOnly = true;
            this.dataGridView_chitiethdnhap.RowHeadersWidth = 50;
            this.dataGridView_chitiethdnhap.RowTemplate.Height = 33;
            this.dataGridView_chitiethdnhap.Size = new System.Drawing.Size(913, 164);
            this.dataGridView_chitiethdnhap.TabIndex = 20;
            this.dataGridView_chitiethdnhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_chitiethdban_CellClick);
            // 
            // Column_STT
            // 
            this.Column_STT.HeaderText = "STT";
            this.Column_STT.MinimumWidth = 10;
            this.Column_STT.Name = "Column_STT";
            this.Column_STT.ReadOnly = true;
            this.Column_STT.Width = 64;
            // 
            // Column_MaSP
            // 
            this.Column_MaSP.HeaderText = "Mã SP";
            this.Column_MaSP.MinimumWidth = 10;
            this.Column_MaSP.Name = "Column_MaSP";
            this.Column_MaSP.ReadOnly = true;
            this.Column_MaSP.Width = 78;
            // 
            // Column_tensp
            // 
            this.Column_tensp.HeaderText = "Tên SP";
            this.Column_tensp.MinimumWidth = 6;
            this.Column_tensp.Name = "Column_tensp";
            this.Column_tensp.ReadOnly = true;
            this.Column_tensp.Width = 84;
            // 
            // Column_tendvt
            // 
            this.Column_tendvt.HeaderText = "Tên ĐVT";
            this.Column_tendvt.MinimumWidth = 6;
            this.Column_tendvt.Name = "Column_tendvt";
            this.Column_tendvt.ReadOnly = true;
            this.Column_tendvt.Width = 94;
            // 
            // Column_sl
            // 
            this.Column_sl.HeaderText = "Số Lượng";
            this.Column_sl.MinimumWidth = 6;
            this.Column_sl.Name = "Column_sl";
            this.Column_sl.ReadOnly = true;
            this.Column_sl.Width = 98;
            // 
            // Column_giatien
            // 
            this.Column_giatien.HeaderText = "Giá Tiền";
            this.Column_giatien.MinimumWidth = 6;
            this.Column_giatien.Name = "Column_giatien";
            this.Column_giatien.ReadOnly = true;
            this.Column_giatien.Width = 91;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Thành Tiền";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 110;
            // 
            // textBox_SoLuong
            // 
            this.textBox_SoLuong.Location = new System.Drawing.Point(181, 184);
            this.textBox_SoLuong.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_SoLuong.Name = "textBox_SoLuong";
            this.textBox_SoLuong.Size = new System.Drawing.Size(200, 22);
            this.textBox_SoLuong.TabIndex = 19;
            this.textBox_SoLuong.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_SoLuong_Validating);
            // 
            // textBox_GiaBan
            // 
            this.textBox_GiaBan.Location = new System.Drawing.Point(181, 135);
            this.textBox_GiaBan.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_GiaBan.Name = "textBox_GiaBan";
            this.textBox_GiaBan.Size = new System.Drawing.Size(200, 22);
            this.textBox_GiaBan.TabIndex = 18;
            this.textBox_GiaBan.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_GiaBan_Validating);
            // 
            // textBox_MaDN
            // 
            this.textBox_MaDN.Location = new System.Drawing.Point(181, 91);
            this.textBox_MaDN.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_MaDN.Name = "textBox_MaDN";
            this.textBox_MaDN.ReadOnly = true;
            this.textBox_MaDN.Size = new System.Drawing.Size(200, 22);
            this.textBox_MaDN.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(549, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Mã Sản phẩm:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 139);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Giá Nhập:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 188);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Số Lượng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Mã Đơn Nhập:";
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
            this.comboBox_tendvt.Location = new System.Drawing.Point(659, 184);
            this.comboBox_tendvt.Name = "comboBox_tendvt";
            this.comboBox_tendvt.Size = new System.Drawing.Size(200, 24);
            this.comboBox_tendvt.TabIndex = 31;
            // 
            // ChiTietDN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 532);
            this.Controls.Add(this.comboBox_tendvt);
            this.Controls.Add(this.textBox_tensp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_huy);
            this.Controls.Add(this.comboBox_masp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_Xoa);
            this.Controls.Add(this.button_Xua);
            this.Controls.Add(this.button_Them);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView_chitiethdnhap);
            this.Controls.Add(this.textBox_SoLuong);
            this.Controls.Add(this.textBox_GiaBan);
            this.Controls.Add(this.textBox_MaDN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "ChiTietDN";
            this.Text = "ChiTietDN";
            this.Load += new System.EventHandler(this.ChiTietDN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_chitiethdnhap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_tensp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_huy;
        private System.Windows.Forms.ComboBox comboBox_masp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_Xoa;
        private System.Windows.Forms.Button button_Xua;
        private System.Windows.Forms.Button button_Them;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView_chitiethdnhap;
        private System.Windows.Forms.TextBox textBox_SoLuong;
        private System.Windows.Forms.TextBox textBox_GiaBan;
        private System.Windows.Forms.TextBox textBox_MaDN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_tensp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_tendvt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_giatien;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.ComboBox comboBox_tendvt;
    }
}