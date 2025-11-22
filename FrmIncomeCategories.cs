using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quan_Ly_Tai_San
{
    public partial class FrmIncomeCategories : Form
    {
        private int selectedCategoryId = -1;

        public FrmIncomeCategories()
        {
            InitializeComponent();
            LoadCategories();
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
                dataCategories.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string description = txtDescription.Text;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a name.");
                return;
            }

            dbConnect db = new dbConnect();
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@UserId", FrmSignIn.CurrentUserId),
                    new SqlParameter("@Name", name),
                    new SqlParameter("@Description", description)
                };
                db.ThucThi_Proc("sp_InsertIncomeCategory", parameters);

                MessageBox.Show("Category added.");
                LoadCategories();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding category: " + ex.Message);
            }
        }

        private void dataCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (dataCategories.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataCategories.SelectedRows[0];
                selectedCategoryId = (int)row.Cells["CategoryId"].Value;
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtDescription.Text = row.Cells["Description"].Value?.ToString() ?? "";
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedCategoryId == -1)
            {
                MessageBox.Show("Please select a category to edit.");
                return;
            }

            string name = txtName.Text.Trim();
            string description = txtDescription.Text;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a name.");
                return;
            }

            dbConnect db = new dbConnect();
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@CategoryId", selectedCategoryId),
                    new SqlParameter("@Name", name),
                    new SqlParameter("@Description", description)
                };
                db.ThucThi_Proc("sp_UpdateIncomeCategory", parameters);

                MessageBox.Show("Category updated.");
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error editing category: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCategoryId == -1)
            {
                MessageBox.Show("Please select a category to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this category?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dbConnect db = new dbConnect();
                try
                {
                    SqlParameter[] parameters = {
                        new SqlParameter("@CategoryId", selectedCategoryId)
                    };
                    db.ThucThi_Proc("sp_DeleteIncomeCategory", parameters);

                    MessageBox.Show("Category deleted.");
                    LoadCategories();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting: " + ex.Message);
                }
            }
        }

        private void ClearFields()
        {
            selectedCategoryId = -1;
            txtName.Text = "";
            txtDescription.Text = "";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}