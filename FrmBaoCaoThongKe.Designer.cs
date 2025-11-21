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
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            lblTieuDe = new Label();
            btnBack = new Button();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            btnCreateReport = new Button();
            groupBox1 = new GroupBox();
            chkSaving = new CheckBox();
            chkExpense = new CheckBox();
            chkIncome = new CheckBox();
            lblDateEnd = new Label();
            lblDateStart = new Label();
            dateTimePickerEnd = new DateTimePicker();
            dateTimePickerStart = new DateTimePicker();
            transactionItemBindingSource = new BindingSource(components);
            btnExport = new Button();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)transactionItemBindingSource).BeginInit();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTieuDe.Location = new Point(490, 23);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(128, 41);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Reports";
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Segoe UI", 12F);
            btnBack.Location = new Point(923, 239);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(160, 50);
            btnBack.TabIndex = 1;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chart1.Legends.Add(legend3);
            chart1.Location = new Point(35, 326);
            chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            chart1.Series.Add(series3);
            chart1.Size = new Size(1048, 257);
            chart1.TabIndex = 2;
            chart1.Text = "chart1";
            // 
            // btnCreateReport
            // 
            btnCreateReport.Font = new Font("Segoe UI", 12F);
            btnCreateReport.Location = new Point(923, 100);
            btnCreateReport.Name = "btnCreateReport";
            btnCreateReport.Size = new Size(160, 50);
            btnCreateReport.TabIndex = 3;
            btnCreateReport.Text = "Crete Report";
            btnCreateReport.UseVisualStyleBackColor = true;
            btnCreateReport.Click += btnCreateReport_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chkSaving);
            groupBox1.Controls.Add(chkExpense);
            groupBox1.Controls.Add(chkIncome);
            groupBox1.Controls.Add(lblDateEnd);
            groupBox1.Controls.Add(lblDateStart);
            groupBox1.Controls.Add(dateTimePickerEnd);
            groupBox1.Controls.Add(dateTimePickerStart);
            groupBox1.Location = new Point(48, 84);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(850, 205);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // chkSaving
            // 
            chkSaving.AutoSize = true;
            chkSaving.Font = new Font("Segoe UI", 12F);
            chkSaving.Location = new Point(619, 122);
            chkSaving.Name = "chkSaving";
            chkSaving.Size = new Size(111, 36);
            chkSaving.TabIndex = 6;
            chkSaving.Text = "Saving";
            chkSaving.UseVisualStyleBackColor = true;
            // 
            // chkExpense
            // 
            chkExpense.AutoSize = true;
            chkExpense.Font = new Font("Segoe UI", 12F);
            chkExpense.Location = new Point(313, 122);
            chkExpense.Name = "chkExpense";
            chkExpense.Size = new Size(127, 36);
            chkExpense.TabIndex = 5;
            chkExpense.Text = "Expense";
            chkExpense.UseVisualStyleBackColor = true;
            // 
            // chkIncome
            // 
            chkIncome.AutoSize = true;
            chkIncome.Font = new Font("Segoe UI", 12F);
            chkIncome.Location = new Point(38, 122);
            chkIncome.Name = "chkIncome";
            chkIncome.Size = new Size(119, 36);
            chkIncome.TabIndex = 4;
            chkIncome.Text = "Income";
            chkIncome.UseVisualStyleBackColor = true;
            // 
            // lblDateEnd
            // 
            lblDateEnd.AutoSize = true;
            lblDateEnd.Font = new Font("Segoe UI", 12F);
            lblDateEnd.Location = new Point(412, 51);
            lblDateEnd.Name = "lblDateEnd";
            lblDateEnd.Size = new Size(51, 32);
            lblDateEnd.TabIndex = 3;
            lblDateEnd.Text = "To: ";
            // 
            // lblDateStart
            // 
            lblDateStart.AutoSize = true;
            lblDateStart.Font = new Font("Segoe UI", 12F);
            lblDateStart.Location = new Point(25, 51);
            lblDateStart.Name = "lblDateStart";
            lblDateStart.Size = new Size(81, 32);
            lblDateStart.TabIndex = 2;
            lblDateStart.Text = "From: ";
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.CustomFormat = "yyyy/MM/dd";
            dateTimePickerEnd.Font = new Font("Segoe UI", 12F);
            dateTimePickerEnd.Format = DateTimePickerFormat.Custom;
            dateTimePickerEnd.Location = new Point(484, 46);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(223, 39);
            dateTimePickerEnd.TabIndex = 1;
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.CustomFormat = "yyyy/MM/dd";
            dateTimePickerStart.Font = new Font("Segoe UI", 12F);
            dateTimePickerStart.Format = DateTimePickerFormat.Custom;
            dateTimePickerStart.Location = new Point(128, 46);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(223, 39);
            dateTimePickerStart.TabIndex = 0;
            // 
            // transactionItemBindingSource
            // 
            transactionItemBindingSource.DataSource = typeof(TransactionItem);
            // 
            // btnExport
            // 
            btnExport.Font = new Font("Segoe UI", 12F);
            btnExport.Location = new Point(923, 171);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(160, 50);
            btnExport.TabIndex = 5;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // FrmBaoCaoThongKe
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 620);
            Controls.Add(btnExport);
            Controls.Add(groupBox1);
            Controls.Add(btnCreateReport);
            Controls.Add(chart1);
            Controls.Add(btnBack);
            Controls.Add(lblTieuDe);
            Name = "FrmBaoCaoThongKe";
            Text = "Reports";
            Load += FrmBaoCaoThongKe_Load;
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)transactionItemBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
        private Button btnBack;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Button btnCreateReport;
        private GroupBox groupBox1;
        private CheckBox chkSaving;
        private CheckBox chkExpense;
        private CheckBox chkIncome;
        private Label lblDateEnd;
        private Label lblDateStart;
        private DateTimePicker dateTimePickerEnd;
        private DateTimePicker dateTimePickerStart;
        private BindingSource transactionItemBindingSource;
        private Button btnExport;
    }
}