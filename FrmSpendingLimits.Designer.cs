namespace Quan_Ly_Tai_San
{
    partial class FrmSpendingLimits
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
            lblSpendingLimit = new Label();
            lblType = new Label();
            lblLimit = new Label();
            lblTotal = new Label();
            lblRemaining = new Label();
            lblStatus = new Label();
            txtRemaining = new TextBox();
            txtLimit = new TextBox();
            txtTongChi = new TextBox();
            cboType = new ComboBox();
            dataSpendingLimit = new DataGridView();
            btnSearch = new Button();
            btnBack = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            txtStatus = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataSpendingLimit).BeginInit();
            SuspendLayout();
            // 
            // lblSpendingLimit
            // 
            lblSpendingLimit.AutoSize = true;
            lblSpendingLimit.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblSpendingLimit.Location = new Point(291, 9);
            lblSpendingLimit.Name = "lblSpendingLimit";
            lblSpendingLimit.Size = new Size(277, 41);
            lblSpendingLimit.TabIndex = 0;
            lblSpendingLimit.Text = "SPENDING LIMITS";
            lblSpendingLimit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 12F);
            lblType.Location = new Point(31, 74);
            lblType.Name = "lblType";
            lblType.Size = new Size(77, 32);
            lblType.TabIndex = 1;
            lblType.Text = "Type: ";
            // 
            // lblLimit
            // 
            lblLimit.AutoSize = true;
            lblLimit.Font = new Font("Segoe UI", 12F);
            lblLimit.Location = new Point(31, 135);
            lblLimit.Name = "lblLimit";
            lblLimit.Size = new Size(168, 32);
            lblLimit.TabIndex = 2;
            lblLimit.Text = "Limit amount: ";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F);
            lblTotal.Location = new Point(31, 201);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(77, 32);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "Total: ";
            // 
            // lblRemaining
            // 
            lblRemaining.AutoSize = true;
            lblRemaining.Font = new Font("Segoe UI", 12F);
            lblRemaining.Location = new Point(31, 270);
            lblRemaining.Name = "lblRemaining";
            lblRemaining.Size = new Size(139, 32);
            lblRemaining.TabIndex = 4;
            lblRemaining.Text = "Remaining: ";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 12F);
            lblStatus.Location = new Point(31, 344);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(90, 32);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "Status: ";
            // 
            // txtRemaining
            // 
            txtRemaining.Font = new Font("Segoe UI", 12F);
            txtRemaining.Location = new Point(236, 270);
            txtRemaining.Name = "txtRemaining";
            txtRemaining.Size = new Size(332, 39);
            txtRemaining.TabIndex = 6;
            // 
            // txtLimit
            // 
            txtLimit.Font = new Font("Segoe UI", 12F);
            txtLimit.Location = new Point(236, 135);
            txtLimit.Name = "txtLimit";
            txtLimit.Size = new Size(332, 39);
            txtLimit.TabIndex = 8;
            // 
            // txtTongChi
            // 
            txtTongChi.Font = new Font("Segoe UI", 12F);
            txtTongChi.Location = new Point(236, 201);
            txtTongChi.Name = "txtTongChi";
            txtTongChi.Size = new Size(332, 39);
            txtTongChi.TabIndex = 9;
            // 
            // cboType
            // 
            cboType.Font = new Font("Segoe UI", 12F);
            cboType.FormattingEnabled = true;
            cboType.Location = new Point(237, 74);
            cboType.Name = "cboType";
            cboType.Size = new Size(331, 40);
            cboType.TabIndex = 10;
            // 
            // dataSpendingLimit
            // 
            dataSpendingLimit.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataSpendingLimit.Location = new Point(31, 429);
            dataSpendingLimit.Name = "dataSpendingLimit";
            dataSpendingLimit.RowHeadersWidth = 62;
            dataSpendingLimit.Size = new Size(793, 301);
            dataSpendingLimit.TabIndex = 16;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 12F);
            btnSearch.Location = new Point(670, 74);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(160, 50);
            btnSearch.TabIndex = 17;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Segoe UI", 12F);
            btnBack.Location = new Point(670, 305);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(160, 50);
            btnBack.TabIndex = 15;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnThoat_Click;
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Segoe UI", 12F);
            btnEdit.Location = new Point(670, 148);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(160, 50);
            btnEdit.TabIndex = 18;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 12F);
            btnDelete.Location = new Point(670, 222);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(160, 50);
            btnDelete.TabIndex = 19;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // txtStatus
            // 
            txtStatus.Font = new Font("Segoe UI", 12F);
            txtStatus.Location = new Point(236, 344);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(332, 39);
            txtStatus.TabIndex = 7;
            // 
            // FrmSpendingLimits
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(890, 759);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnSearch);
            Controls.Add(dataSpendingLimit);
            Controls.Add(btnBack);
            Controls.Add(cboType);
            Controls.Add(txtTongChi);
            Controls.Add(txtLimit);
            Controls.Add(txtStatus);
            Controls.Add(txtRemaining);
            Controls.Add(lblStatus);
            Controls.Add(lblRemaining);
            Controls.Add(lblTotal);
            Controls.Add(lblLimit);
            Controls.Add(lblType);
            Controls.Add(lblSpendingLimit);
            Name = "FrmSpendingLimits";
            Text = "FrmHanMuc";
            ((System.ComponentModel.ISupportInitialize)dataSpendingLimit).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSpendingLimit;
        private Label lblType;
        private Label lblLimit;
        private Label lblTotal;
        private Label lblRemaining;
        private Label lblStatus;
        private TextBox txtRemaining;
        private TextBox txtLimit;
        private TextBox txtTongChi;
        private ComboBox cboType;
        private DataGridView dataSpendingLimit;
        private Button btnSearch;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnBack;
        private TextBox txtStatus;
    }
}