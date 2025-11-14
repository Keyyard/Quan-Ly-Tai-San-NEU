namespace Quan_Ly_Tai_San
{
    partial class FrmThuChiCaNhan
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
            lblTieuDe = new Label();
            lblLoaiGD = new Label();
            lblLoaiChiTieu = new Label();
            lblNgayGD = new Label();
            lblGhiChu = new Label();
            cboLoaiGiaoDich = new ComboBox();
            cboLoaiCTTK = new ComboBox();
            dateNgayGiaoDich = new DateTimePicker();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLuu = new Button();
            btnThoat = new Button();
            gridThuChiCaNhan = new DataGridView();
            lblGiaTien = new Label();
            txtGhiChu = new RichTextBox();
            txtGiaTien = new TextBox();
            ((System.ComponentModel.ISupportInitialize)gridThuChiCaNhan).BeginInit();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTieuDe.Location = new Point(355, 20);
            lblTieuDe.Margin = new Padding(5, 0, 5, 0);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(465, 41);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "DANH MỤC THU CHI CÁ NHÂN";
            // 
            // lblLoaiGD
            // 
            lblLoaiGD.AutoSize = true;
            lblLoaiGD.Font = new Font("Segoe UI", 12F);
            lblLoaiGD.Location = new Point(48, 77);
            lblLoaiGD.Name = "lblLoaiGD";
            lblLoaiGD.Size = new Size(174, 32);
            lblLoaiGD.TabIndex = 2;
            lblLoaiGD.Text = "Loại giao dịch: ";
            // 
            // lblLoaiChiTieu
            // 
            lblLoaiChiTieu.AutoSize = true;
            lblLoaiChiTieu.Font = new Font("Segoe UI", 12F);
            lblLoaiChiTieu.Location = new Point(48, 155);
            lblLoaiChiTieu.Name = "lblLoaiChiTieu";
            lblLoaiChiTieu.Size = new Size(270, 32);
            lblLoaiChiTieu.TabIndex = 3;
            lblLoaiChiTieu.Text = "Loại chi tiêu/ Tiết kiệm: ";
            // 
            // lblNgayGD
            // 
            lblNgayGD.AutoSize = true;
            lblNgayGD.Font = new Font("Segoe UI", 12F);
            lblNgayGD.Location = new Point(42, 297);
            lblNgayGD.Name = "lblNgayGD";
            lblNgayGD.Size = new Size(187, 32);
            lblNgayGD.TabIndex = 4;
            lblNgayGD.Text = "Ngày giao dịch: ";
            // 
            // lblGhiChu
            // 
            lblGhiChu.AutoSize = true;
            lblGhiChu.Font = new Font("Segoe UI", 12F);
            lblGhiChu.Location = new Point(42, 379);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(108, 32);
            lblGhiChu.TabIndex = 5;
            lblGhiChu.Text = "Ghi chú: ";
            // 
            // cboLoaiGiaoDich
            // 
            cboLoaiGiaoDich.Font = new Font("Segoe UI", 12F);
            cboLoaiGiaoDich.FormattingEnabled = true;
            cboLoaiGiaoDich.Location = new Point(311, 83);
            cboLoaiGiaoDich.Name = "cboLoaiGiaoDich";
            cboLoaiGiaoDich.Size = new Size(484, 40);
            cboLoaiGiaoDich.TabIndex = 8;
            cboLoaiGiaoDich.Text = "Chi tiêu";
            // 
            // cboLoaiCTTK
            // 
            cboLoaiCTTK.Font = new Font("Segoe UI", 12F);
            cboLoaiCTTK.FormattingEnabled = true;
            cboLoaiCTTK.Location = new Point(311, 155);
            cboLoaiCTTK.Name = "cboLoaiCTTK";
            cboLoaiCTTK.Size = new Size(484, 40);
            cboLoaiCTTK.TabIndex = 9;
            cboLoaiCTTK.Text = "Tiền ăn sáng";
            // 
            // dateNgayGiaoDich
            // 
            dateNgayGiaoDich.Font = new Font("Segoe UI", 12F);
            dateNgayGiaoDich.Format = DateTimePickerFormat.Short;
            dateNgayGiaoDich.Location = new Point(311, 297);
            dateNgayGiaoDich.Name = "dateNgayGiaoDich";
            dateNgayGiaoDich.Size = new Size(484, 39);
            dateNgayGiaoDich.TabIndex = 10;
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Segoe UI", 12F);
            btnThem.Location = new Point(850, 83);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(160, 50);
            btnThem.TabIndex = 11;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Font = new Font("Segoe UI", 12F);
            btnSua.Location = new Point(850, 171);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(160, 50);
            btnSua.TabIndex = 12;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Segoe UI", 12F);
            btnXoa.Location = new Point(850, 353);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(160, 50);
            btnXoa.TabIndex = 13;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            btnLuu.Font = new Font("Segoe UI", 12F);
            btnLuu.Location = new Point(850, 262);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(160, 50);
            btnLuu.TabIndex = 14;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            btnThoat.Font = new Font("Segoe UI", 12F);
            btnThoat.Location = new Point(850, 440);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(160, 50);
            btnThoat.TabIndex = 15;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // gridThuChiCaNhan
            // 
            gridThuChiCaNhan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridThuChiCaNhan.Location = new Point(48, 556);
            gridThuChiCaNhan.Name = "gridThuChiCaNhan";
            gridThuChiCaNhan.RowHeadersWidth = 62;
            gridThuChiCaNhan.Size = new Size(962, 337);
            gridThuChiCaNhan.TabIndex = 16;
            // 
            // lblGiaTien
            // 
            lblGiaTien.AutoSize = true;
            lblGiaTien.Font = new Font("Segoe UI", 12F);
            lblGiaTien.Location = new Point(48, 221);
            lblGiaTien.Name = "lblGiaTien";
            lblGiaTien.Size = new Size(108, 32);
            lblGiaTien.TabIndex = 17;
            lblGiaTien.Text = "Giá tiền: ";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(311, 376);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(484, 144);
            txtGhiChu.TabIndex = 19;
            txtGhiChu.Text = "";
            // 
            // txtGiaTien
            // 
            txtGiaTien.Location = new Point(310, 225);
            txtGiaTien.Name = "txtGiaTien";
            txtGiaTien.Size = new Size(485, 39);
            txtGiaTien.TabIndex = 20;
            // 
            // FrmThuChiCaNhan
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1077, 934);
            Controls.Add(txtGiaTien);
            Controls.Add(txtGhiChu);
            Controls.Add(lblGiaTien);
            Controls.Add(gridThuChiCaNhan);
            Controls.Add(btnThoat);
            Controls.Add(btnLuu);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(dateNgayGiaoDich);
            Controls.Add(cboLoaiCTTK);
            Controls.Add(cboLoaiGiaoDich);
            Controls.Add(lblGhiChu);
            Controls.Add(lblNgayGD);
            Controls.Add(lblLoaiChiTieu);
            Controls.Add(lblLoaiGD);
            Controls.Add(lblTieuDe);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(5, 6, 5, 6);
            Name = "FrmThuChiCaNhan";
            Text = "FrmThuChiCaNhan";
            ((System.ComponentModel.ISupportInitialize)gridThuChiCaNhan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
        private Label lblTenGD;
        private Label lblLoaiGD;
        private Label lblLoaiChiTieu;
        private Label lblNgayGD;
        private Label lblGhiChu;
        private TextBox txtTenGD;
        private ComboBox cboLoaiGiaoDich;
        private ComboBox cboLoaiCTTK;
        private DateTimePicker dateNgayGiaoDich;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLuu;
        private Button btnThoat;
        private DataGridView gridThuChiCaNhan;
        private Label lblGiaTien;
        private RichTextBox txtGhiChu;
        private TextBox txtGiaTien;
    }
}