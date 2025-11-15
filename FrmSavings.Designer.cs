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
            btnSearch = new Button();
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
            lblSavings.Location = new Point(393, 25);
            lblSavings.Name = "lblSavings";
            lblSavings.Size = new Size(126, 41);
            lblSavings.TabIndex = 0;
            lblSavings.Text = "Savings";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F);
            lblName.Location = new Point(40, 86);
            lblName.Name = "lblName";
            lblName.Size = new Size(90, 32);
            lblName.TabIndex = 1;
            lblName.Text = "Name: ";
            // 
            // lblGoal
            // 
            lblGoal.AutoSize = true;
            lblGoal.Font = new Font("Segoe UI", 12F);
            lblGoal.Location = new Point(40, 147);
            lblGoal.Name = "lblGoal";
            lblGoal.Size = new Size(74, 32);
            lblGoal.TabIndex = 2;
            lblGoal.Text = "Goal: ";
            // 
            // dataSavings
            // 
            dataSavings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataSavings.Location = new Point(52, 203);
            dataSavings.Name = "dataSavings";
            dataSavings.RowHeadersWidth = 62;
            dataSavings.Size = new Size(490, 225);
            dataSavings.TabIndex = 3;
            dataSavings.SelectionChanged += dataSavings_SelectionChanged;
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 12F);
            txtName.Location = new Point(129, 91);
            txtName.Name = "txtName";
            txtName.Size = new Size(412, 39);
            txtName.TabIndex = 4;
            // 
            // txtGoal
            // 
            txtGoal.Font = new Font("Segoe UI", 12F);
            txtGoal.Location = new Point(130, 147);
            txtGoal.Name = "txtGoal";
            txtGoal.Size = new Size(412, 39);
            txtGoal.TabIndex = 5;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 12F);
            btnSearch.Location = new Point(589, 91);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(162, 54);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Segoe UI", 12F);
            btnEdit.Location = new Point(589, 168);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(162, 54);
            btnEdit.TabIndex = 7;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 12F);
            btnDelete.Location = new Point(589, 252);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(162, 54);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnDeposit
            // 
            btnDeposit.Font = new Font("Segoe UI", 12F);
            btnDeposit.Location = new Point(589, 252);
            btnDeposit.Name = "btnDeposit";
            btnDeposit.Size = new Size(162, 54);
            btnDeposit.TabIndex = 10;
            btnDeposit.Text = "Deposit";
            btnDeposit.UseVisualStyleBackColor = true;
            btnDeposit.Click += btnDeposit_Click;
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Segoe UI", 12F);
            btnBack.Location = new Point(589, 320);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(162, 54);
            btnBack.TabIndex = 9;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // FrmSavings
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(btnDeposit);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnSearch);
            Controls.Add(txtGoal);
            Controls.Add(txtName);
            Controls.Add(dataSavings);
            Controls.Add(lblGoal);
            Controls.Add(lblName);
            Controls.Add(lblSavings);
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
        private Button btnSearch;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnDeposit;
        private Button btnBack;
    }
}