namespace Quan_Ly_Tai_San
{
    partial class FrmSavings
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
            lblSavings = new Label();
            lblName = new Label();
            lblGoal = new Label();
            dataSavings = new DataGridView();
            txtName = new TextBox();
            txtGoal = new TextBox();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnDeposit = new Button();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dataSavings).BeginInit();
            SuspendLayout();
            // 
            // lblSavings
            // 
            lblSavings.AutoSize = true;
            lblSavings.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblSavings.Location = new Point(314, 20);
            lblSavings.Margin = new Padding(2, 0, 2, 0);
            lblSavings.Name = "lblSavings";
            lblSavings.Size = new Size(104, 35);
            lblSavings.TabIndex = 0;
            lblSavings.Text = "Savings";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F);
            lblName.Location = new Point(32, 69);
            lblName.Margin = new Padding(2, 0, 2, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(73, 28);
            lblName.TabIndex = 1;
            lblName.Text = "Name: ";
            // 
            // lblGoal
            // 
            lblGoal.AutoSize = true;
            lblGoal.Font = new Font("Segoe UI", 12F);
            lblGoal.Location = new Point(32, 118);
            lblGoal.Margin = new Padding(2, 0, 2, 0);
            lblGoal.Name = "lblGoal";
            lblGoal.Size = new Size(62, 28);
            lblGoal.TabIndex = 2;
            lblGoal.Text = "Goal: ";
            // 
            // dataSavings
            // 
            dataSavings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataSavings.Location = new Point(42, 162);
            dataSavings.Margin = new Padding(2, 2, 2, 2);
            dataSavings.Name = "dataSavings";
            dataSavings.RowHeadersWidth = 62;
            dataSavings.Size = new Size(392, 180);
            dataSavings.TabIndex = 3;
            dataSavings.SelectionChanged += dataSavings_SelectionChanged;
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 12F);
            txtName.Location = new Point(103, 73);
            txtName.Margin = new Padding(2, 2, 2, 2);
            txtName.Name = "txtName";
            txtName.Size = new Size(330, 34);
            txtName.TabIndex = 4;
            // 
            // txtGoal
            // 
            txtGoal.Font = new Font("Segoe UI", 12F);
            txtGoal.Location = new Point(104, 118);
            txtGoal.Margin = new Padding(2, 2, 2, 2);
            txtGoal.Name = "txtGoal";
            txtGoal.Size = new Size(330, 34);
            txtGoal.TabIndex = 5;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 12F);
            btnAdd.Location = new Point(471, 73);
            btnAdd.Margin = new Padding(2, 2, 2, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(130, 43);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Segoe UI", 12F);
            btnEdit.Location = new Point(471, 134);
            btnEdit.Margin = new Padding(2, 2, 2, 2);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(130, 43);
            btnEdit.TabIndex = 7;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 12F);
            btnDelete.Location = new Point(471, 202);
            btnDelete.Margin = new Padding(2, 2, 2, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(130, 43);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnDeposit
            // 
            btnDeposit.Font = new Font("Segoe UI", 12F);
            btnDeposit.Location = new Point(471, 202);
            btnDeposit.Margin = new Padding(2, 2, 2, 2);
            btnDeposit.Name = "btnDeposit";
            btnDeposit.Size = new Size(130, 43);
            btnDeposit.TabIndex = 10;
            btnDeposit.Text = "Deposit";
            btnDeposit.UseVisualStyleBackColor = true;
            btnDeposit.Click += btnDeposit_Click;
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Segoe UI", 12F);
            btnBack.Location = new Point(471, 256);
            btnBack.Margin = new Padding(2, 2, 2, 2);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(130, 43);
            btnBack.TabIndex = 9;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // FrmSavings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 360);
            Controls.Add(btnBack);
            Controls.Add(btnDeposit);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(txtGoal);
            Controls.Add(txtName);
            Controls.Add(dataSavings);
            Controls.Add(lblGoal);
            Controls.Add(lblName);
            Controls.Add(lblSavings);
            Margin = new Padding(2, 2, 2, 2);
            Name = "FrmSavings";
            Text = "Manage Savings";
            ((System.ComponentModel.ISupportInitialize)dataSavings).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSavings;
        private Label lblName;
        private Label lblGoal;
        private DataGridView dataSavings;
        private TextBox txtName;
        private TextBox txtGoal;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnDeposit;
        private Button btnBack;
    }
}