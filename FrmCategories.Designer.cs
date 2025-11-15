namespace Quan_Ly_Tai_San
{
    partial class FrmCategories
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
            lblCategories = new Label();
            lblType = new Label();
            lblName = new Label();
            lblDescription = new Label();
            txtDescription = new RichTextBox();
            txtName = new TextBox();
            cboType = new ComboBox();
            btnEdit = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            btnBack = new Button();
            btnRefresh = new Button();
            dataCategories = new DataGridView();
            txtLimit = new TextBox();
            lblLimit = new Label();
            ((System.ComponentModel.ISupportInitialize)dataCategories).BeginInit();
            SuspendLayout();
            // 
            // lblCategories
            // 
            lblCategories.AutoSize = true;
            lblCategories.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblCategories.Location = new Point(278, 14);
            lblCategories.Name = "lblCategories";
            lblCategories.Size = new Size(168, 41);
            lblCategories.TabIndex = 0;
            lblCategories.Text = "Expense Categories";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 12F);
            lblType.Location = new Point(42, 70);
            lblType.Name = "lblType";
            lblType.Size = new Size(77, 32);
            lblType.TabIndex = 1;
            lblType.Text = "Type: ";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F);
            lblName.Location = new Point(42, 131);
            lblName.Name = "lblName";
            lblName.Size = new Size(90, 32);
            lblName.TabIndex = 2;
            lblName.Text = "Name: ";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 12F);
            lblDescription.Location = new Point(42, 264);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(147, 32);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "Description: ";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(201, 278);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(357, 144);
            txtDescription.TabIndex = 4;
            txtDescription.Text = "";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 12F);
            txtName.Location = new Point(196, 136);
            txtName.Name = "txtName";
            txtName.Size = new Size(362, 39);
            txtName.TabIndex = 5;
            // 
            // cboType
            // 
            cboType.Font = new Font("Segoe UI", 12F);
            cboType.FormattingEnabled = true;
            cboType.Location = new Point(196, 70);
            cboType.Name = "cboType";
            cboType.Size = new Size(362, 40);
            cboType.TabIndex = 6;
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Segoe UI", 12F);
            btnEdit.Location = new Point(619, 150);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(169, 55);
            btnEdit.TabIndex = 7;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 12F);
            btnDelete.Location = new Point(619, 229);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(169, 55);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 12F);
            btnAdd.Location = new Point(619, 70);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(169, 55);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Segoe UI", 12F);
            btnBack.Location = new Point(619, 315);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(169, 55);
            btnBack.TabIndex = 10;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Font = new Font("Segoe UI", 12F);
            btnRefresh.Location = new Point(619, 390);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(169, 55);
            btnRefresh.TabIndex = 15;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dataCategories
            // 
            dataCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataCategories.Location = new Point(42, 454);
            dataCategories.Name = "dataCategories";
            dataCategories.RowHeadersWidth = 62;
            dataCategories.Size = new Size(746, 250);
            dataCategories.TabIndex = 11;
            // 
            // txtLimit
            // 
            txtLimit.Font = new Font("Segoe UI", 12F);
            txtLimit.Location = new Point(196, 201);
            txtLimit.Name = "txtLimit";
            txtLimit.Size = new Size(362, 39);
            txtLimit.TabIndex = 13;
            // 
            // lblLimit
            // 
            lblLimit.AutoSize = true;
            lblLimit.Font = new Font("Segoe UI", 12F);
            lblLimit.Location = new Point(42, 196);
            lblLimit.Name = "lblLimit";
            lblLimit.Size = new Size(78, 32);
            lblLimit.TabIndex = 12;
            lblLimit.Text = "Limit: ";
            // 
            // FrmCategories
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(821, 726);
            Controls.Add(txtLimit);
            Controls.Add(lblLimit);
            Controls.Add(dataCategories);
            Controls.Add(btnRefresh);
            Controls.Add(btnBack);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(cboType);
            Controls.Add(txtName);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(lblName);
            Controls.Add(lblType);
            Controls.Add(lblCategories);
            Name = "FrmCategories";
            Text = "Manage Categories";
            ((System.ComponentModel.ISupportInitialize)dataCategories).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCategories;
        private Label lblType;
        private Label lblName;
        private Label lblDescription;
        private RichTextBox txtDescription;
        private TextBox txtName;
        private ComboBox cboType;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnAdd;
        private Button btnBack;
        private Button btnRefresh;
        private DataGridView dataCategories;
        private TextBox txtLimit;
        private Label lblLimit;
    }
}