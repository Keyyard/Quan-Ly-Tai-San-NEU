namespace Quan_Ly_Tai_San
{
    partial class FrmSignUp
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
            lblSignUp = new Label();
            lblUsername = new Label();
            lblEmail = new Label();
            lblPassword = new Label();
            txtUsername = new TextBox();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            btnSignUp = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblSignUp
            // 
            lblSignUp.AutoSize = true;
            lblSignUp.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblSignUp.Location = new Point(258, 9);
            lblSignUp.Name = "lblSignUp";
            lblSignUp.Size = new Size(324, 41);
            lblSignUp.TabIndex = 0;
            lblSignUp.Text = "ĐĂNG KÝ TÀI KHOẢN";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 12F);
            lblUsername.Location = new Point(65, 75);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(133, 32);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username: ";
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
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 12F);
            lblPassword.Location = new Point(65, 200);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(123, 32);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password: ";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.Location = new Point(232, 75);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(419, 39);
            txtUsername.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.Location = new Point(232, 135);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(419, 39);
            txtEmail.TabIndex = 5;
            txtEmail.Text = "nguyenvana@gmail.com";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(232, 200);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(419, 39);
            txtPassword.TabIndex = 6;
            // 
            // btnSignUp
            // 
            btnSignUp.Font = new Font("Segoe UI", 12F);
            btnSignUp.Location = new Point(123, 288);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(160, 50);
            btnSignUp.TabIndex = 7;
            btnSignUp.Text = "Sign Up";
            btnSignUp.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 12F);
            btnCancel.Location = new Point(472, 288);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(160, 50);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnThoat_Click;
            // 
            // FrmSignUp
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSignUp);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(lblEmail);
            Controls.Add(lblUsername);
            Controls.Add(lblSignUp);
            Name = "FrmSignUp";
            Text = "FrmDangKy";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSignUp;
        private Label lblUsername;
        private Label lblEmail;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnSignUp;
        private Button btnCancel;
    }
}