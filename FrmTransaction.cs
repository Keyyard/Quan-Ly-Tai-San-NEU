using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quan_Ly_Tai_San
{
    public partial class FrmTransaction : Form
    {
        public FrmTransaction()
        {
            InitializeComponent();
            LoadTypes();
            LoadCategories();
            LoadTransactions();
        }

        private void LoadTypes()
        {
            cboType.Items.Clear();
            cboType.Items.Add("Income");
            cboType.Items.Add("Expense");
            cboType.Items.Add("Saving");
            cboType.SelectedIndex = 0;
        }

        private void LoadCategories()
        {
            cboCategory.Items.Clear();
            string type = cboType.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(type)) return;

            dbConnect db = new dbConnect();
            db.KetNoi_Dulieu();
            try
            {
                string query = "SELECT Name FROM Categories WHERE UserId = @UserId AND Type = @Type";
                SqlCommand cmd = new SqlCommand(query, db.cnn);
                cmd.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                cmd.Parameters.AddWithValue("@Type", type);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cboCategory.Items.Add(reader["Name"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message);
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
                string query = @"SELECT t.TransactionId, c.Name as Category, t.Type, t.Amount, t.TransactionDate, t.Description
                                 FROM Transactions t
                                 JOIN Categories c ON t.CategoryId = c.CategoryId
                                 WHERE t.UserId = @UserId
                                 ORDER BY t.TransactionDate DESC";
                SqlDataAdapter adapter = new SqlDataAdapter(query, db.cnn);
                adapter.SelectCommand.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                gridTransaction.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải giao dịch: " + ex.Message);
            }
            finally
            {
                db.HuyKetNoi();
            }
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = cboType.SelectedItem?.ToString();
            string categoryName = cboCategory.SelectedItem?.ToString();

            if (type == "Expense" && !string.IsNullOrEmpty(categoryName))
            {
                dbConnect db = new dbConnect();
                db.KetNoi_Dulieu();
                try
                {
                    string query = "SELECT BudgetAmount as Limit, CurrentAmount FROM Categories WHERE UserId = @UserId AND Name = @Name AND Type = 'Expense'";
                    SqlCommand cmd = new SqlCommand(query, db.cnn);
                    cmd.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                    cmd.Parameters.AddWithValue("@Name", categoryName);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        decimal limit = reader["Limit"] != DBNull.Value ? (decimal)reader["Limit"] : 0;
                        decimal current = (decimal)reader["CurrentAmount"];

                        lblBudget.Text = $"Budget: {limit:N2}";
                        lblBudget.Visible = true;

                        int progress = limit > 0 ? (int)((current / limit) * 100) : 0;
                        progressBar1.Value = Math.Min(progress, 100);
                        progressBar1.Visible = true;

                        lblProgress.Text = $"Progress: {progress}% ({current:N2}/{limit:N2})";
                        lblProgress.Visible = true;

                        if (progress > 100)
                        {
                            lblProgress.Text += " (Over Budget!)";
                        }
                        else if (progress == 100)
                        {
                            lblProgress.Text += " (At Limit)";
                        }
                        else
                        {
                            lblProgress.Text += " (Under Budget)";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải thông tin: " + ex.Message);
                }
                finally
                {
                    db.HuyKetNoi();
                }
            }
            else
            {
                lblBudget.Visible = false;
                progressBar1.Visible = false;
                lblProgress.Visible = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string type = cboType.SelectedItem?.ToString();
            string categoryName = cboCategory.SelectedItem?.ToString();
            decimal amount;
            if (!decimal.TryParse(txtBalance.Text, out amount) || amount <= 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền hợp lệ.");
                return;
            }
            DateTime transDate = date.Value;
            string description = txtDescription.Text;

            if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Vui lòng chọn loại và danh mục.");
                return;
            }

            dbConnect db = new dbConnect();
            db.KetNoi_Dulieu();
            try
            {
                // Get CategoryId
                string catQuery = "SELECT CategoryId FROM Categories WHERE UserId = @UserId AND Name = @Name AND Type = @Type";
                SqlCommand catCmd = new SqlCommand(catQuery, db.cnn);
                catCmd.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                catCmd.Parameters.AddWithValue("@Name", categoryName);
                catCmd.Parameters.AddWithValue("@Type", type);
                int categoryId = (int)catCmd.ExecuteScalar();

                // Insert transaction
                string insertQuery = @"INSERT INTO Transactions (UserId, Type, CategoryId, Amount, TransactionDate, Description)
                                       VALUES (@UserId, @Type, @CategoryId, @Amount, @Date, @Description)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, db.cnn);
                insertCmd.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                insertCmd.Parameters.AddWithValue("@Type", type);
                insertCmd.Parameters.AddWithValue("@CategoryId", categoryId);
                insertCmd.Parameters.AddWithValue("@Amount", amount);
                insertCmd.Parameters.AddWithValue("@Date", transDate);
                insertCmd.Parameters.AddWithValue("@Description", description);
                insertCmd.ExecuteNonQuery();

                // Update user balance
                string balanceQuery = type == "Income" ? "UPDATE Users SET CurrentBalance = CurrentBalance + @Amount WHERE UserId = @UserId" :
                                   "UPDATE Users SET CurrentBalance = CurrentBalance - @Amount WHERE UserId = @UserId";
                SqlCommand balanceCmd = new SqlCommand(balanceQuery, db.cnn);
                balanceCmd.Parameters.AddWithValue("@Amount", amount);
                balanceCmd.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                balanceCmd.ExecuteNonQuery();

                // Update category current amount
                string catUpdateQuery = "UPDATE Categories SET CurrentAmount = CurrentAmount + @Amount WHERE CategoryId = @CategoryId";
                SqlCommand catCmd2 = new SqlCommand(catUpdateQuery, db.cnn);
                catCmd2.Parameters.AddWithValue("@Amount", amount);
                catCmd2.Parameters.AddWithValue("@CategoryId", categoryId);
                catCmd2.ExecuteNonQuery();

                MessageBox.Show("Giao dịch đã được thêm.");
                LoadTransactions();
                cboCategory_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm giao dịch: " + ex.Message);
            }
            finally
            {
                db.HuyKetNoi();
            }
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCategories();
            cboCategory_SelectedIndexChanged(null, null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
