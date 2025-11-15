using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quan_Ly_Tai_San
{
    public partial class FrmSavings : Form
    {
        private int selectedCategoryId = -1;

        public FrmSavings()
        {
            InitializeComponent();
            LoadSavings();
        }

        private void LoadSavings()
        {
            dbConnect db = new dbConnect();
            db.KetNoi_Dulieu();
            try
            {
                string query = @"SELECT GoalId, Name, GoalAmount, CurrentAmount, 
                                 CASE WHEN GoalAmount > 0 THEN (CurrentAmount / GoalAmount) * 100 ELSE 0 END as Progress
                                 FROM SavingsGoals WHERE UserId = @UserId";
                SqlDataAdapter adapter = new SqlDataAdapter(query, db.cnn);
                adapter.SelectCommand.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataSavings.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải tiết kiệm: " + ex.Message);
            }
            finally
            {
                db.HuyKetNoi();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e) // Using as Add
        {
            string name = txtName.Text.Trim();
            decimal goal;
            if (string.IsNullOrEmpty(name) || !decimal.TryParse(txtGoal.Text, out goal) || goal <= 0)
            {
                MessageBox.Show("Vui lòng nhập tên và mục tiêu hợp lệ.");
                return;
            }

            dbConnect db = new dbConnect();
            db.KetNoi_Dulieu();
            try
            {
                string insertQuery = @"INSERT INTO SavingsGoals (UserId, Name, GoalAmount) 
                                       VALUES (@UserId, @Name, @Goal)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, db.cnn);
                insertCmd.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                insertCmd.Parameters.AddWithValue("@Name", name);
                insertCmd.Parameters.AddWithValue("@Goal", goal);
                insertCmd.ExecuteNonQuery();

                MessageBox.Show("Tiết kiệm đã được tạo.");
                LoadSavings();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo tiết kiệm: " + ex.Message);
            }
            finally
            {
                db.HuyKetNoi();
            }
        }

        private void dataSavings_SelectionChanged(object sender, EventArgs e)
        {
            if (dataSavings.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataSavings.SelectedRows[0];
                selectedCategoryId = (int)row.Cells["GoalId"].Value;
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtGoal.Text = row.Cells["GoalAmount"].Value.ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedCategoryId == -1)
            {
                MessageBox.Show("Vui lòng chọn tiết kiệm để chỉnh sửa.");
                return;
            }

            string name = txtName.Text.Trim();
            decimal goal;
            if (string.IsNullOrEmpty(name) || !decimal.TryParse(txtGoal.Text, out goal))
            {
                MessageBox.Show("Dữ liệu không hợp lệ.");
                return;
            }

            dbConnect db = new dbConnect();
            db.KetNoi_Dulieu();
            try
            {
                string updateQuery = "UPDATE SavingsGoals SET Name = @Name, GoalAmount = @Goal WHERE GoalId = @GoalId";
                SqlCommand updateCmd = new SqlCommand(updateQuery, db.cnn);
                updateCmd.Parameters.AddWithValue("@Name", name);
                updateCmd.Parameters.AddWithValue("@Goal", goal);
                updateCmd.Parameters.AddWithValue("@GoalId", selectedCategoryId);
                updateCmd.ExecuteNonQuery();

                MessageBox.Show("Tiết kiệm đã được cập nhật.");
                LoadSavings();
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
            if (selectedCategoryId == -1)
            {
                MessageBox.Show("Vui lòng chọn tiết kiệm để xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa tiết kiệm này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dbConnect db = new dbConnect();
                db.KetNoi_Dulieu();
                try
                {
                    string deleteQuery = "DELETE FROM SavingsGoals WHERE GoalId = @GoalId";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, db.cnn);
                    deleteCmd.Parameters.AddWithValue("@GoalId", selectedCategoryId);
                    deleteCmd.ExecuteNonQuery();

                    MessageBox.Show("Tiết kiệm đã được xóa.");
                    LoadSavings();
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
            txtGoal.Text = "";
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            if (selectedCategoryId == -1)
            {
                MessageBox.Show("Vui lòng chọn tiết kiệm để gửi tiền.");
                return;
            }

            string input = Microsoft.VisualBasic.Interaction.InputBox("Nhập số tiền gửi:", "Deposit", "0");
            if (!decimal.TryParse(input, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Số tiền không hợp lệ.");
                return;
            }

            dbConnect db = new dbConnect();
            db.KetNoi_Dulieu();
            try
            {
                // Insert transaction
                string insertQuery = @"INSERT INTO Transactions (UserId, Type, CategoryId, Amount, Description)
                                       VALUES (@UserId, 'Saving', @CategoryId, @Amount, 'Deposit to savings')";
                SqlCommand insertCmd = new SqlCommand(insertQuery, db.cnn);
                insertCmd.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                insertCmd.Parameters.AddWithValue("@CategoryId", selectedCategoryId);
                insertCmd.Parameters.AddWithValue("@Amount", amount);
                insertCmd.ExecuteNonQuery();

                // Update balance
                string balanceQuery = "UPDATE Users SET CurrentBalance = CurrentBalance - @Amount WHERE UserId = @UserId";
                SqlCommand balanceCmd = new SqlCommand(balanceQuery, db.cnn);
                balanceCmd.Parameters.AddWithValue("@Amount", amount);
                balanceCmd.Parameters.AddWithValue("@UserId", FrmSignIn.CurrentUserId);
                balanceCmd.ExecuteNonQuery();

                // Update goal
                string goalQuery = "UPDATE SavingsGoals SET CurrentAmount = CurrentAmount + @Amount WHERE GoalId = @GoalId";
                SqlCommand goalCmd = new SqlCommand(goalQuery, db.cnn);
                goalCmd.Parameters.AddWithValue("@Amount", amount);
                goalCmd.Parameters.AddWithValue("@GoalId", selectedCategoryId);
                goalCmd.ExecuteNonQuery();

                MessageBox.Show("Đã gửi tiền vào tiết kiệm.");
                LoadSavings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi tiền: " + ex.Message);
            }
            finally
            {
                db.HuyKetNoi();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
