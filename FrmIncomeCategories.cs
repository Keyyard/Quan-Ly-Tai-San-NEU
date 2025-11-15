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
            db.KetNoi_Dulieu();
            try
            {
                string query = "SELECT CategoryId, Name, Description FROM IncomeCategories WHERE UserId = @UserId";
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
            db.KetNoi_Dulieu();
            try
            {
                string insertQuery = @"INSERT INTO IncomeCategories (UserId, Name, Description) 
                                       VALUES (@UserId, @Name, @Description)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, db.cnn);
                insertCmd.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                insertCmd.Parameters.AddWithValue("@Name", name);
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
            db.KetNoi_Dulieu();
            try
            {
                string updateQuery = @"UPDATE IncomeCategories SET Name = @Name, Description = @Description
                                       WHERE CategoryId = @CategoryId";
                SqlCommand updateCmd = new SqlCommand(updateQuery, db.cnn);
                updateCmd.Parameters.AddWithValue("@Name", name);
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
                MessageBox.Show("Please select a category to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this category?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dbConnect db = new dbConnect();
                db.KetNoi_Dulieu();
                try
                {
                    string deleteQuery = "DELETE FROM IncomeCategories WHERE CategoryId = @CategoryId";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, db.cnn);
                    deleteCmd.Parameters.AddWithValue("@CategoryId", selectedCategoryId);
                    deleteCmd.ExecuteNonQuery();

                    MessageBox.Show("Category deleted.");
                    LoadCategories();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting: " + ex.Message);
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