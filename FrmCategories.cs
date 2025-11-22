using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quan_Ly_Tai_San
{
    public partial class FrmCategories : Form
    {
        private int selectedCategoryId = -1;

        public FrmCategories()
        {
            InitializeComponent();
            cboType.Visible = false;
            lblType.Visible = false;
            lblLimit.Visible = true;
            txtLimit.Visible = true;
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
                DataTable dt = db.Lay_Dulieu_Proc("sp_GetExpenseCategories", parameters);
                dataCategories.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string description = txtDescription.Text;
            decimal budget = 0;
            if (!decimal.TryParse(txtLimit.Text, out budget) || budget <= 0)
            {
                MessageBox.Show("Please enter a valid budget.");
                return;
            }

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
                    new SqlParameter("@Budget", budget),
                    new SqlParameter("@Description", description)
                };
                db.ThucThi_Proc("sp_InsertExpenseCategory", parameters);

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
                txtLimit.Text = row.Cells["Budget"].Value.ToString();
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
            decimal budget = 0;
            if (!decimal.TryParse(txtLimit.Text, out budget) || budget <= 0)
            {
                MessageBox.Show("Please enter a valid budget.");
                return;
            }

            dbConnect db = new dbConnect();
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@CategoryId", selectedCategoryId),
                    new SqlParameter("@Name", name),
                    new SqlParameter("@Budget", budget),
                    new SqlParameter("@Description", description)
                };
                db.ThucThi_Proc("sp_UpdateExpenseCategory", parameters);

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
                MessageBox.Show("Vui lòng chọn danh mục để xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa danh mục này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dbConnect db = new dbConnect();
                try
                {
                    SqlParameter[] parameters = {
                        new SqlParameter("@CategoryId", selectedCategoryId)
                    };
                    db.ThucThi_Proc("sp_DeleteExpenseCategory", parameters);

                    MessageBox.Show("Category deleted.");
                    LoadCategories();
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
            selectedCategoryId = -1;
            txtName.Text = "";
            txtDescription.Text = "";
            txtLimit.Text = "";
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
