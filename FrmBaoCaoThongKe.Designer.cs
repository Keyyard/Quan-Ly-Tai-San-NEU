namespace Quan_Ly_Tai_San
{
    partial class FrmBaoCaoThongKe
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
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTieuDe.Location = new Point(330, 24);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(312, 41);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "BÁO CÁO THỐNG KÊ";
            // 
            // FrmBaoCaoThongKe
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(963, 450);
            Controls.Add(lblTieuDe);
            Name = "FrmBaoCaoThongKe";
            Text = "FrmBaoCaoThongKe";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
    }
}