namespace Quan_Ly_Tai_San
{
    partial class FrmIncomeCategories
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
            lblName = new Label();
            lblDescription = new Label();
            txtDescription = new RichTextBox();
            txtName = new TextBox();
            btnEdit = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            btnBack = new Button();
            btnRefresh = new Button();
            dataCategories = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataCategories).BeginInit();
            SuspendLayout();
            // 
            // lblCategories
            // 
            lblCategories.AutoSize = true;
            lblCategories.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblCategories.Location = new Point(278, 14);
            lblCategories.Name = "lblCategories";
            lblCategories.Size = new Size(200, 41);
            lblCategories.TabIndex = 0;
            lblCategories.Text = "Income Categories";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F);
            lblName.Location = new Point(42, 70);
            lblName.Name = "lblName";
            lblName.Size = new Size(90, 32);
            lblName.TabIndex = 2;
            lblName.Text = "Name: ";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 12F);
            lblDescription.Location = new Point(42, 131);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(147, 32);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "Description: ";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(201, 145);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(357, 144);
            txtDescription.TabIndex = 4;
            txtDescription.Text = "";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 12F);
            txtName.Location = new Point(196, 75);
            txtName.Name = "txtName";
            txtName.Size = new Size(362, 39);
            txtName.TabIndex = 5;
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Segoe UI", 12F);
            btnEdit.Location = new Point(619, 75);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(169, 55);
            btnEdit.TabIndex = 7;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 12F);
            btnDelete.Location = new Point(619, 154);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(169, 55);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 12F);
            btnAdd.Location = new Point(619, 233);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(169, 55);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Segoe UI", 12F);
            btnBack.Location = new Point(619, 680);
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
            btnRefresh.Location = new Point(619, 755);
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
            dataCategories.Location = new Point(42, 320);
            dataCategories.Name = "dataCategories";
            dataCategories.RowHeadersWidth = 62;
            dataCategories.Size = new Size(746, 350);
            dataCategories.TabIndex = 11;
            dataCategories.SelectionChanged += dataCategories_SelectionChanged;
            // 
            // FrmIncomeCategories
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(821, 850);
            Controls.Add(dataCategories);
            Controls.Add(btnRefresh);
            Controls.Add(btnBack);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(txtName);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(lblName);
            Controls.Add(lblCategories);
            Name = "FrmIncomeCategories";
            Text = "Manage Income Categories";
            ((System.ComponentModel.ISupportInitialize)dataCategories).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCategories;
        private Label lblName;
        private Label lblDescription;
        private RichTextBox txtDescription;
        private TextBox txtName;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnAdd;
        private Button btnBack;
        private Button btnRefresh;
        private DataGridView dataCategories;
    }
}