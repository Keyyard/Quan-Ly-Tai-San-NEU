using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quan_Ly_Tai_San
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
            LoadBalance();
            this.Activated += FrmDashboard_Activated;
        }

        private void FrmDashboard_Activated(object sender, EventArgs e)
        {
            LoadBalance();
        }

        private void LoadBalance()
        {
            dbConnect db = new dbConnect();
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@UserId", FrmSignIn.CurrentUserId)
                };
                System.Data.DataTable result = db.Lay_Dulieu_Proc("sp_GetUserBalance", parameters);
                if (result.Rows.Count > 0)
                {
                    lblBalance.Text = $"Current Balance: {Convert.ToDecimal(result.Rows[0]["Balance"]):N2} VND";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading balance: " + ex.Message);
            }
        }

        private void btnIncome_Click(object sender, EventArgs e)
        {
            FrmIncome incomeForm = new FrmIncome();
            incomeForm.ShowDialog();
        }

        private void btnExpense_Click(object sender, EventArgs e)
        {
            FrmExpense expenseForm = new FrmExpense();
            expenseForm.ShowDialog();
        }

        private void btnTransactionHistory_Click(object sender, EventArgs e)
        {
            FrmTransactionHistory historyForm = new FrmTransactionHistory();
            historyForm.ShowDialog();
        }

        private void btnSavings_Click(object sender, EventArgs e)
        {
            FrmSavings savingsForm = new FrmSavings();
            savingsForm.ShowDialog();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            FrmCategories categoriesForm = new FrmCategories();
            categoriesForm.ShowDialog();
        }

        private void btnIncomeCategories_Click(object sender, EventArgs e)
        {
            FrmIncomeCategories incomeCategoriesForm = new FrmIncomeCategories();
            incomeCategoriesForm.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            FrmBaoCaoThongKe reportForm = new FrmBaoCaoThongKe(UserId);
            reportForm.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBalance();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public int UserId { get; set; }
    }
}
