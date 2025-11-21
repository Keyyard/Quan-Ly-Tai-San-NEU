using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quan_Ly_Tai_San
{
    public partial class FrmIncome : Form
    {
        public FrmIncome()
        {
            InitializeComponent();
            LoadCategories();
            LoadBalance();
            LoadTransactions();
        }

        private void LoadCategories()
        {
            dbConnect db = new dbConnect();
            db.KetNoi_Dulieu();
            try
            {
                string query = "SELECT Name FROM IncomeCategories WHERE UserId = @UserId";
                SqlDataAdapter adapter = new SqlDataAdapter(query, db.cnn);
                adapter.SelectCommand.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cboCategory.DataSource = dt;
                cboCategory.DisplayMember = "Name";
                cboCategory.ValueMember = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
            finally
            {
                db.HuyKetNoi();
            }
        }

        private void LoadBalance()
        {
            dbConnect db = new dbConnect();
            db.KetNoi_Dulieu();
            try
            {
                string query = @"SELECT 
                                    ISNULL(SUM(CASE WHEN Type = 'Income' THEN Amount ELSE 0 END), 0) - 
                                    ISNULL(SUM(CASE WHEN Type = 'Expense' THEN Amount ELSE 0 END), 0) - 
                                    ISNULL(SUM(CASE WHEN Type = 'Saving' THEN Amount ELSE 0 END), 0) AS Balance
                                 FROM Transactions 
                                 WHERE UserId = @UserId";
                SqlCommand cmd = new SqlCommand(query, db.cnn);
                cmd.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    txtBalance.Text = Convert.ToDecimal(result).ToString("N2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading balance: " + ex.Message);
            }
            finally
            {
                db.HuyKetNoi();
            }
        }

        private void LoadTransactions()
        {
            dbConnect db = new dbConnect();
            db.KetNoi_Dulieu();
            try
            {
                string query = @"SELECT t.TransactionId, c.Name as Category, t.Amount, t.TransactionDate, t.Description
                                 FROM Transactions t
                                 JOIN IncomeCategories c ON t.CategoryId = c.CategoryId
                                 WHERE t.UserId = @UserId AND t.Type = 'Income'
                                 ORDER BY t.TransactionDate DESC";
                SqlDataAdapter adapter = new SqlDataAdapter(query, db.cnn);
                adapter.SelectCommand.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                gridTransaction.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading transactions: " + ex.Message);
            }
            finally
            {
                db.HuyKetNoi();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string categoryName = cboCategory.Text;
            decimal amount;
            if (!decimal.TryParse(txtAmount.Text, out amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid amount.");
                return;
            }
            DateTime transDate = date.Value;
            string description = txtDescription.Text;

            dbConnect db = new dbConnect();
            db.KetNoi_Dulieu();
            try
            {
                // Get CategoryId
                string catQuery = "SELECT CategoryId FROM IncomeCategories WHERE UserId = @UserId AND Name = @Name";
                SqlCommand catCmd = new SqlCommand(catQuery, db.cnn);
                catCmd.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                catCmd.Parameters.AddWithValue("@Name", categoryName);
                object catResult = catCmd.ExecuteScalar();
                if (catResult == null)
                {
                    MessageBox.Show("Category not found.");
                    return;
                }
                int categoryId = (int)catResult;

                // Insert transaction
                string insertQuery = @"INSERT INTO Transactions (UserId, Type, CategoryId, Amount, TransactionDate, Description)
                                       VALUES (@UserId, 'Income', @CategoryId, @Amount, @Date, @Description)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, db.cnn);
                insertCmd.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                insertCmd.Parameters.AddWithValue("@CategoryId", categoryId);
                insertCmd.Parameters.AddWithValue("@Amount", amount);
                insertCmd.Parameters.AddWithValue("@Date", transDate);
                insertCmd.Parameters.AddWithValue("@Description", description);
                insertCmd.ExecuteNonQuery();

                // Update balance
                string balanceQuery = "UPDATE Users SET CurrentBalance = CurrentBalance + @Amount WHERE UserId = @UserId";
                SqlCommand balanceCmd = new SqlCommand(balanceQuery, db.cnn);
                balanceCmd.Parameters.AddWithValue("@Amount", amount);
                balanceCmd.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                balanceCmd.ExecuteNonQuery();

                MessageBox.Show("Income added successfully.");
                LoadBalance();
                LoadTransactions();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding income: " + ex.Message);
            }
            finally
            {
                db.HuyKetNoi();
            }
        }

        private void ClearFields()
        {
            txtAmount.Text = "";
            txtDescription.Text = "";
            date.Value = DateTime.Now;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCategories();
            LoadBalance();
            LoadTransactions();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}