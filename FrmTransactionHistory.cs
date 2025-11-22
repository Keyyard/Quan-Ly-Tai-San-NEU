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
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@UserId", FrmSignIn.CurrentUserId),
                    new SqlParameter("@Type", type)
                };
                DataTable dt = db.Lay_Dulieu_Proc("sp_GetCategoryNamesByType", parameters);
                foreach (DataRow row in dt.Rows)
                {
                    cboCategory.Items.Add(row["Name"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
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
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@UserId", FrmSignIn.CurrentUserId)
                };
                DataTable dt = db.Lay_Dulieu_Proc("sp_GetAllTransactions", parameters);
                
                // Filter by type if needed
                if (!string.IsNullOrEmpty(typeFilter))
                {
                    DataView dv = dt.DefaultView;
                    dv.RowFilter = $"Type = '{typeFilter}'";
                    dt = dv.ToTable();
                }
                
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch sử: " + ex.Message);
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
                // Get CategoryId based on type
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
                object catResult = catCmd.ExecuteScalar();
                if (catResult == null)
                {
                    MessageBox.Show("Category not found.");
                    return;
                }
                int categoryId = (int)catResult;

                // Update transaction - trigger will handle balance reversals and updates automatically
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
                try
                {
                    // Delete transaction - trigger will handle balance and category updates
                    SqlParameter[] parameters = {
                        new SqlParameter("@TransactionId", selectedTransactionId)
                    };
                    db.ThucThi_Proc("sp_DeleteTransaction", parameters);

                    MessageBox.Show("Giao dịch đã được xóa.");
                    LoadTransactions();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
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
