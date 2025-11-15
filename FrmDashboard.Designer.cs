namespace Quan_Ly_Tai_San
{
    partial class FrmDashboard
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
            this.lblBalance = new System.Windows.Forms.Label();
            this.btnTransaction = new System.Windows.Forms.Button();
            this.btnTransactionHistory = new System.Windows.Forms.Button();
            this.btnExpense = new System.Windows.Forms.Button();
            this.btnSavings = new System.Windows.Forms.Button();
            this.btnCategories = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.Location = new System.Drawing.Point(50, 50);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(300, 40);
            this.lblBalance.TabIndex = 0;
            this.lblBalance.Text = "Current Balance: 0.00 VND";
            this.btnTransaction.Location = new System.Drawing.Point(50, 120);
            this.btnTransaction.Name = "btnIncome";
            this.btnTransaction.Size = new System.Drawing.Size(150, 50);
            this.btnTransaction.TabIndex = 1;
            this.btnTransaction.Text = "Income";
            this.btnTransaction.UseVisualStyleBackColor = true;
            this.btnTransaction.Click += new System.EventHandler(this.btnIncome_Click);
            // 
            // btnTransactionHistory
            // 
            this.btnTransactionHistory.Location = new System.Drawing.Point(250, 120);
            this.btnTransactionHistory.Name = "btnTransactionHistory";
            this.btnTransactionHistory.Size = new System.Drawing.Size(150, 50);
            this.btnTransactionHistory.TabIndex = 2;
            this.btnTransactionHistory.Text = "Transaction History";
            this.btnTransactionHistory.UseVisualStyleBackColor = true;
            this.btnTransactionHistory.Click += new System.EventHandler(this.btnTransactionHistory_Click);
            // 
            // btnExpense
            // 
            this.btnExpense.Location = new System.Drawing.Point(450, 120);
            this.btnExpense.Name = "btnExpense";
            this.btnExpense.Size = new System.Drawing.Size(150, 50);
            this.btnExpense.TabIndex = 3;
            this.btnExpense.Text = "Expense";
            this.btnExpense.UseVisualStyleBackColor = true;
            this.btnExpense.Click += new System.EventHandler(this.btnExpense_Click);
            // 
            // btnSavings
            // 
            this.btnSavings.Location = new System.Drawing.Point(50, 220);
            this.btnSavings.Name = "btnSavings";
            this.btnSavings.Size = new System.Drawing.Size(150, 40);
            this.btnSavings.TabIndex = 4;
            this.btnSavings.Text = "Savings";
            this.btnSavings.UseVisualStyleBackColor = true;
            this.btnSavings.Click += new System.EventHandler(this.btnSavings_Click);
            // 
            // btnCategories
            // 
            this.btnCategories.Location = new System.Drawing.Point(50, 270);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(150, 40);
            this.btnCategories.TabIndex = 5;
            this.btnCategories.Text = "Expense Categories";
            this.btnCategories.UseVisualStyleBackColor = true;
            this.btnCategories.Click += new System.EventHandler(this.btnCategories_Click);
            // 
            // btnIncomeCategories
            // 
            this.btnIncomeCategories = new System.Windows.Forms.Button();
            this.btnIncomeCategories.Location = new System.Drawing.Point(250, 270);
            this.btnIncomeCategories.Name = "btnIncomeCategories";
            this.btnIncomeCategories.Size = new System.Drawing.Size(150, 40);
            this.btnIncomeCategories.TabIndex = 6;
            this.btnIncomeCategories.Text = "Income Categories";
            this.btnIncomeCategories.UseVisualStyleBackColor = true;
            this.btnIncomeCategories.Click += new System.EventHandler(this.btnIncomeCategories_Click);
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(50, 370);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(150, 40);
            this.btnReports.TabIndex = 7;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(50, 470);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(150, 40);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(50, 520);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 40);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnIncomeCategories);
            this.Controls.Add(this.btnCategories);
            this.Controls.Add(this.btnSavings);
            this.Controls.Add(this.btnExpense);
            this.Controls.Add(this.btnTransactionHistory);
            this.Controls.Add(this.btnTransaction);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.btnRefresh);
            this.Name = "FrmDashboard";
            this.Text = "Finance Tracker Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Button btnTransaction;
        private System.Windows.Forms.Button btnTransactionHistory;
        private System.Windows.Forms.Button btnExpense;
        private System.Windows.Forms.Button btnSavings;
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Button btnIncomeCategories;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRefresh;
    }
}