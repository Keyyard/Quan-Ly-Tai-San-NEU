using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quan_Ly_Tai_San
{
    public partial class FrmExpense : Form
    {
        public FrmExpense()
        {
            InitializeComponent();
            LoadCategories();
            LoadBalance();
            LoadTransactions();
            cboCategory.SelectedIndexChanged += cboCategory_SelectedIndexChanged;
            cboCategory_SelectedIndexChanged(null, null);
        }

        private void LoadCategories()
        {
            dbConnect db = new dbConnect();
            db.KetNoi_Dulieu();
            try
            {
                string query = "SELECT CategoryId, Name, Budget - CurrentSpent as Remaining FROM ExpenseCategories WHERE UserId = @UserId";
                SqlDataAdapter adapter = new SqlDataAdapter(query, db.cnn);
                adapter.SelectCommand.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cboCategory.DataSource = dt;
                cboCategory.DisplayMember = "Name";
                cboCategory.ValueMember = "CategoryId";
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
                // Calculate balance from all transactions instead of using the stored fixed value
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
                                 JOIN ExpenseCategories c ON t.CategoryId = c.CategoryId
                                 WHERE t.UserId = @UserId AND t.Type = 'Expense'
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
            int categoryId = (int)cboCategory.SelectedValue;
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
                // Insert transaction
                string insertQuery = @"INSERT INTO Transactions (UserId, Type, CategoryId, Amount, TransactionDate, Description)
                                       VALUES (@UserId, 'Expense', @CategoryId, @Amount, @Date, @Description)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, db.cnn);
                insertCmd.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                insertCmd.Parameters.AddWithValue("@CategoryId", categoryId);
                insertCmd.Parameters.AddWithValue("@Amount", amount);
                insertCmd.Parameters.AddWithValue("@Date", transDate);
                insertCmd.Parameters.AddWithValue("@Description", description);
                insertCmd.ExecuteNonQuery();

                // Update balance
                string balanceQuery = "UPDATE Users SET CurrentBalance = CurrentBalance - @Amount WHERE UserId = @UserId";
                SqlCommand balanceCmd = new SqlCommand(balanceQuery, db.cnn);
                balanceCmd.Parameters.AddWithValue("@Amount", amount);
                balanceCmd.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                balanceCmd.ExecuteNonQuery();

                // Update category current spent
                string catUpdateQuery = "UPDATE ExpenseCategories SET CurrentSpent = CurrentSpent + @Amount WHERE CategoryId = @CategoryId";
                SqlCommand catCmd = new SqlCommand(catUpdateQuery, db.cnn);
                catCmd.Parameters.AddWithValue("@Amount", amount);
                catCmd.Parameters.AddWithValue("@CategoryId", categoryId);
                catCmd.ExecuteNonQuery();

                MessageBox.Show("Expense added successfully.");
                LoadBalance();
                LoadTransactions();
                LoadCategories(); // to update remaining
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding expense: " + ex.Message);
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.SelectedValue != null && int.TryParse(cboCategory.SelectedValue.ToString(), out int categoryId))
            {
                dbConnect db = new dbConnect();
                db.KetNoi_Dulieu();
                try
                {
                    string query = "SELECT Budget - CurrentSpent FROM ExpenseCategories WHERE CategoryId = @CategoryId";
                    SqlCommand cmd = new SqlCommand(query, db.cnn);
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        decimal remaining = (decimal)result;
                        lblRemaining.Text = $"Remaining Budget: {remaining:N2}";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading remaining budget: " + ex.Message);
                }
                finally
                {
                    db.HuyKetNoi();
                }
            }
        }
    }
}