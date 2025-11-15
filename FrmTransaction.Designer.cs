namespace Quan_Ly_Tai_San
{
    partial class FrmTransaction
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
            lblType = new Label();
            lblCategory = new Label();
            lblDate = new Label();
            lblDescription = new Label();
            cboType = new ComboBox();
            cboCategory = new ComboBox();
            date = new DateTimePicker();
            btnAdd = new Button();
            btnBack = new Button();
            gridTransaction = new DataGridView();
            lblBalance = new Label();
            txtDescription = new RichTextBox();
            txtBalance = new TextBox();
            lblBudget = new Label();
            progressBar1 = new ProgressBar();
            lblProgress = new Label();
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
            lblTransaction.Text = "TRANSACTION";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 12F);
            lblType.Location = new Point(48, 77);
            lblType.Name = "lblType";
            lblType.Size = new Size(77, 32);
            lblType.TabIndex = 2;
            lblType.Text = "Type: ";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 12F);
            lblCategory.Location = new Point(48, 155);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(122, 32);
            lblCategory.TabIndex = 3;
            lblCategory.Text = "Category: ";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 12F);
            lblDate.Location = new Point(42, 297);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(76, 32);
            lblDate.TabIndex = 4;
            lblDate.Text = "Date: ";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 12F);
            lblDescription.Location = new Point(42, 379);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(147, 32);
            lblDescription.TabIndex = 5;
            lblDescription.Text = "Description: ";
            // 
            // cboType
            // 
            cboType.Font = new Font("Segoe UI", 12F);
            cboType.FormattingEnabled = true;
            cboType.Location = new Point(203, 83);
            cboType.Name = "cboType";
            cboType.Size = new Size(484, 40);
            cboType.TabIndex = 8;
            cboType.Text = "Chi tiêu";
            cboType.SelectedIndexChanged += cboType_SelectedIndexChanged;
            // 
            // cboCategory
            // 
            cboCategory.Font = new Font("Segoe UI", 12F);
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(203, 155);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(484, 40);
            cboCategory.TabIndex = 9;
            cboCategory.Text = "Tiền ăn sáng";
            cboCategory.SelectedIndexChanged += cboCategory_SelectedIndexChanged;
            // 
            // date
            // 
            date.Font = new Font("Segoe UI", 12F);
            date.Format = DateTimePickerFormat.Short;
            date.Location = new Point(203, 297);
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
            // gridTransaction
            // 
            gridTransaction.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridTransaction.Location = new Point(48, 556);
            gridTransaction.Name = "gridTransaction";
            gridTransaction.RowHeadersWidth = 62;
            gridTransaction.Size = new Size(909, 337);
            gridTransaction.TabIndex = 16;
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Font = new Font("Segoe UI", 12F);
            lblBalance.Location = new Point(48, 221);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(96, 32);
            lblBalance.TabIndex = 17;
            lblBalance.Text = "Balance";
            // 
            // txtBalance
            // 
            txtBalance.Font = new Font("Segoe UI", 12F);
            txtBalance.Location = new Point(203, 221);
            txtBalance.Name = "txtBalance";
            txtBalance.ReadOnly = true;
            txtBalance.Size = new Size(484, 39);
            txtBalance.TabIndex = 21;
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 12F);
            txtDescription.Location = new Point(203, 379);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(484, 100);
            txtDescription.TabIndex = 22;
            // 
            // lblBudget
            // 
            lblBudget.Font = new Font("Segoe UI", 12F);
            lblBudget.Location = new Point(48, 270);
            lblBudget.Name = "lblBudget";
            lblBudget.Size = new Size(100, 32);
            lblBudget.TabIndex = 18;
            lblBudget.Text = "Budget: ";
            lblBudget.Visible = false;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(203, 300);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(484, 23);
            progressBar1.TabIndex = 19;
            progressBar1.Visible = false;
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Font = new Font("Segoe UI", 12F);
            lblProgress.Location = new Point(48, 330);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(100, 32);
            lblProgress.TabIndex = 20;
            lblProgress.Text = "Progress: ";
            lblProgress.Visible = false;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 12F);
            lblType.Location = new Point(48, 77);
            lblType.Name = "lblType";
            lblType.Size = new Size(77, 32);
            lblType.TabIndex = 2;
            lblType.Text = "Type: ";
            lblType.Visible = true;
            // 
            // FrmTransaction
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1011, 934);
            Controls.Add(txtBalance);
            Controls.Add(txtDescription);
            Controls.Add(lblBalance);
            Controls.Add(lblBudget);
            Controls.Add(progressBar1);
            Controls.Add(lblProgress);
            Controls.Add(gridTransaction);
            Controls.Add(btnBack);
            Controls.Add(btnAdd);
            Controls.Add(date);
            Controls.Add(cboCategory);
            Controls.Add(cboType);
            Controls.Add(lblDescription);
            Controls.Add(lblDate);
            Controls.Add(lblCategory);
            Controls.Add(lblType);
            Controls.Add(lblTransaction);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(5, 6, 5, 6);
            Name = "FrmTransaction";
            Text = "Add Transaction";
            ((System.ComponentModel.ISupportInitialize)gridTransaction).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTransaction;
        private Label lblType;
        private Label lblCategory;
        private Label lblDate;
        private Label lblDescription;
        private ComboBox cboType;
        private ComboBox cboCategory;
        private DateTimePicker date;
        private Button btnAdd;
        private Button btnBack;
        private DataGridView gridTransaction;
        private Label lblBalance;
        private RichTextBox txtDescription;
        private TextBox txtBalance;
        private Label lblBudget;
        private ProgressBar progressBar1;
        private Label lblProgress;
    }
}