namespace Quan_Ly_Tai_San
{
    partial class FrmTransactionHistory
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
            lblHistory = new Label();
            lblType = new Label();
            lblCategory = new Label();
            lblBalance = new Label();
            lblDate = new Label();
            lblDescription = new Label();
            txtBalance = new TextBox();
            txtDescription = new RichTextBox();
            date = new DateTimePicker();
            cboType = new ComboBox();
            cboCategory = new ComboBox();
            btnSearch = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnBack = new Button();
            btnRefresh = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblHistory
            // 
            lblHistory.AutoSize = true;
            lblHistory.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblHistory.Location = new Point(229, 28);
            lblHistory.Name = "lblHistory";
            lblHistory.Size = new Size(369, 41);
            lblHistory.TabIndex = 0;
            lblHistory.Text = "TRANSACTION HISTORY";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 12F);
            lblType.Location = new Point(44, 82);
            lblType.Name = "lblType";
            lblType.Size = new Size(77, 32);
            lblType.TabIndex = 1;
            lblType.Text = "Type: ";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 12F);
            lblCategory.Location = new Point(44, 146);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(122, 32);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Category: ";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Font = new Font("Segoe UI", 12F);
            lblBalance.Location = new Point(44, 219);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(108, 32);
            lblBalance.TabIndex = 3;
            lblBalance.Text = "Balance: ";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 12F);
            lblDate.Location = new Point(44, 285);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(69, 32);
            lblDate.TabIndex = 4;
            lblDate.Text = "Date:";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 12F);
            lblDescription.Location = new Point(44, 353);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(154, 32);
            lblDescription.TabIndex = 5;
            lblDescription.Text = "Description:  ";
            // 
            // txtBalance
            // 
            txtBalance.Font = new Font("Segoe UI", 12F);
            txtBalance.Location = new Point(202, 219);
            txtBalance.Name = "txtBalance";
            txtBalance.Size = new Size(337, 39);
            txtBalance.TabIndex = 6;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(202, 353);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(337, 144);
            txtDescription.TabIndex = 7;
            txtDescription.Text = "";
            // 
            // date
            // 
            date.Font = new Font("Segoe UI", 12F);
            date.Format = DateTimePickerFormat.Short;
            date.Location = new Point(202, 285);
            date.Name = "date";
            date.Size = new Size(337, 39);
            date.TabIndex = 8;
            // 
            // cboType
            // 
            cboType.Font = new Font("Segoe UI", 12F);
            cboType.FormattingEnabled = true;
            cboType.Location = new Point(202, 82);
            cboType.Name = "cboType";
            cboType.Size = new Size(337, 40);
            cboType.TabIndex = 9;
            cboType.SelectedIndexChanged += cboType_SelectedIndexChanged;
            // 
            // cboCategory
            // 
            cboCategory.Font = new Font("Segoe UI", 12F);
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(202, 146);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(337, 40);
            cboCategory.TabIndex = 10;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 12F);
            btnSearch.Location = new Point(591, 82);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(174, 53);
            btnSearch.TabIndex = 11;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Segoe UI", 12F);
            btnEdit.Location = new Point(591, 161);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(174, 53);
            btnEdit.TabIndex = 12;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 12F);
            btnDelete.Location = new Point(591, 245);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(174, 53);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Segoe UI", 12F);
            btnBack.Location = new Point(591, 332);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(174, 53);
            btnBack.TabIndex = 14;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Font = new Font("Segoe UI", 12F);
            btnRefresh.Location = new Point(591, 400);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(174, 53);
            btnRefresh.TabIndex = 16;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(74, 536);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(681, 283);
            dataGridView1.TabIndex = 15;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // FrmTransactionHistory
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 840);
            Controls.Add(dataGridView1);
            Controls.Add(btnRefresh);
            Controls.Add(btnBack);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnSearch);
            Controls.Add(cboCategory);
            Controls.Add(cboType);
            Controls.Add(date);
            Controls.Add(txtDescription);
            Controls.Add(txtBalance);
            Controls.Add(lblDescription);
            Controls.Add(lblDate);
            Controls.Add(lblBalance);
            Controls.Add(lblCategory);
            Controls.Add(lblType);
            Controls.Add(lblHistory);
            Name = "FrmTransactionHistory";
            Text = "Transaction History";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHistory;
        private Label lblType;
        private Label lblCategory;
        private Label lblBalance;
        private Label lblDate;
        private Label lblDescription;
        private TextBox txtBalance;
        private RichTextBox txtDescription;
        private DateTimePicker date;
        private ComboBox cboType;
        private ComboBox cboCategory;
        private Button btnSearch;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnBack;
        private Button btnRefresh;
        private DataGridView dataGridView1;
    }
}