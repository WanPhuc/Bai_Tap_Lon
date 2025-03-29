
namespace BTL_HSK_ver_1
{
    partial class Nhacungcap
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
            this.btntimkiem = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.dtgncc = new System.Windows.Forms.DataGridView();
            this.btnthem = new System.Windows.Forms.Button();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.txtdiachi = new System.Windows.Forms.TextBox();
            this.txtsdt = new System.Windows.Forms.TextBox();
            this.txtten = new System.Windows.Forms.TextBox();
            this.txtma = new System.Windows.Forms.TextBox();
            this.lbemail = new System.Windows.Forms.Label();
            this.lbdiachi = new System.Windows.Forms.Label();
            this.lbsdt = new System.Windows.Forms.Label();
            this.lbtenncc = new System.Windows.Forms.Label();
            this.lbmncc = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgncc)).BeginInit();
            this.SuspendLayout();
            // 
            // btntimkiem
            // 
            this.btntimkiem.Location = new System.Drawing.Point(660, 176);
            this.btntimkiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(89, 32);
            this.btntimkiem.TabIndex = 33;
            this.btntimkiem.Text = "Tìm kiếm";
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(462, 176);
            this.btnxoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(89, 32);
            this.btnxoa.TabIndex = 32;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(251, 176);
            this.btnsua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(89, 32);
            this.btnsua.TabIndex = 31;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // dtgncc
            // 
            this.dtgncc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgncc.Location = new System.Drawing.Point(23, 257);
            this.dtgncc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtgncc.Name = "dtgncc";
            this.dtgncc.RowHeadersWidth = 62;
            this.dtgncc.RowTemplate.Height = 28;
            this.dtgncc.Size = new System.Drawing.Size(756, 180);
            this.dtgncc.TabIndex = 30;
            this.dtgncc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgncc_CellClick);
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(44, 176);
            this.btnthem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(89, 32);
            this.btnthem.TabIndex = 29;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(514, 14);
            this.txtemail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(192, 22);
            this.txtemail.TabIndex = 28;
            // 
            // txtdiachi
            // 
            this.txtdiachi.Location = new System.Drawing.Point(514, 57);
            this.txtdiachi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtdiachi.Name = "txtdiachi";
            this.txtdiachi.Size = new System.Drawing.Size(266, 22);
            this.txtdiachi.TabIndex = 27;
            // 
            // txtsdt
            // 
            this.txtsdt.Location = new System.Drawing.Point(146, 102);
            this.txtsdt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtsdt.Name = "txtsdt";
            this.txtsdt.Size = new System.Drawing.Size(117, 22);
            this.txtsdt.TabIndex = 26;
            // 
            // txtten
            // 
            this.txtten.Location = new System.Drawing.Point(146, 59);
            this.txtten.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtten.Name = "txtten";
            this.txtten.Size = new System.Drawing.Size(182, 22);
            this.txtten.TabIndex = 25;
            // 
            // txtma
            // 
            this.txtma.Location = new System.Drawing.Point(145, 17);
            this.txtma.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtma.Name = "txtma";
            this.txtma.Size = new System.Drawing.Size(118, 22);
            this.txtma.TabIndex = 24;
            // 
            // lbemail
            // 
            this.lbemail.AutoSize = true;
            this.lbemail.Location = new System.Drawing.Point(447, 19);
            this.lbemail.Name = "lbemail";
            this.lbemail.Size = new System.Drawing.Size(42, 17);
            this.lbemail.TabIndex = 23;
            this.lbemail.Text = "Email";
            // 
            // lbdiachi
            // 
            this.lbdiachi.AutoSize = true;
            this.lbdiachi.Location = new System.Drawing.Point(447, 62);
            this.lbdiachi.Name = "lbdiachi";
            this.lbdiachi.Size = new System.Drawing.Size(51, 17);
            this.lbdiachi.TabIndex = 22;
            this.lbdiachi.Text = "Địa chỉ";
            // 
            // lbsdt
            // 
            this.lbsdt.AutoSize = true;
            this.lbsdt.Location = new System.Drawing.Point(20, 105);
            this.lbsdt.Name = "lbsdt";
            this.lbsdt.Size = new System.Drawing.Size(91, 17);
            this.lbsdt.TabIndex = 21;
            this.lbsdt.Text = "Số điện thoại";
            // 
            // lbtenncc
            // 
            this.lbtenncc.AutoSize = true;
            this.lbtenncc.Location = new System.Drawing.Point(20, 62);
            this.lbtenncc.Name = "lbtenncc";
            this.lbtenncc.Size = new System.Drawing.Size(123, 17);
            this.lbtenncc.TabIndex = 20;
            this.lbtenncc.Text = "Tên nhà cung cấp";
            // 
            // lbmncc
            // 
            this.lbmncc.AutoSize = true;
            this.lbmncc.Location = new System.Drawing.Point(20, 22);
            this.lbmncc.Name = "lbmncc";
            this.lbmncc.Size = new System.Drawing.Size(59, 17);
            this.lbmncc.TabIndex = 19;
            this.lbmncc.Text = "Mã NCC";
            // 
            // Nhacungcap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btntimkiem);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.dtgncc);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.txtemail);
            this.Controls.Add(this.txtdiachi);
            this.Controls.Add(this.txtsdt);
            this.Controls.Add(this.txtten);
            this.Controls.Add(this.txtma);
            this.Controls.Add(this.lbemail);
            this.Controls.Add(this.lbdiachi);
            this.Controls.Add(this.lbsdt);
            this.Controls.Add(this.lbtenncc);
            this.Controls.Add(this.lbmncc);
            this.Name = "Nhacungcap";
            this.Text = "Nhacungcap";
            this.Load += new System.EventHandler(this.Nhacungcap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgncc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.DataGridView dtgncc;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.TextBox txtdiachi;
        private System.Windows.Forms.TextBox txtsdt;
        private System.Windows.Forms.TextBox txtten;
        private System.Windows.Forms.TextBox txtma;
        private System.Windows.Forms.Label lbemail;
        private System.Windows.Forms.Label lbdiachi;
        private System.Windows.Forms.Label lbsdt;
        private System.Windows.Forms.Label lbtenncc;
        private System.Windows.Forms.Label lbmncc;
    }
}