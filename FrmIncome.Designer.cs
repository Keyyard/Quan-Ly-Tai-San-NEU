namespace Quan_Ly_Tai_San
{
    partial class FrmIncome
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
            lblTransaction = new Label();
            lblCategory = new Label();
            lblAmount = new Label();
            lblDate = new Label();
            lblDescription = new Label();
            cboCategory = new ComboBox();
            date = new DateTimePicker();
            btnAdd = new Button();
            btnBack = new Button();
            btnRefresh = new Button();
            gridTransaction = new DataGridView();
            lblBalance = new Label();
            txtDescription = new RichTextBox();
            txtBalance = new TextBox();
            txtAmount = new TextBox();
            ((System.ComponentModel.ISupportInitialize)gridTransaction).BeginInit();
            SuspendLayout();
            // 
            // lblTransaction
            // 
            lblTransaction.AutoSize = true;
            lblTransaction.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTransaction.Location = new Point(402, 19);
            lblTransaction.Margin = new Padding(5, 0, 5, 0);
            lblTransaction.Name = "lblTransaction";
            lblTransaction.Size = new Size(233, 41);
            lblTransaction.TabIndex = 0;
            lblTransaction.Text = "ADD INCOME";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 12F);
            lblCategory.Location = new Point(48, 77);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(122, 32);
            lblCategory.TabIndex = 3;
            lblCategory.Text = "Category: ";
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Font = new Font("Segoe UI", 12F);
            lblAmount.Location = new Point(48, 155);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(96, 32);
            lblAmount.TabIndex = 17;
            lblAmount.Text = "Amount";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 12F);
            lblDate.Location = new Point(42, 223);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(76, 32);
            lblDate.TabIndex = 4;
            lblDate.Text = "Date: ";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 12F);
            lblDescription.Location = new Point(42, 305);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(147, 32);
            lblDescription.TabIndex = 5;
            lblDescription.Text = "Description: ";
            // 
            // cboCategory
            // 
            cboCategory.Font = new Font("Segoe UI", 12F);
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(203, 83);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(484, 40);
            cboCategory.TabIndex = 9;
            // 
            // date
            // 
            date.Font = new Font("Segoe UI", 12F);
            date.Format = DateTimePickerFormat.Short;
            date.Location = new Point(203, 223);
            date.Name = "date";
            date.Size = new Size(484, 39);
            date.TabIndex = 10;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 12F);
            btnAdd.Location = new Point(778, 83);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(160, 50);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Segoe UI", 12F);
            btnBack.Location = new Point(778, 155);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(160, 50);
            btnBack.TabIndex = 15;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnCancel_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Font = new Font("Segoe UI", 12F);
            btnRefresh.Location = new Point(778, 227);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(160, 50);
            btnRefresh.TabIndex = 24;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // gridTransaction
            // 
            gridTransaction.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridTransaction.Location = new Point(48, 456);
            gridTransaction.Name = "gridTransaction";
            gridTransaction.RowHeadersWidth = 62;
            gridTransaction.Size = new Size(909, 337);
            gridTransaction.TabIndex = 16;
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Font = new Font("Segoe UI", 12F);
            lblBalance.Location = new Point(48, 380);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(96, 32);
            lblBalance.TabIndex = 17;
            lblBalance.Text = "Current Balance";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 12F);
            txtDescription.Location = new Point(203, 305);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(484, 60);
            txtDescription.TabIndex = 22;
            // 
            // txtBalance
            // 
            txtBalance.Font = new Font("Segoe UI", 12F);
            txtBalance.Location = new Point(203, 380);
            txtBalance.Name = "txtBalance";
            txtBalance.ReadOnly = true;
            txtBalance.Size = new Size(484, 39);
            txtBalance.TabIndex = 21;
            // 
            // txtAmount
            // 
            txtAmount.Font = new Font("Segoe UI", 12F);
            txtAmount.Location = new Point(203, 155);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(484, 39);
            txtAmount.TabIndex = 23;
            // 
            // FrmIncome
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1011, 834);
            Controls.Add(txtAmount);
            Controls.Add(txtBalance);
            Controls.Add(txtDescription);
            Controls.Add(lblBalance);
            Controls.Add(gridTransaction);
            Controls.Add(btnRefresh);
            Controls.Add(btnBack);
            Controls.Add(btnAdd);
            Controls.Add(date);
            Controls.Add(cboCategory);
            Controls.Add(lblDescription);
            Controls.Add(lblDate);
            Controls.Add(lblAmount);
            Controls.Add(lblCategory);
            Controls.Add(lblTransaction);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(5, 6, 5, 6);
            Name = "FrmIncome";
            Text = "Add Income";
            ((System.ComponentModel.ISupportInitialize)gridTransaction).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTransaction;
        private Label lblCategory;
        private Label lblAmount;
        private Label lblDate;
        private Label lblDescription;
        private ComboBox cboCategory;
        private DateTimePicker date;
        private Button btnAdd;
        private Button btnBack;
        private Button btnRefresh;
        private DataGridView gridTransaction;
        private Label lblBalance;
        private RichTextBox txtDescription;
        private TextBox txtBalance;
        private TextBox txtAmount;
    }
}