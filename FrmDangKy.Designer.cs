namespace Quan_Ly_Tai_San
{
    partial class FrmDangKy
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
            lblTenTK = new Label();
            lblEmail = new Label();
            lblMatKhau = new Label();
            txtTenDangNhap = new TextBox();
            txtEmail = new TextBox();
            txtMatKhau = new TextBox();
            btnDangKy = new Button();
            btnThoat = new Button();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTieuDe.Location = new Point(258, 9);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(324, 41);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "ĐĂNG KÝ TÀI KHOẢN";
            // 
            // lblTenTK
            // 
            lblTenTK.AutoSize = true;
            lblTenTK.Font = new Font("Segoe UI", 12F);
            lblTenTK.Location = new Point(65, 75);
            lblTenTK.Name = "lblTenTK";
            lblTenTK.Size = new Size(170, 32);
            lblTenTK.TabIndex = 1;
            lblTenTK.Text = "Tên tài khoản: ";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 12F);
            lblEmail.Location = new Point(65, 135);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(83, 32);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email: ";
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Font = new Font("Segoe UI", 12F);
            lblMatKhau.Location = new Point(65, 200);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(127, 32);
            lblMatKhau.TabIndex = 3;
            lblMatKhau.Text = "Mật khẩu: ";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(232, 75);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(419, 31);
            txtTenDangNhap.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(232, 135);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(419, 31);
            txtEmail.TabIndex = 5;
            txtEmail.Text = "nguyenvana@gmail.com";
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(232, 200);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new Size(419, 31);
            txtMatKhau.TabIndex = 6;
            // 
            // btnDangKy
            // 
            btnDangKy.Font = new Font("Segoe UI", 12F);
            btnDangKy.Location = new Point(123, 288);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(179, 68);
            btnDangKy.TabIndex = 7;
            btnDangKy.Text = "Đăng ký";
            btnDangKy.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            btnThoat.Font = new Font("Segoe UI", 12F);
            btnThoat.Location = new Point(472, 288);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(179, 68);
            btnThoat.TabIndex = 8;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // FrmDangKy
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnThoat);
            Controls.Add(btnDangKy);
            Controls.Add(txtMatKhau);
            Controls.Add(txtEmail);
            Controls.Add(txtTenDangNhap);
            Controls.Add(lblMatKhau);
            Controls.Add(lblEmail);
            Controls.Add(lblTenTK);
            Controls.Add(lblTieuDe);
            Name = "FrmDangKy";
            Text = "FrmDangKy";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
        private Label lblTenTK;
        private Label lblEmail;
        private Label lblMatKhau;
        private TextBox txtTenDangNhap;
        private TextBox txtEmail;
        private TextBox txtMatKhau;
        private Button btnDangKy;
        private Button btnThoat;
    }
}