namespace Quan_Ly_Tai_San
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblTenDN = new Label();
            lblMatKhau = new Label();
            txtTenDN = new TextBox();
            txtMatKhau = new TextBox();
            btnDangNhap = new Button();
            btnThoat = new Button();
            btnDangKy = new Button();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTieuDe.Location = new Point(238, 9);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(335, 67);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "ĐĂNG NHẬP";
            // 
            // lblTenDN
            // 
            lblTenDN.AutoSize = true;
            lblTenDN.Font = new Font("Segoe UI", 12F);
            lblTenDN.Location = new Point(33, 110);
            lblTenDN.Name = "lblTenDN";
            lblTenDN.Size = new Size(197, 32);
            lblTenDN.TabIndex = 1;
            lblTenDN.Text = "Tên đăng nhập: ";
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Font = new Font("Segoe UI", 12F);
            lblMatKhau.Location = new Point(33, 186);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(135, 32);
            lblMatKhau.TabIndex = 2;
            lblMatKhau.Text = "Mật khẩu: ";
            // 
            // txtTenDN
            // 
            txtTenDN.Font = new Font("Segoe UI", 12F);
            txtTenDN.Location = new Point(236, 110);
            txtTenDN.Name = "txtTenDN";
            txtTenDN.Size = new Size(453, 39);
            txtTenDN.TabIndex = 3;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Segoe UI", 12F);
            txtMatKhau.Location = new Point(238, 186);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new Size(453, 39);
            txtMatKhau.TabIndex = 4;
            // 
            // btnDangNhap
            // 
            btnDangNhap.Font = new Font("Segoe UI", 12F);
            btnDangNhap.Location = new Point(53, 286);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(160, 50);
            btnDangNhap.TabIndex = 6;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            btnThoat.Font = new Font("Segoe UI", 12F);
            btnThoat.Location = new Point(550, 286);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(160, 50);
            btnThoat.TabIndex = 7;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnDangKy
            // 
            btnDangKy.Font = new Font("Segoe UI", 12F);
            btnDangKy.Location = new Point(298, 286);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(160, 50);
            btnDangKy.TabIndex = 8;
            btnDangKy.Text = "Đăng ký";
            btnDangKy.UseVisualStyleBackColor = true;
            btnDangKy.Click += btnDangKy_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDangKy);
            Controls.Add(btnThoat);
            Controls.Add(btnDangNhap);
            Controls.Add(txtMatKhau);
            Controls.Add(txtTenDN);
            Controls.Add(lblMatKhau);
            Controls.Add(lblTenDN);
            Controls.Add(lblTieuDe);
            Name = "FrmLogin";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
        private Label lblTenDN;
        private Label lblMatKhau;
        private TextBox txtTenDN;
        private TextBox txtMatKhau;
        private Button btnDangNhap;
        private Button btnThoat;
        private Button btnDangKy;
    }
}
