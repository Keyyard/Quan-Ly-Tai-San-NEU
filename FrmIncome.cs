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
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@UserId", FrmSignIn.CurrentUserId)
                };
                DataTable dt = db.Lay_Dulieu_Proc("sp_GetIncomeCategories", parameters);
                cboCategory.DataSource = dt;
                cboCategory.DisplayMember = "Name";
                cboCategory.ValueMember = "Name";
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
                DataTable dt = db.Lay_Dulieu_Proc("sp_GetIncomeTransactions", parameters);
                gridTransaction.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading transactions: " + ex.Message);
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
            try
            {
                // Get CategoryId
                SqlParameter[] catParams = {
                    new SqlParameter("@UserId", FrmSignIn.CurrentUserId),
                    new SqlParameter("@Name", categoryName)
                };
                DataTable catResult = db.Lay_Dulieu_Proc("sp_GetIncomeCategoryId", catParams);
                if (catResult.Rows.Count == 0)
                {
                    MessageBox.Show("Category not found.");
                    return;
                }
                int categoryId = (int)catResult.Rows[0]["CategoryId"];

                // Insert transaction - trigger will handle balance update
                SqlParameter[] transParams = {
                    new SqlParameter("@UserId", FrmSignIn.CurrentUserId),
                    new SqlParameter("@CategoryId", categoryId),
                    new SqlParameter("@Amount", amount),
                    new SqlParameter("@TransactionDate", transDate),
                    new SqlParameter("@Description", description)
                };
                db.ThucThi_Proc("sp_InsertIncomeTransaction", transParams);

                MessageBox.Show("Income added successfully.");
                LoadBalance();
                LoadTransactions();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding income: " + ex.Message);
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