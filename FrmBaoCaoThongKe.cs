using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Quan_Ly_Tai_San
{
    public partial class FrmBaoCaoThongKe : Form
    {
        //private int _UserId;

        public FrmBaoCaoThongKe(int UserId)
        {
            InitializeComponent();
            //_UserId = UserId;
            LoadReports();
        }

        dbConnect db = new dbConnect();

        private void LoadReports()
        {
            dbConnect db = new dbConnect();
            db.KetNoi_Dulieu();
            try
            {
                // Total Income
                string incomeQuery = "SELECT SUM(t.Amount) FROM Transactions t WHERE t.UserId = @UserId AND t.Type = 'Income'";
                SqlCommand incomeCmd = new SqlCommand(incomeQuery, db.cnn);
                incomeCmd.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                decimal totalIncome = (decimal)(incomeCmd.ExecuteScalar() ?? 0);

                // Total Expense
                string expenseQuery = "SELECT SUM(t.Amount) FROM Transactions t WHERE t.UserId = @UserId AND t.Type = 'Expense'";
                SqlCommand expenseCmd = new SqlCommand(expenseQuery, db.cnn);
                expenseCmd.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                decimal totalExpense = (decimal)(expenseCmd.ExecuteScalar() ?? 0);

                // Total Saving
                string savingQuery = "SELECT SUM(t.Amount) FROM Transactions t WHERE t.UserId = @UserId AND t.Type = 'Saving'";
                SqlCommand savingCmd = new SqlCommand(savingQuery, db.cnn);
                savingCmd.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                decimal totalSaving = (decimal)(savingCmd.ExecuteScalar() ?? 0);

                // Current Balance - Calculate from transactions instead of using stored value
                string balanceQuery = @"SELECT 
                                          ISNULL(SUM(CASE WHEN Type = 'Income' THEN Amount ELSE 0 END), 0) - 
                                          ISNULL(SUM(CASE WHEN Type = 'Expense' THEN Amount ELSE 0 END), 0) - 
                                          ISNULL(SUM(CASE WHEN Type = 'Saving' THEN Amount ELSE 0 END), 0) AS Balance
                                        FROM Transactions 
                                        WHERE UserId = @UserId";
                SqlCommand balanceCmd = new SqlCommand(balanceQuery, db.cnn);
                balanceCmd.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                decimal balance = (decimal)balanceCmd.ExecuteScalar();

                MessageBox.Show($"Total Income: {totalIncome:N2}\nTotal Expense: {totalExpense:N2}\nTotal Saving: {totalSaving:N2}\nCurrent Balance: {balance:N2}", "Reports");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading reports: " + ex.Message);
            }
            finally
            {
                db.HuyKetNoi();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmBaoCaoThongKe_Load(object sender, EventArgs e)
        {

        }

        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            DateTime start = dateTimePickerStart.Value.Date;
            DateTime end = dateTimePickerEnd.Value.Date;
            var items = LoadTransactions(start, end);

            // Lọc theo checkbox
            var selectedTypes = new System.Collections.Generic.List<string>();
            if (chkIncome.Checked) selectedTypes.Add("Income");
            if (chkExpense.Checked) selectedTypes.Add("Expense");
            if (chkSaving.Checked) selectedTypes.Add("Saving");
            DisplayLineChart(items, selectedTypes);
        }

        private System.Collections.Generic.List<TransactionItem> LoadTransactions(DateTime start, DateTime end)
        {
            var items = new System.Collections.Generic.List<TransactionItem>();
            string query = @"
                            SELECT TransactionId, UserId, Type, CategoryId, Amount, TransactionDate, Description
                            FROM Transactions
                            WHERE UserId = @UserId AND TransactionDate BETWEEN @start AND @end
                            ORDER BY TransactionDate";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserId", FrmSignIn.CurrentUserId),
                new SqlParameter("@start", start),
                new SqlParameter("@end", end)
            };

            DataTable dt = db.Lay_Dulieubang(query, parameters);
            foreach (DataRow row in dt.Rows)
            {
                items.Add(new TransactionItem
                {
                    TransactionId = Convert.ToInt32(row["TransactionId"]),
                    UserId = Convert.ToInt32(row["UserId"]),
                    Type = row["Type"].ToString(),
                    CategoryId = Convert.ToInt32(row["CategoryId"]),
                    Amount = Convert.ToDecimal(row["Amount"]),
                    TransactionDate = Convert.ToDateTime(row["TransactionDate"]),
                    Description = row["Description"].ToString()
                });
            }
            MessageBox.Show("Items loaded: " + items.Count);
            return items;
        }

        private void DisplayLineChart(System.Collections.Generic.List<TransactionItem> items,
        System.Collections.Generic.List<string> selectedTypes)
        {
            chart1.Series.Clear();
            if (chart1.ChartAreas.Count == 0)
                chart1.ChartAreas.Add(new ChartArea("Default"));
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy/MM/dd";

            Series incomeSeries = null;
            Series expenseSeries = null;
            Series savingsSeries = null;

            if (selectedTypes.Contains("Income"))
                incomeSeries = new Series("Income") { ChartType = SeriesChartType.Line, BorderWidth = 3 };

            if (selectedTypes.Contains("Expense"))
                expenseSeries = new Series("Expense") { ChartType = SeriesChartType.Line, BorderWidth = 3 };

            if (selectedTypes.Contains("Saving"))
                savingsSeries = new Series("Saving") { ChartType = SeriesChartType.Line, BorderWidth = 3 };

            var grouped = items
                .Where(t => selectedTypes.Contains(t.Type))
                .GroupBy(t => t.TransactionDate.Date)
                .Select(g => new
                {
                    TransactionDate = g.Key,
                    Income = g.Where(x => x.Type == "Income").Sum(x => x.Amount),
                    Expense = g.Where(x => x.Type == "Expense").Sum(x => x.Amount),
                    Savings = g.Where(x => x.Type == "Saving").Sum(x => x.Amount)
                })
                .OrderBy(x => x.TransactionDate)
                .ToList();

            foreach (var d in grouped)
            {
                if (incomeSeries != null) incomeSeries.Points.AddXY(d.TransactionDate, d.Income);
                if (expenseSeries != null) expenseSeries.Points.AddXY(d.TransactionDate, d.Expense);
                if (savingsSeries != null) savingsSeries.Points.AddXY(d.TransactionDate, d.Savings);
            }

            if (incomeSeries != null) chart1.Series.Add(incomeSeries);
            if (expenseSeries != null) chart1.Series.Add(expenseSeries);
            if (savingsSeries != null) chart1.Series.Add(savingsSeries);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            
        }
    }
    public class TransactionItem
    {
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; }

        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
    }
}
