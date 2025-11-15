using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Quan_Ly_Tai_San
{
    public partial class FrmBaoCaoThongKe : Form
    {
        public FrmBaoCaoThongKe()
        {
            InitializeComponent();
            LoadReports();
        }

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

                // Current Balance
                string balanceQuery = "SELECT CurrentBalance FROM Users WHERE UserId = @UserId";
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
    }
}
