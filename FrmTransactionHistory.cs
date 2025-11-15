using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quan_Ly_Tai_San
{
    public partial class FrmTransactionHistory : Form
    {
        private int selectedTransactionId = -1;

        public FrmTransactionHistory()
        {
            InitializeComponent();
            LoadTypes();
            LoadTransactions();
        }

        private void LoadTypes()
        {
            cboType.Items.Clear();
            cboType.Items.Add("");
            cboType.Items.Add("Income");
            cboType.Items.Add("Expense");
            cboType.Items.Add("Saving");
        }

        private void LoadCategories(string type)
        {
            cboCategory.Items.Clear();
            if (string.IsNullOrEmpty(type)) return;

            dbConnect db = new dbConnect();
            db.KetNoi_Dulieu();
            try
            {
                string query = "";
                if (type == "Income")
                {
                    query = "SELECT Name FROM IncomeCategories WHERE UserId = @UserId";
                }
                else if (type == "Expense")
                {
                    query = "SELECT Name FROM ExpenseCategories WHERE UserId = @UserId";
                }
                else if (type == "Saving")
                {
                    query = "SELECT Name FROM SavingsGoals WHERE UserId = @UserId";
                }

                SqlCommand cmd = new SqlCommand(query, db.cnn);
                cmd.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cboCategory.Items.Add(reader["Name"].ToString());
                }
                reader.Close();
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

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = cboType.SelectedItem?.ToString();
            LoadCategories(type);
        }

        private void LoadTransactions(string typeFilter = "")
        {
            dbConnect db = new dbConnect();
            db.KetNoi_Dulieu();
            try
            {
                string query = @"SELECT t.TransactionId, COALESCE(ic.Name, ec.Name, sg.Name) as Category, t.Type, t.Amount, t.TransactionDate, t.Description
                                 FROM Transactions t
                                 LEFT JOIN IncomeCategories ic ON t.CategoryId = ic.CategoryId AND t.Type = 'Income'
                                 LEFT JOIN ExpenseCategories ec ON t.CategoryId = ec.CategoryId AND t.Type = 'Expense'
                                 LEFT JOIN SavingsGoals sg ON t.CategoryId = sg.GoalId AND t.Type = 'Saving'
                                 WHERE t.UserId = @UserId";
                if (!string.IsNullOrEmpty(typeFilter))
                {
                    query += " AND t.Type = @Type";
                }
                query += " ORDER BY t.TransactionDate DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, db.cnn);
                adapter.SelectCommand.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                if (!string.IsNullOrEmpty(typeFilter))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@Type", typeFilter);
                }
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch sử: " + ex.Message);
            }
            finally
            {
                db.HuyKetNoi();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string type = cboType.SelectedItem?.ToString();
            LoadTransactions(type == "" ? null : type);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                selectedTransactionId = (int)row.Cells["TransactionId"].Value;
                string type = row.Cells["Type"].Value.ToString();
                cboType.Text = type;
                LoadCategories(type);
                cboCategory.Text = row.Cells["Category"].Value.ToString();
                txtBalance.Text = row.Cells["Amount"].Value.ToString();
                date.Value = (DateTime)row.Cells["TransactionDate"].Value;
                txtDescription.Text = row.Cells["Description"].Value.ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedTransactionId == -1)
            {
                MessageBox.Show("Vui lòng chọn giao dịch để chỉnh sửa.");
                return;
            }

            string type = cboType.Text;
            string categoryName = cboCategory.Text;
            decimal amount;
            if (!decimal.TryParse(txtBalance.Text, out amount))
            {
                MessageBox.Show("Số tiền không hợp lệ.");
                return;
            }
            DateTime transDate = date.Value;
            string description = txtDescription.Text;

            dbConnect db = new dbConnect();
            db.KetNoi_Dulieu();
            try
            {
                // Get old transaction details
                string oldQuery = @"SELECT t.Type, t.Amount, t.CategoryId FROM Transactions t WHERE t.TransactionId = @TransactionId";
                SqlCommand oldCmd = new SqlCommand(oldQuery, db.cnn);
                oldCmd.Parameters.AddWithValue("@TransactionId", selectedTransactionId);
                SqlDataReader reader = oldCmd.ExecuteReader();
                string oldType = "";
                decimal oldAmount = 0;
                int oldCategoryId = 0;
                if (reader.Read())
                {
                    oldType = reader["Type"].ToString();
                    oldAmount = (decimal)reader["Amount"];
                    oldCategoryId = (int)reader["CategoryId"];
                }
                reader.Close();

                // Reverse old balance
                string reverseBalanceQuery = oldType == "Income" ? "UPDATE Users SET CurrentBalance = CurrentBalance - @Amount WHERE UserId = @UserId" :
                                     oldType == "Expense" ? "UPDATE Users SET CurrentBalance = CurrentBalance + @Amount WHERE UserId = @UserId" :
                                     "UPDATE Users SET CurrentBalance = CurrentBalance + @Amount WHERE UserId = @UserId"; // Saving
                SqlCommand reverseBalanceCmd = new SqlCommand(reverseBalanceQuery, db.cnn);
                reverseBalanceCmd.Parameters.AddWithValue("@Amount", oldAmount);
                reverseBalanceCmd.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                reverseBalanceCmd.ExecuteNonQuery();

                // Reverse old category
                string reverseCatQuery = "";
                if (oldType == "Expense")
                {
                    reverseCatQuery = "UPDATE ExpenseCategories SET CurrentSpent = CurrentSpent - @Amount WHERE CategoryId = @CategoryId";
                }
                else if (oldType == "Saving")
                {
                    reverseCatQuery = "UPDATE SavingsGoals SET CurrentAmount = CurrentAmount - @Amount WHERE GoalId = @CategoryId";
                }
                // For Income, do nothing
                if (!string.IsNullOrEmpty(reverseCatQuery))
                {
                    SqlCommand reverseCatCmd = new SqlCommand(reverseCatQuery, db.cnn);
                    reverseCatCmd.Parameters.AddWithValue("@Amount", oldAmount);
                    reverseCatCmd.Parameters.AddWithValue("@CategoryId", oldCategoryId);
                    reverseCatCmd.ExecuteNonQuery();
                }

                // Get CategoryId
                string catQuery = "";
                if (type == "Income")
                {
                    catQuery = "SELECT CategoryId FROM IncomeCategories WHERE UserId = @UserId AND Name = @Name";
                }
                else if (type == "Expense")
                {
                    catQuery = "SELECT CategoryId FROM ExpenseCategories WHERE UserId = @UserId AND Name = @Name";
                }
                else if (type == "Saving")
                {
                    catQuery = "SELECT GoalId FROM SavingsGoals WHERE UserId = @UserId AND Name = @Name";
                }
                SqlCommand catCmd = new SqlCommand(catQuery, db.cnn);
                catCmd.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                catCmd.Parameters.AddWithValue("@Name", categoryName);
                int categoryId = (int)catCmd.ExecuteScalar();

                // Update transaction
                string updateQuery = @"UPDATE Transactions SET Type = @Type, CategoryId = @CategoryId, Amount = @Amount, TransactionDate = @Date, Description = @Description
                                       WHERE TransactionId = @TransactionId";
                SqlCommand updateCmd = new SqlCommand(updateQuery, db.cnn);
                updateCmd.Parameters.AddWithValue("@Type", type);
                updateCmd.Parameters.AddWithValue("@CategoryId", categoryId);
                updateCmd.Parameters.AddWithValue("@Amount", amount);
                updateCmd.Parameters.AddWithValue("@Date", transDate);
                updateCmd.Parameters.AddWithValue("@Description", description);
                updateCmd.Parameters.AddWithValue("@TransactionId", selectedTransactionId);
                updateCmd.ExecuteNonQuery();

                // Apply new balance
                string balanceQuery = type == "Income" ? "UPDATE Users SET CurrentBalance = CurrentBalance + @Amount WHERE UserId = @UserId" :
                                   type == "Expense" ? "UPDATE Users SET CurrentBalance = CurrentBalance - @Amount WHERE UserId = @UserId" :
                                   "UPDATE Users SET CurrentBalance = CurrentBalance - @Amount WHERE UserId = @UserId"; // Saving
                SqlCommand balanceCmd = new SqlCommand(balanceQuery, db.cnn);
                balanceCmd.Parameters.AddWithValue("@Amount", amount);
                balanceCmd.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                balanceCmd.ExecuteNonQuery();

                // Apply new category
                string catUpdateQuery = "";
                if (type == "Expense")
                {
                    catUpdateQuery = "UPDATE ExpenseCategories SET CurrentSpent = CurrentSpent + @Amount WHERE CategoryId = @CategoryId";
                }
                else if (type == "Saving")
                {
                    catUpdateQuery = "UPDATE SavingsGoals SET CurrentAmount = CurrentAmount + @Amount WHERE GoalId = @CategoryId";
                }
                // For Income, do nothing
                if (!string.IsNullOrEmpty(catUpdateQuery))
                {
                    SqlCommand catCmd2 = new SqlCommand(catUpdateQuery, db.cnn);
                    catCmd2.Parameters.AddWithValue("@Amount", amount);
                    catCmd2.Parameters.AddWithValue("@CategoryId", categoryId);
                    catCmd2.ExecuteNonQuery();
                }

                MessageBox.Show("Giao dịch đã được cập nhật.");
                LoadTransactions();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chỉnh sửa: " + ex.Message);
            }
            finally
            {
                db.HuyKetNoi();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedTransactionId == -1)
            {
                MessageBox.Show("Vui lòng chọn giao dịch để xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa giao dịch này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dbConnect db = new dbConnect();
                db.KetNoi_Dulieu();
                try
                {
                    // Get transaction details
                    string oldQuery = @"SELECT t.Type, t.Amount, t.CategoryId FROM Transactions t WHERE t.TransactionId = @TransactionId";
                    SqlCommand oldCmd = new SqlCommand(oldQuery, db.cnn);
                    oldCmd.Parameters.AddWithValue("@TransactionId", selectedTransactionId);
                    SqlDataReader reader = oldCmd.ExecuteReader();
                    string oldType = "";
                    decimal oldAmount = 0;
                    int oldCategoryId = 0;
                    if (reader.Read())
                    {
                        oldType = reader["Type"].ToString();
                        oldAmount = (decimal)reader["Amount"];
                        oldCategoryId = (int)reader["CategoryId"];
                    }
                    reader.Close();

                    // Reverse balance
                    string reverseBalanceQuery = oldType == "Income" ? "UPDATE Users SET CurrentBalance = CurrentBalance - @Amount WHERE UserId = @UserId" :
                                         oldType == "Expense" ? "UPDATE Users SET CurrentBalance = CurrentBalance + @Amount WHERE UserId = @UserId" :
                                         "UPDATE Users SET CurrentBalance = CurrentBalance + @Amount WHERE UserId = @UserId"; // Saving
                    SqlCommand reverseBalanceCmd = new SqlCommand(reverseBalanceQuery, db.cnn);
                    reverseBalanceCmd.Parameters.AddWithValue("@Amount", oldAmount);
                    reverseBalanceCmd.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                    reverseBalanceCmd.ExecuteNonQuery();

                    // Reverse category
                    string reverseCatQuery = "";
                    if (oldType == "Expense")
                    {
                        reverseCatQuery = "UPDATE ExpenseCategories SET CurrentSpent = CurrentSpent - @Amount WHERE CategoryId = @CategoryId";
                    }
                    else if (oldType == "Saving")
                    {
                        reverseCatQuery = "UPDATE SavingsGoals SET CurrentAmount = CurrentAmount - @Amount WHERE GoalId = @CategoryId";
                    }
                    // For Income, do nothing
                    if (!string.IsNullOrEmpty(reverseCatQuery))
                    {
                        SqlCommand reverseCatCmd = new SqlCommand(reverseCatQuery, db.cnn);
                        reverseCatCmd.Parameters.AddWithValue("@Amount", oldAmount);
                        reverseCatCmd.Parameters.AddWithValue("@CategoryId", oldCategoryId);
                        reverseCatCmd.ExecuteNonQuery();
                    }

                    string deleteQuery = "DELETE FROM Transactions WHERE TransactionId = @TransactionId";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, db.cnn);
                    deleteCmd.Parameters.AddWithValue("@TransactionId", selectedTransactionId);
                    deleteCmd.ExecuteNonQuery();

                    MessageBox.Show("Giao dịch đã được xóa.");
                    LoadTransactions();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
                finally
                {
                    db.HuyKetNoi();
                }
            }
        }

        private void ClearFields()
        {
            selectedTransactionId = -1;
            cboType.Text = "";
            cboCategory.Text = "";
            txtBalance.Text = "";
            txtDescription.Text = "";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTransactions();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
