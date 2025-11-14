namespace Quan_Ly_Tai_San
{
    partial class FrmHanMuc
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
            lblTieude = new Label();
            lblLoaiChiTieu = new Label();
            lblGiaTriHM = new Label();
            lblTongChi = new Label();
            lblHMConLai = new Label();
            lblTinhTrang = new Label();
            txtHMConLai = new TextBox();
            txtTinhTrang = new TextBox();
            txtGiaTriHM = new TextBox();
            txtTongChi = new TextBox();
            cboTenHM = new ComboBox();
            dataGridView1 = new DataGridView();
            btnTimKiem = new Button();
            btnThoat = new Button();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLuu = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblTieude
            // 
            lblTieude.AutoSize = true;
            lblTieude.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTieude.Location = new Point(213, 9);
            lblTieude.Name = "lblTieude";
            lblTieude.Size = new Size(507, 41);
            lblTieude.TabIndex = 0;
            lblTieude.Text = "DANH MỤC HẠN MỨC GIAO DỊCH";
            // 
            // lblLoaiChiTieu
            // 
            lblLoaiChiTieu.AutoSize = true;
            lblLoaiChiTieu.Font = new Font("Segoe UI", 12F);
            lblLoaiChiTieu.Location = new Point(31, 74);
            lblLoaiChiTieu.Name = "lblLoaiChiTieu";
            lblLoaiChiTieu.Size = new Size(155, 32);
            lblLoaiChiTieu.TabIndex = 1;
            lblLoaiChiTieu.Text = "Loại chi tiêu: ";
            // 
            // lblGiaTriHM
            // 
            lblGiaTriHM.AutoSize = true;
            lblGiaTriHM.Font = new Font("Segoe UI", 12F);
            lblGiaTriHM.Location = new Point(31, 135);
            lblGiaTriHM.Name = "lblGiaTriHM";
            lblGiaTriHM.Size = new Size(189, 32);
            lblGiaTriHM.TabIndex = 2;
            lblGiaTriHM.Text = "Giá trị hạn mức: ";
            // 
            // lblTongChi
            // 
            lblTongChi.AutoSize = true;
            lblTongChi.Font = new Font("Segoe UI", 12F);
            lblTongChi.Location = new Point(31, 201);
            lblTongChi.Name = "lblTongChi";
            lblTongChi.Size = new Size(119, 32);
            lblTongChi.TabIndex = 3;
            lblTongChi.Text = "Tổng chi: ";
            // 
            // lblHMConLai
            // 
            lblHMConLai.AutoSize = true;
            lblHMConLai.Font = new Font("Segoe UI", 12F);
            lblHMConLai.Location = new Point(31, 270);
            lblHMConLai.Name = "lblHMConLai";
            lblHMConLai.Size = new Size(199, 32);
            lblHMConLai.TabIndex = 4;
            lblHMConLai.Text = "Hạn mức còn lại: ";
            // 
            // lblTinhTrang
            // 
            lblTinhTrang.AutoSize = true;
            lblTinhTrang.Font = new Font("Segoe UI", 12F);
            lblTinhTrang.Location = new Point(31, 344);
            lblTinhTrang.Name = "lblTinhTrang";
            lblTinhTrang.Size = new Size(129, 32);
            lblTinhTrang.TabIndex = 5;
            lblTinhTrang.Text = "Tình trạng:";
            // 
            // txtHMConLai
            // 
            txtHMConLai.Font = new Font("Segoe UI", 12F);
            txtHMConLai.Location = new Point(236, 270);
            txtHMConLai.Name = "txtHMConLai";
            txtHMConLai.Size = new Size(332, 39);
            txtHMConLai.TabIndex = 6;
            // 
            // txtTinhTrang
            // 
            txtTinhTrang.Font = new Font("Segoe UI", 12F);
            txtTinhTrang.Location = new Point(236, 344);
            txtTinhTrang.Name = "txtTinhTrang";
            txtTinhTrang.Size = new Size(332, 39);
            txtTinhTrang.TabIndex = 7;
            // 
            // txtGiaTriHM
            // 
            txtGiaTriHM.Font = new Font("Segoe UI", 12F);
            txtGiaTriHM.Location = new Point(236, 135);
            txtGiaTriHM.Name = "txtGiaTriHM";
            txtGiaTriHM.Size = new Size(332, 39);
            txtGiaTriHM.TabIndex = 8;
            // 
            // txtTongChi
            // 
            txtTongChi.Font = new Font("Segoe UI", 12F);
            txtTongChi.Location = new Point(236, 201);
            txtTongChi.Name = "txtTongChi";
            txtTongChi.Size = new Size(332, 39);
            txtTongChi.TabIndex = 9;
            // 
            // cboTenHM
            // 
            cboTenHM.Font = new Font("Segoe UI", 12F);
            cboTenHM.FormattingEnabled = true;
            cboTenHM.Location = new Point(237, 74);
            cboTenHM.Name = "cboTenHM";
            cboTenHM.Size = new Size(331, 40);
            cboTenHM.TabIndex = 10;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(44, 533);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(793, 301);
            dataGridView1.TabIndex = 16;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Font = new Font("Segoe UI", 12F);
            btnTimKiem.Location = new Point(670, 74);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(167, 53);
            btnTimKiem.TabIndex = 17;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            btnThoat.Font = new Font("Segoe UI", 12F);
            btnThoat.Location = new Point(670, 454);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(167, 53);
            btnThoat.TabIndex = 15;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Segoe UI", 12F);
            btnThem.Location = new Point(670, 148);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(167, 53);
            btnThem.TabIndex = 18;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Font = new Font("Segoe UI", 12F);
            btnSua.Location = new Point(670, 222);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(167, 53);
            btnSua.TabIndex = 19;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Segoe UI", 12F);
            btnXoa.Location = new Point(670, 376);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(167, 53);
            btnXoa.TabIndex = 20;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            btnLuu.Font = new Font("Segoe UI", 12F);
            btnLuu.Location = new Point(670, 296);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(167, 53);
            btnLuu.TabIndex = 21;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            // 
            // FrmHanMuc
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(890, 883);
            Controls.Add(btnLuu);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(btnTimKiem);
            Controls.Add(dataGridView1);
            Controls.Add(btnThoat);
            Controls.Add(cboTenHM);
            Controls.Add(txtTongChi);
            Controls.Add(txtGiaTriHM);
            Controls.Add(txtTinhTrang);
            Controls.Add(txtHMConLai);
            Controls.Add(lblTinhTrang);
            Controls.Add(lblHMConLai);
            Controls.Add(lblTongChi);
            Controls.Add(lblGiaTriHM);
            Controls.Add(lblLoaiChiTieu);
            Controls.Add(lblTieude);
            Name = "FrmHanMuc";
            Text = "FrmHanMuc";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieude;
        private Label lblLoaiChiTieu;
        private Label lblGiaTriHM;
        private Label lblTongChi;
        private Label lblHMConLai;
        private Label lblTinhTrang;
        private TextBox txtHMConLai;
        private TextBox txtTinhTrang;
        private TextBox txtGiaTriHM;
        private TextBox txtTongChi;
        private ComboBox cboTenHM;
        private DataGridView dataGridView1;
        private Button btnTimKiem;
        private Button btnThoat;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLuu;
    }
}