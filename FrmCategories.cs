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
            db.KetNoi_Dulieu();
            try
            {
                string query = "SELECT CategoryId, Name, Budget, CurrentSpent, Description FROM ExpenseCategories WHERE UserId = @UserId";
                SqlDataAdapter adapter = new SqlDataAdapter(query, db.cnn);
                adapter.SelectCommand.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataCategories.DataSource = dt;
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
            db.KetNoi_Dulieu();
            try
            {
                string insertQuery = @"INSERT INTO ExpenseCategories (UserId, Name, Budget, Description) 
                                       VALUES (@UserId, @Name, @Budget, @Description)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, db.cnn);
                insertCmd.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                insertCmd.Parameters.AddWithValue("@Name", name);
                insertCmd.Parameters.AddWithValue("@Budget", budget);
                insertCmd.Parameters.AddWithValue("@Description", description);
                insertCmd.ExecuteNonQuery();

                MessageBox.Show("Category added.");
                LoadCategories();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding category: " + ex.Message);
            }
            finally
            {
                db.HuyKetNoi();
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
            db.KetNoi_Dulieu();
            try
            {
                string updateQuery = @"UPDATE ExpenseCategories SET Name = @Name, Budget = @Budget, Description = @Description
                                       WHERE CategoryId = @CategoryId";
                SqlCommand updateCmd = new SqlCommand(updateQuery, db.cnn);
                updateCmd.Parameters.AddWithValue("@Name", name);
                updateCmd.Parameters.AddWithValue("@Budget", budget);
                updateCmd.Parameters.AddWithValue("@Description", description);
                updateCmd.Parameters.AddWithValue("@CategoryId", selectedCategoryId);
                updateCmd.ExecuteNonQuery();

                MessageBox.Show("Category updated.");
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error editing category: " + ex.Message);
            }
            finally
            {
                db.HuyKetNoi();
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
                db.KetNoi_Dulieu();
                try
                {
                    string deleteQuery = "DELETE FROM ExpenseCategories WHERE CategoryId = @CategoryId";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, db.cnn);
                    deleteCmd.Parameters.AddWithValue("@CategoryId", selectedCategoryId);
                    deleteCmd.ExecuteNonQuery();

                    MessageBox.Show("Category deleted.");
                    LoadCategories();
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
