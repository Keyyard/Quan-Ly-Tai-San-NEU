namespace Quan_Ly_Tai_San
{
    partial class FrmTietKiem
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
            lblLoaiTietKiem = new Label();
            lblSoTien = new Label();
            lblTongHienNay = new Label();
            lblTienTrinh = new Label();
            prgbarTienTrinh = new ProgressBar();
            txtTongHienNay = new TextBox();
            txtSoTien = new TextBox();
            cboLoaiTietKiem = new ComboBox();
            btnThem = new Button();
            btnSua = new Button();
            btnLuu = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            dataTietKiem = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataTietKiem).BeginInit();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTieuDe.Location = new Point(335, 23);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(338, 41);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "DANH MỤC TIẾT KIỆM";
            // 
            // lblLoaiTietKiem
            // 
            lblLoaiTietKiem.AutoSize = true;
            lblLoaiTietKiem.Font = new Font("Segoe UI", 12F);
            lblLoaiTietKiem.Location = new Point(48, 77);
            lblLoaiTietKiem.Name = "lblLoaiTietKiem";
            lblLoaiTietKiem.Size = new Size(170, 32);
            lblLoaiTietKiem.TabIndex = 1;
            lblLoaiTietKiem.Text = "Loại tiết kiệm: ";
            // 
            // lblSoTien
            // 
            lblSoTien.AutoSize = true;
            lblSoTien.Font = new Font("Segoe UI", 12F);
            lblSoTien.Location = new Point(48, 147);
            lblSoTien.Name = "lblSoTien";
            lblSoTien.Size = new Size(101, 32);
            lblSoTien.TabIndex = 2;
            lblSoTien.Text = "Số tiền: ";
            // 
            // lblTongHienNay
            // 
            lblTongHienNay.AutoSize = true;
            lblTongHienNay.Font = new Font("Segoe UI", 12F);
            lblTongHienNay.Location = new Point(48, 210);
            lblTongHienNay.Name = "lblTongHienNay";
            lblTongHienNay.Size = new Size(180, 32);
            lblTongHienNay.TabIndex = 3;
            lblTongHienNay.Text = "Tổng hiện nay: ";
            // 
            // lblTienTrinh
            // 
            lblTienTrinh.AutoSize = true;
            lblTienTrinh.Font = new Font("Segoe UI", 12F);
            lblTienTrinh.Location = new Point(48, 282);
            lblTienTrinh.Name = "lblTienTrinh";
            lblTienTrinh.Size = new Size(129, 32);
            lblTienTrinh.TabIndex = 4;
            lblTienTrinh.Text = "Tiến trình: ";
            // 
            // prgbarTienTrinh
            // 
            prgbarTienTrinh.Location = new Point(233, 282);
            prgbarTienTrinh.Name = "prgbarTienTrinh";
            prgbarTienTrinh.Size = new Size(378, 34);
            prgbarTienTrinh.TabIndex = 6;
            // 
            // txtTongHienNay
            // 
            txtTongHienNay.Font = new Font("Segoe UI", 12F);
            txtTongHienNay.Location = new Point(233, 210);
            txtTongHienNay.Name = "txtTongHienNay";
            txtTongHienNay.Size = new Size(378, 39);
            txtTongHienNay.TabIndex = 7;
            // 
            // txtSoTien
            // 
            txtSoTien.Font = new Font("Segoe UI", 12F);
            txtSoTien.Location = new Point(233, 147);
            txtSoTien.Name = "txtSoTien";
            txtSoTien.Size = new Size(378, 39);
            txtSoTien.TabIndex = 8;
            // 
            // cboLoaiTietKiem
            // 
            cboLoaiTietKiem.Font = new Font("Segoe UI", 12F);
            cboLoaiTietKiem.FormattingEnabled = true;
            cboLoaiTietKiem.Location = new Point(230, 77);
            cboLoaiTietKiem.Name = "cboLoaiTietKiem";
            cboLoaiTietKiem.Size = new Size(381, 40);
            cboLoaiTietKiem.TabIndex = 9;
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Segoe UI", 12F);
            btnThem.Location = new Point(725, 77);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(196, 56);
            btnThem.TabIndex = 10;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Font = new Font("Segoe UI", 12F);
            btnSua.Location = new Point(725, 147);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(196, 56);
            btnSua.TabIndex = 11;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            btnLuu.Font = new Font("Segoe UI", 12F);
            btnLuu.Location = new Point(725, 222);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(196, 56);
            btnLuu.TabIndex = 12;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Segoe UI", 12F);
            btnXoa.Location = new Point(725, 293);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(196, 56);
            btnXoa.TabIndex = 13;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            btnThoat.Font = new Font("Segoe UI", 12F);
            btnThoat.Location = new Point(725, 366);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(196, 56);
            btnThoat.TabIndex = 14;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // dataTietKiem
            // 
            dataTietKiem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataTietKiem.Location = new Point(64, 448);
            dataTietKiem.Name = "dataTietKiem";
            dataTietKiem.RowHeadersWidth = 62;
            dataTietKiem.Size = new Size(857, 225);
            dataTietKiem.TabIndex = 15;
            // 
            // FrmTietKiem
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(978, 695);
            Controls.Add(dataTietKiem);
            Controls.Add(btnThoat);
            Controls.Add(btnXoa);
            Controls.Add(btnLuu);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(cboLoaiTietKiem);
            Controls.Add(txtSoTien);
            Controls.Add(txtTongHienNay);
            Controls.Add(prgbarTienTrinh);
            Controls.Add(lblTienTrinh);
            Controls.Add(lblTongHienNay);
            Controls.Add(lblSoTien);
            Controls.Add(lblLoaiTietKiem);
            Controls.Add(lblTieuDe);
            Name = "FrmTietKiem";
            Text = "FrmTietKiem";
            ((System.ComponentModel.ISupportInitialize)dataTietKiem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
        private Label lblLoaiTietKiem;
        private Label lblSoTien;
        private Label lblTongHienNay;
        private Label lblTienTrinh;
        private ProgressBar prgbarTienTrinh;
        private TextBox txtTongHienNay;
        private TextBox txtSoTien;
        private ComboBox cboLoaiTietKiem;
        private Button btnThem;
        private Button btnSua;
        private Button btnLuu;
        private Button btnXoa;
        private Button btnThoat;
        private DataGridView dataTietKiem;
    }
}