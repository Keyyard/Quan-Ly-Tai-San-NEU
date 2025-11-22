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
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@UserId", FrmSignIn.CurrentUserId)
                };
                DataTable dt = db.Lay_Dulieu_Proc("sp_GetExpenseCategories", parameters);
                cboCategory.DataSource = dt;
                cboCategory.DisplayMember = "Name";
                cboCategory.ValueMember = "CategoryId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
        }

        private void LoadBalance()
        {
            dbConnect db = new dbConnect();
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@UserId", FrmSignIn.CurrentUserId)
                };
                DataTable result = db.Lay_Dulieu_Proc("sp_GetUserBalance", parameters);
                if (result.Rows.Count > 0)
                {
                    txtBalance.Text = Convert.ToDecimal(result.Rows[0]["Balance"]).ToString("N2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading balance: " + ex.Message);
            }
        }

        private void LoadTransactions()
        {
            dbConnect db = new dbConnect();
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@UserId", FrmSignIn.CurrentUserId)
                };
                DataTable dt = db.Lay_Dulieu_Proc("sp_GetExpenseTransactions", parameters);
                gridTransaction.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading transactions: " + ex.Message);
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
            try
            {
                // Insert transaction - trigger will handle balance and category updates
                SqlParameter[] parameters = {
                    new SqlParameter("@UserId", FrmSignIn.CurrentUserId),
                    new SqlParameter("@CategoryId", categoryId),
                    new SqlParameter("@Amount", amount),
                    new SqlParameter("@TransactionDate", transDate),
                    new SqlParameter("@Description", description)
                };
                db.ThucThi_Proc("sp_InsertExpenseTransaction", parameters);

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
                try
                {
                    SqlParameter[] parameters = {
                        new SqlParameter("@CategoryId", categoryId)
                    };
                    DataTable result = db.Lay_Dulieu_Proc("sp_GetExpenseCategoryRemaining", parameters);
                    if (result.Rows.Count > 0)
                    {
                        decimal remaining = (decimal)result.Rows[0]["Remaining"];
                        lblRemaining.Text = $"Remaining Budget: {remaining:N2}";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading remaining budget: " + ex.Message);
                }
            }
        }
    }
}